USE [ESL]
GO
DROP PROCEDURE [dbo].[s_Get_IntAdjust]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--EXEC [dbo].[s_Get_IntAdjust] 'ESL_LIQ', 2019, 01, '', '', 0
CREATE PROCEDURE [dbo].[s_Get_IntAdjust]
    @liqDB nvarchar(100),
	@adjYear nvarchar(10),
    @adjMonth nvarchar(10),
    @fromClient nvarchar(20),
	@toClient nvarchar(20),
    @nonZero bit
AS
BEGIN
    Set NOCOUNT ON;
    Set XACT_ABORT ON;

    BEGIN TRAN
	  IF OBJECT_ID('DBO.#tmpipo') IS NOT NULL
		  BEGIN
			 DROP TABLE #tmpipo
		  END

	  IF OBJECT_ID('DBO.#int') IS NOT NULL
		  BEGIN
			 DROP TABLE #int
		  END


	  CREATE TABLE #tmpipo
	     (accno nvarchar(10), 
	      ipo numeric(14,2))

	  CREATE TABLE #int
	     (accno nvarchar(10), 
		  accname nvarchar(200), 
		  interest numeric(14,2), 
		  adj numeric(14,2), 
		  ipo numeric(14,2))
	  
	  DECLARE @sqlStr  VARCHAR(1000)

	  SET @sqlStr = 'SELECT 
	                    accno, sum(ipo) as ipo 
					 FROM dbo.DailyIPOAdj 
					 WHERE 
					        YEAR(adjDate) = ' + @adjYear + ' 
						AND MONTH(adjDate) = ' + @adjMonth + ' 
				     GROUP BY accno'
	  INSERT INTO #tmpipo (accno, ipo) EXEC (@sqlStr)	

	  SET @sqlStr = 'SELECT 
	                    DISTINCT accno 
					 FROM 
					   (SELECT 
					       accno 
						FROM dbo.MonthIntAdj 
						WHERE 
						       YEAR(adjDate) = ' + @adjYear + '
					       AND MONTH(adjDate) = ' + @adjMonth + '
					    UNION 
						SELECT 
						   accno 
						FROM dbo.DailyIPOAdj 
						WHERE 
						       YEAR(adjDate) = ' + @adjYear + ' 
						   AND MONTH(adjDate) = ' + @adjMonth  + ' 
					    UNION 
						SELECT 
						   accno COLLATE DATABASE_DEFAULT 
						FROM ' + @LiqDB + '.dbo.MonthInt 
						WHERE 
						       YEAR(mth) = ' + @adjYear + ' 
						   AND MONTH(mth) = '+ @adjMonth +  '
					  ) a'
      INSERT INTO #int (accno) EXEC (@sqlStr)	    
	  
	  SET @sqlStr = 'UPDATE 
	                    #int 
					 SET 
					    #int.interest = tmpint.interest 
					 FROM ' + @LiqDB + '.dbo.MonthInt tmpint 
					 WHERE 
					        #int.accno COLLATE DATABASE_DEFAULT = tmpint.accno COLLATE DATABASE_DEFAULT 
						AND YEAR(mth) = ' + @adjYear + ' 
						AND MONTH(mth) = ' + @adjMonth

	  EXEC (@sqlStr)

	  UPDATE #int 
	  SET 
	     #int.adj = tmpadj.adj 
	  FROM MonthIntAdj tmpadj 
	  WHERE 
	         #int.accno collate DATABASE_DEFAULT = tmpadj.accno COLLATE DATABASE_DEFAULT 
		 AND YEAR(adjDate) = @adjYear 
		 AND MONTH(adjDate) = @adjMonth

	  UPDATE #int 
	  SET 
	     #int.ipo = #tmpipo.ipo 
	  FROM #tmpipo 
	  WHERE 
	     #int.accno collate DATABASE_DEFAULT = #tmpipo.accno COLLATE DATABASE_DEFAULT

	  SET @sqlStr = 'UPDATE #int
					 SET
					    #int.accname = RTRIM(c.clt_name)
					 FROM ' + @LiqDB + '.dbo.STCLTMASTER c 
					 WHERE 
					    #int.accno COLLATE DATABASE_DEFAULT = c.clt_code COLLATE DATABASE_DEFAULT'

	  EXEC (@sqlStr)

	  UPDATE #int SET accname = '' WHERE accname is null

	  UPDATE #int SET interest = 0 WHERE interest is null

	  UPDATE #int SET adj = 0 WHERE adj is null

	  UPDATE #int SET ipo = 0 WHERE ipo is null

	  SELECT 
	     accno, 
		 accname, 
		 @adjYear + '/' + @adjMonth AS mth, 
		 --interest, 
		 [int] = CASE WHEN interest < 0 THEN 0 ELSE interest END,
		 creint = CASE WHEN interest > 0 THEN 0 ELSE interest END,
		 adj, 
		 ipo, 
		 interest + adj + ipo AS total 
	  FROM 
	     #int AS detail 
	  WHERE 
	         (accno >= @fromClient OR @fromClient = '')
	     AND (accno <= @toClient OR @toClient = '')
	     AND (@nonZero != 1 OR (adj > 0 OR ipo > 0))
	  ORDER BY accno

	  SELECT 
	     @adjYear + '/' + @adjMonth AS tmth, 
		 SUM(interest) AS tinterest, 
		 SUM(adj) AS tadj, 
		 SUM(ipo) AS tipo, 
		 SUM(interest + adj + ipo) AS ttotal 
	  FROM 
	     #int AS total 
	  WHERE 
	         (accno >= @fromClient OR @fromClient = '')
	     AND (accno <= @toClient OR @toClient = '')
	     AND (@nonZero != 1 OR (adj > 0 OR ipo > 0))
	  ORDER BY tmth

    COMMIT TRANSACTION  
    
    IF(@@ERROR <> 0)  
		ROLLBACK TRANSACTION

	IF OBJECT_ID('DBO.#tmpipo') IS NOT NULL
	  BEGIN
         DROP TABLE #tmpipo
      END

	IF OBJECT_ID('DBO.#int') IS NOT NULL
	  BEGIN
         DROP TABLE #int
      END
    
END


GO


