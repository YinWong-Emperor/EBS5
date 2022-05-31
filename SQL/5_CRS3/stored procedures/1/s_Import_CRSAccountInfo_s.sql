USE [ESL]
GO
DROP PROCEDURE IF EXISTS [dbo].[s_Import_CRSAccountInfo_s]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--EXEC [dbo].[s_Import_CRSAccountInfo_s] 2019
CREATE PROCEDURE [dbo].[s_Import_CRSAccountInfo_s]
	@year int
AS
BEGIN

declare @start_date date
declare @end_date date
declare @last_tdate date

SET @start_date = DATEADD(yy, @year - 1900, 0)
SET @end_date = DATEADD(yy, @year - 1900 + 1, -1)
SELECT TOP 1 @last_tdate = tdate FROM dbo.exchangerate WHERE tdate <= @end_date AND System_Type ='Securities' ORDER BY tdate desc;

BEGIN TRAN

	BEGIN TRY

		DELETE FROM [ESL].[dbo].[CRSAccountInfo]
		WHERE	ReturnYear = @year
		AND		AccType = 'Securities';

		WITH clm AS(
			select g2scms.aid,
			  g2scms.cmid,
			  g2scm.accno,
			  g2scm.nature,		  
			  g2scm.name_1 AS name,
			  g2scm.br_id,
			  g2scms.date_open,
			  g2scms.date_close,
			  ISNULL(g2scm.dob,'1900-01-01') AS dob
			 FROM [G2BS_RET_LASTY].dbo.client_master g2scm
			INNER JOIN [G2BS_RET_LASTY].dbo.client_master_s g2scms ON g2scms.aid=g2scm.aid
			WHERE --ISNULL(g2scms.date_close ,'') = '' AND 
			LTRIM(RTRIM( ISNULL(g2scm.br_id,''))) NOT IN ('','*','-','.') 
		),	 
		first_addid AS
		(
			SELECT cam.aid,
			   min(cam.addid) AS addid
			FROM [G2BS_RET_LASTY].dbo.clientadd_master as cam
			INNER JOIN clm ON clm.aid = cam.aid
			GROUP BY cam.aid
		),
		first_addr AS (
			SELECT stadd.aid,
					LTRIM(RTRIM(clma.phone_1)) AS phone_1,
					LTRIM(RTRIM(clma.phone_2)) AS phone_2,
					LTRIM(RTRIM(clma.phone_3)) AS phone_3,
					COALESCE(LTRIM(RTRIM(clma.addr_1)) + ' ' + LTRIM(RTRIM(clma.addr_2)) + ' ' + LTRIM(RTRIM(clma.addr_3)) + ' ' + LTRIM(RTRIM(clma.addr_4)) COLLATE DATABASE_DEFAULT,'') AS addr
			FROM
				first_addid AS stadd 
				LEFT OUTER JOIN [G2BS_RET_LASTY].dbo.clientadd_master AS clma ON clma.addid  = stadd.addid
		)
		,second_addid AS 
		(
			SELECT a.aid,
			   MIN(addid) AS addid
			FROM [G2BS_RET_LASTY].dbo.clientadd_master AS a
			INNER JOIN clm ON clm.aid = a.aid
			WHERE (addid >
					 (SELECT MIN(addid)
					  FROM first_addid AS b
					  WHERE (a.aid = aid)))
			GROUP BY a.aid
		)
		,second_addr AS (
			SELECT secadd.aid,
					COALESCE(LTRIM(RTRIM(clma.addr_1)) + ' ' + LTRIM(RTRIM(clma.addr_2)) + ' ' + LTRIM(RTRIM(clma.addr_3)) + ' ' + LTRIM(RTRIM(clma.addr_4)) COLLATE DATABASE_DEFAULT,'') AS addr
			FROM
				second_addid AS secadd 
				LEFT OUTER JOIN [G2BS_RET_LASTY].dbo.clientadd_master AS clma ON clma.addid = secadd.addid
		),
		vwcb AS
		(
			SELECT vwcb.aid,
					clm.accno,
					vwcb.cuid,
					vwcb.cash_bal
			FROM [G2BS_RET_LASTY].dbo.view_client_bals vwcb
			INNER JOIN clm ON vwcb.aid=clm.aid
		),
		vwmk AS
		(
			SELECT vwmk.client_code,
					currma.cuid,
					vwmk.currency_code,
					vwmk.market_value,
					clm.aid
			FROM [G2BS_RET_LASTY].dbo.view_er_client_master_mkt_mrg_value vwmk
			INNER JOIN [G2BS_RET_LASTY].dbo.currency_master currma ON currma.name_s = vwmk.currency_code
			INNER JOIN clm ON clm.accno = vwmk.client_code
		),
		exrate AS
		(
			SELECT currency_in,
					ex_rate,
					'HKD' AS targetbase
			FROM dbo.exchangerate
			WHERE tdate=@last_tdate AND System_Type ='Securities' 
		
		),
		targetbaseexrate AS
		(
			SELECT currency_in,
					ex_rate AS targetrate
			FROM dbo.exchangerate
			WHERE tdate=@last_tdate AND currency_in='HKD' AND System_Type ='Securities'
		
		),
		exrateprod AS 
		(
			SELECT currma.cuid,
					   exrate.currency_in,
					   exrate.ex_rate / targetbaseexrate.targetrate AS targetrate
				FROM
					[G2BS_RET_LASTY].dbo.currency_master currma               
				INNER JOIN exrate ON currma.name_s = exrate.currency_in
				INNER JOIN
				   targetbaseexrate ON exrate.targetbase = targetbaseexrate.currency_in
		),
		stock_option AS(
			SELECT 
				sob.accno_map,
				sob.cfbal as bal
			FROM dbo.temp_stock_option_bal AS sob
		),	
		acbal_ori AS
		(
			SELECT vwcb.aid,
					vwcb.accno,
					vwcb.cuid,
					vwcb.cash_bal * exrateprod.targetrate AS cash_bal,
					vwmk.market_value * exrateprod.targetrate AS mktval
			 FROM
				vwcb
			 INNER JOIN
				exrateprod ON exrateprod.cuid = vwcb.cuid
			 LEFT OUTER JOIN
				vwmk ON vwmk.aid = vwcb.aid
						AND vwmk.cuid = vwcb.cuid
		),	
		acbal AS
		(
			SELECT aid,
				   accno,
				   cuid,
				   SUM(cash_bal) AS cash_bal,
				   SUM(mktval) AS mktval
			 FROM
				acbal_ori
			 GROUP BY aid,
					  accno,
					  cuid
		),
		cb AS 
		(
			SELECT acbal.aid,
				 ISNULL(ROUND(
				 SUM(  ISNULL(cash_bal,0) + ISNULL(mktval,0))
								,2), 0) --+ ISNULL(so.bal,0)),2), 0) 
				 AS acbal
			  FROM
				 acbal
			  --LEFT JOIN stock_option AS so ON acbal.accno = so.accno_map collate database_default 
			  GROUP BY acbal.aid
		),
		payment_union AS (
			SELECT hf.aid,(CASE hf.[type] WHEN 0 THEN hf.amt * e.ex_rate  ELSE hf.amt * -1 * e.ex_rate  END) as amt,tm.tcode
			FROM [G2BS_RET_LASTY].dbo.histcl_fund AS hf
			INNER JOIN [G2BS_RET_LASTY].dbo.tcode_master AS tm ON hf.lgid_dr = tm.lgid_dr and hf.lgid_cr = tm.lgid_cr
			INNER JOIN clm ON hf.aid = clm.aid
			LEFT JOIN [G2BS_RET_LASTY].dbo.currency_master curr ON hf.cuid = curr.cuid 
			LEFT JOIN exrate e ON curr.name_s = e.currency_in
			WHERE tm.tcode IN ('CPNC', 'CPNRC', 'CPNM', 'CPNRM',
						'DIVC', 'DIVRC', 'DIVM', 'DIVRM',
						'BRC', 'BRRC', 'BRM', 'BRRM',
						'HIC', 'HIRC', 'HIM', 'HIRM')
			UNION ALL
			select fmc.aid,(CASE fmc.[type] WHEN 0 THEN fmc.amt * e.ex_rate ELSE fmc.amt * -1 * e.ex_rate END) as amt,tm.tcode
			FROM [G2BS_RET_LASTY].dbo.fund_move_client AS fmc
			INNER JOIN [G2BS_RET_LASTY].dbo.tcode_master AS tm ON fmc.lgid_dr = tm.lgid_dr and fmc.lgid_cr = tm.lgid_cr
			INNER JOIN clm ON fmc.aid = clm.aid
			LEFT JOIN [G2BS_RET_LASTY].dbo.currency_master curr ON fmc.cuid = curr.cuid 
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
			FROM [G2BS_RET_LASTY].dbo.histcl_fund hf
			LEFT JOIN clm on hf.aid = clm.aid
			LEFT JOIN [G2BS_RET_LASTY].dbo.currency_master curr ON hf.cuid = curr.cuid 
			LEFT JOIN dbo.exchangerate e ON e.tdate = @last_tdate AND system_type = 'Securities' AND currency_out = 'HKD' AND curr.name_s = e.currency_in
			WHERE
				hf.vdate between @start_date AND @end_date
				AND 
				(
					hf.notes like '%Dividend%' 
					OR  
					((hf.lgid_dr = 624 AND hf.lgid_cr = 421) OR (hf.lgid_dr = 421 AND hf.lgid_cr = 624) OR (hf.lgid_dr = 420 AND hf.lgid_cr = 624) OR (hf.lgid_dr = 624 AND hf.lgid_cr = 420))
				)
		),
		interest_sum AS (
			SELECT aid as aid ,sum(amt) as amt
			FROM payment_union
			WHERE tcode in ('CPNC', 'CPNRC', 'CPNM', 'CPNRM')
			group by aid
		),
		dividend_sum AS (
			SELECT aid as aid ,sum(amt) as amt
			FROM payment_union
			WHERE tcode in ('DIVC', 'DIVRC', 'DIVM', 'DIVRM','Dividend')
			group by aid
		),
		redemption_sum AS (
			SELECT aid as aid ,sum(amt) as amt
			FROM payment_union
			WHERE tcode in ('BRC', 'BRRC', 'BRM', 'BRRM')
			group by aid
		),
		other_sum AS (
			SELECT aid as aid ,sum(amt) as amt
			FROM payment_union
			WHERE tcode in ('HIC', 'HIRC', 'HIM', 'HIRM')
			group by aid
		),
		g2scm_ori AS
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
				ISNULL(cb.acbal,0) + ISNULL(so.bal,0) AS acbal,
				ISNULL(interest_sum.amt,0) as interest_amt,
				ISNULL(dividend_sum.amt,0) as dividend_amt,
				ISNULL(redemption_sum.amt,0) as redemption_amt,
				ISNULL(other_sum.amt,0) as other_amt
			FROM clm
			LEFT OUTER JOIN first_addr AS staddr ON staddr.aid = clm.aid
			LEFT OUTER JOIN second_addr AS secddr ON secddr.aid = clm.aid
			LEFT OUTER JOIN cb ON cb.aid = clm.aid
			LEFT OUTER JOIN stock_option AS so ON clm.accno = so.accno_map collate database_default
			LEFT JOIN interest_sum ON clm.aid = interest_sum.aid
			LEFT JOIN dividend_sum ON clm.aid = dividend_sum.aid
			LEFT JOIN redemption_sum ON clm.aid = redemption_sum.aid
			LEFT JOIN other_sum ON clm.aid = other_sum.aid
		)	
		,g2scm AS (
			SELECT
				g2scm.aid,
				g2scm.accno,
				g2scm.name,
				g2scm.br_id,
				g2scm.date_open,
				g2scm.date_close,
				g2scm.dob,			
				g2scm.phone_1,
				g2scm.phone_2,
				g2scm.phone_3,
				fst_addr,
				sec_addr,
				g2scm.acbal			
			FROM g2scm_ori AS g2scm
		)	
		,sum_br AS (	
			SELECT MIN(ACCNO) as min_accno,count(BR_ID) as br_count,SUM(ACBAL) as sum_bal,BR_ID as br_id ,'Individual' as nature_s
			,stuff((SELECT ','+ RTRIM(b.accno) FROM clm as b WHERE b.br_id = g2scm_ori.br_id AND  b.nature = '0'  FOR XML PATH('')),1,1,'') as other_accno,
			SUM(g2scm_ori.interest_amt) AS interest_sum_amt,SUM(g2scm_ori.dividend_amt) AS dividend_sum_amt,SUM(g2scm_ori.redemption_amt) AS redemption_sum_amt,SUM(g2scm_ori.other_amt) AS other_sum_amt 
			FROM g2scm_ori
			WHERE g2scm_ori.nature = '0'
			GROUP BY BR_ID
			UNION ALL
			SELECT MIN(ACCNO) as min_accno,count(BR_ID) as br_count,SUM(ACBAL) as sum_bal,BR_ID as br_id ,'Joint' as nature_s
			,stuff((SELECT ','+ RTRIM(b.accno) FROM clm as b WHERE b.br_id = g2scm_ori.br_id AND  b.nature = '1'  FOR XML PATH('')),1,1,'') as other_accno,
			SUM(g2scm_ori.interest_amt) AS interest_sum_amt,SUM(g2scm_ori.dividend_amt) AS dividend_sum_amt,SUM(g2scm_ori.redemption_amt) AS redemption_sum_amt,SUM(g2scm_ori.other_amt) AS other_sum_amt 
			FROM g2scm_ori
			WHERE g2scm_ori.nature = '1'
			GROUP BY BR_ID
			UNION ALL
			SELECT MIN(ACCNO) as min_accno,count(BR_ID) as br_count,SUM(ACBAL) as sum_bal,BR_ID as br_id ,'Entity' as nature_s
			,stuff((SELECT ','+ RTRIM(b.accno) FROM clm as b WHERE b.br_id = g2scm_ori.br_id AND  b.nature = '2'  FOR XML PATH('')),1,1,'') as other_accno,
			SUM(g2scm_ori.interest_amt) AS interest_sum_amt,SUM(g2scm_ori.dividend_amt) AS dividend_sum_amt,SUM(g2scm_ori.redemption_amt) AS redemption_sum_amt,SUM(g2scm_ori.other_amt) AS other_sum_amt 
			FROM g2scm_ori
			WHERE g2scm_ori.nature = '2'
			GROUP BY BR_ID
		)
	,G2S_table AS (
		SELECT sum_br.min_accno , 
				sum_br.nature_s,
				g2scm.name,
				sum_br.br_id,
				g2scm.date_open,
				g2scm.date_close,
				g2scm.dob,
				g2scm.fst_addr,
				sum_br.sum_bal AS total_bal,			
				sum_br.interest_sum_amt,
				sum_br.dividend_sum_amt,
				sum_br.redemption_sum_amt,
				sum_br.other_sum_amt
		FROM sum_br 
		LEFT JOIN g2scm ON sum_br.min_accno = g2scm.accno 
	
		where (ISNULL(g2scm.date_close ,'') = '' or year(g2scm.date_close) = @year)
	
	)


		 insert into [ESL].[dbo].[CRSAccountInfo]	
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
		  select 'Securities', 
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
	from G2S_table ;

	END TRY
	BEGIN CATCH
		ROLLBACK
		DECLARE @ErrorMessage NVARCHAR(4000);  
		DECLARE @ErrorSeverity INT;  
		DECLARE @ErrorState INT;  
		SELECT  @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE(); 
		RAISERROR('Error occurred in s_Import_CRSAccountInfo_s: %s', @ErrorSeverity, @ErrorState, @ErrorMessage)
	END CATCH

COMMIT

END
GO


