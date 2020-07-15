


/****** Object:  StoredProcedure [dbo].[s_Rpt_AccStat_TotalS]    Script Date: 2017/11/27 10:41:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*-- =============================================
-- Author : HugoLaw
-- Create date : 2017/11/27 16:19
-- Last update : 2017/11/27 10:47
-- Description : Search Procedure FOR AccStat_TotalS
-- ============================================= */

IF OBJECT_ID('[dbo].[s_Rpt_AccStat_TotalS]') > 0
BEGIN
	DROP PROCEDURE [dbo].[s_Rpt_AccStat_TotalS]
END
GO

CREATE PROCEDURE [dbo].[s_Rpt_AccStat_TotalS]	
	@g2sbDB nvarchar(100)
AS
BEGIN
	
	Set NOCOUNT ON;
    Set XACT_ABORT ON;

	DECLARE @sqlStr NVARCHAR(MAX)

	SET @sqlStr = '
	WITH first_addid AS
	(
		SELECT aid,
		   min(addid) AS addid
		FROM '+ @g2sbDB +'.[DBO].clientadd_master
		GROUP BY aid
	)'
	SET @sqlStr = @sqlStr + '
	,second_addid AS 
	(
		SELECT aid,
		   MIN(addid) AS addid
		FROM '+ @g2sbDB +'.[DBO].clientadd_master AS a
		WHERE (addid >
				 (SELECT MIN(addid)
				  FROM first_addid AS b
				  WHERE (a.aid = aid)))
		GROUP BY aid
	)'
	SET @sqlStr = @sqlStr + '
	,it_client_all_fee AS
	(
		SELECT clm.accno,clms.cmid
		FROM '+ @g2sbDB +'.[DBO].client_master AS clm
		INNER JOIN '+ @g2sbDB +'.[DBO].client_master_s AS clms ON clms.aid = clm.aid
		LEFT OUTER JOIN '+ @g2sbDB +'.[DBO].Client_Fee AS cfbp ON cfbp.aid = clms.aid
																	AND cfbp.cmid = clms.cmid
																	AND cfbp.fuid = 18
		LEFT OUTER JOIN '+ @g2sbDB +'.[DBO].fee_master AS feebp ON feebp.fid = cfbp.fid
		LEFT OUTER JOIN '+ @g2sbDB +'.[DBO].Client_Fee AS cfBi ON cfbi.aid = clms.aid
																	AND cfbi.cmid = clms.cmid
																	AND cfbi.fuid = 198
		LEFT OUTER JOIN '+ @g2sbDB +'.[DBO].fee_master AS feebi ON feebi.fid = cfbi.fid
		LEFT OUTER JOIN '+ @g2sbDB +'.[DBO].Client_Fee AS cfrp ON cfrp.aid = clms.aid
																	AND cfrp.cmid = clms.cmid
																	AND cfrp.fuid = 21
		LEFT OUTER JOIN '+ @g2sbDB +'.[DBO].fee_master AS feerp ON feerp.fid = cfrp.fid
		LEFT OUTER JOIN '+ @g2sbDB +'.[DBO].Client_Fee AS cfri ON cfri.aid = clms.aid
																	AND cfri.cmid = clms.cmid
																	AND cfri.fuid = 197
		LEFT OUTER JOIN '+ @g2sbDB +'.[DBO].fee_master AS feeri ON feeri.fid = cfri.fid
	)'
	SET @sqlStr = @sqlStr + '
	,it_client_all AS(
		SELECT clm.accno,
		   clms.date_close AS date_close,
		   (CASE clms.[type]
				WHEN ''2'' THEN ''Cash Account''
				WHEN ''1'' THEN ''Margin Account''
			END) AS client_type
		FROM '+ @g2sbDB +'.[DBO].client_master AS clm
			LEFT OUTER JOIN '+ @g2sbDB +'.[DBO].client_master_s AS clms ON clms.aid = clm.aid
			LEFT OUTER JOIN first_addid AS stadd ON stadd.aid = clm.aid
			LEFT OUTER JOIN '+ @g2sbDB +'.[DBO].clientadd_master AS clma ON clma.addid = stadd.addid
			LEFT OUTER JOIN second_addid AS ndadd ON ndadd.aid = clm.aid
			LEFT OUTER JOIN '+ @g2sbDB +'.[DBO].clientadd_master AS clma1 ON clma1.addid = ndadd.addid
			LEFT OUTER JOIN '+ @g2sbDB +'.[DBO].ae_master AS ae ON ae.aeid = clms.aeid
																	AND ae.cmid = clms.cmid
			LEFT OUTER JOIN '+ @g2sbDB +'.[DBO].client_bal AS bal ON bal.aid = clms.aid
																	AND bal.cmid = clms.cmid
			LEFT OUTER JOIN '+ @g2sbDB +'.[DBO].market_client AS mc ON mc.aid = clms.aid
														AND mc.cmid = clms.cmid
			LEFT OUTER JOIN '+ @g2sbDB +'.[DBO].suspense_master AS sus ON clm.spid = sus.spid
			LEFT OUTER JOIN '+ @g2sbDB +'.[DBO].category_master AS cat ON cat.cgid = clm.cgid
			LEFT OUTER JOIN '+ @g2sbDB +'.[DBO].staff_ae_ac AS rel ON clms.aid = rel.aid
																		AND clms.cmid = rel.cmid
			LEFT OUTER JOIN '+ @g2sbDB +'.[DBO].staff AS stf ON rel.stfid = stf.stfid
			LEFT OUTER JOIN '+ @g2sbDB +'.[DBO].ae_master AS relae ON rel.aeid = relae.aeid
																	AND rel.cmid = relae.cmid
			LEFT OUTER JOIN '+ @g2sbDB +'.[DBO].interest_class AS ic ON ic.icid = bal.icid
			LEFT OUTER JOIN '+ @g2sbDB +'.[DBO].Client_Fee AS cf ON cf.aid = clms.aid
																	AND cf.cmid = clms.cmid
																	AND cf.fuid = ''18''
			LEFT OUTER JOIN '+ @g2sbDB +'.[DBO].fee_master AS fee ON fee.fid = cf.fid
			LEFT OUTER JOIN '+ @g2sbDB +'.[DBO].currency_master AS cur ON cur.cuid = bal.cuid
			LEFT OUTER JOIN it_client_all_fee AS vwFee ON clm.accno = vwFee.accno
															AND clms.cmid = vwFee.cmid
			LEFT OUTER JOIN '+ @g2sbDB +'.[DBO].branch_master AS bh ON bh.cmid = clms.cmid
			AND bh.bhid = clms.bhid
			LEFT OUTER JOIN '+ @g2sbDB +'.[DBO].client_memo AS cme ON cme.aid = clm.aid
	)'



	SET @sqlStr = @sqlStr + '
	select client_type, status, count(1) as cnt 
						from (select client_type, case when date_close is null then ''Open'' else ''Closed'' end as status 
						FROM it_client_all) tmp 
						group by client_type, status order by client_type, status desc'
						
	PRINT @sqlStr

	EXECUTE  sp_ExecuteSql  @sqlStr
END



--select client_type, status, count(1) as cnt 
--                    from (
--					select 
--					CASE clms.[type] WHEN '2' THEN 'Cash' WHEN '1' THEN 'Margin' END AS client_type,
--					case when clms.date_close is null then 'Opened' else 'Closed' end as status 
--                    FROM G2SB_UAT.g2sb_dev.dbo.client_master AS clm
--						LEFT OUTER JOIN
--							G2SB_UAT.g2sb_dev.dbo.client_master_s AS clms
--						ON clms.aid = clm.aid) tmp 
--                    group by client_type, status order by client_type, status desc

--EXEC [dbo].[s_Rpt_AccStat_TotalS] 'G2BF_UAT.g2sb_dev'