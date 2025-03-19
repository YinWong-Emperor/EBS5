SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_Get_LiqList_CreateList]') AND TYPE IN (N'P', N'PC'))
	DROP PROCEDURE [dbo].[s_Get_LiqList_CreateList]
GO

/*-- =============================================
-- Author : Eddie
-- Create date : 2017/10/19 16:19
-- Last update : 2017/10/20 10:47
-- Description : Search Procedure FOR Liquidation Listing Create List
-- ============================================= */
CREATE PROCEDURE [dbo].[s_Get_LiqList_CreateList]
	@LiqConn varchar(100),
	@Rad varchar(10)
AS
BEGIN
    Set NOCOUNT ON;
    Set XACT_ABORT ON;

    BEGIN TRAN
	  IF OBJECT_ID('tempdb..##stcltmaster'+@Rad) IS NOT NULL
		BEGIN
			EXEC('DROP TABLE ##stcltmaster'+@Rad)
		END

	  DECLARE @sqlStr NVARCHAR(1000)
	  SET @sqlStr = 'SELECT 
						*, 0 AS liq_day 
					 INTO ##stcltmaster'+@Rad+' 
					 FROM ' + @LiqConn + '.DBO.Client_Liq_Master'

	  EXEC(@sqlStr)


	  IF OBJECT_ID('tempdb..##margin_tmp'+@Rad) IS NOT NULL
		BEGIN
			EXEC('DROP TABLE ##margin_tmp'+@Rad)
		END
	  SET @sqlStr = 
	   'SELECT
		  a.clt_code, 
		  a.run_code, 
		  a.mc_dr_bal AS dr, 
		  a.mc_act_ratio AS ar, 
		  a.mc_total AS mc, 
		  a.mc_due AS due, 
		  a.mc_t2 AS undue, 
		  a.margin_ratio AS mr, 
		  a.cr_limit AS cl, 
		  a.clt_type, 
		  a.margin_value - ISNULL(b.margin_value, 0) AS due_mv, 
		  ISNULL(b.margin_value, 0) AS undue_margin_value, 
		  ISNULL(b.market_value, 0) AS undue_mv, a.short
	    INTO
		  ##margin_tmp'+@Rad+' 
	    FROM
		  ##stcltmaster'+@Rad+' a 
	    LEFT JOIN 
		  ' + @LiqConn + '.DBO.Client_Mkt_Mrg b 
	    ON a.clt_code = b.client_code 
	    WHERE (a.clt_type = ''M'' OR a.clt_type = ''F'')' 

	  EXEC(@sqlStr)	  
	  	  
	  DECLARE @miscStr NVARCHAR(200)
	  SELECT 
	     TOP 1 @miscStr = misc_desc
	  FROM 
	     DBO.Misc_Master
	  WHERE
		misc_type = 'LiqListLogic'
	  AND misc_code = 'liq_list_margin'


	  IF OBJECT_ID('tempdb..##clt_tmp'+@Rad) IS NOT NULL
		BEGIN
			EXEC('DROP TABLE ##clt_tmp'+@Rad)
		END
	  SET @sqlStr = 
	   'SELECT
		clt_code
	  INTO
		##clt_tmp'+@Rad+' 
	  FROM
		##margin_tmp'+@Rad+' 
	  WHERE '+@miscStr

	  EXEC(@sqlStr)

	  IF OBJECT_ID('tempdb..##cashin_tmp'+@Rad) IS NOT NULL
		BEGIN
			EXEC('DROP TABLE ##cashin_tmp'+@Rad)
		END
	  SET @sqlStr = 'SELECT
			a.accno, 
			SUM(a.amount) AS amount 
		INTO
			##cashin_tmp'+@Rad+'  
		FROM 
			' + @LiqConn + '.DBO.Client_Fund_Movement a, 
			##stcltmaster'+@Rad+' b 
		WHERE 
			a.accno = b.clt_code 
		AND b.clt_type = ''C'' 
		GROUP BY a.accno'

	  EXEC(@sqlStr)

	  EXEC('UPDATE ##stcltmaster'+@Rad+' SET deposit = 0')

	  SET @sqlStr = 'UPDATE
		##stcltmaster'+@Rad+' 
	  SET
		##stcltmaster'+@Rad+'.deposit = ##cashin_tmp'+@Rad+'.amount 
	  FROM
		##cashin_tmp'+@Rad+' 
	  WHERE
		##stcltmaster'+@Rad+'.clt_code = ##cashin_tmp'+@Rad+'.accno 
	  AND ##cashin_tmp'+@Rad+'.amount <> 0'
	  
	  EXEC(@sqlStr)

	  IF OBJECT_ID('tempdb..##os_tmp'+@Rad) IS NOT NULL
		BEGIN
			EXEC('DROP TABLE ##os_tmp'+@Rad)
		END

	  SET @sqlStr ='SELECT 
		clt_code
	  INTO
	    ##os_tmp'+@Rad+' 
	  FROM
	    ##stcltmaster'+@Rad+' 
	  WHERE
	    clt_type = ''C'' 
	  AND 
		( (withdrawal > 0 
		  AND withdrawal > deposit) 
	      OR (mc_act_ratio > 0.7)
	      OR (short = 1) )'

	  EXEC(@sqlStr)
      
	  SET @sqlStr = 'UPDATE
		##stcltmaster'+@Rad+' 
	  SET
		##stcltmaster'+@Rad+'.os_day = ' + @LiqConn + '.DBO.STCLTMASTER.os_day 
	  FROM
		' + @LiqConn + '.DBO.STCLTMASTER 
	  WHERE
		##stcltmaster'+@Rad+'.clt_code = ' + @LiqConn + '.DBO.STCLTMASTER.clt_code'
	  EXEC(@sqlStr)


      SET @sqlStr = 
	  'UPDATE 
		##stcltmaster'+@Rad+'  
	  SET
		##stcltmaster'+@Rad+'.liq_day = 0 
	  FROM
		' + @LiqConn + '.DBO.STCLTMASTER'
	  EXEC(@sqlStr)


      SET @sqlStr = 'UPDATE
		##stcltmaster'+@Rad+'  
	  SET
		##stcltmaster'+@Rad+'.liq_day = ' + @LiqConn + '.DBO.STCLTLIQ.liq_day 
	  FROM
		' + @LiqConn + '.DBO.STCLTLIQ 
	  WHERE
		##stcltmaster'+@Rad+'.clt_code = ' + @LiqConn + '.DBO.STCLTLIQ.clt_code'
	  EXEC(@sqlStr)

	  SET @sqlStr = 'INSERT INTO 
		##clt_tmp'+@Rad+' 
	   (clt_code) 
	  SELECT 
		clt_code 
	  FROM
	    ##os_tmp'+@Rad
	  EXEC(@sqlStr)

    
	COMMIT TRANSACTION  
  
    IF(@@ERROR <> 0) 
	    BEGIN 
		ROLLBACK TRANSACTION
		END

END


GO
