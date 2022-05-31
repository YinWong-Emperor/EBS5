/****** Object:  StoredProcedure [dbo].[s_Rpt_AccIntCls_NoAcc]    Script Date: 2018/01/08 10:41:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*-- =============================================
-- Author : HugoLaw
-- Create date : 2018/01/08 16:19
-- Last update : 2018/01/08 10:47
-- Description : Search Procedure FOR s_Rpt_AccIntCls_NoAcc
-- ============================================= */

IF OBJECT_ID('[dbo].[s_Rpt_AccIntCls_NoAcc]') > 0
BEGIN
	DROP PROCEDURE [dbo].s_Rpt_AccIntCls_NoAcc
END
GO


CREATE PROCEDURE [dbo].s_Rpt_AccIntCls_NoAcc		
	@g2sbDB nvarchar(100)
AS
BEGIN
	Set NOCOUNT ON;
    Set XACT_ABORT ON;

	DECLARE @sqlStr nvarchar(MAX)

	SET @sqlStr = '
		WITH it_client_all AS
		  ( 
		  SELECT distinct clm.accno,
				   (CASE clms.[type]
						WHEN ''2'' THEN ''Cash''
						WHEN ''1'' THEN ''Margin''
					END)AS client_type,
				   ic.int_code,
				   ic.om_rate_1 AS int_1,
				   ic.om_rate_2 AS int_2,
				   ic.om_rate_3 AS int_3
			FROM ' + @g2sbDB + '.dbo.client_master AS clm
			LEFT OUTER JOIN
				' + @g2sbDB + '.dbo.client_master_s AS clms
			ON clms.aid = clm.aid
			LEFT OUTER JOIN
				' + @g2sbDB + '.dbo.client_bal AS bal
			ON bal.aid = clms.aid AND bal.cmid = clms.cmid
			LEFT OUTER JOIN
				' + @g2sbDB + '.dbo.market_client AS mc
			ON mc.aid = clms.aid AND mc.cmid = clms.cmid
			LEFT OUTER JOIN
				' + @g2sbDB + '.dbo.interest_class AS ic
			ON ic.icid = bal.icid
			LEFT OUTER JOIN
				' + @g2sbDB + '.dbo.Client_Fee AS cf
			ON cf.aid = clms.aid AND cf.cmid = clms.cmid AND cf.fuid = ''18''
			LEFT OUTER JOIN
			(
			SELECT clm.accno, clms.cmid
				FROM  
					' + @g2sbDB + '.dbo.client_master AS clm 
				INNER JOIN
					' + @g2sbDB + '.dbo.client_master_s AS clms 
				ON clms.aid = clm.aid 
				LEFT OUTER JOIN
					' + @g2sbDB + '.dbo.Client_Fee AS cfBp 
				ON cfbp.aid = clms.aid AND cfbp.cmid = clms.cmid AND cfbp.fuid = 18
				LEFT OUTER JOIN 
					' + @g2sbDB + '.dbo.fee_master AS feebp 
				ON feebp.fid = cfbp.fid 
				LEFT OUTER JOIN
					' + @g2sbDB + '.dbo.Client_Fee AS cfBi 
				ON cfbi.aid = clms.aid AND cfbi.cmid = clms.cmid AND cfbi.fuid = 198
				LEFT OUTER JOIN 
					' + @g2sbDB + '.dbo.fee_master AS feebi 
				ON feebi.fid = cfbi.fid 
				LEFT OUTER JOIN
					' + @g2sbDB + '.dbo.Client_Fee AS cfrp 
				ON cfrp.aid = clms.aid AND cfrp.cmid = clms.cmid AND cfrp.fuid = 21
				LEFT OUTER JOIN 
				' + @g2sbDB + '.dbo.fee_master AS feerp 
				ON feerp.fid = cfrp.fid 
				LEFT OUTER JOIN
				' + @g2sbDB + '.dbo.Client_Fee AS cfri 
				ON cfri.aid = clms.aid AND cfri.cmid = clms.cmid AND cfri.fuid = 197
				LEFT OUTER JOIN 
				' + @g2sbDB + '.dbo.fee_master AS feeri 
				ON feeri.fid = cfri.fid	
			) AS vwFee
			ON clm.accno = vwFee.accno AND clms.cmid = vwFee.cmid

		   WHERE clms.date_close IS NULL 
		),
		tmp_cash AS
		  ( 
		  SELECT int_code,
				   int_1,
				   int_2,
				   int_3,
				   COUNT(accno) AS quan
		   FROM it_client_all
		   WHERE client_type=''Cash''
		   GROUP BY int_code,int_1,int_2,int_3
		),
		tmp_mgn AS
		  ( 
		  SELECT int_code,
				   int_1,
				   int_2,
				   int_3,
				   COUNT(accno) AS quan
		   FROM it_client_all
		   WHERE client_type=''Margin''
		   GROUP BY int_code,
					int_1,
					int_2,
					int_3
			),
		accint AS
		  ( 
		  SELECT isnull(tmp_cash.int_code, tmp_mgn.int_code) AS int_code,
				   isnull(tmp_cash.int_1, tmp_mgn.int_1) AS int_1,
				   isnull(tmp_cash.int_2, tmp_mgn.int_2) AS int_2,
				   isnull(tmp_cash.int_3, tmp_mgn.int_3) AS int_3,
				   isnull(tmp_cash.quan, 0) AS Cshquan,
				   isnull(tmp_mgn.quan, 0) AS Mgnquan
		   FROM tmp_cash
		   FULL JOIN tmp_mgn ON tmp_cash.int_code = tmp_mgn.int_code --order by int_code
		),
		ic AS
		  ( 
		  SELECT distinct int_code, om_rate_1 AS int_1, om_rate_2 AS int_2, om_rate_3 AS int_3
		  FROM ' + @g2sbDB + '.dbo.interest_class
		   )

		SELECT isnull(accint.int_code, ic.int_code) AS int_code,
		   isnull(accint.int_1, ic.int_1) AS int_1,
		   isnull(accint.int_2, ic.int_2) AS int_2,
		   isnull(accint.int_3, ic.int_3) AS int_3,
		   isnull(Cshquan, 0) AS Cshquan,
		   isnull(Mgnquan, 0) AS Mgnquan
		FROM ic
		LEFT JOIN accint ON ic.int_code = accint.int_code
		ORDER BY int_code
	'

	PRINT @sqlStr

	EXECUTE  sp_ExecuteSql  @sqlStr

END

GO


-- EXEC [dbo].s_Rpt_AccIntCls_NoAcc 'LinkedServer97.g2bs_dev'
