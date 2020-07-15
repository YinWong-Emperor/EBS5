
/*-- =============================================
-- Author : DoraemonYu
-- Create date : 2018/02/01 15:38
-- Last update : 2018/02/01 15:38
-- ============================================= */


IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_Upd_RunnerTaxableIncomeMaster_Description_Selects]') AND TYPE IN (N'P', N'PC'))
	DROP PROCEDURE [dbo].[s_Upd_RunnerTaxableIncomeMaster_Description_Selects]
GO


CREATE PROCEDURE [dbo].[s_Upd_RunnerTaxableIncomeMaster_Description_Selects]
	 @RUN_CODE		varchar(5)
	,@RUN_MEMBER	varchar(1)
	,@TYPE_ID		int
	,@TAXTYPE		varchar(1)
	,@UPDATEBY		varchar(50)
AS
BEGIN

	-- 检查是否存在目标的临时表
	IF NOT exists(select * from tempdb..sysobjects where id=object_id('tempdb..##TMP_Upd_RunnerTaxableIncomeMaster_Description_Selects'))
	BEGIN
		PRINT	'不存在 ##TMP_Upd_RunnerTaxableIncomeMaster_Description_Selects'
		RETURN
	END
	
	-- get db name
	DECLARE @database_name varchar(100)
	SELECT @database_name = [CIfChrDataBase] FROM [DB_Information] WHERE [CIfChrServerType] = 'GL'
	
	-- Set month
	DECLARE @Cur_Month int
	DECLARE @Cur_Year int
	exec @Cur_Month = s_Get_RunnerTaxableIncomeMaster_CurMonth
	exec @Cur_Year	= s_Get_RunnerTaxableIncomeMaster_CurYear
	print @Cur_Month
	print @Cur_Year
	
	-- exec
	DECLARE @sqlStr nvarchar(max)
	SET @sqlStr = N'DELETE	FROM ' + @database_name +  N'.[dbo].[GLRUNTAXDETAILS]
					WHERE		[RUN_CODE] = @RUN_CODE 
							AND	[RUN_MEMBER] = @RUN_MEMBER
							AND [TYPE_ID] = @TYPE_ID
							AND [TAXTYPE] = @TAXTYPE'
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


	SET @sqlStr = N'INSERT INTO ' + @database_name +  N'.[dbo].[GLRUNTAXDETAILS]
				(		[RUN_CODE]
						,[RUN_MEMBER]
						,[TXN_MONTH]
						,[TXN_YEAR]
						,[TYPE_ID]
						,[TAXTYPE]
						,[ITEM]
						,[DESCPT]
						,[AMOUNT]						   
						,[UPDATEBY]
						,[ENTRYDATE])
				SELECT	 @RUN_CODE
						,@RUN_MEMBER
						,@Cur_Month
						,@Cur_Year
						,@TYPE_ID
						,@TAXTYPE
						,ROW_NUMBER() OVER (ORDER BY (SELECT NULL))
						,[DESCPT]
						,[AMOUNT]
						,@UPDATEBY
						,getdate()
				FROM ##TMP_Upd_RunnerTaxableIncomeMaster_Description_Selects
	;'
		EXEC sp_executesql @sqlStr, N'
				    @RUN_CODE		varchar(5)
				   ,@RUN_MEMBER		varchar(1)
				   ,@Cur_Month		int
				   ,@Cur_Year		int				   
				   ,@UPDATEBY		varchar(50)
				   ,@TYPE_ID		int
				   ,@TAXTYPE		varchar(1)
		  ',
					@RUN_CODE
				   ,@RUN_MEMBER
				   ,@Cur_Month
				   ,@Cur_Year
				   ,@UPDATEBY	
				   ,@TYPE_ID	
				   ,@TAXTYPE

	-- 清理临时表
	DROP TABLE ##TMP_Upd_RunnerTaxableIncomeMaster_Description_Selects

END
GO