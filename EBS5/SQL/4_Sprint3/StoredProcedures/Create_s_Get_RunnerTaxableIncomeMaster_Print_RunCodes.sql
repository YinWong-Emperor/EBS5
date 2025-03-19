
/*-- =============================================
-- Author : DoraemonYu
-- Create date : 2018/01/10 16:34
-- Last update : 2018/01/10 16:34
-- ============================================= */


IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_Get_RunnerTaxableIncomeMaster_Print_RunCodes]') AND TYPE IN (N'P', N'PC'))
	DROP PROCEDURE [dbo].[s_Get_RunnerTaxableIncomeMaster_Print_RunCodes]
GO


CREATE PROCEDURE [dbo].[s_Get_RunnerTaxableIncomeMaster_Print_RunCodes]
AS
BEGIN

	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- get db name
	DECLARE @database_name varchar(100)
	SELECT @database_name = [CIfChrDataBase] FROM [DB_Information] WHERE [CIfChrServerType] = 'GL'

	-- exec	
	DECLARE @sqlStr  NVARCHAR(1000)
	SET @sqlStr = N'SELECT DISTINCT [Run_Code] FROM ' + @database_name + N'.[dbo].[GLRunMaster]  ORDER BY [Run_Code]';	


	EXEC sp_executesql @sqlStr
END
GO
