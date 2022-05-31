SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_Get_LiqList_VadCod]') AND TYPE IN (N'P', N'PC'))
	DROP PROCEDURE [dbo].[s_Get_LiqList_VadCod]
GO

/*-- =============================================
-- Author : Eddie
-- Create date : 2017/10/19 16:19
-- Last update : 2017/10/20 10:47
-- Description : Validate Condition Procedure FOR Liquidation Listing Filter Logic
-- ============================================= */
CREATE PROCEDURE [dbo].[s_Get_LiqList_VadCod]
	@liqDB varchar(100),
	@criteria varchar(1000)
AS
BEGIN
    Set NOCOUNT ON;
    Set XACT_ABORT ON;

	BEGIN TRY
		DECLARE @sqlStr NVARCHAR(2000)

		IF OBJECT_ID('tempdb..##margin_tmp_test') IS NOT NULL
			BEGIN
				DROP TABLE ##margin_tmp_test
			END

		SET @sqlStr = 'SELECT
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
			##margin_tmp_test
		FROM
			' +@liqDB+ '.DBO.client_liq_master a 
		LEFT JOIN
			' +@liqDB+ '.DBO.client_mkt_mrg b
		ON
			a.clt_code = b.client_code
		WHERE
			(a.clt_type = ''M'' or a.clt_type = ''F'')'
		
		EXEC(@sqlStr)
	
		IF OBJECT_ID('tempdb..##clt_tmp_test') IS NOT NULL
			BEGIN
				DROP TABLE ##clt_tmp_test
			END


		SET @sqlStr = 'SELECT 
							clt_code
					   INTO 
							##clt_tmp_test
					   FROM
							##margin_tmp_test
					   WHERE ' 
					   +@criteria
		EXEC(@sqlStr)

		SELECT * FROM ##clt_tmp_test

	END TRY
	BEGIN CATCH
	   
	   SELECT 0
	
	END CATCH
END

GO
