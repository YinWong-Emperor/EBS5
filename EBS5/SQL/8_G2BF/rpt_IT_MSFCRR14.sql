/****** Object:  StoredProcedure [dbo].[rpt_MSFCRR14]    Script Date: 05/02/2018 17:21:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[rpt_IT_MSFCRR14]

/* *********************************************************
SP Name:		rpt_MSFCRR14
Date:		
By:		Louisa Yu
Description:	COMMISSION & REBATE REPORT - BY A/E
update:
11/5/2005      Louisa Yu	group oid in close_pos
14/5/2005      Louisa Yu	bug fix 
18/8/2005      Louisa Yu        add day range
25/08/2005     Louisa Yu        bug fix day range on 'day start' status
09/01/2006     Danny Chung	change sorting by user request (sorting -- 
steps:
drop procedure rpt_MSFCRR14
exec rpt_MSFCRR14 '999', 'Oct 2014', '', '', '','','', '', '' 

Remarks :-
BEFORE DAY END
  - DAILY   
    - OPEN POSITION 
      - tdate is trade date -> day
    - CLOSE POSITION
      - tdate = trade date AND open trade date == close trade date -> day
      - tdate = trade date AND open trade date <> close trade date -> night

AFTER DAY END
  - DAILY   
    - OPEN POSITION 
      - all record(s) -> night
    - CLOSE POSITION
      - tdate = trade date AND open trade date == close trade date -> day
      - tdate = trade date AND open trade date <> close trade date -> night
********************************************************* 
Change History:
excluding those correct trades not in current month 
20130204		UR#10876 Monthend report 1136D - A/E ACTIVITIES (COMMISSION & REBATE) hangs -based on UR#6324 report will not route by dayend
20130801	DC	UR#11473 A/E ACTIVITIES (COMMISSION & REBATE) Report generate slowly
20140718	DC	UR#10927 - AE activity report not clear on position after changing client's AE
20141107	DC	UR#13173 - Difference total commission between A/E Activities (comm. & Rebate) report and Commission & Rebate report
20150309	DC	UR#13755 - Run A/E ACTIVITIES (COMMISSION & REBATE) report error
20150310	DC	UR#13759 - Enhance - A/E ACTIVITIES (COMMISSION & REBATE) report
20150624	BT	UR#14072 - Extend trade price to decimal (18, 8)
20150908	DC	UR#14406 - Duplicate Records shown in AE Activities Report
20160224	DC	UR#10818 - No record shown in broker daily trading report
********************************************************* */
@P_cmid		CHAR(10),
@P_month	CHAR(8),
@P_temp		CHAR(8),
@P_mkid_b	CHAR(10)	= NULL,
@P_mkid_e	CHAR(10)	= NULL,
@P_aeid_b	CHAR(10)	= NULL,
@P_aeid_e	CHAR(10)	= NULL,
@p_vdate_b	CHAR(20)	= NULL,
@p_vdate_e	CHAR(20)	= NULL

AS


-- Get system date code
DECLARE	@OP_reason 		CHAR(255),
	@return			CHAR(255),
	-- UR#10818 [begin]
	--@p_mkName_s_begin 	CHAR(4),
	--@p_mkName_s_end		CHAR(4),
	@p_mkName_s_begin 	CHAR(6),
	@p_mkName_s_end		CHAR(6),
	-- UR#10818 end]
	@p_AEno_begin		CHAR(20),
	@p_AEno_end		CHAR(20),
	@vdate_begin		DATETIME,
	@vdate_end		DATETIME,
	@m_month		INTEGER,
--BEGIN 20130204 UR#10876 Monthend report 1136D - A/E ACTIVITIES (COMMISSION & REBATE) hangs
	--@m_year			INTEGER,
	@m_year			INTEGER
	/*@m_action_AL		CHAR(30),
	@m_action_AL_ok		CHAR(1),
	@m_action_DE		CHAR(30),
	@m_action_DE_ok		CHAR(1),
	@iDateCode		INT*/
--BEGIN 20130204 UR#10876 Monthend report 1136D - A/E ACTIVITIES (COMMISSION & REBATE) hangs

SET @m_month = MONTH(CONVERT(DATETIME,  '1' + @P_month))
SET @m_year = YEAR(CONVERT(DATETIME, '1' + @P_month) )


--BEGIN 20130204 UR#10876 Monthend report 1136D - A/E ACTIVITIES (COMMISSION & REBATE) hangs
--select  @m_month 
--select  @m_year 

-- GET SYSTEM CONTROL
--SET @m_action_AL = 'AUTO LIQUIDATION'
--SET @m_action_DE = 'DAY END'
--SELECT @m_action_AL_ok = ok FROM system_control WHERE ACTION = @m_action_AL AND cmid = @P_cmid
--SELECT @m_action_DE_ok = ok FROM system_control WHERE ACTION = @m_action_DE AND cmid = @P_cmid


-- Get system date code
--SELECT
--@iDateCode = datecode
--FROM
--system_parameter
--WHERE
--cmid = @p_cmid
--End 20130204 UR#10876 Monthend report 1136D - A/E ACTIVITIES (COMMISSION & REBATE) hangs

-- range for market
 EXEC	RptGetName
	@p_type = '0',
	@p_b = @p_mkid_b,		
	@p_e = @p_mkid_e,
	@p_name_begin = @p_mkName_s_begin OUTPUT,
	@p_name_end = @p_mkName_s_end	  OUTPUT,
	@op_reason = @op_reason    	  OUTPUT

 IF (@op_reason <> 'OK')
  BEGIN
	SELECT eid AS Error  FROM ERROR_MESSAGE WHERE eid = @op_reason 
	RETURN 
  END


-- range for ae
 EXEC	RptGetName
	@p_type = '7',
	@p_b = @p_aeid_b,		
	@p_e = @p_aeid_e,
	@p_name_begin = @p_AEno_begin OUTPUT,
	@p_name_end = @p_AEno_end     OUTPUT,
	@op_reason = @op_reason       OUTPUT

 IF (@op_reason <> 'OK')
  BEGIN
	SELECT eid AS Error  FROM ERROR_MESSAGE WHERE eid = @op_reason 
	RETURN 
  END



-- set day range Date
SELECT @P_vdate_b = RTRIM(@P_vdate_b)
SELECT @P_vdate_e = RTRIM(@P_vdate_e)
DECLARE @next_month DATETIME

IF	LEN(@P_vdate_b)	= 0 OR @P_vdate_b IS NULL 
BEGIN   
	SELECT @P_vdate_b = NULL
	SELECT @vdate_begin = CONVERT(DATETIME,'1' + @p_month )
--	select @vdate_begin	= NULL

END
IF	LEN(@P_vdate_e)	= 0 OR @P_vdate_e IS NULL 
BEGIN
	SELECT @P_vdate_e = NULL
--	select @next_month = dateadd(month,1,convert(datetime,'1' + @p_month))
	SELECT @vdate_end = DATEADD(DAY, -1 ,DATEADD(MONTH,1,CONVERT(DATETIME,'1' + @p_month)))
--	select @vdate_end	= NULL
END 


-- fix UR#10927 [begin]
/*
SELECT * INTO #tmp_trade_cuid_chrg FROM view_trade_cuid_chrg WHERE cmid = @p_cmid 

--BEGIN 20130204 UR#10876 Monthend report 1136D - A/E ACTIVITIES (COMMISSION & REBATE) hangs
SELECT * INTO #tmp_active_ae FROM view_active_ae WHERE trade_month = @m_month AND trade_year = @m_year
SELECT * INTO #tmp_active_ae_wt_tradetype FROM view_active_ae_wt_tradetype WHERE trade_month = @m_month AND trade_year = @m_year
SELECT * INTO #temp_view_LME_promptdate FROM view_LME_promptdate

SELECT * INTO #tmp_close_pos FROM close_pos 
WHERE cmid = @P_cmid
AND (MONTH(tdate) = @m_month AND year(tdate) = @m_year
		OR MONTH(date) = @m_month AND YEAR(date) = @m_year)

DECLARE @p_oid_min CHAR(10), @p_oid_max CHAR(10), @p_systemDate DATETIME

SELECT @p_systemDate = tradedate FROM system_parameter WHERE cmid = @P_cmid


SELECT @p_oid_min = MIN(CONVERT(INT,oid)), @p_oid_max = MAX(CONVERT(INT,oid)) FROM histcltradeh WHERE tdate >= @P_month
IF MONTH(@p_systemDate) = MONTH(@P_month) AND YEAR(@p_systemDate) = YEAR(@P_month)
BEGIN
	SELECT @p_oid_max = MAX(CONVERT(INT,oid)) FROM daycltradehd
END
IF @p_oid_min IS NULL
BEGIN 
	SELECT @p_oid_min = MIN(CONVERT(INT,oid)) FROM daycltradehd
END


SELECT * INTO #temp_view_total_order_fees FROM view_total_order_fees WHERE CONVERT(INT, oid) >= CONVERT(INT, @p_oid_min)  AND CONVERT(INT, oid) <= CONVERT(INT, @p_oid_max)
SELECT * INTO #temp_view_all_tradeh FROM view_all_tradeh WHERE CONVERT(INT, oid) >= CONVERT(INT, @p_oid_min)  AND CONVERT(INT, oid) <= CONVERT(INT, @p_oid_max)
SELECT * INTO #temp_view_all_traded FROM view_all_traded WHERE CONVERT(INT, oid) >= CONVERT(INT, @p_oid_min)  AND CONVERT(INT, oid) <= CONVERT(INT, @p_oid_max)
SELECT * INTO #temp_view_correct_trade_tdate FROM view_correct_trade_tdate WHERE CONVERT(INT, oid_new) >= CONVERT(INT, @p_oid_min)  AND CONVERT(INT, oid_new) <= CONVERT(INT, @p_oid_max)
SELECT * INTO #temp_view_order_aeid FROM view_order_aeid WHERE CONVERT(INT, oid) >= CONVERT(INT, @p_oid_min)  AND CONVERT(INT, oid) <= CONVERT(INT, @p_oid_max)

--End 20130204 UR#10876 Monthend report 1136D - A/E ACTIVITIES (COMMISSION & REBATE) hangs
*/
-- fix UR#10927 [end]

--BEGIN 20130204 UR#10876 Monthend report 1136D - A/E ACTIVITIES (COMMISSION & REBATE) hangs -based on UR#6324 , before-dayend part skipped 
/*
-- GENERATE RECORDSET
IF @m_action_AL_ok = '1' AND @m_action_DE_ok = '0'
  BEGIN 

	-- BEFORE AUTO-LIQUIDATION
	--select 'BEFORE AUTO-LIQUIDATION'
	SELECT od.cmid,ae.aeid, ae.aeno,ae.name ae_name,
	oid,group_o,RTRIM(acct) AS acct,ae.market,ae.ccy,comdy_code,
	dec_loc,MONTH,put_call,s_price,price_str,s_price_str,future_type,
	--type, tdate, ISNULL(qty_day, 0 ) AS qty_day, ISNULL(qty_night, 0 ) AS qty_night, ISNULL(qty_tg, 0 ) AS qty_tg, comm, exchange_fee,rebate,
	TYPE, 
	RTRIM(CONVERT(CHAR(15), tdate, 3)) AS tdate, 
	qty_day,qty_night,qty_tg, comm, exchange_fee,levy, rebate,
	m_qty_day, m_qty_night,m_qty_tg, m_comm,m_exchange_fee,m_levy, m_rebate,
	bhid,
	ae.tradetype,
	@P_vdate_b AS tranxdate_b,
	@P_vdate_e AS tranxdate_e
--into tmp_rpt14a  
--select * 
	FROM #tmp_active_ae_wt_tradetype ae --where aeno ='S55052'
	LEFT OUTER JOIN (
--	from (
		SELECT 
		u.cmid, u.oid,u.group_o, aeno, am.name AS ae_name, RTRIM(clm.accno) + ' ' + clm.name_1 AS acct, 
		'(' + RTRIM(mm.name_s) + ')' + RTRIM(mm.name) AS market, cm.name_s AS ccy, 
--		RTRIM(cdm.code) AS comdy_code,
		CASE cdm.ptype WHEN '4' THEN RTRIM(lme.LME_code) ELSE RTRIM(lme.com_code) END AS comdy_code,
		cdm.dec_loc AS dec_loc,  
		CASE cdm.ptype WHEN '4' THEN '' ELSE MONTH END AS MONTH , 
--		month, 
		post AS put_call, 
		CASE WHEN post='1' OR post='2' THEN strike_price ELSE fee.price END AS s_price,
		
		CASE dec_loc WHEN 0 THEN CONVERT(VARCHAR,CONVERT(REAL,fee.price)) 
		WHEN 1 THEN CONVERT(VARCHAR,CONVERT(DECIMAL(18,1), fee.price))
		WHEN 2 THEN CONVERT(VARCHAR,CONVERT(DECIMAL(18,2), fee.price))
		WHEN 3 THEN CONVERT(VARCHAR,CONVERT(DECIMAL(18,3), fee.price))
		WHEN 4 THEN CONVERT(VARCHAR,CONVERT(DECIMAL(18,4), fee.price))
		WHEN 5 THEN CONVERT(VARCHAR,CONVERT(DECIMAL(18,5), fee.price))
		WHEN 6 THEN CONVERT(VARCHAR,CONVERT(DECIMAL(18,6), fee.price))
		END AS price_str,
		CASE dec_loc WHEN 0 THEN CONVERT(VARCHAR,CONVERT(REAL,fee.s_price)) 
		WHEN 1 THEN CONVERT(VARCHAR,CONVERT(DECIMAL(18,1), fee.s_price))
		WHEN 2 THEN CONVERT(VARCHAR,CONVERT(DECIMAL(18,2), fee.s_price))
		WHEN 3 THEN CONVERT(VARCHAR,CONVERT(DECIMAL(18,3), fee.s_price))
		WHEN 4 THEN CONVERT(VARCHAR,CONVERT(DECIMAL(18,4), fee.s_price))
		WHEN 5 THEN CONVERT(VARCHAR,CONVERT(DECIMAL(18,5), fee.s_price))
		WHEN 6 THEN CONVERT(VARCHAR,CONVERT(DECIMAL(18,6), fee.s_price))
		END AS s_price_str,	
		CASE WHEN post='1' OR post='2' THEN '1' ELSE '0' END AS future_type,
		dd.type AS TYPE,
		CONVERT(DATETIME, CONVERT(CHAR(15), dd.tdate, 3), 3)  AS tdate,
		SUM(u.qty_day) AS qty_day, SUM(u.qty_night) AS qty_night, SUM(u.qty_tg) AS qty_tg,
		fee.comm AS comm, fee.exchange_fee AS exchange_fee, fee.levy, fee.rebate AS rebate,
	--	CASE WHEN post='1' or post='2' THEN fee.price_str ELSE '-' END as premium,
		0 AS m_comm, 0 AS m_exchange_fee, 0 AS m_levy, 0 AS m_rebate,
		0 AS m_qty_day, 0 AS m_qty_night, 0 AS m_qty_tg,
	--m_qty_day AS m_qty_day, m_qty_night AS m_qty_night, m_qty_tg AS m_qty_tg,
	--m_comm AS m_comm, m_exchange_fee AS m_exchange_fee, m_rebate AS m_rebate,
		--SUM(m_qty_day) AS m_qty_day, SUM(m_qty_night) AS m_qty_night, SUM(m_qty_tg) AS m_qty_tg,
		--SUM(m_comm) AS m_comm, SUM(m_exchange_fee) AS m_exchange_fee,SUM(m_rebate) AS m_rebate,
		u.bhid ,
		CASE WHEN u.tradetype ='L' THEN '0' ELSE u.tradetype END AS tradetype,
--		u.tradetype,
		u.mkid,u.cuid_chrg , mm.name_s AS mkt 
	
		FROM 
		(
	
			-- DAILY
			-----------------------------------------------------------------1	
			-- OPEN POSITION FOR DAY TRADE 
			SELECT op.cmid, op.oid, opd.group_o AS group_o, op.aeid, op.aid, mkid, cuid_chrg, ctid, 
			qty AS qty_day, 0 AS qty_night, 0 AS qty_tg,
			0 AS m_qty_day, 0 AS m_qty_night, 0 AS m_qty_tg,
			0 AS comm, 0 AS exchange_fee, 0 AS levy, 0 AS rebate,
			0 AS m_comm, 0 AS m_exchange_fee, 0 AS m_levy, 0 AS m_rebate , bhid
			bhid ,
			op.tradetype
			FROM open_pos op, open_pos_d opd , client_master_f cmf 
			WHERE opd.oid = op.oid AND op.cmid = cmf.cmid AND op.aid = cmf.aid 
			AND op.oid IN ( SELECT oid FROM #temp_view_all_tradeh WHERE cmid = @p_cmid AND tradetype <> '2' )
				-- excluding those correct trades not in current month 
				AND op.oid NOT IN (SELECT oid_new FROM #temp_view_correct_trade_tdate WHERE cmid = @p_cmid AND (MONTH(tdate)<> @m_month OR YEAR(tdate)<> @m_year))
--				and op.oid not in (select oid_new from ccrecord_client where cmid = @p_cmid )
				-- excluding those correct trades not in current month 
	
			UNION ALL
		
			-- CLOSE POSITION FOR DAY TRADE
			SELECT cmid, oid, group_o, aeid, aid, mkid, cuid_chrg, ctid, 
			qty_day  AS qty_day, 0 AS qty_night, 0 AS qty_tg,
			0 AS m_qty_day, 0 AS m_qty_night, 0 AS m_qty_tg,
			0 AS comm, 0 AS exchange_fee, 0 AS levy, 0 AS rebate,
			0 AS m_comm, 0 AS m_exchange_fee, 0 AS m_levy, 0 AS m_rebate, bhid 
			bhid ,
			tradetype
			FROM
			( 
				-- OPEN ORDER
				SELECT DISTINCT cp.cmid, cp.oid_open AS oid, group_o_open AS group_o, ISNULL(dh.aeid, cp.aeid) AS aeid, cp.aid, cp.mkid, 
						ISNULL(cc.cuid_chrg,cp.cuid_chrg) AS cuid_chrg, cp.ctid, price_open AS price,
						SUM(cp.qty) AS qty_day, cmf.bhid ,dh.tradetype
				FROM close_pos cp 
					LEFT OUTER JOIN client_master_f cmf ON cp.cmid = cmf.cmid AND cp.aid = cmf.aid 
					LEFT OUTER JOIN #temp_view_all_tradeh dh ON cp.oid_open = dh.oid AND dh.cmid = cp.cmid
					LEFT OUTER JOIN #temp_view_all_traded dd ON dh.oid = dd.oid AND dd.group_o = cp.group_o_open 
					LEFT OUTER JOIN #tmp_trade_cuid_chrg cc ON cp.cmid = cc.cmid AND cp.oid_open = cc.oid 
				WHERE rflag_open = 'D' 
				AND oid_open IN ( SELECT oid FROM #temp_view_all_tradeh WHERE cmid = @P_cmid 
					-- excluding those correct trades not in current month 
					AND cp.oid_open NOT IN (SELECT oid_new FROM #temp_view_correct_trade_tdate WHERE cmid = @p_cmid AND (MONTH(tdate)<> @m_month OR YEAR(tdate)<> @m_year))
--					and cp.oid_open not in (select oid_new from ccrecord_client where cmid = @p_cmid )
					-- excluding those correct trades not in current month 

					AND tradetype NOT IN ('2','E','V','W','Y','Z','P','Q','T','U'))
					AND MONTH(dh.tdate) = @m_month AND YEAR(dh.tdate) = @m_year 
				GROUP BY cp.cmid, cp.oid_open, group_o_open,  dh.aeid, cp.aeid, cp.aid, cp.mkid, ISNULL(cc.cuid_chrg,cp.cuid_chrg) , cp.ctid, price_open, cmf.bhid ,dh.tradetype
		
				UNION ALL
			
				-- CLOSE ORDER
				SELECT DISTINCT cp.cmid, oid_close AS oid, group_o_close AS group_o,cp.aeid, cp.aid, mkid, 
						ISNULL(cc.cuid_chrg,cp.cuid_chrg) AS cuid_chrg, ctid_close AS ctid, price_close AS price,
						SUM(qty_close) AS qty_day, cmf.bhid ,tradetype_close AS tradetype
				FROM close_pos cp 
					LEFT OUTER JOIN client_master_f cmf ON cp.cmid = cmf.cmid AND cp.aid = cmf.aid 
					LEFT OUTER JOIN #tmp_trade_cuid_chrg cc ON cp.cmid = cc.cmid AND cp.oid_close = cc.oid 
				WHERE cp.rflag = 'D' 
				AND oid_close IN ( SELECT oid FROM #temp_view_all_tradeh WHERE cmid = @P_cmid 
					-- excluding those correct trades not in current month 
					AND cp.oid_close NOT IN (SELECT oid_new FROM #temp_view_correct_trade_tdate WHERE cmid = @p_cmid AND (MONTH(tdate)<> @m_month OR YEAR(tdate)<> @m_year))
--					and oid not in (select oid_new from ccrecord_client where cmid = @p_cmid )
					-- excluding those correct trades not in current month 

					AND tradetype NOT IN ('2','E','V','W','Y','Z','P','Q','T','U'))
					AND MONTH(cp.date) = @m_month AND YEAR(cp.date) = @m_year 
				GROUP BY  cp.cmid, oid_close , group_o_close,cp.aeid, cp.aid, mkid, ISNULL(cc.cuid_chrg,cp.cuid_chrg) , ctid_close , price_close ,cmf.bhid , tradetype_close
			) u
			--GROUP BY cmid, aeid, aid, mkid, cuid_chrg, ctid	, bhid
			-----------------------------------------------------------------1
		        UNION ALL
		
			-----------------------------------------------------------------2
			-- CLOSE POSITION FOR NIGHT TRADE
			SELECT cmid, oid ,group_o, aeid, aid, mkid, cuid_chrg, ctid, 
			0 AS qty_day, qty_night AS qty_night, 0 AS qty_tg,
			0 AS m_qty_day, 0 AS m_qty_night, 0 AS m_qty_tg,
			0 AS comm, 0 AS exchange_fee, 0 AS levy, 0 AS rebate,
			0 AS m_comm, 0 AS m_exchange_fee, 0 AS m_levy, 0 AS m_rebate, bhid 
			bhid,
			tradetype 	 
			FROM
			(
				SELECT DISTINCT cp.cmid, cp.oid_open AS oid, cp.group_o_open AS group_o,ISNULL(dh.aeid, cp.aeid) AS aeid, cp.aid, cp.mkid, 
						ISNULL(cc.cuid_chrg,cp.cuid_chrg) AS cuid_chrg, cp.ctid,  price_open AS price,
				SUM(cp.qty) AS qty_night, cmf.bhid ,dh.tradetype
				FROM close_pos cp
					LEFT OUTER JOIN client_master_f cmf ON cp.cmid = cmf.cmid AND cp.aid = cmf.aid 
					LEFT OUTER JOIN #temp_view_all_tradeh dh ON cp.oid_open = dh.oid AND dh.cmid = cp.cmid
					LEFT OUTER JOIN #temp_view_all_traded dd ON dh.oid = dd.oid AND dd.group_o = cp.group_o_open 
					LEFT OUTER JOIN #tmp_trade_cuid_chrg cc ON cp.cmid = cc.cmid AND cp.oid_open = cc.oid 
				WHERE rflag_open = 'N' 
				AND oid_open IN ( SELECT oid FROM #temp_view_all_tradeh WHERE cmid = @P_cmid 
					-- excluding those correct trades not in current month 
					AND oid NOT IN (SELECT oid_new FROM #temp_view_correct_trade_tdate WHERE cmid = @p_cmid AND (MONTH(tdate)<> @m_month OR YEAR(tdate)<> @m_year))
--					and oid not in (select oid_new from ccrecord_client where cmid = @p_cmid )
					-- excluding those correct trades not in current month 
					AND tradetype NOT IN ('2','E','V','W','Y','Z','P','Q','T','U'))
					AND MONTH(dh.tdate) = @m_month AND YEAR(dh.tdate) = @m_year 
			--	and cp.clid ='345022'
				GROUP BY cp.cmid, cp.oid_open, group_o_open,  dh.aeid, ISNULL(dh.aeid, cp.aeid) , cp.aid, cp.mkid, ISNULL(cc.cuid_chrg,cp.cuid_chrg), cp.ctid, price_open, cmf.bhid ,dh.tradetype
			
				UNION ALL
			
				SELECT DISTINCT cp.cmid, oid_close AS oid, group_o_close AS group_o, ISNULL(dh.aeid, cp.aeid) AS aeid, cp.aid, cp.mkid, 
						ISNULL(cc.cuid_chrg,cp.cuid_chrg) AS cuid_chrg, ctid_close AS ctid, price_close AS price,
						SUM(qty_close) AS qty_night, cmf.bhid , tradetype_close AS tradetype
				FROM close_pos cp 
					LEFT OUTER JOIN client_master_f cmf ON cp.cmid = cmf.cmid AND cp.aid = cmf.aid 
					LEFT OUTER JOIN #temp_view_all_tradeh dh ON cp.oid_close = dh.oid AND dh.cmid = cp.cmid 
					LEFT OUTER JOIN #temp_view_all_traded dd ON dh.oid = dd.oid AND dd.group_o = cp.group_o_close	
					LEFT OUTER JOIN #tmp_trade_cuid_chrg cc ON cp.cmid = cc.cmid AND cp.oid_close = cc.oid 
				WHERE cp.rflag = 'N'
				AND oid_close IN ( SELECT oid FROM #temp_view_all_tradeh WHERE cmid = @P_cmid 
					-- excluding those correct trades not in current month 
					AND oid_close NOT IN (SELECT oid_new FROM #temp_view_correct_trade_tdate WHERE cmid = @p_cmid AND (MONTH(tdate)<> @m_month OR YEAR(tdate)<> @m_year))
--					and oid not in (select oid_new from ccrecord_client where cmid = @p_cmid )
					-- excluding those correct trades not in current month 

					AND tradetype NOT IN ('2','E','V','W','Y','Z','P','Q','T','U')) 
					AND MONTH(cp.date) = @m_month AND YEAR(cp.date) = @m_year 
				GROUP BY  cp.cmid, oid_close , group_o_close,ISNULL(dh.aeid, cp.aeid), cp.aid, cp.mkid, 
					ISNULL(cc.cuid_chrg,cp.cuid_chrg) , ctid_close , price_close ,cmf.bhid ,tradetype_close
			) u
			--GROUP BY cmid, aeid, aid, mkid, cuid_chrg, ctid, bhid 
			  
			-----------------------------------------------------------------2
			
			UNION ALL
		
			-----------------------------------------------------------------3
			-- DAILY TRADE FOR T / G TRADE
			SELECT dthd.cmid, dthd.oid, dtd.group_o, dthd.aeid, dthd.aid, mkid, cuid_chrg, ctid, 
			0 AS qty_day, 0 AS qty_night, qty AS qty_tg,
			0 AS m_qty_day, 0 AS m_qty_night, 0 AS m_qty_tg,
			0 AS comm, 0 AS exchange_fee, 0 AS levy, 0 AS rebate,	
			0 AS m_comm, 0 AS m_exchange_fee, 0 AS m_levy, 0 AS m_rebate,
			cmf.bhid ,dthd.tradetype
			FROM #temp_view_all_tradeh dthd, #temp_view_all_traded dtd , client_master_f cmf
			WHERE dtd.oid = dthd.oid AND dthd.cmid = cmf.cmid AND dthd.aid = cmf.aid 
			AND (tradetype = '1' OR tradetype = '2') -- and tradetype <> '2' 
			AND MONTH(dthd.tdate) = @m_month AND YEAR(dthd.tdate) = @m_year 
			-----------------------------------------------------------------3
			
		) u,view_LME_promptdate LME ,
	
		ae_master am, client_master clm,
		market_master mm, currency_master cm,
		commod_master cdm, contract_master ctm,
		#temp_view_total_order_fees  fee,
		#temp_view_all_tradeh dd
		WHERE u.cmid =  fee.cmid 
		AND u.ctid = lme.ctid 
		AND u.aeid= fee.aeid
		AND u.oid = fee.oid
		AND u.group_o = fee.group_o
		AND u.oid =dd.oid
		AND am.aeid = u.aeid
		AND clm.aid = u.aid
		AND mm.mkid = u.mkid
		AND cm.cuid = u.cuid_chrg

		AND ctm.ctid = u.ctid
		AND ctm.cyid = cdm.cyid
	
		AND u.cmid = @P_cmid
	
	
	
		AND ((@p_mkName_s_begin IS NULL AND @p_mkName_s_end IS NULL)
			OR (mm.name_s >= @p_mkName_s_begin AND mm.name_s <= @p_mkName_s_end))
	
		AND ((@p_AEno_begin IS NULL AND @p_AEno_end IS NULL)
			OR (am.aeno >= @p_AEno_begin AND am.aeno <= @p_AEno_end))
	
		--GROUP BY 
		--u.cmid, u.oid, aeno, accno, am.name, clm.name_1, clm.name_2, mm.name_s, mm.name, cm.name_s, cdm.code, month, post, strike_price, dec_loc,am.bhid
		
		GROUP BY 
		u.cmid, u.oid, u.group_o, aeno, accno, am.name, clm.accno, clm.name_1, mm.name_s, mm.name, cm.name_s, cdm.code, MONTH, post, dd.type , dd.tdate,
		fee.comm, fee.exchange_fee, fee.levy, fee.rebate,fee.price, fee.price_str,fee.s_price_str, strike_price,u.bhid, cdm.dec_loc,fee.s_price, 
		u.tradetype, u.mkid , u.cuid_chrg ,
		CASE cdm.ptype WHEN '4' THEN RTRIM(lme.LME_code) ELSE RTRIM(lme.com_code) END , cdm.ptype 	
	
	)od  --right outer join #tmp_active_ae ae
--	on od.aeno= ae.aeno 
	ON od.aeno= ae.aeno AND ae.cmid = od.cmid AND ae.tradetype = od.tradetype AND ae.mkid = od.mkid AND ae.cuid_chrg = od.cuid_chrg 
	WHERE ae.trade_month = @m_month 
	AND ae.trade_year = @m_year 
	AND ae.cmid =@P_cmid
	AND ((@p_mkName_s_begin IS NULL AND @p_mkName_s_end IS NULL)
			OR (od.mkt >= @p_mkName_s_begin AND od.mkt <= @p_mkName_s_end))
	
		AND ((@p_AEno_begin IS NULL AND @p_AEno_end IS NULL)
			OR (ae.aeno >= @p_AEno_begin AND ae.aeno <= @p_AEno_end))
		AND ((@vdate_begin IS NULL AND @vdate_end IS NULL)
			OR (tdate >= @vdate_begin AND tdate <= @vdate_end))
			
ORDER BY
--ae.aeno, tdate, od.acct, od.comdy_code, od.month, od.oid, od.put_call, od.s_price
ae.aeno, ae.market, od.acct, od.comdy_code, tdate, od.month, od.oid, od.put_call, od.s_price

  END

ELSE IF @m_action_AL_ok = '1' AND @m_action_DE_ok = '1'  -- AFTER DAY END

  BEGIN
*/ 
--End 20130204 UR#10876 Monthend report 1136D - A/E ACTIVITIES (COMMISSION & REBATE) hangs 


-- fix UR#10927 [begin]
/*
-- fix UR #11473 [begin]
CREATE TABLE #tmp_qty
(
	cmid	char(10),
	oid	char(10),
	group_o	char(10),
	aeid	char(10),
	aid	char(10),
	mkid	char(10),
	cuid_chrg	char(10),
	ctid	char(10),
	qty_day	decimal(18,0),
	qty_night	decimal(18,0),
	qty_tg	decimal(18,0),
	m_qty_day	decimal(18,0),
	m_qty_night	decimal(18,0),
	m_qty_tg	decimal(18,0),
	comm	money,
	exchange_fee	money,
	levy	money,
	rebate	money,
	m_comm	money,
	m_exchange_fee	money,
	m_levy	money,
	m_rebate	money,
	bhid	char(10),
	tradetype	char(1)
)


			-- DAILY
			-----------------------------------------------------------------1	
			-- OPEN POSITION FOR DAY TRADE
			INSERT INTO #tmp_qty
			SELECT op.cmid, op.oid, opd.group_o AS group_o, op.aeid, op.aid, mkid, cuid_chrg, ctid, 
			0 AS qty_day, qty AS qty_night, 0 AS qty_tg,
			0 AS m_qty_day, 0 AS m_qty_night, 0 AS m_qty_tg,
			0 AS comm, 0 AS exchange_fee, 0 AS levy, 0 AS rebate,
			0 AS m_comm, 0 AS m_exchange_fee, 0 AS m_levy, 0 AS m_rebate , 
			bhid, op.tradetype
			FROM open_pos op, open_pos_d opd , client_master_f cmf 
			WHERE opd.oid = op.oid AND op.cmid = cmf.cmid AND op.aid = cmf.aid 
			AND op.oid IN ( SELECT oid FROM #temp_view_all_tradeh WHERE cmid = @p_cmid AND tradetype <> '2' )
				-- excluding those correct trades not in current month 
				AND op.oid NOT IN (SELECT oid_new FROM #temp_view_correct_trade_tdate WHERE cmid = @p_cmid AND (MONTH(tdate)<> @m_month OR YEAR(tdate)<> @m_year))
--				and op.oid not in (select oid_new from ccrecord_client where cmid = @p_cmid )
				-- excluding those correct trades not in current month 
		
		
			-- CLOSE POSITION FOR DAY TRADE
			INSERT INTO #tmp_qty
			SELECT cmid, oid, group_o, aeid, aid, mkid, cuid_chrg, ctid, 
			qty_day AS qty_day, 0 AS qty_night, 0 AS qty_tg,
			0 AS m_qty_day, 0 AS m_qty_night, 0 AS m_qty_tg,
			0 AS comm, 0 AS exchange_fee, 0 AS levy, 0 AS rebate,
			0 AS m_comm, 0 AS m_exchange_fee, 0 AS m_levy, 0 AS m_rebate, 
			bhid , tradetype 
			FROM
			( 
				-- OPEN ORDER
				SELECT DISTINCT cp.cmid, cp.oid_open AS oid, group_o_open AS group_o, ISNULL(dh.aeid, cp.aeid) AS aeid, cp.aid, cp.mkid, 
						ISNULL(cc.cuid_chrg,cp.cuid_chrg) AS cuid_chrg, cp.ctid, price_open AS price,
						SUM(cp.qty) AS qty_day, cmf.bhid , dh.tradetype 
-- fix UR #10876 [begin]
--				FROM close_pos cp 
				FROM #tmp_close_pos cp 
-- fix UR #10876 [end]
					INNER  JOIN client_master_f cmf ON cp.cmid = cmf.cmid AND cp.aid = cmf.aid 
					INNER  JOIN #temp_view_all_tradeh dh ON cp.oid_open = dh.oid AND dh.cmid = cp.cmid
-- fix UR #10876 [begin] -- not use ??
--					INNER  JOIN #temp_view_all_traded dd ON dh.oid = dd.oid AND dd.group_o = cp.group_o_open 
-- fix UR #10876 [end]
					INNER  JOIN #tmp_trade_cuid_chrg cc ON cp.cmid = cc.cmid AND cp.oid_open = cc.oid 
				WHERE rflag_open = 'D' 
				AND oid_open IN ( SELECT oid FROM #temp_view_all_tradeh WHERE cmid = @P_cmid 
					-- excluding those correct trades not in current month 
					AND oid_open NOT IN (SELECT oid_new FROM #temp_view_correct_trade_tdate WHERE cmid = @p_cmid AND (MONTH(tdate)<> @m_month OR YEAR(tdate)<> @m_year))
--					and oid not in (select oid_new from ccrecord_client where cmid = @p_cmid )
					-- excluding those correct trades not in current month 

					AND tradetype NOT IN ('2','E','V','W','Y','Z','P','Q','T','U'))
					AND MONTH(dh.tdate) = @m_month AND YEAR(dh.tdate) = @m_year 
				GROUP BY cp.cmid, cp.oid_open, group_o_open,  dh.aeid, cp.aeid, cp.aid, cp.mkid, 
					ISNULL(cc.cuid_chrg,cp.cuid_chrg), cp.ctid, price_open, cmf.bhid ,dh.tradetype 	
			
				UNION ALL
			
				-- CLOSE ORDER
				SELECT DISTINCT cp.cmid, oid_close AS oid, group_o_close AS group_o,cp.aeid, cp.aid, mkid, 
						ISNULL(cc.cuid_chrg,cp.cuid_chrg) AS cuid_chrg, ctid_close AS ctid, price_close AS price,
						SUM(qty_close) AS qty_day, cmf.bhid , tradetype_close AS tradetype 
-- fix UR #10876 [begin]
--				FROM close_pos cp 
				FROM #tmp_close_pos cp 
-- fix UR #10876 [end]
					INNER  JOIN client_master_f cmf ON cp.cmid = cmf.cmid AND cp.aid = cmf.aid 
					INNER  JOIN #tmp_trade_cuid_chrg cc ON cp.cmid = cc.cmid AND cp.oid_close = cc.oid 
				WHERE cp.rflag = 'D' 
				AND oid_close IN ( SELECT oid FROM #temp_view_all_tradeh WHERE cmid = @P_cmid 
					-- excluding those correct trades not in current month 
					AND oid_close NOT IN (SELECT oid_new FROM #temp_view_correct_trade_tdate WHERE cmid = @p_cmid AND (MONTH(tdate)<> @m_month OR YEAR(tdate)<> @m_year))
--					and oid not in (select oid_new from ccrecord_client where cmid = @p_cmid )
					-- excluding those correct trades not in current month 

					AND tradetype NOT IN ('2','E','V','W','Y','Z','P','Q','T','U'))
					AND MONTH(cp.date) = @m_month AND YEAR(cp.date) = @m_year 
				GROUP BY cp.cmid, oid_close , group_o_close,cp.aeid, cp.aid, mkid, ISNULL(cc.cuid_chrg,cp.cuid_chrg) , ctid_close , price_close ,cmf.bhid , tradetype_close 
			) u
			--GROUP BY cmid, aeid, aid, mkid, cuid_chrg, ctid	, bhid
			-----------------------------------------------------------------1

		
			-----------------------------------------------------------------2
			-- CLOSE POSITION FOR NIGHT TRADE
			INSERT INTO #tmp_qty
			SELECT cmid, oid ,group_o, aeid, aid, mkid, cuid_chrg, ctid, 
			0 AS qty_day, qty_night AS qty_night, 0 AS qty_tg,
			0 AS m_qty_day, 0 AS m_qty_night, 0 AS m_qty_tg,
			0 AS comm, 0 AS exchange_fee, 0 AS levy, 0 AS rebate,
			0 AS m_comm, 0 AS m_exchange_fee, 0 AS m_levy, 0 AS m_rebate, 
			bhid , tradetype 	
			FROM
			(
				SELECT DISTINCT cp.cmid, cp.oid_open AS oid, cp.group_o_open AS group_o,ISNULL(dh.aeid, cp.aeid) AS aeid, cp.aid, cp.mkid, 
						ISNULL(cc.cuid_chrg,cp.cuid_chrg) AS cuid_chrg, cp.ctid, price_open AS price,
						SUM(cp.qty) AS qty_night, cmf.bhid , dh.tradetype 
-- fix UR #10876 [begin]
--				FROM close_pos cp
				FROM #tmp_close_pos cp
-- fix UR #10876 [end]
					INNER  JOIN client_master_f cmf ON cp.cmid = cmf.cmid AND cp.aid = cmf.aid 
					INNER  JOIN #temp_view_all_tradeh dh ON cp.oid_open = dh.oid AND dh.cmid = cp.cmid
-- fix UR #10876 [begin] -- not use ??
--					INNER  JOIN #temp_view_all_traded dd ON dh.oid = dd.oid AND dd.group_o = cp.group_o_open 
-- fix UR #10876 [end]
					INNER  JOIN #tmp_trade_cuid_chrg cc ON cp.cmid = cc.cmid AND cp.oid_open = cc.oid 
				WHERE rflag_open = 'N' 
				AND oid_open IN ( SELECT oid FROM #temp_view_all_tradeh WHERE cmid = @P_cmid 
					-- excluding those correct trades not in current month 
					AND oid_open NOT IN (SELECT oid_new FROM #temp_view_correct_trade_tdate WHERE cmid = @p_cmid AND (MONTH(tdate)<> @m_month OR YEAR(tdate)<> @m_year))
--					and oid not in (select oid_new from ccrecord_client where cmid = @p_cmid )
					-- excluding those correct trades not in current month 

					AND tradetype NOT IN ('2','E','V','W','Y','Z','P','Q','T','U'))
					AND MONTH(dh.tdate) = @m_month AND YEAR(dh.tdate) = @m_year 
				GROUP BY cp.cmid, cp.oid_open, group_o_open,  dh.aeid, cp.aeid, cp.aid, cp.mkid, 
					ISNULL(cc.cuid_chrg,cp.cuid_chrg), cp.ctid, price_open, cmf.bhid , dh.tradetype 	
			
			
				UNION ALL
			
				SELECT DISTINCT cp.cmid, oid_close AS oid, group_o_close AS group_o, vae.aeid, cp.aid, mkid, 
						ISNULL(cc.cuid_chrg,cp.cuid_chrg) AS cuid_chrg, ctid_close AS ctid, price_close AS price,
						SUM(qty_close) AS qty_night, cmf.bhid , tradetype_close AS tradetype 
-- fix UR #10876 [begin]
--				FROM close_pos cp 
				FROM #tmp_close_pos cp 
-- fix UR #10876 [end]
					INNER  JOIN #temp_view_order_aeid vae ON cp.cmid = vae.cmid AND cp.oid_close = vae.oid 
					INNER  JOIN client_master_f cmf ON cp.cmid = cmf.cmid AND cp.aid = cmf.aid 	
					INNER  JOIN #tmp_trade_cuid_chrg cc ON cp.cmid = cc.cmid AND cp.oid_close = cc.oid 
				WHERE cp.rflag = 'N'
				AND oid_close IN ( SELECT oid FROM #temp_view_all_tradeh WHERE cmid = @P_cmid 
					-- excluding those correct trades not in current month 
					AND oid_close NOT IN (SELECT oid_new FROM #temp_view_correct_trade_tdate WHERE cmid = @p_cmid AND (MONTH(tdate)<> @m_month OR YEAR(tdate)<> @m_year))
--					and oid not in (select oid_new from ccrecord_client where cmid = @p_cmid )
					-- excluding those correct trades not in current month 

					AND tradetype NOT IN ('2','E','V','W','Y','Z','P','Q','T','U'))
					AND MONTH(cp.date) = @m_month AND YEAR(cp.date) = @m_year 
				GROUP BY  cp.cmid, oid_close , group_o_close,vae.aeid, cp.aid, mkid, ISNULL(cc.cuid_chrg,cp.cuid_chrg) , ctid_close , price_close ,cmf.bhid , tradetype_close
			) u
			--GROUP BY cmid, aeid, aid, mkid, cuid_chrg, ctid, bhid 
			-----------------------------------------------------------------2
			
		
			-----------------------------------------------------------------3
			-- DAILY TRADE FOR T / G TRADE
			INSERT INTO #tmp_qty
			SELECT dthd.cmid, dthd.oid, dtd.group_o, dthd.aeid, dthd.aid, mkid, cuid_chrg, ctid, 
			0 AS qty_day, 0 AS qty_night, qty AS qty_tg,
			0 AS m_qty_day, 0 AS m_qty_night, 0 AS m_qty_tg,
			0 AS comm, 0 AS exchange_fee, 0 AS levy, 0 AS rebate,	
			0 AS m_comm, 0 AS m_exchange_fee, 0 AS m_levy, 0 AS m_rebate,
			cmf.bhid , dthd.tradetype 
			FROM #temp_view_all_tradeh dthd, #temp_view_all_traded dtd , client_master_f cmf
			WHERE dtd.oid = dthd.oid AND dthd.cmid = cmf.cmid AND dthd.aid = cmf.aid 
			AND (tradetype = '1' OR tradetype = '2') --AND tradetype <> '2' 
			AND MONTH(dthd.tdate) = @m_month AND YEAR(dthd.tdate) = @m_year 			
			-----------------------------------------------------------------3
-- fix UR #11473 [end]		



--BEGIN 20130204 UR#10876 Monthend report 1136D - A/E ACTIVITIES (COMMISSION & REBATE) hangs
-- Comment: by this UR#10876, the left join changed to inner join, refering to the UR#6324
-- Also , all joinings of views became to joinings of temp tables
--End 20130204 UR#10876 Monthend report 1136D - A/E ACTIVITIES (COMMISSION & REBATE) hangs
  	--select 'AFTER AUTO-LIQUIDATION AND AFTER DAY END'
	SELECT od.cmid,ae.aeid, ae.aeno,ae.name ae_name,
	oid,group_o,RTRIM(acct) AS acct,ae.market,ae.ccy,comdy_code,
	dec_loc,MONTH,put_call,s_price,price_str,s_price_str,future_type,
	TYPE, 
	RTRIM(CONVERT(CHAR(15), tdate, 3)) AS tdate,
	qty_day,qty_night,qty_tg, comm, exchange_fee,levy, rebate,
	m_qty_day, m_qty_night,m_qty_tg, m_comm,m_exchange_fee, m_levy, m_rebate,
	bhid, ae.tradetype,
	@P_vdate_b AS tranxdate_b,
	@P_vdate_e AS tranxdate_e  
--into tmp_rpt14 
--select * 
	FROM #tmp_active_ae_wt_tradetype ae --where aeno ='S55052'
	LEFT OUTER JOIN (
--	from (
	
	  	SELECT 
		u.cmid, u.oid,u.group_o, aeno, am.name AS ae_name, RTRIM(clm.accno) + ' ' + clm.name_1 AS acct, 
		'(' + RTRIM(mm.name_s) + ')' + RTRIM(mm.name) AS market, cm.name_s AS ccy, 
--		RTRIM(cdm.code) AS comdy_code,
		CASE cdm.ptype WHEN '4' THEN RTRIM(lme.LME_code) ELSE RTRIM(lme.com_code) END AS comdy_code,
		cdm.dec_loc AS dec_loc,  
		CASE cdm.ptype WHEN '4' THEN '' ELSE MONTH END AS MONTH , 
--		month, 
		post AS put_call, 
		CASE WHEN post='1' OR post='2' THEN strike_price ELSE fee.price END AS s_price,
		
		CASE dec_loc WHEN 0 THEN CONVERT(VARCHAR,CONVERT(REAL,fee.price)) 
		WHEN 1 THEN CONVERT(VARCHAR,CONVERT(DECIMAL(18,1), fee.price))
		WHEN 2 THEN CONVERT(VARCHAR,CONVERT(DECIMAL(18,2), fee.price))
		WHEN 3 THEN CONVERT(VARCHAR,CONVERT(DECIMAL(18,3), fee.price))
		WHEN 4 THEN CONVERT(VARCHAR,CONVERT(DECIMAL(18,4), fee.price))
		WHEN 5 THEN CONVERT(VARCHAR,CONVERT(DECIMAL(18,5), fee.price))
		WHEN 6 THEN CONVERT(VARCHAR,CONVERT(DECIMAL(18,6), fee.price))
		END AS price_str,
		CASE dec_loc WHEN 0 THEN CONVERT(VARCHAR,CONVERT(REAL,fee.s_price)) 
		WHEN 1 THEN CONVERT(VARCHAR,CONVERT(DECIMAL(18,1), fee.s_price))
		WHEN 2 THEN CONVERT(VARCHAR,CONVERT(DECIMAL(18,2), fee.s_price))
		WHEN 3 THEN CONVERT(VARCHAR,CONVERT(DECIMAL(18,3), fee.s_price))
		WHEN 4 THEN CONVERT(VARCHAR,CONVERT(DECIMAL(18,4), fee.s_price))
		WHEN 5 THEN CONVERT(VARCHAR,CONVERT(DECIMAL(18,5), fee.s_price))
		WHEN 6 THEN CONVERT(VARCHAR,CONVERT(DECIMAL(18,6), fee.s_price))
		END AS s_price_str,
		CASE WHEN post='1' OR post='2' THEN '1' ELSE '0' END AS future_type,
		dd.type AS TYPE,
		CONVERT(DATETIME, CONVERT(CHAR(15), dd.tdate, 3), 3)  AS tdate,
		SUM(u.qty_day) AS qty_day, SUM(u.qty_night) AS qty_night, SUM(u.qty_tg) AS qty_tg,
		--fee.comm + fee.exchange_fee AS comm, fee.exchange_fee AS exchange_fee, fee.rebate AS rebate,
		fee.comm AS comm, fee.exchange_fee AS exchange_fee, fee.levy AS levy, fee.rebate AS rebate,
	--	CASE WHEN post='1' or post='2' THEN fee.price_str ELSE '-' END as premium,
		0 AS m_comm, 0 AS m_exchange_fee, 0 AS m_levy, 0 AS m_rebate,
		0 AS m_qty_day, 0 AS m_qty_night, 0 AS m_qty_tg,
	--m_qty_day AS m_qty_day, m_qty_night AS m_qty_night, m_qty_tg AS m_qty_tg,
	--m_comm AS m_comm, m_exchange_fee AS m_exchange_fee, m_rebate AS m_rebate,
		--SUM(m_qty_day) AS m_qty_day, SUM(m_qty_night) AS m_qty_night, SUM(m_qty_tg) AS m_qty_tg,
		--SUM(m_comm) AS m_comm, SUM(m_exchange_fee) AS m_exchange_fee,SUM(m_rebate) AS m_rebate,
		u.bhid ,
		CASE WHEN u.tradetype ='L' THEN '0' ELSE u.tradetype END AS tradetype,
		u.mkid,u.cuid_chrg ,
		mm.name_s AS mkt 
-- fix UR #11473 [begin]	
		FROM 
		(
			SELECT	cmid, oid, group_o, aeid, aid, mkid, cuid_chrg, ctid, 
					qty_day, qty_night, qty_tg,
					m_qty_day, m_qty_night, m_qty_tg,
					comm, exchange_fee, rebate,	
					m_comm, m_exchange_fee, m_levy, m_rebate,
					bhid , tradetype 
			FROM	#tmp_qty
		) u, #temp_view_LME_promptdate LME ,
-- fix UR #11473 [end]
		ae_master am, client_master clm,
		market_master mm, currency_master cm,
		commod_master cdm, contract_master ctm,
		#temp_view_total_order_fees  fee,
		#temp_view_all_tradeh dd
		WHERE u.cmid =  fee.cmid
		AND u.ctid = lme.ctid 
		AND u.aeid= fee.aeid
		AND u.oid = fee.oid
		AND u.group_o = fee.group_o
		AND u.oid =dd.oid
		AND am.aeid = u.aeid
		AND clm.aid = u.aid
		AND mm.mkid = u.mkid
		AND cm.cuid = u.cuid_chrg
		AND ctm.ctid = u.ctid
		AND ctm.cyid = cdm.cyid
	
		AND u.cmid = @P_cmid
	
		AND ((@p_mkName_s_begin IS NULL AND @p_mkName_s_end IS NULL)
			OR (mm.name_s >= @p_mkName_s_begin AND mm.name_s <= @p_mkName_s_end))
	
		AND ((@p_AEno_begin IS NULL AND @p_AEno_end IS NULL)
			OR (am.aeno >= @p_AEno_begin AND am.aeno <= @p_AEno_end))
		GROUP BY 
		u.cmid, u.oid, u.group_o, aeno, accno, am.name, clm.accno, clm.name_1, mm.name_s, mm.name, cm.name_s, cdm.code, MONTH, post, dd.type , dd.tdate,
		fee.comm, fee.exchange_fee, fee.levy, fee.rebate,fee.price, fee.price_str,fee.s_price_str, strike_price,u.bhid, cdm.dec_loc,fee.s_price,
		u.tradetype, u.mkid, u.cuid_chrg , mm.name_s ,
		CASE cdm.ptype WHEN '4' THEN RTRIM(lme.LME_code) ELSE RTRIM(lme.com_code) END , cdm.ptype 	
		
	) od 
	ON od.aeno= ae.aeno AND ae.cmid = od.cmid AND ae.tradetype = od.tradetype AND ae.mkid = od.mkid AND ae.cuid_chrg = od.cuid_chrg 
WHERE ae.trade_month = @m_month 
AND ae.trade_year = @m_year 
AND ae.cmid =@P_cmid	
AND ((@p_mkName_s_begin IS NULL AND @p_mkName_s_end IS NULL)
		OR (od.mkt >= @p_mkName_s_begin AND od.mkt <= @p_mkName_s_end))
	AND ((@p_AEno_begin IS NULL AND @p_AEno_end IS NULL)
		OR (ae.aeno >= @p_AEno_begin AND ae.aeno <= @p_AEno_end))
	AND ((@vdate_begin IS NULL AND @vdate_end IS NULL)
		OR  tdate >= @vdate_begin AND  tdate <= @vdate_end)

ORDER BY

ae.aeno, ae.market, od.acct, od.comdy_code, tdate, od.month, od.oid, od.put_call, od.s_price



--BEGIN 20130204 UR#10876 Monthend report 1136D - A/E ACTIVITIES (COMMISSION & REBATE) hangs
--END

--RETURN
--END 20130204 UR#10876 Monthend report 1136D - A/E ACTIVITIES (COMMISSION & REBATE) hangs
*/


-- fix UR#13173 [begin]
/*
SELECT * INTO #tmp_view_active_ae_wt_tradetype 
FROM view_active_ae_wt_tradetype
WHERE cmid = @P_cmid
AND trade_month = @m_month 
AND trade_year = @m_year
*/
-- fix UR#13173 [end]

SELECT * INTO #tmp_view_LME_promptdate FROM view_LME_promptdate


DECLARE @P_flag CHAR(1)

SELECT @P_flag = '2'

CREATE TABLE #TMP_TRADE_QTY (
	cmid	char(10),
	oid	char(10),
	group_o	char(10),
	qty_day	decimal(18,0),
	qty_night	decimal(18,0),
	qty_tg	decimal(18,0),
	flag	char(1)
)

CREATE TABLE #TMP_TRADE (
	cmid	char(10),
	oid	char(10),
	aeid	char(10),
	aid	char(10),
	ctid	char(10),
-- fix UR#13173 [begin]
	mkid	char(10),
-- fix UR#13173 [end]
	cuid_chrg	char(10),
	tradetype	char(1),
	type	char(1),
	tdate	datetime
)


CREATE TABLE #TMP_TRADE_D (
	oid	char(10),
	price	decimal(12,6),
	group_o	char(10)
)


-- fix UR#13173 [begin]
INSERT INTO #TMP_TRADE EXEC rpt_GetTrade @P_cmid, @P_month, @P_temp, @vdate_begin, @vdate_end, @P_flag
-- fix UR#13173 [end]

INSERT INTO #TMP_TRADE_QTY EXEC rpt_ReturnClosedQty @P_cmid, @P_month, @P_temp, @vdate_begin, @vdate_end, @P_flag


SELECT	cmid, oid, group_o,
	SUM(qty_day) AS qty_day,
	SUM(qty_night) AS qty_night,
	SUM(qty_tg) AS qty_tg
INTO	#TMP_TRADE_QTY_FINAL
FROM	#TMP_TRADE_QTY
GROUP BY cmid, oid, group_o


-- fix UR#13173 [begin]
/*
INSERT INTO #TMP_TRADE
SELECT a.cmid, a.oid, a.aeid, a.aid, a.ctid, a.cuid_chrg, a.tradetype, a.type, a.tdate
FROM daycltradehd a
INNER JOIN (SELECT DISTINCT cmid, oid FROM #TMP_TRADE_QTY) b ON b.cmid = a.cmid AND b.oid = a.oid

INSERT INTO #TMP_TRADE
SELECT a.cmid, a.oid, a.aeid, a.aid, a.ctid, a.cuid_chrg, a.tradetype, a.type, a.tdate
FROM histcltradeh a
INNER JOIN (SELECT DISTINCT cmid, oid FROM #TMP_TRADE_QTY) b ON b.cmid = a.cmid AND b.oid = a.oid

INSERT INTO #TMP_TRADE_D
SELECT a.oid, a.price, a.group_o
FROM daycltraded a
INNER JOIN (SELECT DISTINCT oid FROM #TMP_TRADE_QTY) b ON b.oid = a.oid

INSERT INTO #TMP_TRADE_D
SELECT a.oid, a.price, a.group_o
FROM histcltraded a
INNER JOIN (SELECT DISTINCT oid FROM #TMP_TRADE_QTY) b ON b.oid = a.oid


SELECT	a.oid, a.group_o,
	SUM(a.comm) AS comm, SUM(a.exchange_fee) AS exchange_fee, 
	SUM(a.levy) AS levy, SUM(ABS(a.rebate)) AS rebate
INTO #tmp_view_order_fees
FROM view_total_fees_with_group_o a
INNER JOIN #TMP_TRADE_QTY b ON b.oid = a.oid AND b.group_o = a.group_o
WHERE b.cmid = @P_cmid
GROUP BY a.oid, a.group_o


-- GENERATE RECORDSET
	SELECT	ae.cmid, ae.aeid, ae.aeno, ae.name AS ae_name,
		oid, group_o, RTRIM(acct) AS acct,ae.market,ae.ccy,comdy_code,
		dec_loc, [MONTH],put_call,s_price,price_str,s_price_str,future_type,
		TYPE, RTRIM(CONVERT(CHAR(15), tdate, 3)) AS tdate,
		qty_day,qty_night,qty_tg, comm, exchange_fee, rebate,
		m_qty_day, m_qty_night,m_qty_tg, m_comm,m_exchange_fee, m_rebate,
		bhid, od.tradetype,
		@P_vdate_b AS tranxdate_b,
		@P_vdate_e AS tranxdate_e  

	FROM #tmp_view_active_ae_wt_tradetype ae
	LEFT OUTER JOIN 
	(
	  	SELECT	u.cmid, dd.aeid, cdm.mkid, dd.cuid_chrg, 
			u.oid, u.group_o, RTRIM(clm.accno) + ' ' + clm.name_1 AS acct,
			CASE cdm.ptype WHEN '4' THEN RTRIM(lme.LME_code) ELSE RTRIM(lme.com_code) END AS comdy_code,
			cdm.dec_loc AS dec_loc, [MONTH], post AS put_call,
			CASE WHEN post='1' OR post='2' THEN strike_price ELSE 0 END AS s_price,
			CASE cdm.dec_loc WHEN 0 THEN CONVERT(VARCHAR,CONVERT(REAL,dt.price)) 
				WHEN 1 THEN CONVERT(VARCHAR,CONVERT(DECIMAL(18,1), dt.price))
				WHEN 2 THEN CONVERT(VARCHAR,CONVERT(DECIMAL(18,2), dt.price))
				WHEN 3 THEN CONVERT(VARCHAR,CONVERT(DECIMAL(18,3), dt.price))
				WHEN 4 THEN CONVERT(VARCHAR,CONVERT(DECIMAL(18,4), dt.price))
				WHEN 5 THEN CONVERT(VARCHAR,CONVERT(DECIMAL(18,5), dt.price))
				WHEN 6 THEN CONVERT(VARCHAR,CONVERT(DECIMAL(18,6), dt.price))
			END AS price_str,
			CASE cdm.dec_loc WHEN 0 THEN CONVERT(VARCHAR,CONVERT(REAL,ctm.strike_price)) 
				WHEN 1 THEN CONVERT(VARCHAR,CONVERT(DECIMAL(18,1), ctm.strike_price))
				WHEN 2 THEN CONVERT(VARCHAR,CONVERT(DECIMAL(18,2), ctm.strike_price))
				WHEN 3 THEN CONVERT(VARCHAR,CONVERT(DECIMAL(18,3), ctm.strike_price))
				WHEN 4 THEN CONVERT(VARCHAR,CONVERT(DECIMAL(18,4), ctm.strike_price))
				WHEN 5 THEN CONVERT(VARCHAR,CONVERT(DECIMAL(18,5), ctm.strike_price))
				WHEN 6 THEN CONVERT(VARCHAR,CONVERT(DECIMAL(18,6), ctm.strike_price))
			END AS s_price_str,
			CASE WHEN post='1' OR post='2' THEN '1' ELSE '0' END AS future_type,
			dd.type AS TYPE, dd.tdate,

			u.qty_day, u.qty_night, u.qty_tg,
			fee.comm, fee.exchange_fee, fee.levy, fee.rebate,

			0 AS m_qty_day, 0 AS m_qty_night, 0 AS m_qty_tg,
			0 AS m_comm, 0 AS m_exchange_fee, 0 AS m_levy, 0 AS m_rebate,

			clmf.bhid, dd.tradetype, cdm.ptype, mm.name_s AS mkt

		FROM #TMP_TRADE_QTY_FINAL u

		LEFT OUTER JOIN #TMP_TRADE dd ON u.oid = dd.oid 		
		LEFT OUTER JOIN #TMP_TRADE_D dt ON u.oid = dt.oid AND u.group_o = dt.group_o

		LEFT OUTER JOIN client_master clm ON dd.aid = clm.aid 
		LEFT OUTER JOIN contract_master ctm ON dd.ctid = ctm.ctid 
		LEFT OUTER JOIN commod_master cdm ON ctm.cyid = cdm.cyid 
		LEFT OUTER JOIN #tmp_view_LME_promptdate LME ON dd.ctid = lme.ctid 
		LEFT OUTER JOIN client_master_f clmf ON dd.cmid = clmf.cmid AND dd.aid = clmf.aid
		LEFT OUTER JOIN market_master mm ON cdm.mkid = mm.mkid 
		LEFT OUTER JOIN #tmp_view_order_fees fee ON u.oid = fee.oid AND u.group_o = fee.group_o  
	) od ON od.aeid= ae.aeid AND ae.cmid = od.cmid AND ae.tradetype = od.tradetype 
		AND ae.mkid = od.mkid AND ae.cuid_chrg = od.cuid_chrg 
	WHERE 
		

		((@p_mkName_s_begin IS NULL AND @p_mkName_s_end IS NULL)
			OR (od.mkt >= @p_mkName_s_begin AND od.mkt <= @p_mkName_s_end))
	AND	((@p_AEno_begin IS NULL AND @p_AEno_end IS NULL)
			OR (ae.aeno >= @p_AEno_begin AND ae.aeno <= @p_AEno_end))
	ORDER BY
		ae.aeno, ae.market, od.acct, od.comdy_code, tdate, od.month, od.oid, od.put_call, od.s_price
*/



SELECT	DISTINCT cmid, aeid, mkid, cuid_chrg, tradetype
INTO #tmp_view_active_ae_wt_tradetype
FROM #TMP_TRADE


INSERT INTO #TMP_TRADE_D
SELECT a.oid, a.price, a.group_o
FROM daycltraded a
INNER JOIN #TMP_TRADE b ON b.oid = a.oid

INSERT INTO #TMP_TRADE_D
-- fix UR#14406 [begin]
--SELECT a.oid, a.price, a.group_o
--FROM histcltraded a
--INNER JOIN #TMP_TRADE b ON b.oid = a.oid
SELECT DISTINCT a.oid, a.price, a.group_o
FROM histcltraded a
INNER JOIN #TMP_TRADE b ON b.oid = a.oid
WHERE RTRIM(a.cnid)=''
-- fix UR#14406 [end]


SELECT	a.oid, a.group_o,
		SUM(a.comm) AS comm, SUM(a.exchange_fee) AS exchange_fee, 
		SUM(a.levy) AS levy, SUM(ABS(a.rebate)) AS rebate
INTO #tmp_view_order_fees
FROM view_total_fees_with_group_o a
INNER JOIN #TMP_TRADE b ON b.oid = a.oid
WHERE b.cmid = @P_cmid
GROUP BY a.oid, a.group_o


-- GENERATE RECORDSET
	SELECT	ae.cmid, ae.aeid, aem.aeno, aem.name AS ae_name,
			-- UR#13759 [begin]
			--oid, group_o, RTRIM(acct) AS acct,
			CASE WHEN ttgm.userGrp <> '1' THEN 'S' + oid ELSE oid END AS oid,
			group_o, RTRIM(acct) AS acct,
			-- UR#13759 [end]
			'(' + RTRIM(mm.name_s) + ')' + RTRIM(mm.name) AS market,
			cm.name_s AS ccy,comdy_code,
			dec_loc, [MONTH],put_call,s_price,price_str,s_price_str,future_type,
			TYPE, RTRIM(CONVERT(CHAR(15), tdate, 3)) AS tdate,
-- fix UR#13755 [begin]
--			qty_day,qty_night,qty_tg, comm, exchange_fee, rebate,
--			m_qty_day, m_qty_night,m_qty_tg, m_comm,m_exchange_fee, m_rebate,
			qty_day,qty_night,qty_tg, comm, exchange_fee, levy, rebate,
			m_qty_day, m_qty_night,m_qty_tg, m_comm,m_exchange_fee,m_levy, m_rebate,
-- fix UR#13755 [end]
			od.bhid, od.tradetype,
			@P_vdate_b AS tranxdate_b,
			@P_vdate_e AS tranxdate_e  

	FROM #tmp_view_active_ae_wt_tradetype ae
	LEFT OUTER JOIN 
	(
	  	SELECT	u.cmid, dd.aeid, cdm.mkid, dd.cuid_chrg, 
			u.oid, u.group_o, RTRIM(clm.accno) + ' ' + clm.name_1 AS acct,
			CASE cdm.ptype WHEN '4' THEN RTRIM(lme.LME_code) ELSE RTRIM(lme.com_code) END AS comdy_code,
			cdm.dec_loc AS dec_loc, [MONTH], post AS put_call,
			CASE WHEN post='1' OR post='2' THEN strike_price ELSE 0 END AS s_price,
			-- UR#14072 - BEGIN
			dbo.fn_GetFormattedPrice(dt.price, cdm.dec_loc, 'N') AS price_str,
			dbo.fn_GetFormattedPrice(ctm.strike_price, cdm.strike_dec, 'Y') AS s_price_str,
--			CASE cdm.dec_loc WHEN 0 THEN CONVERT(VARCHAR,CONVERT(REAL,dt.price)) 
--				WHEN 1 THEN CONVERT(VARCHAR,CONVERT(DECIMAL(18,1), dt.price))
--				WHEN 2 THEN CONVERT(VARCHAR,CONVERT(DECIMAL(18,2), dt.price))
--				WHEN 3 THEN CONVERT(VARCHAR,CONVERT(DECIMAL(18,3), dt.price))
--				WHEN 4 THEN CONVERT(VARCHAR,CONVERT(DECIMAL(18,4), dt.price))
--				WHEN 5 THEN CONVERT(VARCHAR,CONVERT(DECIMAL(18,5), dt.price))
--				WHEN 6 THEN CONVERT(VARCHAR,CONVERT(DECIMAL(18,6), dt.price))
--			END AS price_str,
--			CASE cdm.dec_loc WHEN 0 THEN CONVERT(VARCHAR,CONVERT(REAL,ctm.strike_price)) 
--				WHEN 1 THEN CONVERT(VARCHAR,CONVERT(DECIMAL(18,1), ctm.strike_price))
--				WHEN 2 THEN CONVERT(VARCHAR,CONVERT(DECIMAL(18,2), ctm.strike_price))
--				WHEN 3 THEN CONVERT(VARCHAR,CONVERT(DECIMAL(18,3), ctm.strike_price))
--				WHEN 4 THEN CONVERT(VARCHAR,CONVERT(DECIMAL(18,4), ctm.strike_price))
--				WHEN 5 THEN CONVERT(VARCHAR,CONVERT(DECIMAL(18,5), ctm.strike_price))
--				WHEN 6 THEN CONVERT(VARCHAR,CONVERT(DECIMAL(18,6), ctm.strike_price))
--			END AS s_price_str,
			-- UR#14072 - END
			CASE WHEN post='1' OR post='2' THEN '1' ELSE '0' END AS future_type,
			dd.type AS TYPE, dd.tdate,

			ISNULL(u.qty_day,0) AS qty_day, ISNULL(u.qty_night,0) AS qty_night, ISNULL(u.qty_tg,0) AS qty_tg,
			ISNULL(fee.comm,0) AS comm, ISNULL(fee.exchange_fee,0) AS exchange_fee, ISNULL(fee.levy,0) AS levy, ISNULL(fee.rebate,0) AS rebate,

			0 AS m_qty_day, 0 AS m_qty_night, 0 AS m_qty_tg,
			0 AS m_comm, 0 AS m_exchange_fee, 0 AS m_levy, 0 AS m_rebate,

			clmf.bhid, dd.tradetype, cdm.ptype

		FROM #TMP_TRADE dd
		LEFT OUTER JOIN #TMP_TRADE_QTY_FINAL u ON u.oid = dd.oid
		LEFT OUTER JOIN #TMP_TRADE_D dt ON u.oid = dt.oid AND u.group_o = dt.group_o

		LEFT OUTER JOIN client_master clm ON dd.aid = clm.aid 
		LEFT OUTER JOIN contract_master ctm ON dd.ctid = ctm.ctid 
		LEFT OUTER JOIN commod_master cdm ON ctm.cyid = cdm.cyid 
		LEFT OUTER JOIN #tmp_view_LME_promptdate LME ON dd.ctid = lme.ctid 
		LEFT OUTER JOIN client_master_f clmf ON dd.cmid = clmf.cmid AND dd.aid = clmf.aid
		LEFT OUTER JOIN #tmp_view_order_fees fee ON dd.oid = fee.oid AND u.group_o = fee.group_o  
	) od ON od.aeid= ae.aeid AND ae.cmid = od.cmid AND ae.tradetype = od.tradetype 
		AND ae.mkid = od.mkid AND ae.cuid_chrg = od.cuid_chrg 

	LEFT OUTER JOIN ae_master aem ON aem.cmid = ae.cmid AND aem.aeid = ae.aeid
	LEFT OUTER JOIN market_master mm ON mm.mkid = ae.mkid
	LEFT OUTER JOIN currency_master cm ON cm.cuid = ae.cuid_chrg
	-- UR#13759 [begin]
	LEFT JOIN trade_type_grp_master ttgm ON ttgm.tradetype = od.tradetype
	-- UR#13759 [end]

	WHERE 
		((@p_mkName_s_begin IS NULL AND @p_mkName_s_end IS NULL)
			OR (mm.name_s >= @p_mkName_s_begin AND mm.name_s <= @p_mkName_s_end))
	AND	((@p_AEno_begin IS NULL AND @p_AEno_end IS NULL)
			OR (aem.aeno >= @p_AEno_begin AND aem.aeno <= @p_AEno_end))
	ORDER BY
		aem.aeno, mm.name_s, od.acct, od.comdy_code, tdate, od.month, od.oid, od.put_call, od.s_price
-- fix UR#13173 [end]
-- fix UR#10927 [end]


IF (@@ERROR <>0)
 BEGIN
	SELECT eid AS Error  FROM ERROR_MESSAGE WHERE eid= '3100' /* DB system Error*/
	RETURN 
 END

RETURN

GO


