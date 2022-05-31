
/*-- =============================================
-- Author : DoraemonYu
-- Create date : 2018/01/17 11:06
-- Last update : 2018/01/17 14:56
-- ============================================= */


IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_Upd_RunnerTaxableIncomeMaster_CutOff_Monthly]') AND TYPE IN (N'P', N'PC'))
	DROP PROCEDURE [dbo].[s_Upd_RunnerTaxableIncomeMaster_CutOff_Monthly]
GO


CREATE PROCEDURE [dbo].[s_Upd_RunnerTaxableIncomeMaster_CutOff_Monthly]
	@user varchar(30)
AS
BEGIN

	-- get db name
	DECLARE @database_name varchar(100)
	SELECT @database_name = [CIfChrDataBase] FROM [DB_Information] WHERE [CIfChrServerType] = 'GL'
	
	-- backup db
	EXEC s_Upd_RunnerTaxableIncomeMaster_CutOff_BackupDB

	-- exec
	BEGIN TRY
	  BEGIN TRANSACTION UPDATES

		-- Set month
		DECLARE @Cur_Month int
		DECLARE @Cur_Year int
		exec @Cur_Month		= s_Get_RunnerTaxableIncomeMaster_CurMonth

		IF  @Cur_Month		= 12
			EXEC( N'UPDATE ' + @database_name +  N'.[dbo].[GLRunControl] SET Cur_Month = 1, Cur_Year = (Cur_Year + 1), UpdateBy =''' + @user + N''', EntryDate = getdate()' )
		ELSE
			EXEC( N'UPDATE ' + @database_name +  N'.[dbo].[GLRunControl] SET Cur_Month = (Cur_Month + 1), UpdateBy =''' + @user + N''', EntryDate = getdate()' )

		-- Get newest Values
		exec @Cur_Month = s_Get_RunnerTaxableIncomeMaster_CurMonth
		exec @Cur_Year	= s_Get_RunnerTaxableIncomeMaster_CurYear

		-- delete tables
		exec ( N'truncate table '  + @database_name  + N'.[dbo].[GLRunTaxSumHist]' )
		exec ( N'truncate table '  + @database_name  + N'.[dbo].[GLRunTaxDetHist]' )

		-- append tables
		exec ( N'
		INSERT INTO ' + @database_name  + N'.[dbo].[GLRUNTAXDETHIST]
			([RUN_CODE]
			,[RUN_MEMBER]
			,[TXN_MONTH]
			,[TXN_YEAR]
			,[TYPE_ID]
			,[ITEM]
			,[DESCPT]
			,[AMOUNT]
			,[UPDATEBY]
			,[ENTRYDATE])				
		SELECT	 [RUN_CODE]
				,[RUN_MEMBER]
				,[TXN_MONTH]
				,[TXN_YEAR]
				,[TYPE_ID]
				,[ITEM]
				,[DESCPT]
				,[AMOUNT]
				,[UPDATEBY]
				,[ENTRYDATE]				  
		FROM ' + @database_name +  N'.[dbo].[GLRUNTAXDETAILS] ' )

		exec ( N'
		INSERT INTO ' + @database_name +  N'.[dbo].[GLRUNTAXSUMHIST]
			([RUN_CODE]
           ,[RUN_MEMBER]
           ,[TXN_MONTH]
           ,[TXN_YEAR]
           ,[HIDE]
           ,[STK_TO]
           ,[EO_TO]
           ,[HSI_TO]
           ,[HSIO_TO]
		   ,[HSI100]
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
		SELECT	 [RUN_CODE]
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
				,[ENTRYDATE]  
		FROM ' + @database_name +  N'.[dbo].[GLRUNTAXSUMMARY] ' )
		
		-- ¸´ÔÓµÄreplace
		DECLARE @SQL_REP varchar(max)
		SET @SQL_REP = N'
		WITH 
		All_TaxAmt as (
			SELECT	ISNULL(SUM(Amount),0) AS AmtSum		,Run_Code,Run_Member
			FROM	' + @database_name +  N'.[dbo].[GLRunTaxDetails] 
			WHERE	(TaxType = ''0''  OR TaxType = ''1'' OR TaxType = ''2'') 
					AND Type_id != 106 AND Type_id != 105 AND Type_id != 104 AND Type_id != 103 
					AND Type_id != 102
			GROUP BY Run_Code,Run_Member
		),
		All_RemunAmt1 as (
			SELECT	ISNULL(SUM(Amount),0) AS AmtSum		,Run_Code,Run_Member
			FROM	' + @database_name +  N'.[dbo].[GLRunTaxDetails] 
			WHERE	(Type_ID = 16 OR Type_ID = 17) 
			GROUP BY Run_Code,Run_Member
		),
		All_RemunAmt2 as (
			SELECT	ISNULL(SUM(Amount),0) AS AmtSum		,Run_Code,Run_Member
			FROM	' + @database_name +  N'.[dbo].[GLRunTaxDetails] 
			WHERE	Type_ID > 100 AND Type_ID != 16 AND Type_ID != 17 
					AND TaxType = ''1''
			GROUP BY Run_Code,Run_Member
		)

		UPDATE ' + @database_name +  N'.[dbo].[GLRunTaxSummary]  
		SET		 Last_Mpf	= Last_Mpf + Mpf + vol
				,Last_Tax	= Last_tax + Adjust_tax + ISNULL( (SELECT TOP 1 AmtSum FROM All_TaxAmt WHERE Run_Code = ' + @database_name +  N'.[dbo].[GLRunTaxSummary].Run_Code AND Run_Member = ' + @database_name +  N'.[dbo].[GLRunTaxSummary].Run_Member ) , 0)
				,Last_Remun	= Last_remun - ISNULL( ( SELECT TOP 1 AmtSum FROM All_RemunAmt1 WHERE Run_Code = ' + @database_name +  N'.[dbo].[GLRunTaxSummary].Run_Code AND Run_Member = ' + @database_name +  N'.[dbo].[GLRunTaxSummary].Run_Member  ) , 0) +  ISNULL( ( SELECT TOP 1 AmtSum FROM All_RemunAmt2 WHERE Run_Code = ' + @database_name +  N'.[dbo].[GLRunTaxSummary].Run_Code AND Run_Member = ' + @database_name +  N'.[dbo].[GLRunTaxSummary].Run_Member  ) , 0)
				,Txn_Year	= ' +	CAST( @Cur_Year		as varchar )		+ N'
				,Txn_Month	= ' +	CAST( @Cur_Month	as varchar )		+ N'
				,Stk_To		= 0
				,Eo_To		= 0
				,Hsi_To		= 0
				,Hsio_To	= 0
				,Hsi100_To	= 0
				,Hsi100o_To	= 0
				,MHsi_To	= 0
				,Rc_To		= 0
				,Rco_To		= 0
				,Sf_To		= 0
				,Absence	= 0
				,Adjust_Tax	= 0
				,Mpf		= 0
				,Vol		= 0
				,Pay_Date	= ''1900-01-01 00:00:00''
				,Mpf_Co		= 0
				,Vol_Co		= 0
				,Remark		= ''''
				,UpdateBy	= ''' + @user + N'''
				,EntryDate	= getdate()
		
		'
		print N'¸´ÔÓµÄreplace: ' +  @SQL_REP
		exec ( @SQL_REP )


		-- delete target datas
		exec ( N'DELETE '  + @database_name  + N'.[dbo].[GLRunTaxDetails] WHERE Type_ID != 200 AND Amount != 0.00' )
		-- update target datas
		exec ( N'UPDATE '  + @database_name  + N'.[dbo].[GLRunTaxDetails] SET Txn_Year = ' + @Cur_Year + N', Txn_Month = ' + @Cur_Month + N' WHERE Type_ID = 200 AND Amount = 0.00' )
		

	 COMMIT TRANSACTION UPDATES
	END TRY

	BEGIN CATCH 
	  IF (@@TRANCOUNT > 0)
	   BEGIN
		  ROLLBACK TRANSACTION UPDATES
		  PRINT 'Error!'
	   END 
		SELECT
			ERROR_NUMBER() AS ErrorNumber,
			ERROR_SEVERITY() AS ErrorSeverity,
			ERROR_STATE() AS ErrorState,
			ERROR_PROCEDURE() AS ErrorProcedure,
			ERROR_LINE() AS ErrorLine,
			ERROR_MESSAGE() AS ErrorMessage
	END CATCH

END
GO