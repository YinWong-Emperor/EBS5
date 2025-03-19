
/*-- =============================================
-- Author : DoraemonYu
-- Create date : 2018/01/24 10:11
-- Last update : 2018/01/24 10:11
-- ============================================= */


IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_Get_RunnerTaxableIncomeMaster_Description_Withheld]') AND TYPE IN (N'P', N'PC'))
	DROP PROCEDURE [dbo].[s_Get_RunnerTaxableIncomeMaster_Description_Withheld]
GO


CREATE PROCEDURE [dbo].[s_Get_RunnerTaxableIncomeMaster_Description_Withheld]
AS
BEGIN

	-- get db name
	DECLARE @database_name varchar(100)
	SELECT @database_name = [CIfChrDataBase] FROM [DB_Information] WHERE [CIfChrServerType] = 'GL'
	

	-- exec
	EXEC (N'SELECT		Type_ID, 
						Descpt, 
						Company, 
						TmpDash
			FROM ' + @database_name +  N'.[dbo].[glRunTaxDesc]
			WHERE		Type_ID > 100 OR Type_ID = 16 OR Type_ID = 17 
			ORDER BY	Type_ID
		  ')

END
GO