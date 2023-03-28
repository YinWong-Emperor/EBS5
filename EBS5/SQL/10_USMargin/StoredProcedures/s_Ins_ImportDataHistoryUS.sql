USE [ESL]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[s_Ins_ImportDataHistoryUS]
	@group varchar(100),
	@user varchar(100),
	@currentStep int,
	@totleStep int,
	@message varchar(max)
AS
BEGIN
	-- 影响行数
	DECLARE @rowcount int
	SET @rowcount = @@ROWCOUNT
	-- 错误信息
	DECLARE @err_msg AS NVARCHAR(MAX);
	IF @@ERROR <> 0
		SET @err_msg = CONVERT(VARCHAR(100), @@ERROR) + '-' + ERROR_MESSAGE();
	ELSE
		SET @err_msg = ''

	INSERT INTO import_data_history_US(
       [group]
      ,[current_step]
      ,[totle_step]
      ,[message]
      ,[create_user]
      ,[create_date]
      ,[effect_count]
	  ,[error]
	)
	VALUES(
		@group,
		@currentStep,
		@totleStep,
		@message,
		@user,
		getdate(),
		@rowcount,
		@err_msg
	)
	--print @message+','+ convert(varchar(20),@rowcount)+','+@err_msg
END

GO
