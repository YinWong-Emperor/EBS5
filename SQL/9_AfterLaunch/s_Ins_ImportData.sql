USE [ESL]
GO
/****** Object:  StoredProcedure [dbo].[s_Ins_ImportData]    Script Date: 9/10/2018 6:20:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author : DavidYang
-- Create date : 2018/01/08 10:19
-- Last UPDATE : 2018/01/08 17:19
-- Description : Do ImportData Progress
-- 此文?是???境使用，其他?境需要格式化之后使用
-- 注意事?：
-- 1. 每?一?模?，就需要添加一行“--”，用于格式化代?，防止字符串超?
-- 2. 修改?入????考【?明1】
-- 3. 
-- ============================================= 
--EXEC s_Ins_ImportData 'G2BS_RET.G2SB_UAT4_PROD','G2BF_RET.G2FB_UAT4_PROD','ESL_LIQ','BALANCE','','admin', '2019-03-13', '2020-12-03 17:08'
ALTER PROCEDURE [dbo].[s_Ins_ImportData]
	@G2BSDB nvarchar(100),
	@G2BFDB nvarchar(100),
	@LiqDB nvarchar(100),
	@BalanceDB nvarchar(100),
	@group nvarchar(100),
	@user nvarchar(30),
	@nextTradeDate datetime,
	@timestamp nvarchar(200)
AS
BEGIN

	-- ---------- Test Code Begin ----------
	--DECLARE @G2BSDB			varchar(100);
	--DECLARE @G2BFDB			varchar(100);
	--DECLARE @LiqDB			varchar(100);
	--DECLARE @BalanceDB		varchar(100);
	--DECLARE @group			varchar(100);
	--DECLARE @user			varchar(30);
	--DECLARE @nextTradeDate	varchar(50);
	--DECLARE @timestamp		varchar(200);

	--SET @G2BSDB		 		= '[LinkedServer97].[g2bs_dev]';
	--SET @G2BFDB		 		= '[LinkedServer97].[g2bf_dev]';
	--SET @LiqDB		 		= '[ESL_Liq_dev_ebs4]';
	--SET @BalanceDB		 	= '[balance_dev_ebs4]';
	--SET @group		 		= convert(varchar(50),newid());
	--SET @user					= 'davidtest';
	--SET @nextTradeDate		= cast('2017-1-5' as datetime) -- getdate();
	--SET @timestamp	 		= convert(varchar(50),newid());

	-- ------- Sql Format Replace Config Begin -------
	--'|''
	--@G2BSDB|''' + @G2BSDB		 + N'''
	--@G2BFDB|''' + @G2BFDB		 + N'''
	--@BalanceDB|''' + @BalanceDB		 + N'''
	--@LiqDB|''' + @LiqDB		 + N'''
	--@group|''' + @group		 + N'''
	--@user|''' + @user			 + N'''
	--@nextTradeDate|''' + convert(varchar(50), @nextTradeDate) + N'''
	--@timestamp|''' + @timestamp	 + N'''
	--[LinkedServer97].[g2bs_dev]|' + @G2BSDB + N'
	--[LinkedServer97].[g2bf_dev]|' + @G2BFDB + N'
	--[balance]|' + @BalanceDB + N'
	--[ESL_Liq_dev]|' + @LiqDB + N'
	-- ------- Sql Format Replace Config End -------;

	-- VS正?替??容：
	-- 1. ? /*--xx*/ ?成 --xxx
	-- /\* *\t*(-- *[^\*]*)\*/  -->  ${1}
	-- 2. --上面添加?行
	-- ^( *\t*)(-- *\t*)\r\n    -->  \r\n${1}${2}\r\n;

	-- Sql分段，添加;
	-- 1. (EXEC[ a-z_@,.\[\]]*\r\n[\t'\- a-z_@,.\[\]#]*)\r\n --> ${1};\r\n; --【不用】EXEC??的?行，最后添加;
	-- 2. ([^\r\n;]{1})\r\n[\t ]*\r\n --> ${1};\r\n\r\n -- 不是以;?尾，后面有一?空行的添加;
	-- ---------- Test Code End ----------;

DECLARE @sql1 NVARCHAR(MAX)
DECLARE @sql2 NVARCHAR(MAX)
DECLARE @sql3 NVARCHAR(MAX)
DECLARE @sql4 NVARCHAR(MAX)
DECLARE @sql5 NVARCHAR(MAX)
DECLARE @sql6 NVARCHAR(MAX)
DECLARE @sql7 NVARCHAR(MAX)
DECLARE @sql8 NVARCHAR(MAX)
DECLARE @sql9 NVARCHAR(MAX)
DECLARE @sql10 NVARCHAR(MAX)
DECLARE @sql11 NVARCHAR(MAX)
DECLARE @sql12 NVARCHAR(MAX)
DECLARE @sql13 NVARCHAR(MAX)
DECLARE @sql14 NVARCHAR(MAX)
DECLARE @sql15 NVARCHAR(MAX)
DECLARE @sql16 NVARCHAR(MAX)
DECLARE @sql17 NVARCHAR(MAX)
DECLARE @sql18 NVARCHAR(MAX)
DECLARE @sql19 NVARCHAR(MAX)
DECLARE @sql20 NVARCHAR(MAX)
DECLARE @sql21 NVARCHAR(MAX)
DECLARE @sql22 NVARCHAR(MAX)
DECLARE @sql23 NVARCHAR(MAX)
DECLARE @sql24 NVARCHAR(MAX)
DECLARE @sql25 NVARCHAR(MAX)
DECLARE @sql26 NVARCHAR(MAX)
DECLARE @sql27 NVARCHAR(MAX)
DECLARE @sql28 NVARCHAR(MAX)
DECLARE @sql29 NVARCHAR(MAX)
DECLARE @sql30 NVARCHAR(MAX)
  SET @sql1 = N'	

	DECLARE @tempG2BSDB			nvarchar(100);
	DECLARE @tempG2BFDB			nvarchar(100);
	DECLARE @tempLiqDB			nvarchar(100);
	DECLARE @tempBalanceDB		nvarchar(100);
	DECLARE @tempgroup			nvarchar(100);
	DECLARE @tempuser			nvarchar(30);
	DECLARE @tempnextTradeDate	datetime;
	DECLARE @temptimestamp		nvarchar(200);

	-- ?入的??只在?里使用，方便StringFormat【?明1】
	SET @tempG2BSDB			= ''' + @G2BSDB		 + N''';
	SET @tempG2BFDB			= ''' + @G2BFDB		 + N''';
	SET @tempLiqDB			= ''' + @LiqDB		 + N''';
	SET @tempBalanceDB		= ''' + @BalanceDB		 + N''';
	SET @tempgroup			= ''' + @group		 + N''';
	SET @tempuser			= ''' + @user			 + N''';
	SET @tempnextTradeDate	= ''' + convert(varchar(50), @nextTradeDate) + N''';
	SET @temptimestamp		= ''' + @timestamp	 + N''';

	-- 步???
	DECLARE @currentStep int;
	DECLARE @totleStep int;
	DECLARE @message nvarchar(max);
	DECLARE @isDebug int;
	SET @currentStep = 0;
	SET @totleStep = 23;
	SET @isDebug = 0;

	DECLARE @isBackup bit;
	SET @isBackup = 0;

	
BEGIN TRY
	-- ?份?据?
	IF EXISTS(
				SELECT
					1
				FROM
					[misc_master]
				WHERE
					[misc_type] = ''ImportData''
					AND [misc_code] = ''enabled''
					AND [misc_desc] = ''1''
			)
	BEGIN
	IF @isBackup = 1
	BEGIN

		-- ?份添加2?步?
		SET @totleStep = @totleStep + 2;

		DECLARE @backpupPath varchar(max);
		DECLARE @backpupFullPath varchar(max);
		DECLARE @backupReturn varchar(max);
		DECLARE @database_name varchar(100);

		SELECT
			@backpupPath = [misc_desc]
		FROM
			[misc_master]
		WHERE
			[misc_type] = ''ImportData''
			AND [misc_code] = ''backuppath'';

		-- ?份DB ESL
		SELECT
			@database_name = [CIfChrDataBase]
		FROM
			[DB_Information]
		WHERE
			[CIfChrServerType] = ''ESL'';
		SET
			@backpupFullPath = @backpupPath + @database_name + N''_backup_'' + @temptimestamp + N''.bak'';
		SET
			@currentStep = @currentStep + 1;
		SET @message = N''Begin backup DB '' + @database_name + N''...''; --N'', Backup Path(server): '' + @backpupFullPath
		EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep, @message;
		-- ?始?份
		
		IF @isDebug = 0 
			BACKUP DATABASE @database_name TO DISK = @backpupFullPath;
		SET @message = N''Backup DB '' + @database_name + '' finished!'';
		EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,@message;
		
		-- ?份DB Balance
		SELECT
			@database_name = [CIfChrDataBase]
		FROM
			[DB_Information]
		WHERE
			[CIfChrServerType] = ''BAL'';
		SET
			@backpupFullPath = @backpupPath + @database_name + N''_backup_'' + @temptimestamp + N''.bak'';
		SET
			@currentStep = @currentStep + 1;
		SET @message = N''Begin backup DB '' + @database_name + N''...''; --'', Backup Path(server): '' + @backpupFullPath
		EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,@message;
		-- ?始?份
		IF @isDebug = 0 
			BACKUP DATABASE @database_name TO DISK = @backpupFullPath;
		SET @message = N''Backup DB '' + @database_name + '' finished!'';
		EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,@message;
			
		-- ?份DB Liq
		SELECT
'
 SET @sql2 = N'			@database_name = [CIfChrDataBase]
		FROM
			[DB_Information]
		WHERE
			[CIfChrServerType] = ''LIQ'';
		SET
			@backpupFullPath = @backpupPath + @database_name + N''_backup_'' + @temptimestamp + N''.bak'';
		SET
			@currentStep = @currentStep + 1;
		SET @message = N''Begin backup DB '' + @database_name + N''...''; --'', Backup Path(server): '' + @backpupFullPath
		EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,@message;
		-- ?始?份
		IF @isDebug = 0 
			BACKUP DATABASE @database_name TO DISK = @backpupFullPath;
		SET @message = N''Backup DB '' + @database_name + '' finished!'';
		EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,@message;
	END;
	END;
END TRY
BEGIN CATCH
	-- 返回异常值
	SELECT 
		  ERROR_NUMBER() AS [error]
		, ERROR_MESSAGE() AS [message]
		, ERROR_LINE() AS [ERROR_LINE]
		, ERROR_PROCEDURE() AS [ERROR_PROCEDURE]
		, ERROR_SEVERITY() AS [ERROR_SEVERITY]
	RETURN;
END CATCH

BEGIN TRAN tran_importdata --?始事?

DECLARE @tran_error INT;
SET @tran_error = 0;
BEGIN TRY


	-- 系???
	DECLARE @tradeDate datetime;
	SELECT
		@tradeDate = trade_date
	FROM
		' + @G2BSDB + N'.dbo.view_ER_system_parameter;

	-- Drop Temp Table
	IF OBJECT_ID(N''TEMPDB..#temp_view_er_exchange_rate'',N''U'') IS NOT NULL				DROP TABLE  #temp_view_er_exchange_rate;
	IF OBJECT_ID(N''TEMPDB..#temp_view_er_client_fund_movement'',N''U'') IS NOT NULL		DROP TABLE  #temp_view_er_client_fund_movement;
	IF OBJECT_ID(N''TEMPDB..#temp_view_er_client_portfolio'',N''U'') IS NOT NULL			DROP TABLE  #temp_view_er_client_portfolio;
	IF OBJECT_ID(N''TEMPDB..#temp_view_er_client_trade_namt_with_fee'',N''U'') IS NOT NULL	DROP TABLE  #temp_view_er_client_trade_namt_with_fee;
	IF OBJECT_ID(N''TEMPDB..#temp_view_er_client_master_bals'',N''U'') IS NOT NULL			DROP TABLE  #temp_view_er_client_master_bals;
	IF OBJECT_ID(N''TEMPDB..#temp_view_er_client_master_mkt_mrg_value'',N''U'') IS NOT NULL	DROP TABLE  #temp_view_er_client_master_mkt_mrg_value;
	IF OBJECT_ID(N''TEMPDB..#temp_view_er_client_master'',N''U'') IS NOT NULL				DROP TABLE  #temp_view_er_client_master;
	IF OBJECT_ID(N''TEMPDB..#temp_view_er_client_master_g2bs'',N''U'') IS NOT NULL			DROP TABLE  #temp_view_er_client_master_g2bs;
	IF OBJECT_ID(N''TEMPDB..#temp_view_er_client_portfolio_g2bs'',N''U'') IS NOT NULL		DROP TABLE  #temp_view_er_client_portfolio_g2bs;
	IF OBJECT_ID(N''TEMPDB..#temp_ibscaccupl_view'',N''U'') IS NOT NULL						DROP TABLE  #temp_ibscaccupl_view;
	IF OBJECT_ID(N''TEMPDB..#temp_ststktxnlst_view'',N''U'') IS NOT NULL					DROP TABLE  #temp_ststktxnlst_view;
	IF OBJECT_ID(N''TEMPDB..#temp_testbal_view'',N''U'') IS NOT NULL						DROP TABLE  #temp_testbal_view;
	IF OBJECT_ID(N''TEMPDB..#temp_testport_view'',N''U'') IS NOT NULL						DROP TABLE  #temp_testport_view;
	IF OBJECT_ID(N''TEMPDB..#temp_teststatus_view'',N''U'') IS NOT NULL						DROP TABLE  #temp_teststatus_view;
	IF OBJECT_ID(N''TEMPDB..#temp_testtrade_view'',N''U'') IS NOT NULL						DROP TABLE  #temp_testtrade_view;
'
 SET @sql3 = N'	IF OBJECT_ID(N''TEMPDB..#temp_stcltportfolio_view'',N''U'') IS NOT NULL					DROP TABLE  #temp_stcltportfolio_view;
	IF OBJECT_ID(N''TEMPDB..#stockcon'',N''U'') IS NOT NULL			DROP TABLE  #stockcon;
	IF OBJECT_ID(N''TEMPDB..#stockTotal'',N''U'') IS NOT NULL		DROP TABLE  #stockTotal;
	IF OBJECT_ID(N''TEMPDB..#updt_tmp'',N''U'') IS NOT NULL			DROP TABLE  #updt_tmp;
	IF OBJECT_ID(N''TEMPDB..#liq_tmp'',N''U'') IS NOT NULL			DROP TABLE  #liq_tmp;
	IF OBJECT_ID(N''TEMPDB..#clt_tmp'',N''U'') IS NOT NULL			DROP TABLE  #clt_tmp;
	IF OBJECT_ID(N''TEMPDB..#clt_tmp2'',N''U'') IS NOT NULL			DROP TABLE  #clt_tmp2;
	IF OBJECT_ID(N''TEMPDB..#clt_tmp3'',N''U'') IS NOT NULL			DROP TABLE  #clt_tmp3;
	IF OBJECT_ID(N''TEMPDB..#new_tmp'',N''U'') IS NOT NULL			DROP TABLE  #new_tmp;
	IF OBJECT_ID(N''TEMPDB..#new_tmp2'',N''U'') IS NOT NULL			DROP TABLE  #new_tmp2;
	IF OBJECT_ID(N''TEMPDB..#day0_tmp'',N''U'') IS NOT NULL			DROP TABLE  #day0_tmp;
	IF OBJECT_ID(N''TEMPDB..#day1_tmp'',N''U'') IS NOT NULL			DROP TABLE  #day1_tmp;
	IF OBJECT_ID(N''TEMPDB..#clt_no_liq_tmp'',N''U'') IS NOT NULL	DROP TABLE  #clt_no_liq_tmp;
	IF OBJECT_ID(N''TEMPDB..#clt_must_liq_tmp'',N''U'') IS NOT NULL	DROP TABLE  #clt_must_liq_tmp;
	IF OBJECT_ID(N''TEMPDB..#clt_need_liq_tmp'',N''U'') IS NOT NULL	DROP TABLE  #clt_need_liq_tmp;
	IF OBJECT_ID(N''TEMPDB..#del_tmp'',N''U'') IS NOT NULL			DROP TABLE  #del_tmp;
	IF OBJECT_ID(N''TEMPDB..#os_tmp'',N''U'') IS NOT NULL			DROP TABLE  #os_tmp;
	IF OBJECT_ID(N''TEMPDB..#cash_tmp'',N''U'') IS NOT NULL			DROP TABLE  #cash_tmp;
	IF OBJECT_ID(N''TEMPDB..#cashin_tmp'',N''U'') IS NOT NULL		DROP TABLE  #cashin_tmp;
	IF OBJECT_ID(N''TEMPDB..#margin_tmp'',N''U'') IS NOT NULL		DROP TABLE  #margin_tmp;
	IF OBJECT_ID(N''TEMPDB..#good_mr_tmp'',N''U'') IS NOT NULL		DROP TABLE  #good_mr_tmp;
	IF OBJECT_ID(N''TEMPDB..#good_ar_tmp'',N''U'') IS NOT NULL		DROP TABLE  #good_ar_tmp;
	IF OBJECT_ID(N''TEMPDB..#a'',N''U'') IS NOT NULL				DROP TABLE  #a;
	IF OBJECT_ID(N''TEMPDB..#b'',N''U'') IS NOT NULL				DROP TABLE  #b;
	IF OBJECT_ID(N''TEMPDB..#c'',N''U'') IS NOT NULL				DROP TABLE  #c;
	IF OBJECT_ID(N''TEMPDB..#d'',N''U'') IS NOT NULL				DROP TABLE  #d;
	IF OBJECT_ID(N''TEMPDB..#stcltnetbuy_tmp'',N''U'') IS NOT NULL	DROP TABLE  #stcltnetbuy_tmp;
	IF OBJECT_ID(N''TEMPDB..#stcltbuy_tmp'',N''U'') IS NOT NULL		DROP TABLE  #stcltbuy_tmp;
	IF OBJECT_ID(N''TEMPDB..#stcltsell_tmp'',N''U'') IS NOT NULL	DROP TABLE  #stcltsell_tmp;
	IF OBJECT_ID(N''TEMPDB..#stcltsell_tmp2'',N''U'') IS NOT NULL	DROP TABLE  #stcltsell_tmp2;
	IF OBJECT_ID(N''TEMPDB..#stcltbuy_tmp2'',N''U'') IS NOT NULL	DROP TABLE  #stcltbuy_tmp2;
	IF OBJECT_ID(N''TEMPDB..#stcltnet_tmp'',N''U'') IS NOT NULL		DROP TABLE  #stcltnet_tmp;
	IF OBJECT_ID(N''TEMPDB..#stcltnet_tmp2'',N''U'') IS NOT NULL	DROP TABLE  #stcltnet_tmp2;
	IF OBJECT_ID(N''TEMPDB..#stcltnetmv_tmp'',N''U'') IS NOT NULL	DROP TABLE  #stcltnetmv_tmp;
	IF OBJECT_ID(N''TEMPDB..#stcltmv_tmp'',N''U'') IS NOT NULL		DROP TABLE  #stcltmv_tmp;
	IF OBJECT_ID(N''TEMPDB..#tmpval'',N''U'') IS NOT NULL			DROP TABLE  #tmpval;
'
 SET @sql4 = N'	IF OBJECT_ID(N''TEMPDB..#hol1_tmp'',N''U'') IS NOT NULL			DROP TABLE  #hol1_tmp;
	IF OBJECT_ID(N''TEMPDB..#hol2_tmp'',N''U'') IS NOT NULL			DROP TABLE  #hol2_tmp;
	IF OBJECT_ID(N''TEMPDB..#hol4_tmp'',N''U'') IS NOT NULL			DROP TABLE  #hol4_tmp;
	IF OBJECT_ID(N''TEMPDB..#hol5_tmp'',N''U'') IS NOT NULL			DROP TABLE  #hol5_tmp;
	
	--goto debugBeginStep
	

	-- 表 stcontrol --> Liq.stcontrol 日期和??（原有）
	SET @currentStep = @currentStep + 1
	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Liq.stcontrol  ...'';
		
	IF EXISTS(
		SELECT
			1
		FROM
			' + @LiqDB + N'.dbo.stcontrol
	)
	BEGIN
		UPDATE
			' + @LiqDB + N'.dbo.stcontrol
		SET
			tradedate = @tradeDate,
			starttime = GETDATE(),
			endtime = NULL,
			procflag = 0 ;
	END
	ELSE
	BEGIN
		INSERT INTO
			' + @LiqDB + N'.dbo.stcontrol(
				tradedate,
				starttime,
				endtime,
				procflag
			)
		VALUES(
				@tradeDate,
				GETDATE(),
				NULL,
				0
			);
	END;

	-- 准??据
	SET @currentStep = @currentStep + 1;
	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Preparing temp table(PTT) ...'';
	-- #temp_view_er_exchange_rate  ????率
	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''PTT - temp_view_er_exchange_rate...'';

	SELECT
		currency,
		base,
		Rate
	INTO #temp_view_er_exchange_rate
	FROM
		' + @G2BSDB + N'.dbo.view_ER_exchange_rate;

	-- #temp_view_er_client_fund_movement 客??金流?金?（已?算）
	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''PTT - temp_view_er_client_fund_movement...'';
	SELECT
		cmid,
		client_code,
		date,
		dep_wtd,
		currency_code,
		base_unit,
		exchange_rate,
		amount,
		0 AS orig_amount,
		description
	INTO #temp_view_er_client_fund_movement
	FROM
		' + @G2BSDB + N'.dbo.view_ER_client_fund_movement;
		
	--【Update?? -- david】
	--UPDATE
	--	#temp_view_er_client_fund_movement
	--SET
	--	orig_amount = floor(e.amount), -- 跟EBS3向下取整的?理
	--	amount = e.amount * r.rate
	--FROM
	--	#temp_view_er_client_fund_movement e,
	--	#temp_view_er_exchange_rate r
	--WHERE
	--	e.currency_code = r.currency;
		
	---- 跟EBS3??的?果（把?据Update成第1???）
	--UPDATE
	--	#temp_view_er_client_fund_movement
	--SET
	--	orig_amount = floor(tb.amount), -- 跟EBS3向下取整的?理
	--	amount = tb.amount * tb.rate
	--FROM (
	--	SELECT TOP 1
	--		e.amount,
	--		r.rate
	--	FROM
	--		#temp_view_er_client_fund_movement e,
	--		#temp_view_er_exchange_rate r
	--	WHERE
	--		e.currency_code = r.currency
	--) tb;

	UPDATE
		#temp_view_er_client_fund_movement
	SET
		orig_amount = amount,
		amount = amount * r.rate
	FROM 	#temp_view_er_client_fund_movement e,
			#temp_view_er_exchange_rate r
	WHERE
			e.currency_code = r.currency

	-- #temp_view_er_client_portfolio  客?有价?券收市价（已?算）
	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''PTT - temp_view_er_client_portfolio...'';

	SELECT
		cmid,
		accno,
		market,
		currency_code,
		stock_code,
		unsettled_buy_qty,
		unsettled_sell_qty,
		tday_qty,
		onhand,
		net_onhand_qty,
		underreg_qty,
		underwtd_qty,
		closing_price,
		0 AS orig_closing_price,
		margin_ratio,
		aid,
		Suspended,
		cuid
	INTO #temp_view_er_client_portfolio
	FROM
		' + @G2BSDB + N'.dbo.view_ER_client_portfolio;
		
	--【Update?? -- david】
	--UPDATE
'
 SET @sql5 = N'	--	#temp_view_er_client_portfolio
	--SET
	--	orig_closing_price = floor(e.closing_price), -- 跟EBS3向下取整的?理
	--	closing_price = e.closing_price * r.rate
	--FROM
	--	#temp_view_er_client_portfolio e,
	--	#temp_view_er_exchange_rate r
	--WHERE
	--	e.currency_code = r.currency;
		
	-- 跟EBS3??的?果（把?据Update成第1???）
	--UPDATE
	--	#temp_view_er_client_portfolio
	--SET
	--	orig_closing_price = floor(tb.closing_price), -- 跟EBS3向下取整的?理
	--	closing_price = tb.closing_price * tb.rate
	--FROM (
	--	SELECT TOP 1
	--		e.closing_price,
	--		r.rate
	--	FROM
	--		#temp_view_er_client_portfolio e,
	--		#temp_view_er_exchange_rate r
	--	WHERE
	--		e.currency_code = r.currency
	--) tb;

	UPDATE
		#temp_view_er_client_portfolio
	SET
		orig_closing_price = closing_price,
		closing_price = closing_price * r.rate
	FROM 	#temp_view_er_client_portfolio e,
			#temp_view_er_exchange_rate r
		WHERE
			e.currency_code = r.currency;

	-- new_temp_ststktxnlst_view.prg
	-- #temp_view_er_client_trade_namt_with_fee  客? ??值（已?算）
	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''PTT - temp_view_er_client_trade_namt_with_fee...'';

	SELECT
		cmid,
		client_code,
		oid,
		trade_date,
		market,
		stkno,
		stock_code,
		price,
		0 AS orig_price,
		bs,
		qty,
		comm,
		rebate,
		stamp,
		tran_levy,
		I_C_levy,
		trading_fee,
		ccass_fee,
		currency_code_set,
		Exchange_Base_Unit_for_Trade_Ccy,
		Exchange_Rate_of_Setl_Ccy,
		net_amount
	INTO #temp_view_er_client_trade_namt_with_fee
	FROM
		' + @G2BSDB + N'.dbo.view_EMP_client_trade_namt_with_fee
	WHERE
		(trade_date) = @tradeDate;
		
	UPDATE
		#temp_view_er_client_trade_namt_with_fee
	SET
		orig_price = floor(e.price), -- 跟EBS3向下取整的?理
		price = e.price * r.rate,
		comm = e.comm * r.rate,
		rebate = e.rebate * r.rate,
		stamp = e.stamp * r.rate,
		tran_levy = e.tran_levy * r.rate,
		I_C_levy = e.I_C_levy * r.rate,
		trading_fee = e.trading_fee * r.rate,
		ccass_fee = e.ccass_fee * r.rate,
		NET_AMOUNT = e.NET_AMOUNT * r.rate
	FROM
		#temp_view_er_client_trade_namt_with_fee e,
		#temp_view_ER_exchange_rate r
	WHERE
		e.currency_code_set = r.currency;

	-- #temp_view_er_client_master_bals 客? 余?
	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''PTT - temp_view_er_client_master_bals...'';

	SELECT
		cmid,
		client_code,
		ae_code,
		client_name,
		client_type,
		credit_lmt,
		locked,
		suspend_date,
		close_date,
		currency_code,
		base_unit,
		exchange_rate,
		ledger_bal,
		interest_accrued,
		t1_trade_amount,
		t2_trade_amount,
		avail_bal
	INTO #temp_view_er_client_master_bals
	FROM
		' + @G2BSDB + N'.dbo.view_ER_client_master_bals;

	-- #temp_view_er_client_master_mkt_mrg_value  客? 市? 利? 价值
	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''PTT - temp_view_er_client_master_mkt_mrg_value...'';

	SELECT
		cmid,
		client_code,
		ae_code,
		client_name,
		client_type,
		locked,
		suspend_date,
		close_date,
		currency_code,
		base_unit,
		exchange_rate,
		market_value,
		margin_value,
		cal_margin_value,
		t2_margin_value,
		cal_t2_margin_value
	INTO #temp_view_er_client_master_mkt_mrg_value
	FROM
		' + @G2BSDB + N'.dbo.view_ER_client_master_mkt_mrg_value;

	-- #temp_view_er_client_master  客? 余?、市? 利?（合并上面??表），再?算
'
 SET @sql6 = N'	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''PTT - temp_view_er_client_master...'';

	SELECT
		cmid,
		client_code,
		ae_code,
		client_name,
		client_type,
		locked,
		suspend_date,
		close_date,
		credit_lmt,
		ledger_bal,
		interest_accrued,
		market_value,
		margin_value,
		cal_margin_value,
		t1_trade_amount,
		t2_trade_amount,
		t2_margin_value,
		cal_t2_margin_value,
		avail_bal
	INTO #temp_view_er_client_master
	FROM
		(
			SELECT
				DISTINCT cmid,
				client_code,
				ae_code,
				client_name,
				client_type,
				locked,
				suspend_date,
				close_date,
				CONVERT(NUMERIC(16, 2), 0) AS credit_lmt,
				CONVERT(NUMERIC(16, 2), 0) AS ledger_bal,
				CONVERT(NUMERIC(16, 2), 0) AS interest_accrued,
				CONVERT(NUMERIC(16, 2), 0) AS market_value,
				CONVERT(NUMERIC(16, 2), 0) AS margin_value,
				CONVERT(NUMERIC(16, 2), 0) AS cal_margin_value,
				CONVERT(NUMERIC(16, 2), 0) AS t1_trade_amount,
				CONVERT(NUMERIC(16, 2), 0) AS t2_trade_amount,
				CONVERT(NUMERIC(16, 2), 0) AS t2_margin_value,
				CONVERT(NUMERIC(16, 2), 0) AS cal_t2_margin_value,
				CONVERT(NUMERIC(16, 2), 0) AS avail_bal
			FROM
				#temp_view_er_client_master_mkt_mrg_value
			UNION
			SELECT
				DISTINCT cmid,
				client_code,
				ae_code,
				client_name,
				client_type,
				locked,
				suspend_date,
				close_date,
				CONVERT(NUMERIC(16, 2), 0) AS credit_lmt,
				CONVERT(NUMERIC(16, 2), 0) AS ledger_bal,
				CONVERT(NUMERIC(16, 2), 0) AS interest_accrued,
				CONVERT(NUMERIC(16, 2), 0) AS market_value,
				CONVERT(NUMERIC(16, 2), 0) AS margin_value,
				CONVERT(NUMERIC(16, 2), 0) AS cal_margin_value,
				CONVERT(NUMERIC(16, 2), 0) AS t1_trade_amount,
				CONVERT(NUMERIC(16, 2), 0) AS t2_trade_amount,
				CONVERT(NUMERIC(16, 2), 0) AS t2_margin_value,
				CONVERT(NUMERIC(16, 2), 0) AS cal_t2_margin_value,
				CONVERT(NUMERIC(16, 2), 0) AS avail_bal
			FROM
				#temp_view_er_client_master_bals
		) a;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''PTT - temp_view_er_client_master - UPDATE...'';

	-- ?算
	UPDATE
		#temp_view_er_client_master
	SET
		market_value = a.market_value,
		margin_value = a.margin_value,
		cal_margin_value = a.cal_margin_value,
		t2_margin_value = a.t2_margin_value,
		cal_t2_margin_value = a.cal_t2_margin_value
	FROM
		(
			SELECT
				cmmv.client_code,
				SUM(market_value * exchange_rate) AS market_value,
				SUM(margin_value * exchange_rate) AS margin_value,
				SUM(cal_margin_value * exchange_rate) AS cal_margin_value,
				SUM(t2_margin_value * exchange_rate) AS t2_margin_value,
				SUM(cal_t2_margin_value * exchange_rate) AS cal_t2_margin_value
			FROM
				#temp_view_er_client_master_mkt_mrg_value AS cmmv
			GROUP BY
				cmmv.client_code
		) a
	WHERE
		#temp_view_er_client_master.client_code = a.client_code;

	--EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
	--	N''PTT - temp_view_er_client_master - update2.'';
		
	UPDATE
		#temp_view_er_client_master
	SET
		ledger_bal = a.ledger_bal,
'
 SET @sql7 = N'		credit_lmt = a.credit_lmt,
		interest_accrued = a.interest_accrued,
		t1_trade_amount = a.t1_trade_amount,
		t2_trade_amount = a.t2_trade_amount,
		avail_bal = a.avail_bal
	FROM
		(
			SELECT
				cb.client_code,
				SUM (avail_bal * exchange_rate) AS avail_bal,
				SUM (ledger_bal * exchange_rate) AS ledger_bal,
				SUM (interest_accrued * exchange_rate) AS interest_accrued,
				SUM (credit_lmt * exchange_rate) AS credit_lmt,
				SUM (t1_trade_amount * exchange_rate) AS t1_trade_amount,
				SUM (t2_trade_amount * exchange_rate) AS t2_trade_amount
			FROM
				#temp_view_er_client_master_bals AS cb
			GROUP BY
				cb.client_code
		) a
	WHERE
		#temp_view_er_client_master.client_code = a.client_code;

	-- #temp_ibscaccupl_view 客? ?金 流? 的信息
	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''PTT - temp_ibscaccupl_view - ...'';

	SELECT
		client_code AS acc,
		amount AS amt,
		'''' AS amt_type,
		dep_wtd
	INTO #temp_ibscaccupl_view
	FROM
		#temp_view_er_client_fund_movement
	WHERE
		client_code IN(
			SELECT
				client_code
			FROM
				#temp_view_er_client_master
			WHERE
				client_type = ''Cash''
		)
	ORDER BY
		acc;

	-- Fixed?度??
	ALTER TABLE
		#temp_ibscaccupl_view
	ALTER COLUMN
		amt_type VARCHAR(30);

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''PTT - temp_ibscaccupl_view - udpate...'';

	UPDATE
		#temp_ibscaccupl_view
	SET
		amt = - amt
	WHERE
		dep_wtd = ''Withdraw'';

	UPDATE
		#temp_ibscaccupl_view
	SET
		amt_type = ''CR''
	WHERE
		dep_wtd <> ''Withdraw'';

	-- #temp_ststktxnlst_view 客? ??值（未?算）
	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''PTT - temp_ststktxnlst_view - ...'';

	SELECT
		A.client_code AS acc,
		A.bs AS tn_type,
		@tradeDate AS dt,
		A.stkno AS coll,
		A.price AS avg_pce,
		A.qty,
		A.price * A.qty AS g_amt,
		A.comm AS comm_amt,
		A.rebate,
		A.stamp,
		A.tran_levy AS levy,
		A.I_C_levy AS tax,
		A.trading_fee,
		A.ccass_fee AS o_fee,
		ABS(A.net_amount) AS net_amt
	INTO #temp_ststktxnlst_view
	FROM
		' + @G2BSDB + N'.dbo.view_EMP_client_trade_namt_with_fee A
	 WHERE
		A.trade_date = @tradeDate;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''PTT - temp_ststktxnlst_view - UPDATE...'';

	UPDATE
		#temp_ststktxnlst_view
	SET
		acc = t.client_code,
		tn_type = t.bs,
		coll = t.stkno,
		avg_pce = t.price,
		qty = t.qty,
		g_amt = t.price * t.qty,
		comm_amt = t.comm,
		rebate = t.rebate,
		stamp = t.stamp,
		levy = t.tran_levy,
		tax = t.I_C_levy,
		trading_fee = t.trading_fee,
		o_fee = t.ccass_fee,
		net_amt = ABS(t.net_amount)
	FROM
		#temp_view_er_client_trade_namt_with_fee t;

	-- #temp_testbal_view
	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''PTT - temp_testbal_view - ...'';

	Select
		ae_code AS AE,
		client_code AS ACC,
		client_name AS AC_NAME,
		'''' AS sac_type,
		credit_lmt AS CR_LINE,
		ledger_bal AS LedgerBal,
		interest_accrued AS Interest,
'
 SET @sql8 = N'		avail_bal,
		t1_trade_amount,
		t2_trade_amount,
		cmid,
		client_type
	INTO #temp_testbal_view
	FROM
		#temp_view_er_client_master
	ORDER BY
		client_code;

	-- Fixed?度??
	ALTER TABLE
		#temp_testbal_view
	ALTER COLUMN
		sac_type VARCHAR(1);

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''PTT - temp_testbal_view - UPDATE...'';

	UPDATE
		#temp_testbal_view
	SET
		sac_type = ''F''
	WHERE
		cmid = ''368'';

	UPDATE
		#temp_testbal_view
	SET
		sac_type = LEFT(client_type, 1)
	WHERE
		cmid <> ''368'';

	-- #temp_testport_view
	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''PTT - temp_testport_view - ...'';

	SELECT
		accno AS acc,
		stock_code AS code,
		onhand AS qty,
		unsettled_buy_qty AS bt_qty,
		unsettled_sell_qty AS st_qty
	INTO #temp_testport_view
	FROM
		#temp_view_er_client_portfolio
	WHERE (onhand <> 0 OR unsettled_buy_qty <> 0 OR unsettled_sell_qty <> 0)
	ORDER BY
		accno;

	-- #temp_teststatus_view
	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''PTT - temp_teststatus_view - ...'';

	SELECT
		client_code AS acc,
		locked AS stop,
		close_date AS cls_dt,
		suspend_date AS susp_dt
	INTO #temp_teststatus_view
	FROM
		#temp_view_er_client_master
	ORDER BY
		acc;

	-- #temp_testtrade_view
	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''PTT - temp_testtrade_view - ...'';

	Select
		client_code AS acc,
		t2_trade_amount AS T2Trade,
		t1_trade_amount AS T1Trade,
		market_value AS MarketValue,
		cal_margin_value AS MarginValue,
		cal_t2_margin_value AS T2Margin
	INTO #temp_testtrade_view
	FROM
		#temp_view_er_client_master
	ORDER BY
		ACC;

	-- #temp_view_er_client_master_g2bs
	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''PTT - temp_view_er_client_master_g2bs - ...'';

	SELECT
		cmid,
		client_code,
		ae_code,
		client_name,
		client_type,
		credit_lmt,
		locked,
		suspend_date,
		close_date,
		ledger_bal,
		interest_accrued,
		market_value,
		margin_value,
		cal_margin_value,
		t1_trade_amount,
		t2_trade_amount,
		t2_margin_value,
		cal_t2_margin_value,
		avail_bal
	INTO #temp_view_er_client_master_g2bs
	FROM
		#temp_view_er_client_master;

	-- #temp_view_er_client_portfolio_g2bs
	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''PTT - temp_view_er_client_portfolio_g2bs - ...'';

	SELECT
		cmid,
		accno,
		stock_code,
		unsettled_buy_qty,
		unsettled_sell_qty,
		tday_qty,
		onhand,
		net_onhand_qty,
		underreg_qty,
		underwtd_qty,
		closing_price,
		margin_ratio,
		aid,
		Suspended
	INTO #temp_view_er_client_portfolio_g2bs
	FROM
		#temp_view_er_client_portfolio;

	-- #temp_stcltportfolio_view
	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''PTT - temp_stcltportfolio_view - ...'';

	SELECT
		P.accno AS acc,
		P.stock_code AS code,
		@tradeDate AS cur_dt,
		P.underreg_qty AS reg_qty,
		P.onhand AS qty,
		CONVERT(NUMERIC(16, 4), 
			(
				P.underreg_qty + P.onhand
			)
'
 SET @sql9 = N'		) AS sum_qty,
		P.closing_price AS pce,
		CONVERT(NUMERIC(16, 4), 
			(
				P.underreg_qty + P.onhand
			) 
			* 
			P.closing_price -- closePrice的小?位是6位，?里跟EBS3?成4位
		) AS coll_mkt,
		CONVERT(NUMERIC(16, 4), P.margin_ratio / 100) AS mar_pcnt,
		CONVERT(
			NUMERIC(16, 4), 
			(
				P.underreg_qty + P.onhand
			) * P.closing_price * P.margin_ratio / 100
		) AS coll_mar,	-- EBS3?12位小?（4+4+4），?里用4位
		P.Suspended AS suspend_flag
	INTO #temp_stcltportfolio_view
	FROM
		#temp_view_er_client_portfolio P
	ORDER BY
		P.accno;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''PTT - Preparing temp table finished!  ...''
	---------------------------------------------------------------------------------------------------------------------------------------------------
		--?注：
		--1. ??：表stcontrol 和 ESL_Liq的 stcontrol 重复（使用Liq）;

		--' + @G2BSDB + N'.dbo.
		--' + @LiqDB + N'.dbo.
		--' + @BalanceDB + N'.dbo.;

		--表整理：
		--EBS3 DB	Table ----- EBS4 DB Table
		--Ibssttxndate		--> ibs_st_txn_date
		--stcontrol			--> Liq.stcontrol（原有）
		--Testbal			--> Liq.testbal（原有）
		--staemaster		--> Liq.staemaster（原有） ? Import只?2列，但原本?据有5列，是否正确？
		--StStkTxnLst		--> st_stk_txn_lst 
		--TestTrade			--> test_trade
		--testport			--> test_port
		--TestStatus		--> Liq.TestStatus（原有）
		--stsuspendstock	--> Liq.stsuspendstock（原有）
		--Ibscaccup1		--> ibs_cac_cup
		--Stcltportfolio	--> st_clt_portfolio  字段stk_code?度不同(有?据超?5位)
		--monthcomm			--> Liq.monthcomm（原有）
		--monthcommdetailf	--> Liq.monthcommdetailf（原有）
		--monthcommf		--> Liq.monthcommf（原有）
		--monthint			--> Liq.monthint（原有）
		--exchangerate		--> exchangerate（原有）?构不一?
		--table_itas_ebs3	--> Bal.acbal（原有）
		--stockconcentration --> Bal.stockconcentration （原有）
		--stcltmaster		--> Liq.stcltmaster（原有）
		--stcltliq			-->	Liq.stcltliq（原有）
		--stcltliqlist		--> Liq.stcltliqlist（原有）
		--stcltliqfb		--> Liq.stcltliqfb（原有）
		--stcltliqfblist	--> Liq.stcltliqfblist（原有）
		--stimportdate		--> Liq.stimportdate（原有）;
		--stsysparameter	--> Liq.stsysparameter（原有）
		-- select table
		--sttxndate --> Liq.sttxndate（原有）;

	-- ?入?据

	-- 表 Ibssttxndate --> ibs_st_txn_date ?置日期
	SET @currentStep = @currentStep + 1
	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - ibs_st_txn_date  ...'';

	-- 清?据
	TRUNCATE TABLE ibs_st_txn_date;

	-- ?量
	DECLARE @tmpIbsStTxnDate datetime
	SET @tmpIbsStTxnDate = @tradeDate;

	-- 插入?据
	INSERT INTO
		ibs_st_txn_date
		(
			t2_date
		)
	VALUES (
		@tmpIbsStTxnDate
	);

	TRUNCATE TABLE ' + @LiqDB + N'.dbo.IBSSTTXNDATE;
	INSERT INTO	' + @LiqDB + N'.dbo.IBSSTTXNDATE
		(
			t2_date
		)
	VALUES (
		@tradeDate
	);

	-- 表 Testbal --> Liq.testbal  AE 金?（原有）
	SET @currentStep = @currentStep + 1
	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - testbal  ...'';

	-- 清?据
	TRUNCATE TABLE ' + @LiqDB + N'.dbo.testbal;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - testbal - DELETE All.'';

	-- 插入?据
	INSERT INTO
		' + @LiqDB + N'.dbo.testbal(
			ae_code,
			clt_code,
			clt_name,
			clt_type,
'
 SET @sql10 = N'			cr_limit,
			bal,
			interest,
			ava_bal,
			t1_trade,
			t2_trade
		)
	SELECT
		LTRIM(RTRIM(ae)),
		LTRIM(RTRIM(acc)),
		LTRIM(RTRIM(ac_name)),
		LTRIM(RTRIM(sac_type)),
		cr_line,
		LedgerBal,
		interest,
		avail_bal,
		t1_trade_amount,
		t2_trade_amount
	FROM
		#temp_testbal_view
	ORDER BY
		acc
	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Liq.testbal - INSERT.'';



	-- 表 staemaster --> Liq.staemaster AE名（原有）
	SET @currentStep = @currentStep + 1
	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Liq.staemaster  ...'';

	-- 清?据
	--TRUNCATE TABLE ' + @LiqDB + N'.[dbo].[staemaster];

	--EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		--N''Save data - Liq.staemaster - DELETE All.'';

	-- 插入?据
	INSERT INTO
		' + @LiqDB + N'.[dbo].[staemaster] 
		(
			run_code, 
			run_name
		)
	SELECT
		RTRIM(aeno),
		RTRIM(name)
	FROM
		' + @G2BSDB + N'.dbo.ae_master
	WHERE RTRIM(aeno) not in (SELECT rtrim(run_code) FROM ' + @LiqDB + N'.[dbo].[staemaster])
	-- ae_view
	ORDER BY
		aeno;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Liq.staemaster - INSERT.'';

	UPDATE M
	SET M.run_name = G.aename,
	M.branch_name = G.branchname
	FROM ' + @LiqDB + N'.[dbo].[staemaster] M
	JOIN
	(SELECT RTRIM(a.aeno) as aeno, RTRIM(a.name) as aename, RTRIM(ISNULL(b.name,'''')) as branchname
	FROM ' + @G2BSDB + N'.dbo.ae_master a
	LEFT JOIN ' + @G2BSDB + N'.dbo.branch_master b
	ON a.bhid=b.bhid) G
	ON M.run_code = G.aeno;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Liq.staemaster - UPDATE.'';


	-- 表 StStkTxnLst --> st_stk_txn_lst 
	SET @currentStep = @currentStep + 1
	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - st_stk_txn_lst  ...'';

	-- 清?据
	TRUNCATE TABLE st_stk_txn_lst
	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - st_stk_txn_lst - DELETE All.'';

	-- 插入?据
	INSERT INTO
		st_stk_txn_lst(
			clt_code,
			inv_no,
			txn_date,
			stk_code,
			stk_price,
			txn_qty,
			txn_to,
			clt_comm,
			run_rbt_ibs,
			stamp_duty,
			levy,
			ic_levy,
			trading_fee,
			ccass_fee,
			credit,
			debit
		)
	SELECT
		LTRIM(RTRIM(acc)),
		LTRIM(RTRIM(tn_type)),
		dt,
		LTRIM(RTRIM(coll)),
		avg_pce,
		qty,
		g_amt,
		comm_amt,
		rebate,
		stamp,
		levy,
		tax,
		-- 不知?什么用????ic_levy
		levy,
		o_fee,
		CASE WHEN tn_type = ''S'' THEN net_amt ELSE 0.00 END,
		CASE WHEN tn_type = ''B'' THEN net_amt ELSE 0.00 END
	FROM
		#temp_ststktxnlst_view
	ORDER BY
		acc;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - st_stk_txn_lst - INSERT.'';

	-- 表 TestTrade --> test_trade 
	SET @currentStep = @currentStep + 1
	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - test_trade  ...'';

	-- 清?据
	TRUNCATE TABLE test_trade;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - test_trade - DELETE All.'';

	-- 插入?据
	INSERT INTO
		test_trade(
			clt_code,
			t1_trade,
			t2_trade,
			mkt_value,
			margin_value,
			t2_margin
		)
	SELECT
		LTRIM(RTRIM(acc)),
		t1trade,
		t2trade,
		marketvalue,
		marginvalue,
		t2margin
	FROM
		#temp_testtrade_view
	WHERE
		t2trade <> 0
		OR t1trade <> 0
		OR marketvalue <> 0
		OR marginvalue <> 0
		OR t2margin <> 0
	ORDER BY
		acc;

'
 SET @sql11 = N'	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - test_trade - INSERT.'';


	-- 表 testport --> test_port
	SET @currentStep = @currentStep + 1
	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - test_port  ...'';

	-- 清?据
	TRUNCATE TABLE test_port;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - test_port - Delte All.'';

	-- 插入?据
	INSERT INTO
		test_port(
			clt_code,
			stk_code,
			qty,
			bt_qty,
			st_qty
		)
	SELECT
		LTRIM(RTRIM(acc)),
		LTRIM(RTRIM(code)),
		qty,
		bt_qty,
		st_qty
	FROM
		#temp_testport_view
	WHERE
		qty <> 0
		OR bt_qty <> 0
		OR st_qty <> 0
	ORDER BY
		Acc;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - test_port - INSERT.'';


	-- 表 TestStatus --> Liq.TestStatus（原有）
	SET @currentStep = @currentStep + 1
	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - TestStatus  ...'';

	-- 清?据
	TRUNCATE TABLE ' + @LiqDB + N'.dbo.TestStatus;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Liq.TestStatus - DELETE All.'';

	-- 插入?据
	INSERT INTO
		' + @LiqDB + N'.dbo.TestStatus(
			clt_code,
			[stop],
			susp_date,
			cls_date
		)
	SELECT
		LTRIM(RTRIM(acc)),
		LTRIM(RTRIM([stop])),
		susp_dt,
		cls_dt
	FROM
		#temp_teststatus_view
	ORDER BY
		acc;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Liq.TestStatus - INSERT.'';


	-- 表 stsuspendstock --> Liq.stsuspendstock（原有）
	SET @currentStep = @currentStep + 1
	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - stsuspendstock  ...'';

	-- 清?据
	TRUNCATE TABLE ' + @LiqDB + N'.dbo.stsuspendstock;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Liq.stsuspendstock - DELETE All.'';

	-- 插入?据
	INSERT INTO
		' + @LiqDB + N'.dbo.stsuspendstock(stkno, suspend_date)
	SELECT
		stkno,
		date_suspend
	FROM
		' + @G2BSDB + N'.dbo.stock_master
	WHERE
		so3 = ''Y''
		AND stkno NOT LIKE ''%-%'';

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Liq.stsuspendstock - INSERT.'';

	-- 表 Ibscaccup1 --> ibs_cac_cup 客? 金?
	SET @currentStep = @currentStep + 1
	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - ibs_cac_cup  ...'';

	-- 清?据
	TRUNCATE TABLE ibs_cac_cup;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - ibs_cac_cup - DELETE All.'';

	-- 插入?据
	INSERT INTO
		ibs_cac_cup
		(
			clt_code, 
			amt, 
			amt_type
		)
	SELECT
		LTRIM(RTRIM(acc)),
		amt,
		CASE WHEN amt > 0 THEN ''CR'' ELSE '''' END
	FROM
		#temp_ibscaccupl_view
	ORDER BY
		acc;

	DELETE FROM ' + @LiqDB + N'.dbo.client_fund_movement;
	INSERT INTO ' + @LiqDB + N'.dbo.client_fund_movement(accno, amount, amount_type) 
	SELECT LTRIM(RTRIM(acc)), amt, amt_type
	FROM #temp_ibscaccupl_view;	

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - ibs_cac_cup - INSERT.'';


	-- 表 Stcltportfolio --> st_clt_portfolio
'
 SET @sql12 = N'	SET @currentStep = @currentStep + 1
	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - st_clt_portfolio  ...'';
	
	-- 清?据
	TRUNCATE TABLE st_clt_portfolio;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - st_clt_portfolio - DELETE All.'';

	-- [fixed]Error: String or binary data would be truncated. debug
	INSERT INTO
		st_clt_portfolio(
			clt_code,
			stk_code,
			txn_date,
			qty_underreg,
			qty_onhand,
			qty_total,
			mkt_price,
			mkt_value,
			margin_ratio,
			margin_value,
			suspend_flag,
			net_qty_onhand,
			net_market_value
		)
	SELECT
		LTRIM(RTRIM(accno)),
		LTRIM(RTRIM(stock_code)),
		@tradeDate,
		underreg_qty,
		onhand,
		CONVERT(
			NUMERIC(16, 4),
			(
				 P.underreg_qty +  P.onhand
			)
		),
		closing_price,
		CONVERT(
			NUMERIC(16, 4),
			(
				 P.underreg_qty + P.onhand
			) * P.closing_price
		),
		CONVERT(
			NUMERIC(16, 4), 
			P.margin_ratio / 100
		),
		CONVERT(
			NUMERIC(16, 4),
			(
				 P.underreg_qty + P.onhand
			) * P.closing_price * P.margin_ratio / 100
		),
		Suspended,
		CONVERT(
			NUMERIC(16, 4),
			(
				 P.net_onhand_qty
			)
		),
		CONVERT(
			NUMERIC(16, 4),
			(
				 P.net_onhand_qty * P.closing_price
			)
		)
	FROM
		#temp_view_er_client_portfolio AS P
	ORDER BY
		accno;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - st_clt_portfolio - INSERT.'';

	DELETE FROM ' + @LiqDB + N'.dbo.STPortfolio;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - STPortfolio - DELETE.'';

	INSERT INTO ' + @LiqDB + N'.dbo.STPortfolio(clt_code, stk_code, qty, market_value, net_qty, net_market_value, ldate)
	SELECT clt_code, stk_code, qty_onhand, mkt_value, net_qty_onhand, net_market_value, getdate()
    FROM st_clt_portfolio

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - STPortfolio - INSERT.'';


	-- 表 monthcomm --> Liq.monthcomm
	SET @currentStep = @currentStep + 1
	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Liq.monthcomm  ...'';
		
	-- 定??量
	DECLARE @sdbdate datetime
	DECLARE @lastmonth datetime;

	SELECT
		@sdbdate = MAX(tdate)
	FROM
		' + @G2BSDB + N'.dbo.view_it_client_last_day_trade ;

	-- 用于查?（提高性能）
	DECLARE @sdbdateBegin datetime
	DECLARE @sdbdateEnd datetime
	SET @sdbdateBegin = DATEADD(m, DATEDIFF(m, 0, @sdbdate), 0) -- ??月1?
	SET @sdbdateEnd = DATEADD(m, 1, DATEADD(m, DATEDIFF(m, 0, @sdbdate), 0)) --下?月1?;

	IF DAY(@sdbdate) < 5
	BEGIN
		-- 上?月最后一天
		SET
			@lastmonth = DATEADD(d, -1, DATEADD(m, DATEDIFF(m, 0, @sdbdate), 0));
		-- 用于查?（提高性能）
		DECLARE @lastmonthBegin datetime
		DECLARE @lastmonthEnd datetime
		SET @lastmonthBegin = DATEADD(m, DATEDIFF(m, 0, @lastmonth), 0) -- ??月1?
		SET @lastmonthEnd = DATEADD(m, 1, DATEADD(m, DATEDIFF(m, 0, @lastmonth), 0)) --下?月1?;

		-- ?除上?月?据
		DELETE FROM
			' + @LiqDB + N'.dbo.monthcomm
		WHERE
			--YEAR(mth) = YEAR(@lastmonth)
			--AND MONTH(mth) = MONTH(@lastmonth);
			mth >= @lastmonthBegin
			AND mth < @lastmonthEnd;

		EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
			N''Save data - Liq.monthcomm - lastmonth DELETE.'';

		INSERT INTO
			' + @LiqDB + N'.dbo.monthcomm
			(
				 [ACCNO]
				,[MTH]
				,[COMM]
				,[adj]
				,[CLIENT_TYPE]
				,[ipo]
			)
		SELECT
			a.accno,
			mth,
			comm,
			adj,
			b.client_type,
			0 AS ipo
		FROM
			(
				SELECT
					accno,
					@lastmonth AS mth,
					SUM(comm) AS comm,
					0 AS adj
				FROM
					' + @G2BSDB + N'.dbo.view_G2B_client_trade_dt_with_comm
				WHERE
					YEAR(tdate) = YEAR(@lastmonth)
					AND MONTH(tdate) = MONTH(@lastmonth)
'
 SET @sql13 = N'					AND (
						tradetype = ''0''
						OR tradetype = ''4''
					)
				GROUP BY
					accno
			) AS a
			INNER JOIN (
				SELECT
					DISTINCT accno,
					client_type
				FROM
					' + @G2BSDB + N'.dbo.view_it_client_all
			) AS b ON a.accno = b.accno
		ORDER BY
			a.accno;

		EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
			N''Save data - Liq.monthcomm - lastmonth INSERT.'';

	END;

	-- ?除?月?据
	DELETE FROM
		' + @LiqDB + N'.dbo.monthcomm
	WHERE
		--YEAR(mth) = YEAR(@sdbdate)
		--AND MONTH(mth) = MONTH(@sdbdate)
		mth >= @sdbdateBegin
		AND mth < @sdbdateEnd;
		
	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Liq.monthcomm - this month DELETE.'';

	INSERT INTO
		' + @LiqDB + N'.dbo.monthcomm
			(
				 [ACCNO]
				,[MTH]
				,[COMM]
				,[adj]
				,[CLIENT_TYPE]
				,[ipo]
			)
	SELECT
		--top 10 -- debug test code
		a.accno,
		mth,
		comm,
		adj,
		b.client_type,
		0 AS ipo
	FROM
		(
			SELECT
				accno,
				@sdbdate AS mth,
				SUM(comm) AS comm,
				0 AS adj
			FROM
				' + @G2BSDB + N'.dbo.view_G2B_client_trade_dt_with_comm
			WHERE
				--YEAR(tdate) = YEAR(@sdbdate)
				--AND MONTH(tdate) = MONTH(@sdbdate)
				tdate >= @sdbdateBegin
				AND tdate < @sdbdateEnd
				AND (
					tradetype = ''0''
					OR tradetype = ''4''
				)
			GROUP BY
				accno
		) a
		INNER JOIN (
			SELECT
				DISTINCT accno,
				client_type
			FROM
				' + @G2BSDB + N'.dbo.view_it_client_all
		) b ON a.accno = b.accno
	ORDER BY
		a.accno;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Liq.monthcomm - this month INSERT.'';


	-- 
	-- ?量;

	DECLARE @fdbdate datetime;
	DECLARE @fcurDate datetime;

	SELECT
		@fdbdate = MAX(tdate)
	FROM
		' + @G2BFDB + N'.dbo.view_IT_client_last_day_trade;

	DECLARE @fdbdateBegin datetime;
	DECLARE @fdbdateEnd datetime;
	SET @fdbdateBegin = DATEADD(m, DATEDIFF(m, 0, @fdbdate), 0); -- ??月1?
	SET @fdbdateEnd = DATEADD(m, 1, DATEADD(m, DATEDIFF(m, 0, @fdbdate), 0)); --下?月1?;

	SELECT
		@fcurDate = MAX(tdate)
	FROM
		exchangerate;

	---- 不是同一?月
	--IF (YEAR(@fdbdate) <> YEAR(@fcurDate))
	--		OR (month(@fdbdate) <> month(@fcurDate))
	IF 1=1
	BEGIN
		SET @totleStep = @totleStep + 1
		SET @currentStep = @currentStep + 1
		EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
			N''Save data - exchangerate ...'';

		DECLARE @dt_now datetime = GETDATE()

		DELETE FROM exchangerate WHERE system_type =''Futures'' AND tdate = @fdbdate;
		  INSERT INTO exchangerate
		  SELECT ''Futures'' AS system_type, currm.name_s AS currency_in, ''HKD'' AS currency_out, currex.last/currm.base AS ex_rate, @dt_now AS lupdtdate, @fdbdate AS tdate
		  FROM ' + @G2BFDB + N'.dbo.currency_exchange currex
		  JOIN ' + @G2BFDB + N'.dbo.currency_master currm
		  ON currex.cuid = currm.cuid
		  AND currex.cuid_ex = 1;
  
		  DELETE FROM exchangerate WHERE system_type =''Securities'' AND tdate = @sdbdate;
		  INSERT INTO exchangerate
		  SELECT ''Securities'' AS system_type, currency AS currency_in, ''HKD'' AS currency_out, rate AS ex_rate, @dt_now AS lupdtdate, @sdbdate AS tdate
		  FROM ' + @G2BSDB + N'.dbo.view_er_exchange_rate;

		EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
			N''Save data - exchangerate - INSERT.'';


	END;'

 SET @sql14 = N'
	-- 表 monthcommdetailf --> Liq.monthcommdetailf（原有）
	-- 表 monthcommf --> Liq.monthcommf（原有）
	SET @currentStep = @currentStep + 1
	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Liq.monthcommdetailf, Liq.monthcommf ...'';

	-- ?理 上?月 ?据
	IF DAY(@fdbdate) < 8
	BEGIN;

		-- 上?月最后一天
		SET
			@lastmonth = DATEADD(d, -1, DATEADD(m, DATEDIFF(m, 0, @fdbdate), 0));

		-- ?除 ' + @LiqDB + N'.dbo.monthcommdetailf 上?月?据
		DELETE FROM
			' + @LiqDB + N'.dbo.monthcommdetailf
		WHERE
			YEAR(mth) = YEAR(@lastmonth)
			AND MONTH(mth) = MONTH(@lastmonth);

		EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
			N''Save data - Liq.monthcommdetailf - lastmonth DELETE.'';


		-- 添加 ' + @LiqDB + N'.dbo.monthcommdetailf 上?月?据
		INSERT INTO
			' + @LiqDB + N'.dbo.monthcommdetailf
			(
				 [accno]
				,[mth]
				,[comm]
				,[comm_curr]
			)
		SELECT
			accno,
			tdate,
			comm,
			charge_currency
		FROM
			' + @G2BFDB + N'.dbo.view_it_G2B_client_trade_dt_with_comm
		WHERE
			YEAR(tdate) = YEAR(@lastmonth)
			AND MONTH(tdate) = MONTH(@lastmonth)
			AND comm is NOT null;

		EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
			N''Save data - Liq.monthcommdetailf - lastmonth INSERT.'';


		-- ?除 ' + @LiqDB + N'.dbo.monthcommf 上?月?据
		DELETE FROM
			' + @LiqDB + N'.dbo.monthcommf
		WHERE
			YEAR(mth) = YEAR(@lastmonth)
			AND MONTH(mth) = MONTH(@lastmonth);

		EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
			N''Save data - Liq.monthcommf - lastmonth DELETE.'';


		-- 添加 ' + @LiqDB + N'.dbo.monthcommf 上?月?据
		INSERT INTO
			' + @LiqDB + N'.dbo.monthcommf
			(
				 [ACCNO]
				,[MTH]
				,[COMM]
				,[adj]
				,[ipo]
			)
		SELECT
			a.accno,
			mth = b.tdate,
			SUM(a.comm * b.ex_rate) AS comm,
			0 AS adj,
			0 AS ipo
		FROM
			' + @LiqDB + N'.dbo.monthcommdetailf a
			INNER JOIN view_month_exchangerate b ON a.comm_curr = b.currency_in collate Chinese_Taiwan_Bopomofo_CI_AS
			AND YEAR(a.mth) = YEAR(b.tdate)
			AND YEAR(a.mth) = YEAR(@lastmonth)
			AND MONTH(a.mth) = MONTH(b.tdate)
			AND MONTH(a.mth) = MONTH(@lastmonth)
			AND system_type = ''Futures''
		GROUP BY
			a.accno,
			b.tdate
		ORDER BY
			a.accno;

		EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
			N''Save data - Liq.monthcommf - lastmonth INSERT.'';


	END;

	-- ?除 ' + @LiqDB + N'.dbo.monthcommdetailf ?月?据	
	DELETE FROM
		' + @LiqDB + N'.dbo.monthcommdetailf
	WHERE
		YEAR(mth) = YEAR(@fdbdate)
		AND MONTH(mth) = MONTH(@fdbdate);

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Liq.monthcommdetailf - DELETE.'';


	-- 添加 ' + @LiqDB + N'.dbo.monthcommdetailf ?月?据
	INSERT INTO
		' + @LiqDB + N'.dbo.monthcommdetailf
		(
			[accno]
			,[mth]
			,[comm]
			,[comm_curr]
		)
	SELECT 
		accno,
		tdate,
		comm,
		charge_currency
	FROM
		' + @G2BFDB + N'.dbo.view_it_G2B_client_trade_dt_with_comm
	WHERE
		--YEAR(tdate) = YEAR(@fdbdate)
		--AND MONTH(tdate) = MONTH(@fdbdate)
		tdate >= @fdbdateBegin AND
		tdate < @fdbdateEnd 
		AND comm IS NOT null;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Liq.monthcommdetailf - INSERT.'';
	
	-- ?除 ' + @LiqDB + N'.dbo.monthcommf ?月?据
	DELETE FROM
		' + @LiqDB + N'.dbo.monthcommf
	WHERE
		YEAR(mth) = YEAR(@fdbdate)
		AND MONTH(mth) = MONTH(@fdbdate);

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Liq.monthcommf - DELETE.'';

	-- 添加 ' + @LiqDB + N'.dbo.monthcommf ?月?据
	INSERT INTO
		' + @LiqDB + N'.dbo.monthcommf
		(
			 [ACCNO]
			,[MTH]
			,[COMM]
			,[adj]
			,[ipo]
		)
'
SET @sql15 = N'	
	SELECT
		a.accno,
		mth = b.tdate,
		SUM(a.comm * b.ex_rate) AS comm,
		0 AS adj,
		0 AS ipo
	FROM
		' + @LiqDB + N'.dbo.monthcommdetailf a
		INNER JOIN view_month_exchangerate b ON a.comm_curr = b.currency_in collate Chinese_Taiwan_Bopomofo_CI_AS
		AND YEAR(a.mth) = YEAR(b.tdate)
		AND YEAR(a.mth) = YEAR(@fdbdate)
		AND MONTH(a.mth) = MONTH(b.tdate)
		AND MONTH(a.mth) = MONTH(@fdbdate)
		AND system_type = ''Futures''
	GROUP BY
		a.accno,
		b.tdate
	ORDER BY
		a.accno;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Liq.monthcommf - INSERT.'';

	-- 表 monthint --> Liq.monthint（原有）
	SET
		@currentStep = @currentStep + 1
	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - monthint ...'';

	-- ?除 monthint ?月?据
	DELETE FROM
		' + @LiqDB + N'.dbo.monthint
	WHERE
		YEAR(mth) = YEAR(@sdbdate)
		AND MONTH(mth) = MONTH(@sdbdate);

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Liq.monthint - DELETE.'';


	-- 添加 monthint ?月?据
	INSERT INTO
		' + @LiqDB + N'.dbo.monthint
		(
			[ACCNO],
			[MTH],
			[INTerest],
			[adj],
			[ipo],
			[CLIENT_TYPE]
		)
	SELECT
		a.accno,
		mth,
		[int],
		0 AS adj,
		0 AS ipo,
		b.client_type
	FROM
		(
			SELECT
				accno,
				@sdbdate AS mth,
				-1 * SUM(int_amt) AS [int]
			FROM
				' + @G2BSDB + N'.dbo.view_it_client_accrue_int
			WHERE
				YEAR(to_date) = YEAR(@sdbdate)
				AND MONTH(to_date) = MONTH(@sdbdate)
			GROUP BY
				accno
		) a
		INNER JOIN (
			SELECT
				DISTINCT accno,
				client_type
			FROM
				' + @G2BSDB + N'.dbo.view_IT_client_all
		) b ON a.accno = b.accno
	ORDER BY
		a.accno;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Liq.monthint - INSERT.'';
	
	DELETE FROM ' + @LiqDB + N'.dbo.CommissionMaster 
	WHERE YEAR(TDate) = YEAR(@sdbdate)
	AND MONTH(TDate) = MONTH(@sdbdate)

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Liq.CommissionMaster - DELETE.'';
	
	INSERT INTO ' + @LiqDB + N'.dbo.CommissionMaster
		SELECT AccType=''Securities'', ISNULL(A.AccNo, B.AccNo) AS AccNo, ISNULL(A.Comm, 0) As Comm, ISNULL(A.TDate, B.TDate) AS TDate, ISNULL(B.Interest, 0) AS Interest, ISNULL(A.Ccy, B.Ccy) AS Ccy, GETDATE() AS LastUpdateDate
		FROM
		(
		SELECT accno AS AccNo, tdate AS TDate, SUM(ISNULL(comm,0)) AS Comm, currency_code_trade As Ccy
		FROM ' + @G2BSDB + N'.dbo.view_G2B_client_trade_dt_with_comm
		WHERE YEAR(tdate)=YEAR(@sdbdate) 
		AND MONTH(tdate)=MONTH(@sdbdate)
		AND (tradetype = ''0'' OR tradetype = ''4'')
		GROUP BY accno, tdate, currency_code_trade
		) A
		FULL OUTER JOIN
		(
		SELECT accno AS AccNo, fm_date AS TDate, -1*SUM(int_amt) AS Interest, name_s as Ccy
		FROM ' + @G2BSDB + N'.dbo.view_it_client_accrue_int
		WHERE YEAR(to_date) = YEAR(@sdbdate)
		AND MONTH(to_date) = MONTH(@sdbdate)
		GROUP BY accno, fm_date, name_s
		) B
		ON A.AccNo = B.AccNo
		AND A.TDate = B.TDate

		UNION ALL

		SELECT AccType=''Futures'', accno AS AccNo, SUM(ISNULL(comm,0)) AS Comm, tdate AS TDate, 0 AS Interest, charge_currency AS Ccy, GETDATE() AS LastUpdateDate
		FROM ' + @G2BFDB + N'.dbo.view_it_G2B_client_trade_dt_with_comm
		WHERE YEAR(tdate) = YEAR(@fdbdate)
		AND MONTH(tdate) = MONTH(@fdbdate)
		AND comm IS NOT NULL
		GROUP BY accno, tdate, charge_currency

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Liq.CommissionMaster - INSERT.'';
'
SET @sql16 = N'
	--------------------------------------------------------------------------------------------------------------------
	-- 表 table_itas_ebs3 --> ' + @BalanceDB + N'.dbo.acbal （原有）??
	--SELECT Acbal.accno, Acbal.tdate, Acbal.led_bal, Acbal.ava_bal
	--FROM dbo.acbal
	SET @currentStep = @currentStep + 1
	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,

	N''Save data - Bal.acbal  ...'';

	DELETE FROM
		' + @BalanceDB + N'.dbo.acbal
	WHERE
		tdate = @sdbdate;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Bal.acbal - DELETE.'';


	INSERT INTO
		' + @BalanceDB + N'.dbo.acbal
		(
			accno, 
			tdate, 
			led_bal, 
			ava_bal
		)
	SELECT
		client_code,
		@sdbdate AS tDate,
		ledger_bal,
		avail_bal
	FROM
		#temp_view_er_client_master_g2bs
	WHERE
		ledger_bal <> 0
		OR avail_bal <> 0;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Bal.acbal - INSERT.'';


	-- 添加 ??表 #stockcon
	SELECT
		accno,
		@sdbdate AS sdbdate,
		stock_code,
		net_onhand_qty AS qty,
		100.0000 AS percentage,
		(underreg_qty + onhand) * closing_price AS market_value
	INTO #stockcon
	FROM
		' + @G2BSDB + N'.dbo.view_ER_client_portfolio;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - #stockcon - INSERT.'';

	-- 添加 ??表 #stockTotal
	SELECT
		''Total'' AS accno,
		@sdbdate AS sdbdate,
		stock_code,
		SUM(qty) AS qty,
		100.0000 AS percentage,
		SUM(market_value) AS market_value
	INTO #stockTotal
	FROM
		#stockcon
	GROUP BY
		stock_code;

	-- Fixed Percentage太大的??
	ALTER TABLE #stockcon ALTER COLUMN percentage numeric(12,6);

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - #stockTotal - INSERT.'';
	
	-- 更新 #stockcon 比率
	-- [fixed]ERROR: Arithmetic overflow error converting numeric to data type numeric.
	UPDATE
		#stockcon
	SET
		percentage = ROUND((#stockcon.qty / #stockTotal.qty * 100), 4)
	FROM
		#stockTotal
	WHERE
		#stockcon.stock_code = #stockTotal.stock_code
		AND #stockTotal.qty > 0;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - #stockcon - UPDATE1.'';

	UPDATE
		#stockcon
	SET
		percentage = 0
	WHERE
		qty = 0;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - #stockcon - UPDATE2.'';

	-- 添加???据
	INSERT INTO
		#stockcon(
			accno,
			sdbdate,
			stock_code,
			qty,
			percentage,
			market_value
		)
	SELECT
		accno,
		sdbdate,
		stock_code,
		qty,
		percentage,
		market_value
	FROM
		#stockTotal;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - #stockcon - INSERT2.'';

	-- 表 stockconcentration --> ' + @BalanceDB + N'.dbo.stockconcentration （原有） ??
	SET @currentStep = @currentStep + 1
	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - stockconcentration  ...'';
	
	--DECLARE @lcDate datetime
	--SET
	--	@lcDate = DATEADD(d, DATEDIFF(d, 0, @sdbdate), 0)-- 去掉??部分;

	-- ?除 stockconcentration ?天?据
	DELETE FROM
		' + @BalanceDB + N'.dbo.stockconcentration
	WHERE
		tdate = @sdbdate;

'
 SET @sql17 = N'	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - stockconcentration - DELETE.'';

	
	
	---- 添加 stockconcentration ?天?据 
	INSERT INTO
		' + @BalanceDB + N'.dbo.stockconcentration(
			accno,
			tdate,
			stock_code,
			qty,
			percentage,
			market_value
		)
	SELECT
		accno,
		sdbdate,
		stock_code,
		qty,
		percentage,
		market_value
	FROM
		#stockcon;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Bal.stockconcentration - INSERT.'';


	DELETE FROM
		' + @LiqDB + N'.dbo.stockconcentration
	WHERE
		tdate = @sdbdate;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - liq.stockconcentration - DELETE.'';

	INSERT INTO
		' + @LiqDB + N'.dbo.stockconcentration(
			accno,
			tdate,
			stock_code,
			qty,
			percentage,
			market_value
		)
	SELECT
		accno,
		sdbdate,
		stock_code,
		qty,
		percentage,
		market_value
	FROM
		#stockcon;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - liq.stockconcentration - INSERT.'';


	--sttxndate --> Liq.sttxndate（原有）
	UPDATE ' + @LiqDB + N'.dbo.sttxndate 
	SET 
		t0_date = t1_date, 
		t1_date = t2_date 
	WHERE
		[date] <> @tradeDate;

	UPDATE ' + @LiqDB + N'.dbo.sttxndate 
	SET 
		t2_date = @tradeDate 
	WHERE 
		[date] <> @tradeDate;

	UPDATE ' + @LiqDB + N'.dbo.sttxndate 
	SET 
		[date] = @tradeDate 
	WHERE 
		[date] <> @tradeDate;
	
	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Liq.sttxndate - UPDATE.'';

	DECLARE @LastDate datetime
	SELECT @LastDate = t1_date FROM ' + @LiqDB + N'.dbo.sttxndate 

	-- stsysparameter --> Liq.stsysparameter（原有）
	UPDATE ' + @LiqDB + N'.dbo.stsysparameter 
	SET
		txn_date = @tradeDate 
	WHERE
		[date] <> @tradeDate;

	UPDATE ' + @LiqDB + N'.dbo.stsysparameter 
	SET 
		last_date = @LastDate;

	UPDATE ' + @LiqDB + N'.dbo.stsysparameter 
	SET 
		[date] = @tradeDate;

	UPDATE ' + @LiqDB + N'.dbo.stsysparameter 
	SET 
		[month] = MONTH([date]);

	UPDATE ' + @LiqDB + N'.dbo.stsysparameter 
	SET 
		[year] = YEAR([date]);
	
	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Liq.stsysparameter - UPDATE.'';


	-- gcholdetails --> Liq.gcholdetails（原有）
	SELECT 
		hol_date
	INTO #hol1_tmp
	FROM ' + @LiqDB + N'.dbo.gcholdetails
	WHERE hol_code = ''LOCAL''
	  AND hol_date >= @tradeDate
	  AND holiday = 0
	ORDER BY hol_date;
		
	SELECT 
		ROW_NUMBER() OVER(ORDER BY hol_date) AS cnt 
	INTO #hol2_tmp
	FROM #hol1_tmp
	WHERE 
		hol_date = @tradeDate

	

	DECLARE @holRowNumber INT
	DECLARE @holDate datetime;
	
	SET @holRowNumber = 0
	SET @holDate = null;

	SELECT TOP 1 
		@holRowNumber = cnt + 1
	FROM #hol2_tmp;

	SELECT  TOP 1 
		@holDate = hol_date
	FROM (
		SELECT 
			ROW_NUMBER() OVER(ORDER BY hol_date) AS rownum, 
			hol_date
		FROM #hol1_tmp
	) AS tb
	WHERE 
		rownum = @holRowNumber
	ORDER BY hol_date;

	-- 更新t3_date
	IF @IsDebug = 0 AND @holDate IS NOT NULL
		UPDATE ' + @LiqDB + N'.dbo.sttxndate
		SET t3_date = @holDate;

		
	SET @holRowNumber = 0
	SET @holDate = DATEADD(DAY, -50, @tradeDate);

	SELECT 
		hol_date 
	INTO #hol4_tmp
	FROM ' + @LiqDB + N'.dbo.gcholdetails
	WHERE 
		    hol_code = ''LOCAL''
		AND hol_date <= @tradeDate
		AND hol_date > @holDate
		AND holiday = 0
	ORDER BY hol_date DESC;	
	
	SELECT 
		ROW_NUMBER() OVER(ORDER BY hol_date) AS cnt 
	INTO #hol5_tmp
	FROM #hol4_tmp
	WHERE hol_date = @tradeDate;

	
	SET @holDate = null;
	
	SELECT TOP 1 
'
 SET @sql18 = N'		@holRowNumber = cnt + 21
	FROM #hol5_tmp;

	SELECT TOP 1
		@holDate = hol_date
	FROM (
		SELECT 
			ROW_NUMBER() OVER(ORDER BY hol_date) AS rownum, 
			hol_date
		FROM #hol4_tmp
	) AS tb
	WHERE 
		rownum = @holRowNumber
	ORDER BY hol_date DESC;

	
	-- 更新roll_date
	IF @IsDebug = 0 AND @holDate IS NOT NULL
		UPDATE ' + @LiqDB + N'.dbo.sttxndate
		SET roll_date = @holDate;





	-- 表 stcltmaster --> Liq.stcltmaster（原有）
	SET @currentStep = @currentStep + 1
	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Liq.stcltmaster ...'';

	-- 更新?0
	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		cr_limit = 0,
		withdrawal = 0,
		interest = 0,
		dr_bal = 0,
		cr_bal = 0,
		mc_dr_bal = 0,
		mc_cr_bal = 0;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Liq.stcltmaster - UPDATE.'';


	-- 插入?据
	INSERT INTO
		' + @LiqDB + N'.[dbo].[stcltmaster](
			run_code,
			clt_code,
			clt_name,
			clt_type,
			cr_limit,
			interest
		)
	SELECT
		ae_code,
		clt_code,
		clt_name,
		clt_type,
		cr_limit,
		interest
	FROM
		' + @LiqDB + N'.dbo.testbal
	WHERE
		clt_code NOT IN (
			SELECT
				clt_code collate Chinese_Taiwan_Bopomofo_CI_AS
			FROM
				' + @LiqDB + N'.[dbo].[stcltmaster]
		)
	ORDER BY
		ae_code;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Liq.stcltmaster - INSERT.'';

debugBeginStep:
	-- stcltbalmargcallupdt.prg
	-- 更新基本?据
	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		run_code = tb.ae_code,
		clt_code = tb.clt_code,
		clt_name = tb.clt_name,
		clt_type = tb.clt_type,
		cr_limit = tb.cr_limit,
		interest = tb.interest
	FROM
		' + @LiqDB + N'.dbo.testbal AS tb
	WHERE
		tb.clt_code = ' + @LiqDB + N'.[dbo].[stcltmaster].clt_code collate Chinese_Taiwan_Bopomofo_CI_AS;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Liq.stcltmaster - UPDATE2.'';
	-- 更新stcltmaster.bal
	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		cr_bal = tb.bal
	FROM
		' + @LiqDB + N'.dbo.testbal AS tb
	WHERE
		tb.clt_code = ' + @LiqDB + N'.[dbo].[stcltmaster].clt_code collate Chinese_Taiwan_Bopomofo_CI_AS
		AND tb.bal > 0;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Liq.stcltmaster - UPDATE3.'';

	-- 更新dr_bal=0
	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		dr_bal = 0
	WHERE
		clt_code IN (
			SELECT
				clt_code collate Chinese_Taiwan_Bopomofo_CI_AS
			FROM
				' + @LiqDB + N'.dbo.testbal
			WHERE
				bal > 0
		);

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Liq.stcltmaster - UPDATE4.'';

	-- 更新cr_bal=0
	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		cr_bal = 0
	WHERE
		cr_bal IS NULL;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Liq.stcltmaster - UPDATE5.'';

	-- 更新dr_bal（??值）
	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
'
 SET @sql19 = N'		dr_bal = tb.bal * -1
	FROM
		' + @LiqDB + N'.dbo.testbal AS tb
	WHERE
		tb.clt_code = ' + @LiqDB + N'.[dbo].[stcltmaster].clt_code collate Chinese_Taiwan_Bopomofo_CI_AS
		AND tb.bal < 0;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Liq.stcltmaster - UPDATE6.'';

	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		cr_bal = 0
	WHERE
		clt_code IN (
			SELECT
				clt_code collate Chinese_Taiwan_Bopomofo_CI_AS
			FROM
				' + @LiqDB + N'.dbo.testbal
			WHERE
				bal < 0
		);

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Liq.stcltmaster - UPDATE7.'';

	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		dr_bal = 0
	WHERE
		dr_bal IS NULL;

	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		mc_dr_bal = dr_bal;

	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		mc_dr_bal = dr_bal - interest
	WHERE
		interest < 0
		AND (
			dr_bal > 0
			OR (
				dr_bal = 0
				AND cr_bal = 0
				AND interest < 0
			)
		);

	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		mc_dr_bal = 0
	WHERE
		mc_dr_bal IS NULL;

	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		mc_cr_bal = cr_bal;

	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		mc_cr_bal = cr_bal + interest
	WHERE
		interest < 0
		AND (
			cr_bal > 0
			OR (
				cr_bal = 0
				AND dr_bal = 0
				AND interest > 0
			)
		);

	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		mc_cr_bal = 0
	WHERE
		mc_cr_bal IS NULL;

	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		mc_dr_bal = mc_cr_bal * (-1)
	WHERE
		mc_cr_bal < 0;

	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		mc_cr_bal = 0
	WHERE
		mc_cr_bal < 0;

	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		short = 0;

	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		short = 1
	WHERE
		clt_code IN (
			SELECT
				clt_code collate Chinese_Taiwan_Bopomofo_CI_AS
			FROM
				test_port
			WHERE
				(qty + bt_qty - st_qty) < 0
		);

	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		net_trade = 0,
		t2_unrealized = 0,
		t1_unrealized = 0,
		mkt_value = 0,
		margin_value = 0,
		mc_act_ratio = 0,
		margin_ratio = 0,
		mc_total = 0;
		
	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		net_trade = - t2_trade,
		t2_unrealized = tt.t2_trade,
		t1_unrealized = tt.t1_trade,
		mkt_value = tt.mkt_value,
		margin_value = tt.margin_value
	FROM
		test_trade AS tt
	WHERE
		tt.clt_code = ' + @LiqDB + N'.[dbo].[stcltmaster].clt_code collate Chinese_Taiwan_Bopomofo_CI_AS;

	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		mc_act_ratio = mc_dr_bal / mkt_value
	WHERE
		mkt_value > 0;

	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		mc_act_ratio = 999.99
	WHERE
		mkt_value = 0
		AND mc_dr_bal > 0;

	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		mc_act_ratio = 999.99
	WHERE
		mkt_value < 0;

	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		margin_ratio = mc_dr_bal / margin_value
	WHERE
		margin_value > 0;
		
	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
'
 SET @sql20 = N'		margin_ratio = 999.99
	WHERE
		margin_value = 0
		AND mc_dr_bal > 0;

	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		margin_ratio = 999.99
	WHERE
		margin_value < 0;

	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		mc_total = mc_dr_bal - cr_limit
	WHERE
		(margin_value - dr_bal) > (cr_limit - dr_bal);

	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		mc_total = mc_dr_bal - margin_value
	WHERE
		(margin_value - dr_bal) < (cr_limit - dr_bal);
		
	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		mc_total = mc_dr_bal
	WHERE
		margin_value = cr_limit;

	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		mc_total = mc_dr_bal - margin_value - mc_cr_bal
	WHERE
		mkt_value < 0;
		
	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		mc_total = (-1) * mc_total
	WHERE
		mc_total < 0;

	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		mc_t2 = 0;

	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		mc_t2 = t2_unrealized * (-1)
	WHERE
		t2_unrealized < 0
		AND mc_dr_bal > 0;
		
	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		withdrawal = mc_due,
		mc_due = 0;

	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		mc_due = mc_dr_bal - mc_t2 - margin_value
	WHERE
		mc_dr_bal > 0;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Liq.stcltmaster - UPDATE8.'';


	DECLARE @sttxndatedate datetime
	SELECT TOP 1 @sttxndatedate = date
	FROM ' + @LiqDB + N'.dbo.[sttxndate];

	-- 构建??表
	SELECT
		a.clt_code,
		SUBSTRING(a.inv_no, 1, 1) AS type,
		a.stk_code,
		SUM(a.txn_qty) AS qty,
		b.margin_ratio,
		b.mkt_price,
		(SUM(a.txn_qty) * mkt_price * margin_ratio) AS margin_value
	INTO #stcltbuy_tmp
	FROM
		st_stk_txn_lst a,
		st_clt_portfolio b
	WHERE
		a.clt_code = b.clt_code
		AND a.stk_code = b.stk_code
		AND a.txn_date = @sttxndatedate
		AND SUBSTRING(a.inv_no, 1, 1) = ''B''
	GROUP BY
		a.clt_code,
		a.stk_code,
		SUBSTRING(a.inv_no, 1, 1),
		b.margin_ratio,
		b.mkt_price
	ORDER BY
		a.clt_code;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - #stcltbuy_tmp - INSERT.'';

	SELECT
		a.clt_code,
		SUBSTRING(a.inv_no, 1, 1) AS type,
		a.stk_code,
		SUM(a.txn_qty) AS qty,
		b.margin_ratio,
		b.mkt_price,
		(SUM(a.txn_qty) * mkt_price * margin_ratio) AS margin_value
	INTO #stcltsell_tmp
	FROM
		st_stk_txn_lst a,
		st_clt_portfolio b
	WHERE
		a.clt_code = b.clt_code
		AND a.stk_code = b.stk_code
		AND a.txn_date = @sttxndatedate
		AND SUBSTRING(a.inv_no, 1, 1) = ''S''
	GROUP BY
		a.clt_code,
		a.stk_code,
		SUBSTRING(a.inv_no, 1, 1),
		b.margin_ratio,
		b.mkt_price
	ORDER BY
		a.clt_code;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - #stcltsell_tmp - INSERT.'';
		;
	SELECT
		a.clt_code,
		a.stk_code,
		(a.margin_value - b.margin_value) AS margin_value
	INTO #stcltnet_tmp
	FROM
		#stcltbuy_tmp a,
		#stcltsell_tmp b
	WHERE
		a.clt_code = b.clt_code collate Chinese_Taiwan_Bopomofo_CI_AS
		AND a.stk_code = b.stk_code
'
 SET @sql21 = N'	UNION ALL
	SELECT
		clt_code,
		stk_code,
		margin_value
	FROM
		#stcltbuy_tmp scb
	WHERE
		clt_code NOT IN (
			SELECT
				clt_code collate Chinese_Taiwan_Bopomofo_CI_AS
			FROM
				#stcltsell_tmp scs
			WHERE
				scs.clt_code = scb.clt_code collate Chinese_Taiwan_Bopomofo_CI_AS
				AND scs.stk_code = scb.stk_code
		);

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - #stcltnet_tmp - INSERT.'';
		;
	SELECT
		clt_code,
		stk_code,
		margin_value
	INTO #stcltnetmv_tmp
	FROM
		#stcltnet_tmp
	WHERE
		margin_value > 0;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - #stcltnetmv_tmp - INSERT.'';

	SELECT
		clt_code,
		SUM(margin_value) AS margin_value
	INTO #stcltmv_tmp
	FROM
		#stcltnetmv_tmp
	GROUP BY
		clt_code;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - #stcltmv_tmp - INSERT.'';

	SELECT
		scm.margin_value,
		scm.clt_code
	INTO #tmpval
	FROM
		#stcltmv_tmp AS scm,
		' + @LiqDB + N'.[dbo].[stcltmaster] AS scmt
	WHERE
		scm.clt_code = scmt.clt_code collate Chinese_Taiwan_Bopomofo_CI_AS;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - #tmpval - INSERT.'';

	--EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
	--	N''Save data - Liq.stcltmaster - UPDATE ...'';

	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		' + @LiqDB + N'.[dbo].[stcltmaster].mc_due = ' + @LiqDB + N'.[dbo].[stcltmaster].mc_due + tv.margin_value
	FROM
		#tmpval AS tv
	WHERE
		' + @LiqDB + N'.[dbo].[stcltmaster].clt_code = tv.clt_code collate Chinese_Taiwan_Bopomofo_CI_AS;

	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		mc_due = 0
	WHERE
		mc_due < 0;

	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		mc_t2 = 0
	WHERE
		mc_t2 < 0;

	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		mc_overdraft = 0;

	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		mc_overdraft = mc_total - mc_due - mc_t2
	WHERE
		mc_total > 0;

	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		mc_overdraft = 0
	WHERE
		mc_overdraft < 0;

	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		mc_total = mc_cr_bal * (-1)
	WHERE
		clt_type = ''C''
		AND mc_cr_bal > 0;

	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		mc_total = mc_dr_bal
	WHERE
		clt_type = ''C''
		AND mc_dr_bal > 0;

	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		mc_t2 = t2_unrealized * (-1)
	WHERE
		clt_type = ''C'';

	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		mc_due = mc_total - mc_t2
	WHERE
		clt_type = ''C'';

	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		avail_bal = t2_unrealized;

	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		avail_bal = 0
	WHERE
		avail_bal < 0;

	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		avail_bal = mc_cr_bal - mc_dr_bal - avail_bal;

	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		avail_bal = 0
	WHERE
		avail_bal < 0;

'
 SET @sql22 = N'	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Liq.stcltmaster - UPDATE9.'';




	-- DO stcltmastliqlistupdt.prg		
	--Use stcltliqlist excl	
	--delete all	
	--pack	
	--close tables all	
	-- 表 stcltliqlist --> Liq.stcltliqlist（原有）
	SET @currentStep = @currentStep + 1
	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Liq.stcltliqlist  ...'';

	-- 清除 stcltliqlist ?据
	TRUNCATE TABLE ' + @LiqDB + N'.dbo.stcltliqlist;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Liq.stcltliqlist - DELETE All.'';

	SELECT
		a.clt_code,
		SUBSTRING(a.inv_no, 1, 1) AS type,
		a.stk_code,
		SUM(a.txn_qty) AS qty,
		b.margin_ratio,
		b.mkt_price,
		b.mkt_value
	INTO #stcltbuy_tmp2
	FROM
		st_stk_txn_lst a,
		st_clt_portfolio b
	WHERE
		a.clt_code = b.clt_code collate Chinese_Taiwan_Bopomofo_CI_AS
		AND a.stk_code = b.stk_code
		AND a.txn_date = @sttxndatedate
		AND SUBSTRING(a.inv_no, 1, 1) = ''B''
	GROUP BY
		a.clt_code,
		a.stk_code,
		SUBSTRING(a.inv_no, 1, 1),
		b.margin_ratio,
		b.mkt_price,
		b.mkt_value;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - #stcltbuy_tmp2 - INSERT.'';

	SELECT
		a.clt_code,
		SUBSTRING(a.inv_no, 1, 1) AS type,
		a.stk_code,
		SUM(a.txn_qty) AS qty,
		b.margin_ratio,
		b.mkt_price
	INTO #stcltsell_tmp2
	FROM
		st_stk_txn_lst a,
		st_clt_portfolio b
	WHERE
		a.clt_code = b.clt_code collate Chinese_Taiwan_Bopomofo_CI_AS
		AND a.stk_code = b.stk_code
		AND a.txn_date = @sttxndatedate
		AND SUBSTRING(a.inv_no, 1, 1) = ''S''
	GROUP BY
		a.clt_code,
		a.stk_code,
		SUBSTRING(a.inv_no, 1, 1),
		b.margin_ratio,
		b.mkt_price;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - #stcltsell_tmp2 - INSERT.'';

	SELECT
		a.clt_code,
		a.stk_code,
		a.margin_ratio,
		a.mkt_price,
		a.qty AS b_qty,
		b.qty AS s_qty,
		a.qty AS n_qty,
		a.mkt_value AS n_mkt_value,
		a.mkt_value AS n_margin_value
	INTO #stcltnetbuy_tmp
	FROM
		#stcltbuy_tmp2 a
		LEFT JOIN #stcltsell_tmp2 b on a.clt_code = b.clt_code collate Chinese_Taiwan_Bopomofo_CI_AS
		AND a.stk_code = b.stk_code
	WHERE
		a.clt_code IN (
			SELECT
				clt_code collate Chinese_Taiwan_Bopomofo_CI_AS
			FROM
				' + @LiqDB + N'.[dbo].[stcltmaster] AS scm
			WHERE
				scm.clt_type = ''M''
				OR scm.clt_type = ''F''
		);

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - #stcltnetbuy_tmp - INSERT.'';

	UPDATE
		#stcltnetbuy_tmp
	SET
		n_qty = 0,
		n_mkt_value = 0,
		n_margin_value = 0;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - #stcltnetbuy_tmp - UPDATE.'';

	SELECT
		clt_code,
		stk_code,
		margin_ratio,
		mkt_price,
		b_qty,
		s_qty,
		n_qty,
		n_mkt_value,
		n_margin_value
	INTO #a
	FROM
		#stcltnetbuy_tmp
	WHERE
		s_qty IS NULL;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - #a - INSERT.'';

	UPDATE
		#stcltnetbuy_tmp
	SET
		s_qty = 0
	WHERE
		s_qty IS NULL;

	UPDATE
		#stcltnetbuy_tmp
	SET
		n_qty = b_qty - s_qty;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - #stcltnetbuy_tmp - UPDATE.'';
'
 SET @sql23 = N'
	SELECT
		clt_code,
		stk_code,
		margin_ratio,
		mkt_price,
		b_qty,
		s_qty,
		n_qty,
		n_mkt_value,
		n_margin_value
	INTO #b
	FROM
		#stcltnetbuy_tmp
	WHERE
		n_qty < 0;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - #b - INSERT.'';

	UPDATE
		#stcltnetbuy_tmp
	SET
		n_qty = 0
	WHERE
		n_qty < 0;

	UPDATE
		#stcltnetbuy_tmp
	SET
		n_mkt_value = n_qty * mkt_price;

	UPDATE
		#stcltnetbuy_tmp
	SET
		n_margin_value = n_qty * mkt_price * margin_ratio;

	SELECT
		clt_code,
		SUM(n_mkt_value) AS mkt_value,
		SUM(n_margin_value) AS margin_value
	INTO #stcltnet_tmp2
	FROM
		#stcltnetbuy_tmp
	WHERE
		n_qty > 0
	GROUP BY
		clt_code;

	DELETE FROM ' + @LiqDB + N'.dbo.client_mkt_mrg;
	INSERT INTO ' + @LiqDB + N'.dbo.client_mkt_mrg(client_code, market_value, margin_value) 
	SELECT clt_code, mkt_value, margin_value
	FROM #stcltnet_tmp2;

	DELETE FROM ' + @LiqDB + N'.dbo.client_liq_master;
	INSERT INTO ' + @LiqDB + N'.dbo.client_liq_master(CLT_CODE,CLT_TYPE,CLT_NAME,RUN_CODE,CR_LIMIT,CR_BAL,DR_BAL,DEPOSIT,
	WITHDRAWAL,AVAIL_BAL,MKT_VALUE,MARGIN_VALUE,MARGIN_RATIO,NET_TRADE,T1_UNREALIZED,T2_UNREALIZED,
	INTEREST,MC_CR_BAL,MC_DR_BAL,MC_ACT_RATIO,MC_DUE,MC_T2,MC_OVERDRAFT,MC_TOTAL,OS_DAY,SHORT) 
	SELECT CLT_CODE,CLT_TYPE,CLT_NAME,RUN_CODE,CR_LIMIT,CR_BAL,DR_BAL,DEPOSIT,WITHDRAWAL,AVAIL_BAL,
	MKT_VALUE,MARGIN_VALUE,MARGIN_RATIO,NET_TRADE,T1_UNREALIZED,T2_UNREALIZED,INTEREST,MC_CR_BAL,
	MC_DR_BAL,MC_ACT_RATIO,MC_DUE,MC_T2,MC_OVERDRAFT,MC_TOTAL,OS_DAY,SHORT 
	from ' + @LiqDB + N'.dbo.STCLTMASTER;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - #stcltnet_tmp2 - INSERT.'';

	SELECT
		a.clt_code,
		a.run_code,
		a.mc_dr_bal AS dr,
		a.mc_act_ratio AS ar,
		a.mc_total AS mc,
		a.mc_due AS due,
		a.mc_t2 AS undue,
		a.margin_ratio AS mr,
		a.cr_limit AS cl,
		a.clt_type,
		a.margin_value AS due_mv,
		b.margin_value AS undue_margin_value,
		b.mkt_value AS undue_mv,
		a.short
	INTO #margin_tmp
	FROM
		' + @LiqDB + N'.[dbo].[stcltmaster] a
		LEFT JOIN #stcltnet_tmp2 b on a.clt_code = b.clt_code collate Chinese_Taiwan_Bopomofo_CI_AS
	WHERE
		(
			a.clt_type = ''M''
			OR a.clt_type = ''F''
		);

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - #margin_tmp - INSERT.'';

	SELECT
		clt_code,
		run_code,
		dr,
		ar,
		mc,
		due,
		undue,
		mr,
		cl,
		clt_type,
		due_mv,
		undue_margin_value,
		undue_mv,
		short
	INTO #c
	FROM
		#margin_tmp
	WHERE
		undue_margin_value IS NULL;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - #c - INSERT.'';

	UPDATE
		#margin_tmp
	SET
		undue_margin_value = 0
	WHERE
		undue_margin_value IS NULL;

	SELECT
		clt_code,
		run_code,
		dr,
		ar,
		mc,
		due,
		undue,
		mr,
		cl,
		clt_type,
		due_mv,
		undue_margin_value,
		undue_mv,
		short
	INTO #d
	FROM
		#margin_tmp
	WHERE
		undue_mv IS NULL;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - #d - INSERT.'';

	UPDATE
		#margin_tmp
	SET
		undue_mv = 0
	WHERE
		undue_mv IS NULL;

	UPDATE
		#margin_tmp
	SET
		due_mv = due_mv - undue_margin_value;
		
	SELECT
		clt_code,
		''*'' AS is_ar,
		''*'' AS is_mr
	INTO #clt_tmp
	FROM
		#margin_tmp
	WHERE
		(
			(
				(
					(dr < 300000)
					AND (
						(
							ar >= 0.6
							AND mr >= 1
						)
						OR dr >= (due_mv * 1.6 + undue_mv * 0.7)
					)
				)
				OR (
					(
						300000 <= dr
						AND dr < 1000000
					)
					AND (
						(
							ar >= 0.5
							AND mr >= 1
						)
'
 SET @sql24 = N'						OR dr >= (due_mv * 1.6 + undue_mv * 0.7)
					)
				)
				OR (
					(
						1000000 <= dr
						AND dr < 3000000
					)
					AND (
						(
							ar >= 0.4
							AND mr >= 1
						)
						OR dr >= (due_mv * 1.3 + undue_mv * 0.7)
					)
				)
				OR (
					(3000000 <= dr)
					AND dr >= (due_mv * 1.0 + undue_mv * 0.7)
				)
			)
			OR (
				cl < 100
				AND mc > 0
			)
			OR ((dr - cl) > 0)
		)
		AND (
			NOT (
				dr <= 1000000
				AND due = 0
				AND undue >= 0
				AND ar < 0.7
			)
		)
		OR (short = 1);

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - #clt_tmp - INSERT.'';

		
	SELECT
		a.clt_code
	INTO #good_ar_tmp
	FROM
		#margin_tmp a,
		#clt_tmp b
	WHERE
		a.clt_code = b.clt_code collate Chinese_Taiwan_Bopomofo_CI_AS
		AND (
			(
				(
					(dr < 300000)
					AND (
						(
							ar < 0.6
							OR mr < 1
						)
					)
				)
				OR (
					(
						300000 <= dr
						AND dr < 1000000
					)
					AND (
						(
							ar < 0.5
							OR mr < 1
						)
					)
				)
				OR (
					(
						1000000 <= dr
						AND dr < 3000000
					)
					AND (
						(
							ar < 0.4
							OR mr < 1
						)
					)
				)
			)
		);

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - #good_ar_tmp - INSERT.'';

		
	SELECT
		a.clt_code
	INTO #good_mr_tmp
	FROM
		#margin_tmp a,
		#clt_tmp b
	WHERE
		a.clt_code = b.clt_code collate Chinese_Taiwan_Bopomofo_CI_AS
		AND (
			(
				(
					(dr < 300000)
					AND (dr <(due_mv * 1.6 + undue_mv * 0.7))
				)
				OR (
					(
						300000 <= dr
						AND dr < 1000000
					)
					AND (dr <(due_mv * 1.6 + undue_mv * 0.7))
				)
				OR (
					(
						1000000 <= dr
						AND dr < 3000000
					)
					AND (dr <(due_mv * 1.3 + undue_mv * 0.7))
				)
				OR (
					(3000000 <= dr)
					AND dr <(due_mv * 1.0 + undue_mv * 0.7)
				)
			)
		);

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - #good_mr_tmp - INSERT.'';
		
	UPDATE
		#clt_tmp
	SET
		is_ar = '' ''
	WHERE
		clt_code NOT IN (
			SELECT
				clt_code collate Chinese_Taiwan_Bopomofo_CI_AS
			FROM
				#good_ar_tmp
		);

	UPDATE
		#clt_tmp
	SET
		is_mr = '' ''
	WHERE
		clt_code NOT IN (
			SELECT
				clt_code collate Chinese_Taiwan_Bopomofo_CI_AS
			FROM
				#good_mr_tmp
		);

	SELECT
		clt_code,
		dr_bal AS amt
	INTO #cash_tmp
	FROM
		' + @LiqDB + N'.[dbo].[stcltmaster]
	WHERE
		clt_type = ''C'';

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - #cash_tmp - INSERT.'';
		
	UPDATE
		#cash_tmp
	SET
		amt = 0;

	SELECT
		a.clt_code,
		SUM(a.amt) AS amt
	INTO #cashin_tmp
	FROM
		ibs_cac_cup a,
		' + @LiqDB + N'.[dbo].[stcltmaster] b
	WHERE
		a.clt_code = b.clt_code collate Chinese_Taiwan_Bopomofo_CI_AS
		AND b.clt_type = ''C''
		AND a.amt <> 0
	GROUP BY
		a.clt_code;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - #cashin_tmp - INSERT.'';

	UPDATE
		#cash_tmp
	SET
'
 SET @sql25 = N'		amt = #cash_tmp.amt + ci.amt
	FROM
		#cashin_tmp ci
	WHERE
		#cash_tmp.clt_code = ci.clt_code collate Chinese_Taiwan_Bopomofo_CI_AS;

	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		deposit = 0;

	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		deposit = ct.amt
	FROM
		#cash_tmp ct
	WHERE
		amt <> 0
		AND ' + @LiqDB + N'.[dbo].[stcltmaster].clt_code = ct.clt_code collate Chinese_Taiwan_Bopomofo_CI_AS;

	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		deposit = 0
	WHERE
		deposit IS NULL;


	SELECT
		clt_code
	INTO #os_tmp
	FROM
		' + @LiqDB + N'.[dbo].[stcltmaster]
	WHERE
		clt_type = ''C''
		AND (
			(
				withdrawal > 0
				AND withdrawal > deposit
			)
			OR (mc_act_ratio > 0.7)
			OR (short = 1)
		);

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - #os_tmp - INSERT.'';
		
	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		os_day = 0
	WHERE
		clt_code NOT IN (
			SELECT
				clt_code collate Chinese_Taiwan_Bopomofo_CI_AS
			FROM
				#os_tmp
		);

	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		os_day = ISNULL(os_day, 0) + 1
	WHERE
		clt_code IN (
			SELECT
				clt_code collate Chinese_Taiwan_Bopomofo_CI_AS
			FROM
				#os_tmp
		);


	INSERT INTO #clt_tmp(
		clt_code,
		is_ar,
		is_mr
		)
	select 
		clt_code,
		'' '',
		'' ''
	FROM 
		#os_tmp;

	INSERT INTO
		' + @LiqDB + N'.dbo.stcltliqlist
		(
			clt_code, 
			ar_good, 
			mr_good
		)
	SELECT
		clt_code,
		'' '',
		'' ''
	FROM
		#clt_tmp
	ORDER BY
		clt_code;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Liq.stcltliqlist - INSERT.'';



	--SELECT #clt_tmp	
	--close tables all	
	--delete file sys(5) + SYS(2003)+''\clt_tmp.dbf''	
	--delete file sys(5) + SYS(2003)+''\cash_tmp.dbf''	;

	--DO stcltmastliqupdt.prg		
	SELECT
		clt_code,
		@sttxndatedate AS start_date,
		0 AS os_day
	INTO #new_tmp
	FROM
		' + @LiqDB + N'.dbo.stcltliqlist
	WHERE
		clt_code NOT IN (
			SELECT
				clt_code collate Chinese_Taiwan_Bopomofo_CI_AS
			FROM
				' + @LiqDB + N'.dbo.stcltliq
		);

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - #new_tmp - INSERT.'';

	SELECT
		clt_code
	INTO #del_tmp
	FROM
		' + @LiqDB + N'.dbo.stcltliq
	WHERE
		clt_code NOT IN (
			SELECT
				clt_code collate Chinese_Taiwan_Bopomofo_CI_AS
			FROM
				' + @LiqDB + N'.dbo.stcltliqlist
		);

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - #del_tmp - INSERT.'';
		
	--stcltliq			-->	Liq.stcltliq（原有）
	INSERT INTO
		' + @LiqDB + N'.dbo.stcltliq(
			clt_code,
			start_date,
			os_day,
			liq_day,
			ar_good,
			mr_good
		)
	SELECT
		nt.clt_code,
		nt.start_date,
		nt.os_day,
		nt.os_day,
		'' '',
		'' ''
	FROM
		#new_tmp nt
	ORDER BY
		clt_code;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Liq.stcltliq - INSERT.'';


	-- ?除 stcltliq ?据
	DELETE FROM
		' + @LiqDB + N'.dbo.stcltliq
	WHERE
		clt_code IN (
'
 SET @sql26 = N'			SELECT
				clt_code collate Chinese_Taiwan_Bopomofo_CI_AS
			FROM
				#del_tmp
		);

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Liq.stcltliq - DELETE.'';


	UPDATE
		' + @LiqDB + N'.dbo.stcltliq
	SET
		os_day = ISNULL(os_day, 0) + 1;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Liq.stcltliq - UPDATE.'';


	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		os_day = 0;

	-- 更新stcltmaster.os_day = stcltliq.os_day
	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		os_day = scl.os_day
	FROM
		' + @LiqDB + N'.dbo.stcltliq scl
	WHERE
		' + @LiqDB + N'.[dbo].[stcltmaster].clt_code = scl.clt_code collate Chinese_Taiwan_Bopomofo_CI_AS;

	
	-- 更新stcltliq.ar_good = stcltliqlist.ar_good
	UPDATE
		' + @LiqDB + N'.dbo.stcltliq
	SET
		ar_good = scll.ar_good,
		mr_good = scll.mr_good
	FROM
		' + @LiqDB + N'.dbo.stcltliqlist scll
	WHERE
		' + @LiqDB + N'.dbo.stcltliq.clt_code = scll.clt_code collate Chinese_Taiwan_Bopomofo_CI_AS;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Liq.stcltliq - UPDATE2.'';


	--UPDATE
	--	' + @LiqDB + N'.dbo.stcltliq
	--SET
	--	ar_good = '' ''
	--WHERE
	--	ar_good IS NULL;

	--UPDATE
	--	' + @LiqDB + N'.dbo.stcltliq
	--SET
	--	mr_good = '' ''
	--WHERE
	--	mr_good IS NULL;

	SELECT
		clt_code
	INTO #clt_must_liq_tmp
	FROM
		' + @LiqDB + N'.dbo.stcltliq
	WHERE
		clt_code IN (
			SELECT
				a.clt_code collate Chinese_Taiwan_Bopomofo_CI_AS
			FROM
				' + @LiqDB + N'.[dbo].[stcltmaster] a,
				' + @LiqDB + N'.dbo.stcltliqlist b
			WHERE
				a.clt_code = b.clt_code collate Chinese_Taiwan_Bopomofo_CI_AS
				AND (
					NOT (
						(
							(a.mc_dr_bal < 500)
							OR (
								a.mc_act_ratio < 0.01
								AND a.mc_dr_bal < 10000
							)
							OR (
								a.mc_act_ratio < 0.05
								AND a.mc_dr_bal < 2000
							)
						)
						AND (a.short = 0)
					)
					OR (
						a.clt_type = ''C''
						AND a.withdrawal > 0
						AND a.withdrawal > a.deposit
					)
				)
		);

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - #clt_must_liq_tmp - INSERT.'';
		
	SELECT
		clt_code
	INTO #clt_need_liq_tmp
	FROM
		' + @LiqDB + N'.dbo.stcltliq
	WHERE
		clt_code IN (
			SELECT
				a.clt_code collate Chinese_Taiwan_Bopomofo_CI_AS
			FROM
				' + @LiqDB + N'.[dbo].[stcltmaster] a,
				' + @LiqDB + N'.dbo.stcltliqlist b
			WHERE
				a.clt_code = b.clt_code collate Chinese_Taiwan_Bopomofo_CI_AS
				AND (
					(
						(
							(a.mc_dr_bal < 500)
							OR (
								a.mc_act_ratio < 0.01
								AND a.mc_dr_bal < 10000
							)
							OR (
								a.mc_act_ratio < 0.05
								AND a.mc_dr_bal < 2000
							)
						)
						AND (a.short = 0)
					)
				)
		)
		AND os_day >= 20;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - #clt_need_liq_tmp - INSERT.'';

	SELECT
		clt_code
	INTO #clt_no_liq_tmp
	FROM
'
 SET @sql27 = N'		' + @LiqDB + N'.dbo.stcltliq
	WHERE
		clt_code NOT IN (
			SELECT
				clt_code collate Chinese_Taiwan_Bopomofo_CI_AS
			FROM
				#clt_must_liq_tmp
		)
		AND clt_code NOT IN (
			SELECT
				clt_code
			FROM
				#clt_need_liq_tmp
		);

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - #clt_no_liq_tmp - INSERT.'';
		
	UPDATE
		' + @LiqDB + N'.dbo.stcltliq
	SET
		liq_day = ISNULL(liq_day, 0) + 1
	WHERE
		clt_code IN (
			SELECT
				clt_code collate Chinese_Taiwan_Bopomofo_CI_AS
			FROM
				#clt_must_liq_tmp
		)
		OR clt_code IN (
			SELECT
				clt_code
			FROM
				#clt_need_liq_tmp
		);

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Liq.stcltliq - UPDATE3.''
	UPDATE
		' + @LiqDB + N'.dbo.stcltliq
	SET
		liq_day = 0
	WHERE
		clt_code IN (
			SELECT
				clt_code collate Chinese_Taiwan_Bopomofo_CI_AS
			FROM
				#clt_no_liq_tmp
		);

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Liq.stcltliq - UPDATE4.'';

		
	--DO stcltmastliqfbupdt.prg		
	SELECT
		a.clt_code
	INTO #clt_tmp2
	FROM
		' + @LiqDB + N'.dbo.stcltliq a,
		' + @LiqDB + N'.[dbo].[stcltmaster] b
	WHERE
		a.clt_code = b.clt_code collate Chinese_Taiwan_Bopomofo_CI_AS
		AND (NOT b.mkt_value = 0)
		AND a.liq_day > 0;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - #clt_tmp2 - INSERT.'';

	SELECT
		clt_code,
		-1 AS tolerate_day,
		@sttxndatedate AS start_date,
		0 AS os_day,
		0 AS liq_day
	INTO #new_tmp2
	FROM
		#clt_tmp2
	WHERE
		clt_code NOT IN (
			SELECT
				clt_code collate Chinese_Taiwan_Bopomofo_CI_AS
			FROM
				' + @LiqDB + N'.dbo.stcltliqfb
		)
	ORDER BY
		clt_code;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - #new_tmp2 - INSERT.'';

	-- 表 stcltliqfb -- Liq.stcltliqfb
	SET @currentStep = @currentStep + 1
	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - stcltliqfb  ...'';

	INSERT INTO
		' + @LiqDB + N'.dbo.stcltliqfb(
			clt_code,
			tolerate_day,
			start_date,
			os_day,
			liq_day
		)
	SELECT
		nt.clt_code,
		nt.tolerate_day,
		nt.start_date,
		nt.os_day,
		nt.liq_day
	FROM
		#new_tmp2 nt;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Liq.stcltliqfb - INSERT.'';


	DELETE FROM
		' + @LiqDB + N'.dbo.stcltliqfb
	WHERE
		clt_code NOT IN (
			SELECT
				clt_code collate Chinese_Taiwan_Bopomofo_CI_AS
			FROM
				#clt_tmp2
		);

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Liq.stcltliqfb - DELETE.'';


	SELECT
		clt_code,
		mc_dr_bal AS dr_bal,
		mc_act_ratio AS ar
	INTO #clt_tmp3
	FROM
		' + @LiqDB + N'.[dbo].[stcltmaster]
	WHERE
		clt_code IN (
			SELECT
				clt_code collate Chinese_Taiwan_Bopomofo_CI_AS
			FROM
				' + @LiqDB + N'.dbo.stcltliqfb
		);

'
 SET @sql28 = N'	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - #clt_tmp3 - INSERT.'';

	SELECT
		clt_code
	INTO #day1_tmp
	FROM
		#clt_tmp3
	WHERE
		(
			(dr_bal < 300000)
			AND (
				ar < 0.6
				OR (
					0.6 <= ar
					AND ar <= 0.7
				)
			)
		)
		OR (
			(
				300000 <= dr_bal
				AND dr_bal < 1000000
			)
			AND (
				ar < 0.5
				OR (
					0.5 <= ar
					AND ar <= 0.6
				)
			)
		)
		OR (
			(
				1000000 <= dr_bal
				AND dr_bal < 3000000
			)
			AND (
				ar < 0.4
				OR (
					0.4 <= ar
					AND ar <= 0.5
				)
			)
		)
		OR (
			(3000000 <= dr_bal)
			AND (ar <= 0.4)
		);

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - #day1_tmp - INSERT.'';

	SELECT
		clt_code
	INTO #day0_tmp
	FROM
		#clt_tmp3
	WHERE
		(
			(dr_bal < 300000)
			AND (ar > 0.7)
		)
		OR (
			(
				300000 <= dr_bal
				AND dr_bal < 1000000
			)
			AND (ar > 0.6)
		)
		OR (
			(
				1000000 <= dr_bal
				AND dr_bal < 3000000
			)
			AND (ar > 0.5)
		)
		OR (
			(3000000 <= dr_bal)
			AND (ar > 0.4)
		);

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - #day0_tmp - INSERT.'';

	UPDATE
		' + @LiqDB + N'.dbo.stcltliqfb
	SET
		tolerate_day = 1
	WHERE
		clt_code IN (
			SELECT
				clt_code collate Chinese_Taiwan_Bopomofo_CI_AS
			FROM
				#day1_tmp
		)
		AND (
			tolerate_day < 1
			OR tolerate_day = -1
		);

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Liq.stcltliqfb - UPDATE.'';

	UPDATE
		' + @LiqDB + N'.dbo.stcltliqfb
	SET
		tolerate_day = 0
	WHERE
		clt_code IN (
			SELECT
				clt_code collate Chinese_Taiwan_Bopomofo_CI_AS
			FROM
				#day0_tmp
		)
		AND (
			tolerate_day < 0
			OR tolerate_day = -1
		);

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Liq.stcltliqfb - UPDATE2.'';

		
	SELECT
		a.clt_code,
		(a.liq_day - b.tolerate_day -1) AS os_day
	INTO #liq_tmp
	FROM
		' + @LiqDB + N'.dbo.stcltliq a,
		' + @LiqDB + N'.dbo.stcltliqfb b
	WHERE
		a.clt_code = b.clt_code collate Chinese_Taiwan_Bopomofo_CI_AS
		AND (a.liq_day - b.tolerate_day) > 1;
		
	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - #liq_tmp - INSERT.'';

	UPDATE
		' + @LiqDB + N'.dbo.stcltliqfb
	SET
		os_day = lt.os_day
	FROM
		#liq_tmp lt
	WHERE
		' + @LiqDB + N'.dbo.stcltliqfb.clt_code = lt.clt_code collate Chinese_Taiwan_Bopomofo_CI_AS;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Liq.stcltliqfb - UPDATE3.'';

		
	SELECT
		a.clt_code,
		b.liq_day
	INTO #updt_tmp
	FROM
		' + @LiqDB + N'.[dbo].[stcltmaster] a,
		' + @LiqDB + N'.dbo.stcltliq b
	WHERE
		a.clt_code = b.clt_code collate Chinese_Taiwan_Bopomofo_CI_AS
		AND a.clt_type = ''C''
		AND b.liq_day > 0
		AND a.clt_code IN (
			SELECT
				sclf.clt_code collate Chinese_Taiwan_Bopomofo_CI_AS
			FROM
				' + @LiqDB + N'.dbo.stcltliqfb AS sclf
		);

'
 SET @sql29 = N'	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - #updt_tmp - INSERT.'';

	UPDATE
		' + @LiqDB + N'.dbo.stcltliqfb
	SET
		tolerate_day = 0,
		os_day = ISNULL(ut.liq_day, 0) -1
	FROM
		#updt_tmp ut
	WHERE
		' + @LiqDB + N'.dbo.stcltliqfb.clt_code = ut.clt_code collate Chinese_Taiwan_Bopomofo_CI_AS;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Liq.stcltliqfb - UPDATE4.'';

	
	UPDATE
		' + @LiqDB + N'.dbo.stcltliqfb
	SET
		liq_day = os_day;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Liq.stcltliqfb - UPDATE5.'';

		
	-- 表 stcltliqfblist -- Liq.stcltliqfblist（原有）
	SET @currentStep = @currentStep + 1
	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - stcltliqfblist  ...'';

	-- 清除?据
	TRUNCATE TABLE ' + @LiqDB + N'.dbo.stcltliqfblist;

	INSERT INTO
		' + @LiqDB + N'.dbo.stcltliqfblist(
			clt_code,
			tolerate_day,
			start_date,
			ACTIVE_DAY,
			os_day
		)
	SELECT
		sclf.clt_code,
		sclf.tolerate_day,
		sclf.start_date,
		0, -- debug ??不知用什么值，先用0
		sclf.os_day
	FROM
		' + @LiqDB + N'.dbo.stcltliqfb sclf
	ORDER BY
		clt_code;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Liq.stcltliqfblist - INSERT.'';


	-- frmliq.scx
	UPDATE
		' + @LiqDB + N'.[dbo].[stcltmaster]
	SET
		run_code = CUST.ae collate Chinese_Taiwan_Bopomofo_CI_AS
	FROM
		(
			SELECT
				RTRIM(client_code) AS acc,
				RTRIM(client_name) AS ac_name,
				RTRIM(ae_code) AS ae,
				RTRIM(addr_1) AS addr1,
				RTRIM(addr_2) AS addr2,
				RTRIM(addr_3) AS addr3,
				RTRIM(addr_4) AS addr4,
				RTRIM(hkid) AS ac_id,
				RTRIM(contact_no) AS h_tel,
				RTRIM(name_1_c) AS ac_name_c
			FROM
				' + @G2BSDB + N'.dbo.view_client_contact_info AS vcci
				INNER JOIN ' + @G2BSDB + N'.dbo.client_master AS cm
				ON vcci.client_code = cm.accno collate Chinese_Taiwan_Bopomofo_CI_AS
		) AS CUST
	WHERE
		' + @LiqDB + N'.[dbo].[stcltmaster].clt_code = CUST.acc collate Chinese_Taiwan_Bopomofo_CI_AS;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Liq.stcltmaster - UPDATE10'';


	UPDATE
		' + @LiqDB + N'.dbo.stcontrol
	SET
		endtime = GETDATE(),
		procflag = 1;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Liq.stcontrol - UPDATE.'';

		
	-- 表 stimportdate --> Liq.stimportdate（原有）
	SET @currentStep = @currentStep + 1;

	INSERT INTO
		' + @LiqDB + N'.dbo.stimportdate
	(
		impdate, 
		msg
	)
	VALUES
	(
		getdate(), 
		''Import Liquidation Data Completed''
	);

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data - Liq.stimportdate - INSERT.'';



	-- 更新TradeDate
	IF @isDebug = 0
	BEGIN
		SET @message = N''Update current tradedate to '' + convert(varchar(100), @tempnextTradeDate, 111)
		EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep, @message;

		UPDATE
'
 SET @sql30 = N'			' + @LiqDB + N'.dbo.[STCONTROL]
		SET
			tradedate = @tempnextTradeDate
	END;

	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, @currentStep, @totleStep,
		N''Save data finished!''
	-- ?束
	EXEC [s_Ins_ImportDataHistory] @tempgroup, @tempuser, -1, -1,
		N''Import data finished!'';
		
END TRY
BEGIN CATCH
	SET @tran_error = @tran_error + 1;
	-- 返回异常值
	SELECT 
		  ERROR_NUMBER() AS [error]
		, ERROR_MESSAGE() AS [message]
		, ERROR_LINE() AS [ERROR_LINE]
		, ERROR_PROCEDURE() AS [ERROR_PROCEDURE]
		, ERROR_SEVERITY() AS [ERROR_SEVERITY]
END CATCH
IF(@tran_error > 0)
BEGIN
	ROLLBACK TRAN tran_importdata; --?行出?，回?事?(指定事?名?)
END 
ELSE
BEGIN
	COMMIT TRAN tran_importdata; --?有异常，提交事?(指定事?名?)
	-- 返回正常值
	SELECT 
		0 AS [error],
		'''' AS [message];
END
'
declare @sqlAll nvarchar(MAX)
SET @sqlAll = @sql1 + @sql2 + @sql3 + @sql4 + @sql5 + @sql6 + @sql7 + @sql8 + @sql9 + @sql10 + @sql11 + @sql12 + @sql13 + @sql14 + @sql15 + @sql16 + @sql17 + @sql18 + @sql19 + @sql20 + @sql21 + @sql22 + @sql23 + @sql24 + @sql25 + @sql26 + @sql27 + @sql28 + @sql29 + @sql30
DECLARE @Counter INT
SET @Counter = 0
DECLARE @TotalPrints INT
SET @TotalPrints = (LEN(@sqlAll) / 4000) + 1
WHILE @Counter < @TotalPrints 
BEGIN
    --PRINT SUBSTRING(@sqlAll, @Counter * 4000, 4000)
    SET @Counter = @Counter + 1
END

--PRINT(LEN(@sql1)) PRINT(LEN(@sql2)) PRINT(LEN(@sql3)) PRINT(LEN(@sql4)) PRINT(LEN(@sql5)) PRINT(LEN(@sql6))  PRINT(LEN(@sql7)) PRINT(LEN(@sql8)) PRINT(LEN(@sql9)) PRINT(LEN(@sql10))
--PRINT(LEN(@sql11)) PRINT(LEN(@sql12)) PRINT(LEN(@sql13)) PRINT(LEN(@sql14)) PRINT(LEN(@sql15)) PRINT(LEN(@sql16)) PRINT(LEN(@sql17)) PRINT(LEN(@sql18)) PRINT(LEN(@sql19)) PRINT(LEN(@sql20))
--PRINT(LEN(@sql21)) PRINT(LEN(@sql22)) PRINT(LEN(@sql23)) PRINT(LEN(@sql24)) PRINT(LEN(@sql25)) PRINT(LEN(@sql26)) PRINT(LEN(@sql27)) PRINT(LEN(@sql28)) PRINT(LEN(@sql29)) PRINT(LEN(@sql30))
EXEC (@sqlAll)
 --EXEC('' + @sql1 + @sql2 + @sql3 + @sql4 + @sql5 + @sql6 + @sql7 + @sql8 + @sql9 + @sql10 + @sql11 + @sql12 + @sql13 + @sql14 + @sql15 + @sql16 + @sql17 + @sql18 + @sql19 + @sql20 + @sql21 + @sql22 + @sql23 + @sql24 + @sql25 + @sql26 + @sql27 + @sql28 + @sql29 + @sql30)
	--------- Content End -----------

END
