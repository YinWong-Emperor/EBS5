
/*-- =============================================
-- Author : DoraemonYu
-- Create date : 2018/01/17 11:06
-- Last update : 2018/01/17 14:56
-- ============================================= */


IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_Upd_RunnerTaxableIncomeMaster_CutOff_BackupDB]') AND TYPE IN (N'P', N'PC'))
	DROP PROCEDURE [dbo].[s_Upd_RunnerTaxableIncomeMaster_CutOff_BackupDB]
GO


CREATE PROCEDURE [dbo].[s_Upd_RunnerTaxableIncomeMaster_CutOff_BackupDB]
AS
BEGIN

	-- get db name
	DECLARE @database_name varchar(100)
	SELECT @database_name = [CIfChrDataBase] FROM [DB_Information] WHERE [CIfChrServerType] = 'GL'
	
	-- backup db
	IF EXISTS(SELECT 1 FROM [misc_master] WHERE [misc_type] = 'RunnerTaxable' AND [misc_code] = 'enabled' AND [misc_desc] = '1')
	BEGIN

		DECLARE @backpupDirName		varchar(max)
		DECLARE @backpupFileName	varchar(max)
		DECLARE @backpupFullPath	varchar(max)
		DECLARE @timestamp			varchar(100)		

		SET @timestamp				= REPLACE( REPLACE( CONVERT(varchar(100), GETDATE(), 20) , '-','') , ':' , '')
		SELECT @backpupDirName		= [misc_desc] FROM [misc_master] WHERE [misc_type] = 'RunnerTaxable' AND [misc_code] = 'backuppath'		
		SET @backpupFileName		= @database_name + N' ' + @timestamp + N'.bak'
		SET @backpupFullPath		= @backpupDirName + @backpupFileName

		BACKUP DATABASE @database_name TO DISK = @backpupFullPath
	END

END
GO