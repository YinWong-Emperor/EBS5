
/*-- =============================================
-- Author : DoraemonYu
-- Create date : 2018/01/24 16:00
-- Last update : 2018/01/24 16:00
-- ============================================= */


IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_Get_RunnerTaxableIncomeMaster_Details_TargetOneRecord]') AND TYPE IN (N'P', N'PC'))
	DROP PROCEDURE [dbo].[s_Get_RunnerTaxableIncomeMaster_Details_TargetOneRecord]
GO


CREATE PROCEDURE [dbo].[s_Get_RunnerTaxableIncomeMaster_Details_TargetOneRecord]
@TargetRunCode varchar(5),
@TargetRunMember varchar(1)
AS
BEGIN

	-- get db name
	DECLARE @database_name varchar(100)
	SELECT @database_name = [CIfChrDataBase] FROM [DB_Information] WHERE [CIfChrServerType] = 'GL'
	


	
	-- Set month
	DECLARE @Cur_Month int
	DECLARE @Cur_Year int
	exec @Cur_Month = s_Get_RunnerTaxableIncomeMaster_CurMonth
	exec @Cur_Year	= s_Get_RunnerTaxableIncomeMaster_CurYear

	-- exec
	EXEC (N'SELECT TSum.[RUN_CODE]
				  ,TSum.[RUN_MEMBER]
				  ,TSum.[TXN_MONTH]
				  ,TSum.[TXN_YEAR]
				  ,TSum.[HIDE]
				  ,TSum.[STK_TO]
				  ,TSum.[EO_TO]
				  ,TSum.[HSI_TO]
				  ,TSum.[HSIO_TO]
				  ,TSum.[HSI100_TO]
				  ,TSum.[HSI100O_TO]
				  ,TSum.[MHSI_TO]
				  ,TSum.[RC_TO]
				  ,TSum.[RCO_TO]
				  ,TSum.[SF_TO]
				  ,TSum.[ABSENCE]
				  ,TSum.[ADJUST_TAX]
				  ,TSum.[MPF]
				  ,TSum.[VOL]
				  ,TSum.[PAY_DATE]
				  ,TSum.[MPF_CO]
				  ,TSum.[VOL_CO]
				  ,TSum.[HELD_REMUN]
				  ,TSum.[LAST_TAX]
				  ,TSum.[LAST_REMUN]
				  ,TSum.[LAST_MPF]
				  ,TSum.[REMARK]
				  ,RunMaster.[Run_Name]
			FROM ' + @database_name +  N'.[dbo].[GLRUNTAXSUMMARY] as TSum
			JOIN ' + @database_name +  N'.[dbo].[GLRUNMASTER] as RunMaster
			ON		RunMaster.Run_Code	= TSum.Run_Code 
				AND	RunMaster.Run_Member= TSum.Run_Member 
				AND	TSum.Txn_Month		= ''' + @Cur_Month			+ N'''
				AND	TSum.Txn_Year		= ''' + @Cur_Year			+ N'''
				AND	TSum.Run_Code		= ''' + @TargetRunCode		+ N'''
				AND	TSum.Run_Member		= ''' + @TargetRunMember	+ N'''
		  ')

END
GO