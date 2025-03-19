/****** Object:  StoredProcedure [dbo].[s_Rpt_AccCommRate_NoAcc]    Script Date: 2018/01/08 10:41:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*-- =============================================
-- Author : HugoLaw
-- Create date : 2018/01/08 16:19
-- Last update : 2018/01/08 10:47
-- Description : Search Procedure FOR s_Rpt_AccCommRate_NoAcc
-- ============================================= */

IF OBJECT_ID('[dbo].[s_Rpt_AccCommRate_NoAcc]') > 0
BEGIN
	DROP PROCEDURE [dbo].s_Rpt_AccCommRate_NoAcc
END
GO


CREATE PROCEDURE [dbo].s_Rpt_AccCommRate_NoAcc		
	@g2sbDB nvarchar(100)
AS
BEGIN
	Set NOCOUNT ON;
    Set XACT_ABORT ON;

	DECLARE @sqlStr nvarchar(MAX)

	SET @sqlStr = '
		WITH it_client_all AS
		( 
			SELECT DISTINCT  clm.accno, (CASE clms.[type]
									WHEN ''2'' THEN ''Cash''
									WHEN ''1'' THEN ''Margin''
								END)AS client_type, ISNULL(fee.name, '''') AS brokerage_income
			FROM ' + @g2sbDB + '.[DBO].client_master AS clm
			LEFT OUTER JOIN ' + @g2sbDB + '.[DBO].client_master_s AS clms ON clms.aid = clm.aid
			LEFT OUTER JOIN ' + @g2sbDB + '.[DBO].Client_Fee AS cf ON cf.aid = clms.aid
			AND cf.cmid = clms.cmid
			AND cf.fuid = ''18''
			LEFT OUTER JOIN ' + @g2sbDB + '.[DBO].fee_master AS fee ON fee.fid = cf.fid
			WHERE clms.date_close IS NULL 
		),
		cur_cash AS
		( 
			SELECT brokerage_income AS bi,
					COUNT(accno) AS quan
			FROM it_client_all
			WHERE client_type=''Cash''
			GROUP BY brokerage_income
		),
		cur_margin AS
		( 
			SELECT brokerage_income AS bi, COUNT(accno) AS quan
			FROM it_client_all
			WHERE client_type=''Margin''
			GROUP BY brokerage_income
		)
		SELECT isnull(curMargin.bi, curCash.bi) AS bi,
		isnull(curCash.quan, 0) AS Cquan,
		isnull(curMargin.quan, 0) AS Mquan
		FROM cur_cash AS curCash
		FULL JOIN cur_margin AS curMargin ON curCash.bi = curMargin.bi
		ORDER BY bi
	'
	
	PRINT @sqlStr

	EXECUTE  sp_ExecuteSql  @sqlStr

END
GO


--EXEC [dbo].s_Rpt_AccCommRate_NoAcc	'LinkedServer97.g2bs_dev'