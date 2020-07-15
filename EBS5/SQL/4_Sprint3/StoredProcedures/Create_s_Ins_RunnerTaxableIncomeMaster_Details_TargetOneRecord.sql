
/*-- =============================================
-- Author : DoraemonYu
-- Create date : 2018/01/24 16:00
-- Last update : 2018/01/24 16:00
-- ============================================= */


IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_Ins_RunnerTaxableIncomeMaster_Details_TargetOneRecord]') AND TYPE IN (N'P', N'PC'))
	DROP PROCEDURE [dbo].[s_Ins_RunnerTaxableIncomeMaster_Details_TargetOneRecord]
GO


CREATE PROCEDURE [dbo].[s_Ins_RunnerTaxableIncomeMaster_Details_TargetOneRecord]
	 @RUN_CODE		varchar(5)
	,@RUN_MEMBER	varchar(1)
	,@HIDE			int
	,@STK_TO		numeric(16,2)
	,@EO_TO			int
	,@HSI_TO		int
	,@HSIO_TO		int
	,@HSI100_TO		int
	,@HSI100O_TO	int
	,@MHSI_TO		int
	,@RC_TO			int
	,@RCO_TO		int
	,@SF_TO			int
	,@ABSENCE		int
	,@ADJUST_TAX	numeric(16,2)
	,@MPF			numeric(16,2)
	,@VOL			numeric(16,2)
	,@PAY_DATE		datetime
	,@MPF_CO		numeric(16,2)
	,@VOL_CO		numeric(16,2)
	,@REMARK		varchar(50)
	,@UPDATEBY		varchar(50)
	,@RUN_NAME		varchar(50)
AS
BEGIN

	-- get db name
	DECLARE @database_name varchar(100)
	SELECT @database_name = [CIfChrDataBase] FROM [dbo].[DB_Information] WHERE [CIfChrServerType] = 'GL'

	BEGIN TRY

		SET TRANSACTION ISOLATION LEVEL REPEATABLE READ
		BEGIN TRANSACTION ACTIONS

	--数据检查
	--重复性检查
	DECLARE @checkSql nvarchar(MAX)
	DECLARE @Ret_Check INT
	SET @checkSql = N'SELECT @Ret_Check=1 FROM ' + @database_name +  N'.[dbo].[GLRunMaster] WHERE RUN_CODE = @RUN_CODE AND RUN_MEMBER = @RUN_MEMBER'	
	EXEC Sp_executesql @checkSql, N'
						 @RUN_CODE			varchar(5)
						,@RUN_MEMBER		varchar(1)
						,@Ret_Check INT out
				   ',
						 @RUN_CODE
						,@RUN_MEMBER
						,@Ret_Check out
	IF @Ret_Check > 0
	BEGIN
		rollback TRANSACTION ACTIONS;
		RETURN -1 ;		--REPEAT
	END

	-- Set month
	DECLARE @Cur_Month int
	DECLARE @Cur_Year int
	exec @Cur_Month = s_Get_RunnerTaxableIncomeMaster_CurMonth
	exec @Cur_Year	= s_Get_RunnerTaxableIncomeMaster_CurYear

	-- exec
	DECLARE @sqlStr nvarchar(max)
	SET @sqlStr = N'
			INSERT INTO ' + @database_name +  N'.[dbo].[GLRUNTAXSUMMARY]
				   ([RUN_CODE]
				   ,[RUN_MEMBER]
				   ,[TXN_MONTH]
				   ,[TXN_YEAR]
				   ,[HIDE]
				   ,[STK_TO]
				   ,[EO_TO]
				   ,[HSI_TO]
				   ,[HSIO_TO]
				   ,[HSI100_TO]
				   ,[HSI100O_TO]
				   ,[MHSI_TO]
				   ,[RC_TO]
				   ,[RCO_TO]
				   ,[SF_TO]
				   ,[ABSENCE]
				   ,[ADJUST_TAX]
				   ,[MPF]
				   ,[VOL]
				   ,[PAY_DATE]
				   ,[MPF_CO]
				   ,[VOL_CO]
				   ,[HELD_REMUN]
				   ,[LAST_TAX]
				   ,[LAST_REMUN]
				   ,[LAST_MPF]
				   ,[REMARK]
				   ,[UPDATEBY]
				   ,[ENTRYDATE])
			 VALUES
				   (@RUN_CODE
				   ,@RUN_MEMBER
				   ,@Cur_Month
				   ,@Cur_Year
				   ,@HIDE
				   ,@STK_TO
				   ,@EO_TO
				   ,@HSI_TO
				   ,@HSIO_TO
				   ,@HSI100_TO
				   ,@HSI100O_TO
				   ,@MHSI_TO
				   ,@RC_TO
				   ,@RCO_TO
				   ,@SF_TO
				   ,@ABSENCE
				   ,@ADJUST_TAX
				   ,@MPF
				   ,@VOL
				   ,@PAY_DATE
				   ,@MPF_CO
				   ,@VOL_CO
				   ,0
				   ,0
				   ,0
				   ,0
				   ,@REMARK
				   ,@UPDATEBY
				   ,getdate())
		  '
		EXEC sp_executesql @sqlStr, N'
				    @RUN_CODE		varchar(5)
				   ,@RUN_MEMBER		varchar(1)
				   ,@Cur_Month		int
				   ,@Cur_Year		int
				   ,@HIDE			int
				   ,@STK_TO			numeric(16,2)
				   ,@EO_TO			int
				   ,@HSI_TO			int
				   ,@HSIO_TO		int
				   ,@HSI100_TO		int
				   ,@HSI100O_TO		int
				   ,@MHSI_TO		int
				   ,@RC_TO			int
				   ,@RCO_TO			int
				   ,@SF_TO			int
				   ,@ABSENCE		int
				   ,@ADJUST_TAX		numeric(16,2)
				   ,@MPF			numeric(16,2)
				   ,@VOL			numeric(16,2)
				   ,@PAY_DATE		datetime
				   ,@MPF_CO			numeric(16,2)
				   ,@VOL_CO			numeric(16,2)
				   ,@REMARK			varchar(50)
				   ,@UPDATEBY		varchar(50)
		  ',
					@RUN_CODE
				   ,@RUN_MEMBER
				   ,@Cur_Month
				   ,@Cur_Year
				   ,@HIDE
				   ,@STK_TO
				   ,@EO_TO
				   ,@HSI_TO
				   ,@HSIO_TO
				   ,@HSI100_TO
				   ,@HSI100O_TO
				   ,@MHSI_TO
				   ,@RC_TO
				   ,@RCO_TO
				   ,@SF_TO
				   ,@ABSENCE
				   ,@ADJUST_TAX
				   ,@MPF
				   ,@VOL
				   ,@PAY_DATE
				   ,@MPF_CO
				   ,@VOL_CO
				   ,@REMARK
				   ,@UPDATEBY		

		SET @sqlStr = N'
			INSERT INTO ' + @database_name +  N'.[dbo].[GLRUNMASTER]
				   ([RUN_CODE]
				   ,[RUN_MEMBER]
				   ,[RUN_NAME]
				   ,[UPDATEBY]
				   ,[ENTRYDATE])
			 VALUES
				   (@RUN_CODE
				   ,@RUN_MEMBER
				   ,@RUN_NAME
				   ,@UPDATEBY
				   ,getdate())
		'
		EXEC sp_executesql @sqlStr, N'
					@RUN_CODE		varchar(5)
				   ,@RUN_MEMBER		varchar(1)
				   ,@RUN_NAME		varchar(50)
				   ,@UPDATEBY		varchar(10)
		',
					@RUN_CODE
				   ,@RUN_MEMBER
				   ,@RUN_NAME
				   ,@UPDATEBY

				   
		COMMIT TRANSACTION ACTIONS;
		RETURN 0; --OK
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