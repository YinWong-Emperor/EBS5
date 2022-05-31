
/*-- =============================================
-- Author : DoraemonYu
-- Create date : 2018/01/30 15:00
-- Last update : 2018/01/30 17:36
-- ============================================= */


IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_Del_RunnerTaxableIncomeMaster_Details_TargetOneRecord]') AND TYPE IN (N'P', N'PC'))
	DROP PROCEDURE [dbo].[s_Del_RunnerTaxableIncomeMaster_Details_TargetOneRecord]
GO


CREATE PROCEDURE [dbo].[s_Del_RunnerTaxableIncomeMaster_Details_TargetOneRecord]
	 @RUN_CODE		varchar(5)
	,@RUN_MEMBER	varchar(1)
AS
BEGIN

	-- get db name
	DECLARE @database_name varchar(100)
	SELECT @database_name = [CIfChrDataBase] FROM [dbo].[DB_Information] WHERE [CIfChrServerType] = 'GL'

	BEGIN TRY

		SET TRANSACTION ISOLATION LEVEL REPEATABLE READ
		BEGIN TRANSACTION ACTIONS

	--数据检查
	--增强检查
	DECLARE @checkSql nvarchar(MAX)
	SET @checkSql = N'SELECT 1 FROM ' + @database_name +  N'.[dbo].[GLRunMaster] WHERE RUN_CODE = @RUN_CODE AND RUN_MEMBER = @RUN_MEMBER'
	EXEC Sp_executesql @checkSql, N'
						 @RUN_CODE			varchar(5)
						,@RUN_MEMBER		varchar(1)
				   ',
						 @RUN_CODE
						,@RUN_MEMBER
	IF @@ROWCOUNT <= 0
	BEGIN
		rollback TRANSACTION ACTIONS;
		RETURN -2 ;		--NOT_EXIST
	END
		
	-- exec
	DECLARE @sqlStr nvarchar(max)
	SET @sqlStr = N'
			DELETE FROM ' + @database_name +  N'.[dbo].[GLRUNTAXSUMMARY]
			WHERE [RUN_CODE] = @RUN_CODE AND [RUN_MEMBER] = @RUN_MEMBER
		  '
		EXEC sp_executesql @sqlStr, N'
				    @RUN_CODE		varchar(5)
				   ,@RUN_MEMBER		varchar(1)
		  ',
					@RUN_CODE
				   ,@RUN_MEMBER	

		SET @sqlStr = N'
			DELETE FROM ' + @database_name +  N'.[dbo].[GLRUNMASTER]
			WHERE [RUN_CODE] = @RUN_CODE AND [RUN_MEMBER] = @RUN_MEMBER
		'
		EXEC sp_executesql @sqlStr, N'
					@RUN_CODE		varchar(5)
				   ,@RUN_MEMBER		varchar(1)
		',
					@RUN_CODE
				   ,@RUN_MEMBER

				   
		COMMIT TRANSACTION ACTIONS;
		RETURN 0;	--OK
	END TRY

	BEGIN CATCH 
	  IF (@@TRANCOUNT > 0)
	   BEGIN
		  ROLLBACK TRANSACTION ACTIONS
	   END 
		SELECT
			ERROR_NUMBER() AS ErrorNumber,
			ERROR_SEVERITY() AS ErrorSeverity,
			ERROR_STATE() AS ErrorState,
			ERROR_PROCEDURE() AS ErrorProcedure,
			ERROR_LINE() AS ErrorLine,
			ERROR_MESSAGE() AS ErrorMessage
			--INTO [dbo].[TEST_ONLY_LOGS]

		RETURN -9999;
	END CATCH		   

END
GO