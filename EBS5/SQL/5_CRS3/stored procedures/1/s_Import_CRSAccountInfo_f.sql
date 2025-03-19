USE [ESL]
GO
DROP PROCEDURE IF EXISTS [dbo].[s_Import_CRSAccountInfo_f]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--EXEC [dbo].[s_Import_CRSAccountInfo_f] 2019
CREATE PROCEDURE [dbo].[s_Import_CRSAccountInfo_f]
	@year int
AS
BEGIN

declare @start_date date
declare @end_date date
declare @last_tdate date

SET @start_date = DATEADD(yy, @year - 1900, 0)
SET @end_date = DATEADD(yy, @year - 1900 + 1, -1)
SELECT TOP 1 @last_tdate = tdate FROM dbo.exchangerate WHERE tdate <= @end_date AND System_Type ='Futures' ORDER BY tdate desc;

BEGIN TRAN

	BEGIN TRY

		DELETE FROM [ESL].[dbo].[CRSAccountInfo]
		WHERE	ReturnYear = @year
		AND		AccType = 'Futures';

	WITH clm AS(
		select g2fcms.aid,
          g2fcms.cmid,
          g2fcm.accno,
		  g2fcm.nature,		  
		  g2fcm.name_1 AS name,
		  g2fcm.br_id,
		  g2fcms.date_open,
		  g2fcms.date_close,
		  ISNULL(g2fcm.dob,'1900-01-01') AS dob
		 FROM [G2FB_RET_LASTY].dbo.client_master g2fcm
		INNER JOIN [G2FB_RET_LASTY].dbo.client_master_f g2fcms ON g2fcms.aid=g2fcm.aid
		WHERE --ISNULL(g2fcms.date_close ,'') = '' AND 
		LTRIM(RTRIM( ISNULL(g2fcm.br_id,''))) NOT IN ('','*','-','.')
	),
	first_addid AS
	(
		SELECT cm.aid,
			ISNULL(cam.addid, cm2.addid) AS addid
		FROM [G2FB_RET_LASTY].dbo.client_master cm
		LEFT JOIN [G2FB_RET_LASTY].dbo.clientadd_master cam ON cm.aid = cam.aid
														AND cm.name_1 = cam.contact_name
		LEFT JOIN
			(SELECT aid,
					RTRIM(CAST(MIN(CAST(addid AS INT)) AS CHAR(10))) AS addid
			FROM [G2FB_RET_LASTY].dbo.clientadd_master
			GROUP BY aid) cm2 ON cm.aid = cm2.aid
	),
	first_addr AS (
		SELECT stadd.aid,
				LTRIM(RTRIM(clma.phone_1)) AS phone_1,
				LTRIM(RTRIM(clma.phone_2)) AS phone_2,
				LTRIM(RTRIM(clma.phone_3)) AS phone_3,
				COALESCE(LTRIM(RTRIM(clma.addr_1)) + ' ' + LTRIM(RTRIM(clma.addr_2)) + ' ' + LTRIM(RTRIM(clma.addr_3)) + ' ' + LTRIM(RTRIM(clma.addr_4)) COLLATE DATABASE_DEFAULT,'') AS addr
		FROM
			first_addid AS stadd 
			LEFT OUTER JOIN [G2FB_RET_LASTY].dbo.clientadd_master AS clma ON clma.addid  = stadd.addid
	)
	,second_addid AS 
	(
			SELECT a.aid, MIN(addid) AS addid
		FROM [G2FB_RET_LASTY].dbo.clientadd_master AS a
		INNER JOIN clm ON clm.aid = a.aid
		WHERE (addid >
					(SELECT MIN(addid)
						FROM first_addid AS b
						WHERE (a.aid = b.aid)))
			GROUP BY a.aid
	)
	,second_addr AS (
		SELECT secadd.aid,
				COALESCE(LTRIM(RTRIM(clma.addr_1)) + ' ' + LTRIM(RTRIM(clma.addr_2)) + ' ' + LTRIM(RTRIM(clma.addr_3)) + ' ' + LTRIM(RTRIM(clma.addr_4)) COLLATE DATABASE_DEFAULT,'') AS addr
		FROM
			second_addid AS secadd 
			LEFT OUTER JOIN [G2FB_RET_LASTY].dbo.clientadd_master AS clma ON clma.addid = secadd.addid
	),
	vwcb AS 
	(
		SELECT vwcb.aid,
                clm.accno,
                vwcb.cuid,
                vwcb.bal
        FROM [G2FB_RET_LASTY].dbo.view_client_bal_for_CSV vwcb
        INNER JOIN clm ON vwcb.aid=clm.aid
	),
	vwcbfl AS
	(
		SELECT clm.aid,
                    clm.accno,
                    cm.name_s AS ccy,
					cm.cuid,
                    vwcbfl.float_pl
            FROM [G2FB_RET_LASTY].dbo.client_bal vwcbfl
            INNER JOIN clm ON vwcbfl.aid = clm.aid
            INNER JOIN [G2FB_RET_LASTY].dbo.currency_master cm ON cm.cuid=vwcbfl.cuid
	),
	exrate AS
	(
		SELECT currency_in,
				ex_rate,
				'HKD' AS targetbase
		FROM dbo.exchangerate
		WHERE tdate=@last_tdate AND System_Type ='Futures' 
		--WHERE System_Type ='Futures' 
	),
	targetbaseexrate AS
	(
		SELECT currency_in,
                ex_rate AS targetrate
        FROM dbo.exchangerate
        WHERE tdate=@last_tdate AND currency_in='HKD' AND System_Type ='Futures' 
		--WHERE currency_in='HKD' AND System_Type ='Futures'
	),
	exrateprod AS
	(
		SELECT currma.cuid,
                exrate.currency_in,
                exrate.ex_rate / targetbaseexrate.targetrate AS targetrate
        FROM
			[G2FB_RET_LASTY].dbo.currency_master currma
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
	),
	payment_union AS (
		SELECT hf.aid,(CASE hf.[type] WHEN 0 THEN hf.amt * e.ex_rate  ELSE hf.amt * -1 * e.ex_rate  END) as amt,tm.tcode
		FROM [G2FB_RET_LASTY].dbo.histcl_fund AS hf
		INNER JOIN [G2FB_RET_LASTY].dbo.tcode_master AS tm ON hf.lgid_dr = tm.lgid_dr and hf.lgid_cr = tm.lgid_cr
		INNER JOIN clm ON hf.aid = clm.aid
		LEFT JOIN [G2FB_RET_LASTY].dbo.currency_master curr ON hf.cuid = curr.cuid 
		LEFT JOIN exrate e ON curr.name_s = e.currency_in
		WHERE tm.tcode IN ('CPNC', 'CPNRC', 'CPNM', 'CPNRM',
					'DIVC', 'DIVRC', 'DIVM', 'DIVRM',
					'BRC', 'BRRC', 'BRM', 'BRRM',
					'HIC', 'HIRC', 'HIM', 'HIRM')
		UNION ALL
		select fmc.aid,(CASE fmc.[type] WHEN 0 THEN fmc.amt * e.ex_rate ELSE fmc.amt * -1 * e.ex_rate END) as amt,tm.tcode
		FROM [G2FB_RET_LASTY].dbo.fund_move_client AS fmc
		INNER JOIN [G2FB_RET_LASTY].dbo.tcode_master AS tm ON fmc.lgid_dr = tm.lgid_dr and fmc.lgid_cr = tm.lgid_cr
		INNER JOIN clm ON fmc.aid = clm.aid
		LEFT JOIN [G2FB_RET_LASTY].dbo.currency_master curr ON fmc.cuid = curr.cuid 
		LEFT JOIN exrate e ON curr.name_s = e.currency_in
		WHERE tm.tcode IN ('CPNC', 'CPNRC', 'CPNM', 'CPNRM',
					'DIVC', 'DIVRC', 'DIVM', 'DIVRM',
					'BRC', 'BRRC', 'BRM', 'BRRM',
					'HIC', 'HIRC', 'HIM', 'HIRM')
		UNION ALL
		SELECT 
			hf.aid,
			(CASE hf.[type] WHEN 0 THEN hf.amt * e.ex_rate  ELSE hf.amt * -1 * e.ex_rate  END) as amt,
			'Dividend' AS tcode
		FROM [G2FB_RET_LASTY].dbo.histcl_fund hf
		LEFT JOIN clm on hf.aid = clm.aid
		LEFT JOIN [G2FB_RET_LASTY].dbo.currency_master curr ON hf.cuid = curr.cuid 
		LEFT JOIN dbo.exchangerate e ON e.tdate = @last_tdate AND system_type = 'Futures' AND currency_out = 'HKD' AND curr.name_s = e.currency_in
		WHERE
			hf.vdate between @start_date AND @end_date
			AND 
			(
				hf.notes like '%Dividend%' 
				OR  
				((hf.lgid_dr = 624 AND hf.lgid_cr = 421) OR (hf.lgid_dr = 421 AND hf.lgid_cr = 624) OR (hf.lgid_dr = 420 AND hf.lgid_cr = 624) OR (hf.lgid_dr = 624 AND hf.lgid_cr = 420))
			)
	)
	,interest_sum AS (
		SELECT aid as aid ,sum(amt) as amt
		FROM payment_union
		WHERE tcode in ('CPNC', 'CPNRC', 'CPNM', 'CPNRM')
		group by aid
	)
	,dividend_sum AS (
		SELECT aid as aid ,sum(amt) as amt
		FROM payment_union
		WHERE tcode in ('DIVC', 'DIVRC', 'DIVM', 'DIVRM','Dividend')
		group by aid
	)
	,redemption_sum AS (
		SELECT aid as aid ,sum(amt) as amt
		FROM payment_union
		WHERE tcode in ('BRC', 'BRRC', 'BRM', 'BRRM')
		group by aid
	)
	,other_sum AS (
		SELECT aid as aid ,sum(amt) as amt
		FROM payment_union
		WHERE tcode in ('HIC', 'HIRC', 'HIM', 'HIRM')
		group by aid
	),
	g2fcm_ori AS
	(
		select 
            clm.aid,
			clm.cmid,
			clm.accno,
            clm.nature,       
            clm.name,
            clm.br_id,
            clm.date_open,
            clm.date_close,
            clm.dob,
            staddr.phone_1 AS phone_1,
            staddr.phone_2 AS phone_2,
            staddr.phone_3 AS phone_3,
            staddr.addr as fst_addr,
            ISNULL(secddr.addr,'') AS sec_addr,
            ISNULL(cb.acbal,0) acbal,
			ISNULL(interest_sum.amt,0) as interest_amt,
			ISNULL(dividend_sum.amt,0) as dividend_amt,
			ISNULL(redemption_sum.amt,0) as redemption_amt,
			ISNULL(other_sum.amt,0) as other_amt
        FROM clm
		LEFT OUTER JOIN first_addr AS staddr ON staddr.aid = clm.aid
		LEFT OUTER JOIN second_addr AS secddr ON secddr.aid = clm.aid
		LEFT OUTER JOIN cb ON cb.aid = clm.aid
		LEFT JOIN interest_sum ON clm.aid = interest_sum.aid
		LEFT JOIN dividend_sum ON clm.aid = dividend_sum.aid
		LEFT JOIN redemption_sum ON clm.aid = redemption_sum.aid
		LEFT JOIN other_sum ON clm.aid = other_sum.aid
	),
	g2fcm AS (
		SELECT
			g2fcm.accno,
			g2fcm.name,
			g2fcm.br_id,
			g2fcm.date_open,
			g2fcm.date_close,
			g2fcm.dob,			
			g2fcm.phone_1,
			g2fcm.phone_2,
			g2fcm.phone_3,
			fst_addr,
			sec_addr,
			g2fcm.acbal			
		FROM g2fcm_ori AS g2fcm
	)	
	,sum_br AS (	
		SELECT MIN(ACCNO) as min_accno,count(BR_ID) as br_count,SUM(ACBAL) as sum_bal,BR_ID as br_id ,'Individual' as nature_s
		,stuff((SELECT ','+ RTRIM(b.accno) FROM clm as b WHERE b.br_id = g2fcm_ori.br_id AND  b.nature = '0'  FOR XML PATH('')),1,1,'') as other_accno,
		SUM(g2fcm_ori.interest_amt) AS interest_sum_amt,SUM(g2fcm_ori.dividend_amt) AS dividend_sum_amt,SUM(g2fcm_ori.redemption_amt) AS redemption_sum_amt,SUM(g2fcm_ori.other_amt) AS other_sum_amt 
		FROM g2fcm_ori
		WHERE g2fcm_ori.nature = '0'
		GROUP BY BR_ID
		UNION ALL
		SELECT MIN(ACCNO) as min_accno,count(BR_ID) as br_count,SUM(ACBAL) as sum_bal,BR_ID as br_id ,'Joint' as nature_s
		,stuff((SELECT ','+ RTRIM(b.accno) FROM clm as b WHERE b.br_id = g2fcm_ori.br_id AND  b.nature = '1'  FOR XML PATH('')),1,1,'') as other_accno,
		SUM(g2fcm_ori.interest_amt) AS interest_sum_amt,SUM(g2fcm_ori.dividend_amt) AS dividend_sum_amt,SUM(g2fcm_ori.redemption_amt) AS redemption_sum_amt,SUM(g2fcm_ori.other_amt) AS other_sum_amt 
		FROM g2fcm_ori
		WHERE g2fcm_ori.nature = '1'
		GROUP BY BR_ID
		UNION ALL
		SELECT MIN(ACCNO) as min_accno,count(BR_ID) as br_count,SUM(ACBAL) as sum_bal,BR_ID as br_id ,'Entity' as nature_s
		,stuff((SELECT ','+ RTRIM(b.accno) FROM clm as b WHERE b.br_id = g2fcm_ori.br_id AND  b.nature = '2'  FOR XML PATH('')),1,1,'') as other_accno,
		SUM(g2fcm_ori.interest_amt) AS interest_sum_amt,SUM(g2fcm_ori.dividend_amt) AS dividend_sum_amt,SUM(g2fcm_ori.redemption_amt) AS redemption_sum_amt,SUM(g2fcm_ori.other_amt) AS other_sum_amt 
		FROM g2fcm_ori
		WHERE g2fcm_ori.nature = '2'
		GROUP BY BR_ID
	)
, G2F_table as (
	SELECT sum_br.min_accno , 
			sum_br.nature_s,
			g2fcm.name,
			sum_br.br_id,
			g2fcm.date_open,
			g2fcm.date_close,
			g2fcm.dob,
			g2fcm.fst_addr,
			sum_br.sum_bal AS total_bal,
			sum_br.interest_sum_amt,
			sum_br.dividend_sum_amt,
			sum_br.redemption_sum_amt,
			sum_br.other_sum_amt
	FROM sum_br
	LEFT JOIN g2fcm ON sum_br.min_accno = g2fcm.accno 	
	where (ISNULL(g2fcm.date_close ,'') = '' or year(g2fcm.date_close) = @year)	
	--ORDER BY sum_br.min_accno 
)	
	
	
	

	 
	 insert into [dbo].[CRSAccountInfo]
	
	([AccType],[ReturnYear]
      ,[Accno]
      ,[CloseDate]
      ,[CrsType]
      ,[ClientName]
      ,[LastName]
	  ,[FirstName]
      ,[NameType]
      ,[AccHolderType]
      ,[CPType]
      ,[ResCountryCode]
      ,[TIN]
      ,[TINIssueBy]
      ,[BR_ID]
      ,[BirthDate]
      ,[BirthCountryCode]
      ,[AddressCountryCode]
      ,[LegalAddressType]
      ,[AddressFree]
      ,[AccBal]
      ,[Dividend]
      ,[Interest]
      ,[Redemption]
      ,[OtherPayment])
      
      select 'Futures', 
      @year, 
      min_accno, 
      date_close, 
            CASE
           WHEN nature_s = 'Individual' THEN 'I'
           WHEN nature_s = 'Joint' THEN 'J'
           WHEN nature_s = 'Entity' THEN 'E'
           ELSE ''
       END , 
      name, 
      CASE
           WHEN nature_s = 'Individual' and CHARINDEX(' ', name) > 0
           THEN SUBSTRING(name, 1, CHARINDEX(' ', name) - 1)
           ELSE name
       END  ,
      CASE
           WHEN nature_s = 'Individual' and CHARINDEX(' ', name) > 0 and LEN(name) - CHARINDEX(' ', name) > 0
           THEN SUBSTRING(name, CHARINDEX(' ', name) + 1, LEN(name) - CHARINDEX(' ', name))
           ELSE name
       END   ,
             CASE
           WHEN nature_s = 'Individual' THEN 'OECD202'
           WHEN nature_s = 'Joint' THEN 'OECD207'
           WHEN nature_s = 'Entity' THEN 'OECD207'
           ELSE ''
       END 
      , 
         CASE
			WHEN nature_s = 'Joint' THEN 'CRS102'
           WHEN nature_s = 'Entity' THEN 'CRS102'
           ELSE ''
       END 
      , '','HK',br_id, 'HK','', dob,'','HK','',SUBSTRING(fst_addr, 1, 150), 
                CASE 
        WHEN total_bal < 0  THEN 0 
        ELSE total_bal 
    END, 
    CASE 
        WHEN dividend_sum_amt < 0  THEN 0 
        ELSE dividend_sum_amt 
    END,
    CASE 
        WHEN interest_sum_amt < 0  THEN 0 
        ELSE interest_sum_amt 
    END,
    CASE 
        WHEN redemption_sum_amt < 0  THEN 0 
        ELSE redemption_sum_amt 
    END,
    CASE 
        WHEN other_sum_amt < 0  THEN 0 
        ELSE other_sum_amt 
    END
from G2F_table ;

	END TRY
	BEGIN CATCH
		ROLLBACK
		DECLARE @ErrorMessage NVARCHAR(4000);  
		DECLARE @ErrorSeverity INT;  
		DECLARE @ErrorState INT;  
		SELECT  @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE(); 
		RAISERROR('Error occurred in s_Import_CRSAccountInfo_f: %s', @ErrorSeverity, @ErrorState, @ErrorMessage)
	END CATCH

COMMIT

END
GO


