
/*-- =============================================
-- Author : DoraemonYu
-- Create date : 2018/01/10 16:34
-- Last update : 2018/01/10 16:34
-- ============================================= */


IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_Get_RunnerTaxableIncomeMaster_CurMonth]') AND TYPE IN (N'P', N'PC'))
	DROP PROCEDURE [dbo].[s_Get_RunnerTaxableIncomeMaster_CurMonth]
GO


CREATE PROCEDURE [dbo].[s_Get_RunnerTaxableIncomeMaster_CurMonth]
AS
BEGIN

	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- get db name
	DECLARE @database_name varchar(100)
	SELECT @database_name = [CIfChrDataBase] FROM [DB_Information] WHERE [CIfChrServerType] = 'GL'

	-- exec	
	DECLARE @sqlStr  NVARCHAR(1000)
	SET @sqlStr = 'SELECT @Ret = Cur_month FROM ' + @database_name + '.[dbo].[GLRunControl]';	
	PRINT @sqlStr

	DECLARE @Ret INT
	EXEC sp_executesql @sqlStr, N'@Ret INT out',@Ret out 
	
	return @Ret
END
GO