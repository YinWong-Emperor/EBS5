/****** Object:  StoredProcedure [dbo].[s_Rpt_AccIntCls_AccDtl]    Script Date: 2018/01/08 10:41:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*-- =============================================
-- Author : HugoLaw
-- Create date : 2018/01/08 16:19
-- Last update : 2018/01/08 10:47
-- Description : Search Procedure FOR s_Rpt_AccIntCls_AccDtl
-- ============================================= */

IF OBJECT_ID('[dbo].[s_Rpt_AccIntCls_AccDtl]') > 0
BEGIN
	DROP PROCEDURE [dbo].s_Rpt_AccIntCls_AccDtl
END
GO


CREATE PROCEDURE [dbo].s_Rpt_AccIntCls_AccDtl
	@g2sbDB nvarchar(100)
AS
BEGIN
	Set NOCOUNT ON;
    Set XACT_ABORT ON;

	DECLARE @sqlStr nvarchar(MAX)

	SET @sqlStr = '
		SELECT DISTINCT clm.accno AS accno,
			   clm.name_1,
			   ae.aeno,
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
				' + @g2sbDB + '.dbo.ae_master AS ae
			ON ae.aeid = clms.aeid AND ae.cmid = clms.cmid
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

		ORDER BY int_code,accno
	'

	PRINT @sqlStr

	EXECUTE  sp_ExecuteSql  @sqlStr

END

GO


-- EXEC [dbo].s_Rpt_AccIntCls_AccDtl 'LinkedServer97.g2bs_dev'