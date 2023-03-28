USE [ESL]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[s_Get_ImportDataUS]
	@ESLLiqDB varchar(100)
AS
BEGIN
	
	--DECLARE @backupPath varchar(max)
	--DECLARE @backupEnabled varchar(max)
	--SELECT @backupPath = [misc_desc] FROM [misc_master] WHERE [misc_type] = 'ImportData' AND [misc_code] = 'backuppath'
	--SELECT @backupEnabled = [misc_desc] FROM [misc_master] WHERE [misc_type] = 'ImportData' AND [misc_code] = 'enabled'

		--,''' + @backupPath + ''' AS backuppath
		--,''' + @backupEnabled + ''' AS backupenabled
	EXEC ('
	SELECT 
		tradedate
		,procflag
	FROM ' + @ESLLiqDB + '.[dbo].[STCONTROL_US] WITH (NOLOCK)')
END

GO