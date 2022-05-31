


/****** Object:  StoredProcedure [dbo].[s_Rpt_AccStat_TotalF]    Script Date: 2017/11/27 10:41:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*-- =============================================
-- Author : HugoLaw
-- Create date : 2017/11/27 16:19
-- Last update : 2017/11/27 10:47
-- Description : Search Procedure FOR AccStat_TotalF
-- ============================================= */

IF OBJECT_ID('[dbo].[s_Rpt_AccStat_TotalF]') > 0
BEGIN
	DROP PROCEDURE [dbo].[s_Rpt_AccStat_TotalF]
END
GO

CREATE PROCEDURE [dbo].[s_Rpt_AccStat_TotalF]	
	@g2fbDB nvarchar(100)
AS
BEGIN

	Set NOCOUNT ON;
    Set XACT_ABORT ON;

	DECLARE @sqlStr nvarchar(MAX)

	SET @sqlStr = '
		WITH first_addid AS
		(
			SELECT cm.aid,
			   ISNULL(cam.addid, cm2.addid) AS addid
			FROM '+ @g2fbDB +'.dbo.client_master cm
			LEFT JOIN '+ @g2fbDB +'.dbo.clientadd_master cam ON cm.aid = cam.aid
															AND cm.name_1 = cam.contact_name
			LEFT JOIN
				(SELECT aid,
						RTRIM(CAST(MIN(CAST(addid AS INT)) AS CHAR(10))) AS addid
				FROM '+ @g2fbDB +'.dbo.clientadd_master
				GROUP BY aid) cm2 ON cm.aid = cm2.aid
		)'
	
	SET @sqlStr = @sqlStr + '
		,second_addid AS
		  ( SELECT aid, MIN(addid) AS addid
		   FROM '+ @g2fbDB +'.dbo.clientadd_master AS a
		   WHERE (addid >
					(SELECT MIN(addid)
					 FROM first_addid AS b
					 WHERE (a.aid = aid)))
		   GROUP BY aid)'

	SET @sqlStr = @sqlStr + '
		,it_first_addid AS
		  ( SELECT aid, min(addid) AS addid
		   FROM '+ @g2fbDB +'.dbo.clientadd_master
		   GROUP BY aid )
	'

	SET @sqlStr = @sqlStr + '
		,IT_client_all AS
		  ( SELECT clm.accno,  clms.date_close
		   FROM '+ @g2fbDB +'.dbo.client_master clm
		   LEFT OUTER JOIN '+ @g2fbDB +'.dbo.client_master_f clms ON clms.aid = clm.aid
		   LEFT OUTER JOIN it_first_addid stadd ON stadd.aid = clm.aid
		   LEFT OUTER JOIN '+ @g2fbDB +'.dbo.clientadd_master clma ON clma.addid = stadd.addid
		   LEFT OUTER JOIN second_addid ndadd ON ndadd.aid = clm.aid
		   LEFT OUTER JOIN '+ @g2fbDB +'.dbo.clientadd_master clma1 ON clma1.addid = ndadd.addid
		   LEFT OUTER JOIN '+ @g2fbDB +'.dbo.ae_master ae ON ae.aeid = clms.aeid
		   AND ae.cmid = clms.cmid
		   LEFT OUTER JOIN '+ @g2fbDB +'.dbo.client_bal bal ON bal.aid = clm.aid
		   AND bal.cuid = ''1''
		   LEFT OUTER JOIN '+ @g2fbDB +'.dbo.suspense_master sus ON clm.spid = sus.spid
		   LEFT OUTER JOIN '+ @g2fbDB +'.dbo.category_master cat ON cat.cgid = clm.cgid
		   LEFT OUTER JOIN '+ @g2fbDB +'.dbo.staff_ae_ac rel ON clm.aid = rel.aid
		   LEFT OUTER JOIN '+ @g2fbDB +'.dbo.staff stf ON rel.stfid = stf.stfid
		   LEFT OUTER JOIN '+ @g2fbDB +'.dbo.ae_master relae ON rel.aeid = relae.aeid
		   LEFT OUTER JOIN '+ @g2fbDB +'.dbo.interest_class ic ON ic.icid = bal.icid		   
		   LEFT OUTER JOIN '+ @g2fbDB +'.dbo.client_memo cme ON cme.aid = clm.aid)'


	SET @sqlStr = @sqlStr + '
		SELECT ''Futures Account'' client_type,
						   status,
						   count(1) AS cnt
		FROM
		  (SELECT CASE
					  WHEN date_close IS NULL THEN ''Open''
					  ELSE ''Closed''
				  END AS status
		   FROM IT_client_all) tmp
		GROUP BY status
		ORDER BY status DESC'


	PRINT @sqlStr

	EXECUTE  sp_ExecuteSql  @sqlStr

END

GO


--EXEC [s_Rpt_AccStat_TotalF] '[G2BF_UAT].g2fb_dev'


