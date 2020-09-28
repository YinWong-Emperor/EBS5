USE [ESL]
GO
DROP PROCEDURE [dbo].[s_Get_CommAdjRpt]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--EXEC [dbo].[s_Get_CommAdjRpt] 'ESL_LIQ','stock interest','ALL', '2019-01-01', '2019-02-01', 0, '', '', 0
CREATE PROCEDURE [dbo].[s_Get_CommAdjRpt]
    @liqDB nvarchar(100),
	@commOption nvarchar(100),
	@intOption nvarchar(100),
    @fromDate datetime,
	@toDate datetime,
    @nonZero bit,
	@fromAE nvarchar(20),
	@toAE nvarchar(20),
	@isPrc bit
AS
BEGIN
    Set NOCOUNT ON;
    Set XACT_ABORT ON;

    BEGIN TRAN

	DECLARE @mtable NVARCHAR(20)
	DECLARE @nmtable NVARCHAR(20)
	DECLARE @mfield NVARCHAR(20)
	DECLARE @sqlStr  NVARCHAR(1000)

	SET @mfield = 'comm'
	IF @commOption = 'stock commission'
	  BEGIN
         SET @mtable = 'MonthComm'
		 SET @nmtable = 'MonthCommAdj'
      END

	IF @commOption = 'futures commission'
	  BEGIN
         SET @mtable = 'MonthCommF'
		 SET @nmtable = 'MonthCommFAdj'
      END

	IF @commOption = 'stock interest'
	  BEGIN
         IF OBJECT_ID('tempdb..##tempint') IS NOT NULL
		   BEGIN
			  DROP TABLE ##tempint
		   END

        SET @sqlStr = 'SELECT
		    accno, 
		    mth, 
			DATEPART(yyyy, mth) AS yr, 
			DATEPART(m, mth) AS mnth, 
			interest as [int],
			adj, 
			CAST(0 AS DECIMAL(16,2)) AS ipo, 
			client_type INTO ##tempint
		FROM '+@liqDB+'.dbo.MonthInt'

		EXEC (@sqlStr)

        IF OBJECT_ID('tempdb..##tmpipo') IS NOT NULL
		   BEGIN
			  DROP TABLE ##tmpipo
		   END
       
	   IF OBJECT_ID('tempdb..##tmpdaily') IS NOT NULL
		   BEGIN
			  DROP TABLE ##tmpdaily
		   END


	    SELECT
	        accno AS client_code, 
			DATEPART(yyyy, adjDate) AS yr, 
			DATEPART(m, adjDate) AS mnth, 
			ipo AS ipo 
	    INTO ##tmpdaily
		FROM DailyIpoAdj

		SELECT 
		    client_code, 
			yr, 
			mnth, 
			SUM(ipo) as ipo 
		INTO ##tmpipo FROM ##tmpdaily GROUP BY client_code, yr, mnth

        IF OBJECT_ID('tempdb..##temp') IS NOT NULL
		   BEGIN
			  DROP TABLE ##temp
		   END

		SELECT 
		   ISNULL(##tempint.accno, ##tmpipo.client_code) as accno, 
		   ISNULL(##tempint.mth, ##tmpipo.yr + '-' + ##tmpipo.mnth + '-01') as mth, 
		   ISNULL(##tempint.yr, ##tmpipo.yr) as yr, 
		   ISNULL(##tempint.mnth, ##tmpipo.mnth) as mnth, 
		   ISNULL([int], 0) as [int], 
		   ISNULL(adj, 0) as adj, 
		   ISNULL(##tmpipo.ipo, 0) as ipo 
		INTO ##temp
        FROM ##tempint FULL JOIN ##tmpipo 
		ON ##tempint.accno COLLATE DATABASE_DEFAULT = ##tmpipo.client_code 
		   AND ##tempint.yr = ##tmpipo.yr 
		   AND ##tempint.mnth = ##tmpipo.mnth

		IF OBJECT_ID('tempdb..##tempint') IS NOT NULL
		   BEGIN
			  DROP TABLE ##tempint
		   END
        SELECT * INTO ##tempint FROM ##temp

		SET @mtable = 'tempint'
        SET @mfield = 'int'
		SET @nmtable = 'MonthIntAdj'
      END

	  ------------------

	  DECLARE @indexDate dateTime
	  DECLARE @i int
      SET @indexDate = @fromDate
	  SET @i = 0

      WHILE @indexDate <= @toDate
         BEGIN
		    SET @i = @i + 1

			IF OBJECT_ID('tempdb..##temp') IS NOT NULL
		    BEGIN
			   DROP TABLE ##temp
		    END

			IF @commOption = 'stock commission' OR @commOption = 'futures commission'
			   BEGIN
				SET @sqlStr = 'SELECT accno AS accno_'+CONVERT(VARCHAR,@i)+ ', mth AS mth_'+CONVERT(VARCHAR,@i)+', 
				COMM AS val_'+CONVERT(VARCHAR,@i)+', 
				CAST(0 AS DECIMAL(16,2)) AS adj_'+CONVERT(VARCHAR,@i)+', 
				CAST(0 AS DECIMAL(16,2)) AS creadj_'+CONVERT(VARCHAR,@i)+',
				 ipo AS ipo_'+CONVERT(VARCHAR,@i)+' 
				 INTO ##temp 
				 FROM '+@liqDB+'.dbo.'+@mtable+
							' WHERE accno <> ''EMP'' AND DATEPART(yyyy, mth)=' +CONVERT(VARCHAR, YEAR(@indexDate))+ '
							AND DATEPART(m,mth) = '+CONVERT(VARCHAR, MONTH(@indexDate))
			   END
			
			IF @commOption = 'stock interest'
			   BEGIN
				SET @sqlStr = 'SELECT accno AS accno_'+CONVERT(VARCHAR,@i)+ ', mth AS mth_'+CONVERT(VARCHAR,@i)+', 
				[int] AS val_'+CONVERT(VARCHAR,@i)+', 
				CAST(0 AS DECIMAL(16,2)) AS adj_'+CONVERT(VARCHAR,@i)+', 
				CAST(0 AS DECIMAL(16,2)) AS creadj_'+CONVERT(VARCHAR,@i)+',
				 ipo AS ipo_'+CONVERT(VARCHAR,@i)+' 
				 INTO ##temp 
				 FROM ##'+@mtable+
							' WHERE accno <> ''EMP'' AND DATEPART(yyyy, mth)=' +CONVERT(VARCHAR, YEAR(@indexDate))+ '
							AND DATEPART(m,mth) = '+CONVERT(VARCHAR, MONTH(@indexDate))
			   END


			IF @nonZero = 1
			   BEGIN
				 SET @sqlStr = @sqlStr + ' AND (adj <> 0 OR ipo <> 0)'
			   END

            IF @commOption = 'stock interest'
			   BEGIN
				 IF @intOption = '>=0 only'
				 BEGIN
					SET @sqlStr = @sqlStr + ' AND [int] >= 0 '
				 End
				 IF @intOption = '<0 only'
				 BEGIN
					SET @sqlStr = @sqlStr + ' AND [int] < 0 '
				 End
			   END

		    --PRINT (@sqlStr)
			EXEC (@sqlStr)

			SET @sqlStr = 'UPDATE ##temp SET adj_'+CONVERT(VARCHAR,@i)+' = adj, 
			creadj_'+CONVERT(VARCHAR,@i)+' = adj
				FROM dbo.'+ @nmtable + ' WHERE DATEPART(yyyy, adjDate)=' +CONVERT(VARCHAR, YEAR(@indexDate))+ '
						AND DATEPART(m,adjDate) = '+CONVERT(VARCHAR, MONTH(@indexDate))+'
						AND accno_'+CONVERT(VARCHAR,@i)+' COLLATE DATABASE_DEFAULT = dbo.' + @nmtable + '.accno'

			EXEC(@sqlStr)

			SET @sqlStr = 'UPDATE ##temp SET adj_'+CONVERT(VARCHAR,@i)+' = adj_'+CONVERT(VARCHAR,@i)+' + val_'+CONVERT(VARCHAR,@i)+', 
			creadj_'+CONVERT(VARCHAR,@i)+' = creadj_'+CONVERT(VARCHAR,@i)+' + val_'+CONVERT(VARCHAR,@i)

			EXEC(@sqlStr)

			IF OBJECT_ID('tempdb..##cur_'+CONVERT(VARCHAR,@i)) IS NOT NULL
			   BEGIN
				  SET @sqlStr = 'DROP TABLE tempdb..##cur_'+CONVERT(VARCHAR,@i)
				  EXEC(@sqlStr)
			   END

			SET @sqlStr = 'SELECT * INTO ##cur_' +CONVERT(VARCHAR,@i)+ ' FROM ##temp'
			EXEC(@sqlStr)

			SET @sqlStr = 'UPDATE ##cur_' +CONVERT(VARCHAR,@i)+ ' SET adj_' +CONVERT(VARCHAR,@i)+ '= 0 
			   WHERE adj_' +CONVERT(VARCHAR,@i)+ ' < 0'
            EXEC(@sqlStr)

            SET @sqlStr = 'UPDATE ##cur_' +CONVERT(VARCHAR,@i)+ ' SET creadj_' +CONVERT(VARCHAR,@i)+ '= 0 
			   WHERE creadj_' +CONVERT(VARCHAR,@i)+ ' > 0'
            EXEC(@sqlStr)

            SELECT @indexDate = DATEADD(month, 1, @indexDate)
         END

	  DECLARE @lcIndex int
	  SET @lcIndex = 2
	  WHILE @lcIndex <= @i
         BEGIN
		    IF OBJECT_ID('tempdb..##temp') IS NOT NULL
		       BEGIN
			      DROP TABLE ##temp
		       END

		    SET @sqlStr = 'SELECT * INTO ##temp 
			FROM ##cur_1 FULL JOIN ##cur_' +CONVERT(VARCHAR,@lcIndex)+ ' 
			ON accno_1 = accno_' +CONVERT(VARCHAR,@lcIndex)
			EXEC(@sqlStr)

		    IF OBJECT_ID('tempdb..##cur_1') IS NOT NULL
		       BEGIN
			      DROP TABLE ##cur_1
		       END
            SELECT * INTO ##cur_1 FROM ##temp
			SET @sqlStr = 'UPDATE ##cur_1 SET accno_1=accno_' +CONVERT(VARCHAR,@lcIndex)+ ' WHERE accno_1 IS NULL'
			EXEC(@sqlStr)
			SET @lcIndex = @lcIndex + 1
		 END

	 IF  @i = 1
         BEGIN
			IF OBJECT_ID('tempdb..##temp') IS NOT NULL
		       BEGIN
			      DROP TABLE ##temp
		       END
			SET @sqlStr = 'SELECT * INTO ##temp FROM ##cur_1'
			EXEC (@sqlStr)

			IF OBJECT_ID('tempdb..##cur_1') IS NOT NULL
		       BEGIN
			      DROP TABLE ##cur_1
		       END
			SET @sqlStr = 'SELECT * INTO ##cur_1 FROM ##temp'
			EXEC (@sqlStr)
		 END

		 SET @lcIndex = 1
	     WHILE @lcIndex <= @i
         BEGIN
            SET @sqlStr = 'UPDATE ##cur_1 SET adj_'+CONVERT(VARCHAR,@lcIndex)+'=0 
			WHERE adj_'+CONVERT(VARCHAR,@lcIndex)+' IS NULL'
			EXEC(@sqlStr)

			SET @sqlStr = 'UPDATE ##cur_1 SET creadj_'+CONVERT(VARCHAR,@lcIndex)+'=0 
			WHERE creadj_'+CONVERT(VARCHAR,@lcIndex)+' IS NULL'
			EXEC(@sqlStr)

			SET @sqlStr = 'UPDATE ##cur_1 SET ipo_'+CONVERT(VARCHAR,@lcIndex)+'=0 
			WHERE ipo_'+CONVERT(VARCHAR,@lcIndex)+' IS NULL'
			EXEC(@sqlStr)

			SET @lcIndex = @lcIndex + 1
        END

		IF OBJECT_ID('tempdb..##temp') IS NOT NULL
		       BEGIN
			      DROP TABLE ##temp
		       END

		SET @sqlStr = 'SELECT accno_1, adj_1, creadj_1, ipo_1'
		DECLARE @sql2 NVARCHAR(200)
		SET @sql2 = ', adj_1 '
		DECLARE @sql3 NVARCHAR(200)
		SET @sql3 = ', creadj_1 '
		DECLARE @sql4 NVARCHAR(200)
		SET @sql4 = ', ipo_1 '

		SET @lcIndex = 2
	     WHILE @lcIndex <= @i
         BEGIN
            SET @sqlStr = @sqlStr + ', adj_' +CONVERT(VARCHAR,@lcIndex)+ ', creadj_' +CONVERT(VARCHAR,@lcIndex)+ ', ipo_' + CONVERT(VARCHAR,@lcIndex)
			SET @sql2 = @sql2 + '+adj_' +CONVERT(VARCHAR,@lcIndex)
			SET @sql3 = @sql3 + '+creadj_' +CONVERT(VARCHAR,@lcIndex)
			SET @sql4 = @sql4 + '+ipo_' +CONVERT(VARCHAR,@lcIndex)
			SET @lcIndex = @lcIndex + 1
         END

		DECLARE @val VARCHAR(8)
		SET @val = '0'
		IF @isPrc <> 1
		 BEGIN
			SET @val = '-9999'
		 END

		SET @lcIndex = @i + 1
	     WHILE @lcIndex <= 12
         BEGIN
            SET @sqlStr = @sqlStr + ', ' +@val+ ' AS adj_' +CONVERT(VARCHAR,@lcIndex)+ ', ' +@val+ ' AS creadj_' +CONVERT(VARCHAR,@lcIndex)+ ', ' +@val+ ' AS ipo_' + CONVERT(VARCHAR,@lcIndex)
			SET @lcIndex = @lcIndex + 1
         END

		 SET @sqlStr = @sqlStr + @sql2 + ' AS adj_all ' + @sql3 + ' AS creadj_all ' + 
		 @sql4 + ' AS ipo_all INTO ##temp FROM ##cur_1 ORDER BY accno_1'
		 EXEC(@sqlStr)

		 IF OBJECT_ID('tempdb..##cur_1') IS NOT NULL
		       BEGIN
			      DROP TABLE ##cur_1
		       END

		 SET @sqlStr = 'SELECT * INTO ##cur_1 FROM ##temp'
		 EXEC(@sqlStr)

		 IF @fromAE <> ''
		    BEGIN
				IF OBJECT_ID('tempdb..##temp') IS NOT NULL
				   BEGIN
					  DROP TABLE ##temp
				   END
				SET @sqlStr = 'SELECT * INTO ##temp FROM ##cur_1 WHERE accno_1 >= ' + @fromAE
				EXEC(@sqlStr)

				IF OBJECT_ID('tempdb..##cur_1') IS NOT NULL
				   BEGIN
					  DROP TABLE ##cur_1
				   END
				SET @sqlStr = 'SELECT * INTO ##cur_1 FROM ##temp'
				EXEC(@sqlStr)
			END
        
		IF @toAE <> ''
		    BEGIN
               IF OBJECT_ID('tempdb..##temp') IS NOT NULL
				   BEGIN
					  DROP TABLE ##temp
				   END
			   SET @sqlStr = 'SELECT * INTO ##temp FROM ##cur_1 WHERE accno_1 <= ' + @toAE
			   EXEC(@sqlStr)

			   IF OBJECT_ID('tempdb..##cur_1') IS NOT NULL
				   BEGIN
					  DROP TABLE ##cur_1
				   END
				SET @sqlStr = 'SELECT * INTO ##cur_1 FROM ##temp'
				EXEC(@sqlStr)
		    END

        SELECT * FROM ##cur_1 order by accno_1

    COMMIT TRANSACTION  
    
    IF(@@ERROR <> 0)  
		ROLLBACK TRANSACTION
    
	IF OBJECT_ID('tempdb..##temp') IS NOT NULL
		 BEGIN
			 DROP TABLE ##temp
		 END

    IF OBJECT_ID('tempdb..##cur_1') IS NOT NULL
		 BEGIN
			 DROP TABLE ##cur_1
		 END
END


GO


