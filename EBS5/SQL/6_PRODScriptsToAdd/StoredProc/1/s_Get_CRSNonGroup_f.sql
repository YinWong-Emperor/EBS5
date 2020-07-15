USE [ESL]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*-- =============================================
-- Author : HugoLaw
-- Create date : 2017/10/26 16:19
-- Last update : 2017/10/26 10:47
-- Description : Search Procedure FOR CRCDebitBalance
-- ============================================= */

IF OBJECT_ID('[dbo].[s_Get_CRSNonGroup_f]') > 0
BEGIN
	DROP PROCEDURE [dbo].[s_Get_CRSNonGroup_f]
END
GO

CREATE PROCEDURE [dbo].[s_Get_CRSNonGroup_f]
(
	@g2bDB nvarchar(100),
	@return_year INT
)
AS

	Set NOCOUNT ON;
    Set XACT_ABORT ON;

	DECLARE @sqlStr1 nvarchar(4000)
	DECLARE @sqlStr2 nvarchar(4000)
	DECLARE @sqlStr3 nvarchar(4000)
	DECLARE @sqlStr4 nvarchar(4000)
	DECLARE @sqlStr5 nvarchar(4000)
	DECLARE @sqlStr6 nvarchar(4000)
	DECLARE @sqlStr7 nvarchar(4000)
	DECLARE @sqlStr8 nvarchar(4000)
	DECLARE @sqlStr9 nvarchar(4000)
	DECLARE @sqlStr10 nvarchar(4000)
	
	--Truncate Table dbo.CRSAccountInfo
	DELETE FROM dbo.CRSAccountInfo WHERE accType = 'Futures'

	DECLARE @begindate varchar(20) ,@enddate varchar(20)
	SET @begindate = cast(@return_year AS varchar(5)) + '-01-01'
	SET @enddate = cast(@return_year AS varchar(5)) + '-12-31' 


	SET @sqlStr1 = '
		DECLARE @tran_error INT;
		SET @tran_error = 0;
		BEGIN TRY;
		BEGIN TRAN;
		WITH clm AS(
			select g2fcms.aid,
				  g2fcms.cmid,
				  g2fcm.accno,
				  g2fcm.nature,		  
				  g2fcm.name_1 AS name,
				  g2fcm.br_id,
				  g2fcms.date_close,
				  ISNULL(g2fcm.dob,''1900-01-01'') AS dob
				 FROM '+ @g2bDB +'.dbo.client_master g2fcm
				INNER JOIN '+ @g2bDB +'.dbo.client_master_f g2fcms ON g2fcms.aid=g2fcm.aid
				WHERE LTRIM(RTRIM( ISNULL(g2fcm.br_id,''''))) NOT IN ('''',''*'',''-'',''.'') AND (g2fcms.date_close >= ''' +@begindate+''' or g2fcms.date_close IS NULL)
		),
		first_addid AS
		(
			SELECT cm.aid,
				ISNULL(cam.addid, cm2.addid) AS addid
			FROM '+ @g2bDB +'.dbo.client_master cm
			LEFT JOIN '+ @g2bDB +'.dbo.clientadd_master cam ON cm.aid = cam.aid
															AND cm.name_1 = cam.contact_name
			LEFT JOIN
				(SELECT aid,
						RTRIM(CAST(MIN(CAST(addid AS INT)) AS CHAR(10))) AS addid
				FROM '+ @g2bDB +'.dbo.clientadd_master
				GROUP BY aid) cm2 ON cm.aid = cm2.aid
		),
		first_addr AS (
			SELECT stadd.aid,
					LTRIM(RTRIM(clma.phone_1)) AS phone_1,
					LTRIM(RTRIM(clma.phone_2)) AS phone_2,
					LTRIM(RTRIM(clma.phone_3)) AS phone_3,
					COALESCE(LTRIM(RTRIM(clma.addr_1)) + '' '' + LTRIM(RTRIM(clma.addr_2)) + '' '' + LTRIM(RTRIM(clma.addr_3)) + '' '' + LTRIM(RTRIM(clma.addr_4)) COLLATE DATABASE_DEFAULT,'''') AS addr
			FROM
				first_addid AS stadd 
				LEFT OUTER JOIN '+ @g2bDB +'.dbo.clientadd_master AS clma ON clma.addid  = stadd.addid
		)
		,second_addid AS 
		(
				SELECT a.aid, MIN(addid) AS addid
			FROM '+ @g2bDB +'.[DBO].clientadd_master AS a
			INNER JOIN clm ON clm.aid = a.aid
			WHERE (addid >
						(SELECT MIN(addid)
							FROM first_addid AS b
							WHERE (a.aid = b.aid)))
				GROUP BY a.aid
		)
		,second_addr AS (
			SELECT secadd.aid,
					COALESCE(LTRIM(RTRIM(clma.addr_1)) + '' '' + LTRIM(RTRIM(clma.addr_2)) + '' '' + LTRIM(RTRIM(clma.addr_3)) + '' '' + LTRIM(RTRIM(clma.addr_4)) COLLATE DATABASE_DEFAULT,'''') AS addr
			FROM
				second_addid AS secadd 
				LEFT OUTER JOIN '+ @g2bDB +'.dbo.clientadd_master AS clma ON clma.addid = secadd.addid
		),'
		SET @sqlStr2 = '
		vwcb AS 
		(
			SELECT vwcb.aid,
					clm.accno,
					vwcb.cuid,
					vwcb.bal
			FROM '+ @g2bDB +'.dbo.view_client_bal_for_CSV vwcb
			INNER JOIN clm ON vwcb.aid=clm.aid
		),
		vwcbfl AS
		(
			SELECT clm.aid,
						clm.accno,
						cm.name_s AS ccy,
						cm.cuid,
						vwcbfl.float_pl
				FROM '+ @g2bDB +'.dbo.client_bal vwcbfl
				INNER JOIN clm ON vwcbfl.aid = clm.aid
				INNER JOIN '+ @g2bDB +'.dbo.currency_master cm ON cm.cuid=vwcbfl.cuid
		),
		exrate AS
		(
			SELECT currency_in,
					ex_rate,
					''HKD'' AS targetbase
			FROM ESL.dbo.exchangerate
			WHERE tdate between ''' +@begindate+''' and ''' +@enddate+''' AND System_Type =''Futures'' 
			--WHERE System_Type =''Futures'' 
		),
		targetbaseexrate AS
		(
			SELECT currency_in,
					ex_rate AS targetrate
			FROM ESL.dbo.exchangerate
			WHERE tdate between ''' +@begindate+''' and ''' +@enddate+''' AND currency_in=''HKD'' AND System_Type =''Futures'' 
			--WHERE currency_in=''HKD'' AND System_Type =''Futures''
		),
		exrateprod AS
		(
			SELECT currma.cuid,
					exrate.currency_in,
					exrate.ex_rate / targetbaseexrate.targetrate AS targetrate
			FROM
				'+ @g2bDB +'.dbo.currency_master currma
			INNER JOIN  exrate ON currma.name_s = exrate.currency_in
			INNER JOIN
				targetbaseexrate ON exrate.targetbase = targetbaseexrate.currency_in
		),
		acbal AS(
			SELECT vwcb.aid,
				vwcb.accno,
				vwcb.cuid,
				SUM(vwcb.bal * exrateprod.targetrate) AS bal,
				SUM(vwcbfl.float_pl * exrateprod.targetRate) AS floatpl
				FROM
				vwcb
				LEFT OUTER JOIN
				vwcbfl ON vwcbfl.aid = vwcb.aid
				AND vwcbfl.cuid = vwcb.cuid
				INNER JOIN
				exrateprod ON exrateprod.cuid = vwcb.cuid
				GROUP BY vwcb.aid,
						vwcb.accno,
						vwcb.cuid
		),
		cb AS 
		(
			SELECT aid,
				ISNULL(ROUND(SUM(ISNULL(bal,0) + ISNULL(floatpl,0)),2), 0) AS acbal
				FROM
				acbal
				GROUP BY acbal.aid
		),'
		SET @sqlStr3 = '
		g2scm_ori AS
		(
			select 
				clm.aid,
				clm.cmid,
				clm.accno,
				clm.nature,       
				clm.name,
				clm.br_id,
				clm.date_close,
				clm.dob,
				staddr.addr as fst_addr,
				ISNULL(secddr.addr,'''') AS sec_addr,
				ISNULL(cb.acbal,0) AS acbal
			FROM clm
			LEFT OUTER JOIN first_addr AS staddr ON staddr.aid = clm.aid
			LEFT OUTER JOIN second_addr AS secddr ON secddr.aid = clm.aid
			LEFT OUTER JOIN cb ON cb.aid = clm.aid
		),'
		SET @sqlStr4 = '
		payment_union as(

				SELECT aid, 
					ISNULL(SUM(p.intAmt),0) + ISNULL(SUM(p.intAmtR),0) as intsum, 
					ISNULL(SUM(p.divAmt),0)+ ISNULL( SUM(p.divAmtR),0) AS divsum, 
					ISNULL(SUM(p.redemAmt),0)+ ISNULL(SUM(p.redemAmtR),0) AS redsum, 
					ISNULL( SUM(p.OtherAmt),0)+ ISNULL(SUM(p.OtherAmtR),0) AS othsum
				FROM (
					SELECT fmc.aid, fmc.vdate, fmc.amt AS intAmt, 0 AS intAmtR, 0 AS divAmt, 0 AS divAmtR, 0 AS redemAmt, 0 AS redemAmtR, 0 AS OtherAmt, 0 AS OtherAmtR, fmc.notes
						FROM '+ @g2bDB +'.dbo.fund_move_client fmc
						INNER JOIN (SELECT distinct type, lgid_cr, lgid_dr FROM '+ @g2bDB +'.dbo.tcode_master WHERE tcode in (''CPNC'', ''CPNM'')) tcm
							ON fmc.type= tcm.type AND fmc.lgid_cr = tcm.lgid_cr AND fmc.lgid_dr = tcm.lgid_dr
						WHERE fmc.aid in (select clm.aid from clm) and fmc.notes like ''%COUPON%''
					UNION ALL
					SELECT hf.aid, hf.vdate, hf.amt AS intAmt, 0 AS intAmtR, 0 AS divAmt, 0 AS divAmtR, 0 AS redemAmt, 0 AS redemAmtR, 0 AS OtherAmt, 0 AS OtherAmtR, hf.notes
						FROM '+ @g2bDB +'.dbo.histcl_fund hf
						INNER JOIN (SELECT distinct type, lgid_cr, lgid_dr FROM '+ @g2bDB +'.dbo.tcode_master WHERE tcode in (''CPNC'', ''CPNM'')) tcm
							ON hf.type= tcm.type AND hf.lgid_cr = tcm.lgid_cr AND hf.lgid_dr = tcm.lgid_dr
						WHERE hf.aid in (select clm.aid from clm) and  vdate between ''' +@begindate+''' and ''' +@enddate+'''
							AND hf.notes like ''%COUPON%''
					UNION ALL
					SELECT fmc.aid, fmc.vdate, 0 AS intAmt, fmc.amt AS intAmtR, 0 AS divAmt, 0 AS divAmtR, 0 AS redemAmt, 0 AS redemAmtR, 0 AS OtherAmt, 0 AS OtherAmtR, fmc.notes
						FROM '+ @g2bDB +'.dbo.fund_move_client fmc
						INNER JOIN (SELECT distinct type, lgid_cr, lgid_dr FROM '+ @g2bDB +'.dbo.tcode_master WHERE tcode in (''CPNRC'', ''CPNRM'')) tcm
							ON fmc.type= tcm.type AND fmc.lgid_cr = tcm.lgid_cr AND fmc.lgid_dr = tcm.lgid_dr
						WHERE fmc.aid in (select clm.aid from clm) and  fmc.notes like ''%COUPON%''
					UNION ALL
					SELECT hf.aid, hf.vdate, 0 AS intAmt, hf.amt AS intAmtR, 0 AS divAmt, 0 AS divAmtR, 0 AS redemAmt, 0 AS redemAmtR, 0 AS OtherAmt, 0 AS OtherAmtR, hf.notes
						FROM '+ @g2bDB +'.dbo.histcl_fund hf
						INNER JOIN (SELECT distinct type, lgid_cr, lgid_dr FROM '+ @g2bDB +'.dbo.tcode_master WHERE tcode in (''CPNRC'', ''CPNRM'')) tcm
							ON hf.type= tcm.type AND hf.lgid_cr = tcm.lgid_cr AND hf.lgid_dr = tcm.lgid_dr
						WHERE hf.aid in (select clm.aid from clm) and  vdate between ''' +@begindate+''' and ''' +@enddate+'''
							AND hf.notes like ''%COUPON%'''
			SET @sqlStr5 = '
				UNION ALL
					SELECT fmc.aid, fmc.vdate, 0 AS intAmt, 0 AS intAmtR, fmc.amt AS divAmt, 0 AS divAmtR, 0 AS redemAmt, 0 AS redemAmtR, 0 AS OtherAmt, 0 AS OtherAmtR, fmc.notes
						FROM '+ @g2bDB +'.dbo.fund_move_client fmc
						INNER JOIN (SELECT distinct type, lgid_cr, lgid_dr FROM '+ @g2bDB +'.dbo.tcode_master WHERE tcode in (''DIVC'', ''DIVM'')) tcm
							ON fmc.type= tcm.type AND fmc.lgid_cr = tcm.lgid_cr AND fmc.lgid_dr = tcm.lgid_dr
						WHERE fmc.aid in (select clm.aid from clm) 
					UNION ALL
					SELECT hf.aid, hf.vdate, 0 AS intAmt, 0 AS intAmtR, hf.amt AS divAmt, 0 AS divAmtR, 0 AS redemAmt, 0 AS redemAmtR, 0 AS OtherAmt, 0 AS OtherAmtR, hf.notes
						FROM '+ @g2bDB +'.dbo.histcl_fund hf
						INNER JOIN (SELECT distinct type, lgid_cr, lgid_dr FROM '+ @g2bDB +'.dbo.tcode_master WHERE tcode in (''DIVC'', ''DIVM'')) tcm
							ON hf.type= tcm.type AND hf.lgid_cr = tcm.lgid_cr AND hf.lgid_dr = tcm.lgid_dr
						WHERE hf.aid in (select clm.aid from clm) and  vdate between ''' +@begindate+''' and ''' +@enddate+'''
					UNION ALL
					SELECT fmc.aid, fmc.vdate, 0 AS intAmt, 0 AS intAmtR, 0 AS divAmt, fmc.amt AS divAmtR, 0 AS redemAmt, 0 AS redemAmtR, 0 AS OtherAmt, 0 AS OtherAmtR, fmc.notes
						FROM '+ @g2bDB +'.dbo.fund_move_client fmc
						INNER JOIN (SELECT distinct type, lgid_cr, lgid_dr FROM '+ @g2bDB +'.dbo.tcode_master WHERE tcode in (''DIVRC'', ''DIVRM'')) tcm
							ON fmc.type= tcm.type AND fmc.lgid_cr = tcm.lgid_cr AND fmc.lgid_dr = tcm.lgid_dr
						WHERE fmc.aid in (select clm.aid from clm)
					UNION ALL
					SELECT hf.aid, hf.vdate, 0 AS intAmt, 0 AS intAmtR, 0 AS divAmt, hf.amt AS divAmtR, 0 AS redemAmt, 0 AS redemAmtR, 0 AS OtherAmt, 0 AS OtherAmtR, hf.notes
						FROM '+ @g2bDB +'.dbo.histcl_fund hf
						INNER JOIN (SELECT distinct type, lgid_cr, lgid_dr FROM '+ @g2bDB +'.dbo.tcode_master WHERE tcode in (''DIVRC'', ''DIVRM'')) tcm
							ON hf.type= tcm.type AND hf.lgid_cr = tcm.lgid_cr AND hf.lgid_dr = tcm.lgid_dr
						WHERE hf.aid in (select clm.aid from clm) and  vdate between ''' +@begindate+''' and ''' +@enddate+''''
			SET @sqlStr6 = '
				UNION ALL
					SELECT fmc.aid, fmc.vdate, 0 AS intAmt, 0 AS intAmtR, 0 AS divAmt, 0 AS divAmtR, fmc.amt AS redemAmt, 0 AS redemAmtR, 0 AS OtherAmt, 0 AS OtherAmtR, fmc.notes
						FROM '+ @g2bDB +'.dbo.fund_move_client fmc
						INNER JOIN (SELECT distinct type, lgid_cr, lgid_dr FROM '+ @g2bDB +'.dbo.tcode_master WHERE tcode in (''BRC'', ''BRM'')) tcm
							ON fmc.type= tcm.type AND fmc.lgid_cr = tcm.lgid_cr AND fmc.lgid_dr = tcm.lgid_dr
						WHERE fmc.aid in (select clm.aid from clm) and  fmc.notes like ''%REDEMPTION%''
					UNION ALL
					SELECT hf.aid, hf.vdate, 0 AS intAmt, 0 AS intAmtR, 0 AS divAmt, 0 AS divAmtR, hf.amt AS redemAmt, 0 AS redemAmtR, 0 AS OtherAmt, 0 AS OtherAmtR, hf.notes
						FROM '+ @g2bDB +'.dbo.histcl_fund hf
						INNER JOIN (SELECT distinct type, lgid_cr, lgid_dr FROM '+ @g2bDB +'.dbo.tcode_master WHERE tcode in (''BRC'', ''BRM'')) tcm
							ON hf.type= tcm.type AND hf.lgid_cr = tcm.lgid_cr AND hf.lgid_dr = tcm.lgid_dr
						WHERE hf.aid in (select clm.aid from clm) and  vdate between ''' +@begindate+''' and ''' +@enddate+'''
							AND hf.notes like ''%REDEMPTION%''
					UNION all
					SELECT fmc.aid, fmc.vdate, 0 AS intAmt, 0 AS intAmtR, 0 AS divAmt, 0 AS divAmtR, 0 AS redemAmt, fmc.amt AS redemAmtR, 0 AS OtherAmt, 0 AS OtherAmtR, fmc.notes
						FROM '+ @g2bDB +'.dbo.fund_move_client fmc
						INNER JOIN (SELECT distinct type, lgid_cr, lgid_dr FROM '+ @g2bDB +'.dbo.tcode_master WHERE tcode in (''BRRC'', ''BRRM'')) tcm
							ON fmc.type= tcm.type AND fmc.lgid_cr = tcm.lgid_cr AND fmc.lgid_dr = tcm.lgid_dr
						WHERE fmc.aid in (select clm.aid from clm) and  fmc.notes like ''%REDEMPTION%''
					UNION ALL
					SELECT hf.aid, hf.vdate, 0 AS intAmt, 0 AS intAmtR, 0 AS divAmt, 0 AS divAmtR, 0 AS redemAmt, hf.amt AS redemAmtR, 0 AS OtherAmt, 0 AS OtherAmtR, hf.notes
						FROM '+ @g2bDB +'.dbo.histcl_fund hf
						INNER JOIN (SELECT distinct type, lgid_cr, lgid_dr FROM '+ @g2bDB +'.dbo.tcode_master WHERE tcode in (''BRRC'', ''BRRM'')) tcm
							ON hf.type= tcm.type AND hf.lgid_cr = tcm.lgid_cr AND hf.lgid_dr = tcm.lgid_dr
						WHERE hf.aid in (select clm.aid from clm) and  vdate between ''' +@begindate+''' and ''' +@enddate+'''
							AND hf.notes like ''%REDEMPTION%'''
				SET @sqlStr7 = '
				UNION ALL
					SELECT fmc.aid, fmc.vdate, 0 AS intAmt, 0 AS intAmtR, 0 AS divAmt, 0 AS divAmtR, 0 AS redemAmt, 0 AS redemAmtR, fmc.amt AS OtherAmt, 0 AS OtherAmtR, fmc.notes
						FROM '+ @g2bDB +'.dbo.fund_move_client fmc
						INNER JOIN (SELECT distinct type, lgid_cr, lgid_dr FROM '+ @g2bDB +'.dbo.tcode_master WHERE tcode in (''HIC'', ''HIM'')) tcm
							ON fmc.type= tcm.type AND fmc.lgid_cr = tcm.lgid_cr AND fmc.lgid_dr = tcm.lgid_dr
						where fmc.aid in (select clm.aid from clm)
					UNION ALL
					SELECT hf.aid, hf.vdate, 0 AS intAmt, 0 AS intAmtR, 0 AS divAmt, 0 AS divAmtR, 0 AS redemAmt, 0 AS redemAmtR, hf.amt AS OtherAmt, 0 AS OtherAmtR, hf.notes
						FROM '+ @g2bDB +'.dbo.histcl_fund hf
						INNER JOIN (SELECT distinct type, lgid_cr, lgid_dr FROM '+ @g2bDB +'.dbo.tcode_master WHERE tcode in (''HIC'', ''HIM'')) tcm
							ON hf.type= tcm.type AND hf.lgid_cr = tcm.lgid_cr AND hf.lgid_dr = tcm.lgid_dr
						WHERE hf.aid in (select clm.aid from clm) and  vdate between ''' +@begindate+''' and ''' +@enddate+'''
					UNION ALL
					SELECT fmc.aid, fmc.vdate, 0 AS intAmt, 0 AS intAmtR, 0 AS divAmt, 0 AS divAmtR, 0 AS redemAmt, 0 AS redemAmtR, 0 AS OtherAmt, fmc.amt AS OtherAmtR, fmc.notes
						FROM '+ @g2bDB +'.dbo.fund_move_client fmc
						INNER JOIN (SELECT distinct type, lgid_cr, lgid_dr FROM '+ @g2bDB +'.dbo.tcode_master WHERE tcode in (''HIRC'', ''HIRM'')) tcm
							ON fmc.type= tcm.type AND fmc.lgid_cr = tcm.lgid_cr AND fmc.lgid_dr = tcm.lgid_dr
						where fmc.aid in (select clm.aid from clm)
					UNION ALL
					SELECT hf.aid, hf.vdate, 0 AS intAmt, 0 AS intAmtR, 0 AS divAmt, 0 AS divAmtR, 0 AS redemAmt, 0 AS redemAmtR, 0 AS OtherAmt, hf.amt AS OtherAmtR, hf.notes
						FROM '+ @g2bDB +'.dbo.histcl_fund hf
						INNER JOIN (SELECT distinct type, lgid_cr, lgid_dr FROM '+ @g2bDB +'.dbo.tcode_master WHERE tcode in (''HIRC'', ''HIRM'')) tcm
							ON hf.type= tcm.type AND hf.lgid_cr = tcm.lgid_cr AND hf.lgid_dr = tcm.lgid_dr
						WHERE hf.aid in (select clm.aid from clm) and  vdate between ''' +@begindate+''' and ''' +@enddate+'''
				) p
				GROUP BY aid
		)'
		SET @sqlStr8 = '
		,crs_clm AS(
				SELECT ''Futures'' AS AccType,'''+ CAST(@return_year AS VARCHAR(5)) + ''' AS RetrunYear, clm.accno AS Accno,clm.aid AS G2BAid ,clm.date_close AS CloseDate,
				(CASE clm.nature WHEN ''0'' THEN ''I'' WHEN ''1'' THEN ''J'' ELSE ''E'' END) AS CrsType,
				clm.name AS ClientName , SUBSTRING(clm.name,charindex('' '',clm.name),LEN(clm.name) - CHARINDEX('' '',clm.name) + 1) AS FirstName,
				SUBSTRING(clm.name,0,CHARINDEX('' '',clm.name)-1) AS LastName,(CASE WHEN clm.nature IN (''0'',''1'') THEN ''OECD202'' ELSE ''OECD207'' END) AS NameType,
				clm.br_id AS BR_ID,clm.dob AS BirthDate,clm.fst_addr + ''   '' + ISNULL(clm.sec_addr,'''') as AddressFree,
				(CASE WHEN 
				   Lower(fst_addr) like ''%hong kong%'' 
				   OR Lower(fst_addr) like ''%hongkong%'' 
				   OR RTRIM(REPLACE(REPLACE(RTRIM(Lower(fst_addr)), ''.'', ''''), '','', '''')) like ''%hk''
				   OR LTRIM(REPLACE(REPLACE(LTRIM(Lower(fst_addr)), ''.'', ''''), '','', '''')) like ''香港%''
				   OR Lower(fst_addr) like ''%kowloon%'' 
				   OR RTRIM(REPLACE(REPLACE(RTRIM(Lower(fst_addr)), ''.'', ''''), '','', '''')) like ''%kln''
				   OR LTRIM(REPLACE(REPLACE(LTRIM(Lower(fst_addr)), ''.'', ''''), '','', '''')) like ''九龍%''
				   OR RTRIM(REPLACE(REPLACE(RTRIM(Lower(fst_addr)), ''.'', ''''), '','', '''')) like ''%NT'' 
				   OR LTRIM(REPLACE(REPLACE(LTRIM(Lower(fst_addr)), ''.'', ''''), '','', '''')) like ''新界%''
				   OR RTRIM(REPLACE(REPLACE(RTRIM(Lower(fst_addr)), ''.'', ''''), '','', '''')) like ''%新界''
				THEN ''HK''
				WHEN 
				   Lower(sec_addr) like ''%hong kong%'' 
				   OR Lower(sec_addr) like ''%hongkong%'' 
				   OR RTRIM(REPLACE(REPLACE(RTRIM(Lower(sec_addr)), ''.'', ''''), '','', '''')) like ''%hk''
				   OR LTRIM(REPLACE(REPLACE(LTRIM(Lower(sec_addr)), ''.'', ''''), '','', '''')) like ''香港%''
				   OR Lower(sec_addr) like ''%kowloon%'' 
				   OR RTRIM(REPLACE(REPLACE(RTRIM(Lower(sec_addr)), ''.'', ''''), '','', '''')) like ''%kln''
				   OR LTRIM(REPLACE(REPLACE(LTRIM(Lower(sec_addr)), ''.'', ''''), '','', '''')) like ''九龍%''
				   OR RTRIM(REPLACE(REPLACE(RTRIM(Lower(sec_addr)), ''.'', ''''), '','', '''')) like ''%NT'' 
				   OR LTRIM(REPLACE(REPLACE(LTRIM(Lower(sec_addr)), ''.'', ''''), '','', '''')) like ''新界%''
				   OR RTRIM(REPLACE(REPLACE(RTRIM(Lower(sec_addr)), ''.'', ''''), '','', '''')) like ''%新界''
				   THEN ''HK''
				ELSE '''' END) AS AddressCountryCode,
				clm.acbal AS total_bal,
				pu.intsum as interest_amt,
				pu.divsum as dividend_amt,
				pu.redsum as redemption_amt,
				pu.othsum as other_amt
			FROM g2scm_ori as clm
			LEFT JOIN payment_union AS pu ON clm.aid = pu.aid
		)'
		SET @sqlStr9 = '
				
			INSERT INTO [dbo].[CRSAccountInfo]([AccType],[ReturnYear],[Accno],[CloseDate],[CrsType],[ClientName],[FirstName],[LastName],[NameType]
										,[BR_ID],[BirthDate],[AddressCountryCode],[AddressFree],[AccBal],[Dividend],[Interest],[Redemption],[OtherPayment])
			SELECT [AccType],[RetrunYear],RTRIM([Accno]),[CloseDate],[CrsType],[ClientName],[FirstName],[LastName],[NameType]
										,[BR_ID],[BirthDate],[AddressCountryCode],[AddressFree],total_bal,dividend_amt,interest_amt,redemption_amt,other_amt
			FROM crs_clm

			UPDATE [dbo].[CRSAccountInfo]
			SET	AccholderType = cm.AccholderType,
				ResCountryCode = cm.ResCountryCode,
				TIN = cm.TIN,
				TINIssueBy = cm.TINIssueBy,
				BirthCountryCode = cm.BirthCountryCode,
				BirthCity = cm.BirthCity,
				AddressCountryCode = cm.AddressCountryCode,
				LegalAddressType = (CASE WHEN ISNULL(cm.LegalAddressType,'''') = '''' THEN [dbo].[CRSAccountInfo].LegalAddressType ELSE cm.LegalAddressType END)
			FROM DBO.CRSMaster AS cm
			WHERE [dbo].[CRSAccountInfo].Accno = cm.Accno AND [dbo].[CRSAccountInfo].AccType = ''Futures'' AND cm.[CRSType] IN (''I'',''J'',''E'')

			INSERT INTO [dbo].[CRSMaster]([Accno],[AccType],[CrsType],[AddressCountryCode],[FirstName],[LastName],[AddressFree],[BirthDate])
			SELECT info.[Accno],info.[AccType],info.[CrsType],info.[AddressCountryCode],[FirstName],[LastName],[AddressFree],[BirthDate]
			FROM [dbo].[CRSAccountInfo] as info
			WHERE not exists (select 1 from [dbo].[CRSMaster] AS cm WHERE info.accType = cm.accType and info.Accno = cm.Accno) '
		SET @sqlStr10 = '
			INSERT INTO [dbo].[CRSAccountInfo]([AccType],[ReturnYear],[Accno],[CrsType],[ClientName],[FirstName],[LastName],[NameType],[CPType],[ResCountryCode],[TIN],[TINIssueBy]
											,[BirthDate],[BirthCountryCode],[BirthCity],[AddressCountryCode],[LegalAddressType],[AddressFree])
			SELECT cm.AccType,'''+ CAST(@return_year AS VARCHAR(5)) + ''' AS RetrunYear,cm.Accno,''CP'',cm.FirstName+'' ''+cm.LastName,cm.FirstName,cm.LastName ,''OECD202'',cm.CPType,cm.ResCountryCode,cm.TIN,cm.TINIssueBy,cm.BirthDate,cm.BirthCountryCode,
				cm.BirthCity,cm.AddressCountryCode,cm.LegalAddressType,cm.AddressFree
			FROM [dbo].[CRSMaster] as cm
			WHERE cm.CrsType = ''CP'' AND cm.accType = ''Futures''
			COMMIT; 
		END TRY
		BEGIN CATCH
			ROLLBACK ;
			SET @tran_error = @tran_error + 1;
			-- 返回异常值
			SELECT 
				  ERROR_NUMBER() AS [error]
				, ERROR_MESSAGE() AS [message]
				, ERROR_LINE() AS [ERROR_LINE]
				, ERROR_PROCEDURE() AS [ERROR_PROCEDURE]
				, ERROR_SEVERITY() AS [ERROR_SEVERITY]
		END CATCH
		IF(@tran_error = 0)
		BEGIN
			-- 返回正常值
			SELECT [Crs_id],[AccType],[ReturnYear],[Accno],[CloseDate],[CrsType],[ClientName],[FirstName],[LastName],[NameType]
				,[ResCountryCode],[TIN],[TINIssueBy],[BR_ID],[BirthDate],[BirthCountryCode],[AddressCountryCode],[LegalAddressType],[AddressFree]
				,[AccBal],[Dividend],[Interest],[Redemption],[OtherPayment],[BirthCity]
				,(CASE WHEN [CrsType] IN (''I'',''J'') THEN ''Individual'' ELSE  [AccHolderType] END) AS [AccHolderType]
				,(CASE [CrsType] WHEN ''I'' THEN ''Individual'' WHEN ''J'' THEN ''Joint'' WHEN ''E'' THEN ''Entity'' ELSE [CPType] END) AS [CPType]
			FROM [dbo].[CRSAccountInfo] WHERE accType = ''Futures'' 
		END
		'

		PRINT @sqlStr1 
		PRINT @sqlStr2 
		PRINT @sqlStr3 
		PRINT @sqlStr4
		PRINT @sqlStr5
		PRINT @sqlStr6 
		PRINT @sqlStr7 
		PRINT @sqlStr8
		PRINT @sqlStr9
		PRINT @sqlStr10

		EXEC(@sqlStr1 + @sqlStr2 + @sqlStr3 + @sqlStr4 + @sqlStr5 + @sqlStr6 + @sqlStr7 + @sqlStr8 + @sqlStr9 + @sqlStr10)


GO

--EXEC [dbo].[s_Get_CRSNonGroup_f] 'LinkedServer97.g2bf_dev',2017

