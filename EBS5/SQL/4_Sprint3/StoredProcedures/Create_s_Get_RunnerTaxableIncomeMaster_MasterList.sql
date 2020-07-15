
/*-- =============================================
-- Author : DoraemonYu
-- Create date : 2018/01/12 14:10
-- Last update : 2018/01/12 14:10
-- ============================================= */


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_Get_RunnerTaxableIncomeMaster_MasterList]') AND TYPE IN (N'P', N'PC'))
	DROP PROCEDURE [dbo].[s_Get_RunnerTaxableIncomeMaster_MasterList]
GO


CREATE PROCEDURE [dbo].[s_Get_RunnerTaxableIncomeMaster_MasterList]
AS
BEGIN

	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	-- get db name
	DECLARE @database_name varchar(100)
	SELECT @database_name = [CIfChrDataBase] FROM [DB_Information] WHERE [CIfChrServerType] = 'GL'


	DECLARE @sqlStr  NVARCHAR(1000)

	SET @sqlStr = 'SELECT [RUN_CODE]
						 ,[RUN_MEMBER]
						 ,[RUN_NAME]
				   FROM ' 
				 + @database_name 
				 + '.[dbo].[GLRUNMASTER]  
				    ORDER BY [RUN_CODE],[RUN_MEMBER]
					';

	PRINT @sqlStr
	EXEC (@sqlStr)

END
GO
