
/*-- =============================================
-- Author : DoraemonYu
-- Create date : 2018/02/01 15:38
-- Last update : 2018/02/01 15:38
-- ============================================= */


IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_Upd_RunnerTaxableIncomeMaster_Description_Selects_TmpTable]') AND TYPE IN (N'P', N'PC'))
	DROP PROCEDURE [dbo].[s_Upd_RunnerTaxableIncomeMaster_Description_Selects_TmpTable]
GO


CREATE PROCEDURE [dbo].[s_Upd_RunnerTaxableIncomeMaster_Description_Selects_TmpTable]
AS
BEGIN

	-- 检查是否存在目标的临时表
	IF OBJECT_ID('tempdb..##TMP_Upd_RunnerTaxableIncomeMaster_Description_Selects' , 'U') IS NOT NULL
		DROP TABLE ##TMP_Upd_RunnerTaxableIncomeMaster_Description_Selects

	-- exec
	CREATE TABLE ##TMP_Upd_RunnerTaxableIncomeMaster_Description_Selects
	(
		[DESCPT] varchar(40)
	   ,[AMOUNT] numeric(16,2)
	   ,[ITEM] int
	)

END
GO