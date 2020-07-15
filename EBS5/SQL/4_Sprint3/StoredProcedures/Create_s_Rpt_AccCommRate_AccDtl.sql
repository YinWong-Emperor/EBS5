/****** Object:  StoredProcedure [dbo].[s_Rpt_AccCommRate_AccDtl]    Script Date: 2018/01/08 10:41:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*-- =============================================
-- Author : HugoLaw
-- Create date : 2018/01/08 16:19
-- Last update : 2018/01/08 10:47
-- Description : Search Procedure FOR s_Rpt_AccCommRate_AccDtl
-- ============================================= */

IF OBJECT_ID('[dbo].[s_Rpt_AccCommRate_AccDtl]') > 0
BEGIN
	DROP PROCEDURE [dbo].s_Rpt_AccCommRate_AccDtl
END
GO


CREATE PROCEDURE [dbo].s_Rpt_AccCommRate_AccDtl
	@g2sbDB nvarchar(100)
AS
BEGIN
	Set NOCOUNT ON;
    Set XACT_ABORT ON;

	DECLARE @sqlStr nvarchar(MAX)

	SET @sqlStr = '
		SELECT DISTINCT clm.accno,
			   clm.name_1,
			   ISNULL(fee.name, '''') AS brokerage_income,
			   ae.aeno
		FROM ' + @g2sbDB + '.[DBO].client_master AS clm
		LEFT OUTER JOIN ' + @g2sbDB + '.[DBO].client_master_s AS clms ON clms.aid = clm.aid
		LEFT OUTER JOIN ' + @g2sbDB + '.[DBO].ae_master AS ae ON ae.aeid = clms.aeid
																	AND ae.cmid = clms.cmid
		LEFT OUTER JOIN ' + @g2sbDB + '.[DBO].Client_Fee AS cf ON cf.aid = clms.aid
																	AND cf.cmid = clms.cmid
																	AND cf.fuid = ''18''
		LEFT OUTER JOIN ' + @g2sbDB + '.[DBO].fee_master AS fee ON fee.fid = cf.fid
		WHERE clms.date_close IS NULL
		ORDER BY brokerage_income, accno 
	'

	PRINT @sqlStr

	EXECUTE  sp_ExecuteSql  @sqlStr

END
GO

--EXEC [dbo].s_Rpt_AccCommRate_AccDtl	'LinkedServer97.g2bs_dev'