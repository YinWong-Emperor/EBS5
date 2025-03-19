
/*-- =============================================
-- Author : DoraemonYu
-- Create date : 2018/02/01 15:38
-- Last update : 2018/02/01 15:38
-- ============================================= */


IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_Get_RunnerTaxableIncomeMaster_Description_Selects]') AND TYPE IN (N'P', N'PC'))
	DROP PROCEDURE [dbo].[s_Get_RunnerTaxableIncomeMaster_Description_Selects]
GO


CREATE PROCEDURE [dbo].[s_Get_RunnerTaxableIncomeMaster_Description_Selects]
	 @RUN_CODE		varchar(5)
	,@RUN_MEMBER	varchar(1)
	,@TYPE_ID		int
	,@TAXTYPE		varchar(1)
AS
BEGIN

	-- get db name
	DECLARE @database_name varchar(100)
	SELECT @database_name = [CIfChrDataBase] FROM [DB_Information] WHERE [CIfChrServerType] = 'GL'
	
	-- exec
	DECLARE @sqlStr nvarchar(max)
	SET @sqlStr = N'SELECT		[DESCPT]
							   ,[AMOUNT]
							   ,[ITEM]
					FROM ' + @database_name +  N'.[dbo].[GLRUNTAXDETAILS]
					WHERE		[RUN_CODE] = @RUN_CODE 
							AND	[RUN_MEMBER] = @RUN_MEMBER
							AND [TYPE_ID] = @TYPE_ID
							AND [TAXTYPE] = @TAXTYPE
							--AND [AMOUNT] <> 0
					ORDER BY	[ITEM]'
	
	EXEC sp_executesql @sqlStr, N'
				    @RUN_CODE		varchar(5)
				   ,@RUN_MEMBER		varchar(1)
				   ,@TYPE_ID		int
				   ,@TAXTYPE		varchar(1)
				   ',
				   @RUN_CODE
				  ,@RUN_MEMBER
				  ,@TYPE_ID
				  ,@TAXTYPE

END
GO