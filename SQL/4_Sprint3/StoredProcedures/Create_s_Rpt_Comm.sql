/****** Object:  StoredProcedure [dbo].[s_Rpt_Comm]    Script Date: 2018/01/08 10:41:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*-- =============================================
-- Author : HugoLaw
-- Create date : 2018/01/08 16:19
-- Last update : 2018/01/08 10:47
-- Description : Search Procedure FOR s_Rpt_Comm
-- ============================================= */

IF OBJECT_ID('[dbo].[s_Rpt_Comm]') > 0
BEGIN
	DROP PROCEDURE [dbo].s_Rpt_Comm
END
GO


CREATE PROCEDURE [dbo].s_Rpt_Comm		
	@g2sbDB nvarchar(100),
	@g2fbDB nvarchar(100),
	@liqDB nvarchar(100),
	@fromDate NVARCHAR(20),
	@toDate NVARCHAR(20),
	@fromAECode NVARCHAR(20),
	@toAECode NVARCHAR(20)
AS
BEGIN

	Set NOCOUNT ON;
    Set XACT_ABORT ON;

	DECLARE @sqlStr nvarchar(max)

	SET @sqlStr = '
	WITH g2bs_client 
	AS( 
		SELECT DISTINCT clm.accno,ae.aeno
		FROM '+ @g2sbDB +'.[DBO].client_master AS clm
		LEFT OUTER JOIN '+ @g2sbDB +'.[DBO].client_master_s AS clms ON clms.aid = clm.aid
		LEFT OUTER JOIN '+ @g2sbDB +'.[DBO].ae_master AS ae ON ae.aeid = clms.aeid
		AND ae.cmid = clms.cmid
	),
	g2bf_client 
	AS( 
		SELECT DISTINCT clm.accno,ae.aeno
		FROM '+ @g2fbDB +'.[DBO].client_master AS clm
		LEFT OUTER JOIN '+ @g2fbDB +'.[DBO].client_master_f AS clms ON clms.aid = clm.aid
		LEFT OUTER JOIN '+ @g2fbDB +'.[DBO].ae_master AS ae ON ae.aeid = clms.aeid
		AND ae.cmid = clms.cmid
   ),
	g2b_client 
	AS( 
		SELECT accno, aeno
		FROM g2bs_client
		UNION SELECT accno, aeno
		FROM g2bf_client
	),
	monthcomm 
	AS(
		SELECT accno, sum(isnull(comm, 0)) + sum(isnull(ipo,0)) AS scomm
		FROM '+ @liqDB +'.dbo.monthcomm
		WHERE mth>=''' + @fromDate + ''' AND mth <=''' + @toDate + '''
		GROUP BY accno
   ),
   monthcommf 
   AS( 
	   SELECT accno, sum(isnull(comm,0)) + sum(isnull(ipo,0)) AS fcomm
	   FROM '+ @liqDB +'.dbo.monthcommf
	   WHERE mth>=''' + @fromDate + ''' AND mth <=''' + @toDate + '''
	   GROUP BY accno
   ),
   monthint 
   AS( 
		SELECT accno, sum(isnull(interest,0)) AS sint, sum(isnull(ipo,0)) AS ipoint
		FROM '+ @liqDB +'.dbo.monthint
		WHERE mth>=''' + @fromDate + ''' AND mth <=''' + @toDate + '''
		GROUP BY accno
   ),
   monthcommadj 
   AS(
		SELECT accno, sum(isnull(adj,0)) AS scomm_adj
		FROM dbo.monthcommadj
		WHERE adjdate>=''' + @fromDate + '''
		AND adjdate < =''' + @toDate + '''
		GROUP BY accno
   ),
   monthcommfadj 
   AS( 
		SELECT accno, sum(isnull(adj,0)) AS fcomm_adj
		FROM dbo.monthcommfadj
		WHERE adjdate>=''' + @fromDate + ''' AND adjdate <=''' + @toDate + '''
		GROUP BY accno
   ),
   monthintadj 
   AS( 
		SELECT accno, sum(isnull(adj,0)) AS int_adj
		FROM dbo.monthintadj
		WHERE adjdate>=''' + @fromDate + ''' AND adjdate <=''' + @toDate + '''
		GROUP BY accno
   ),
   dailyipoadj 
   AS
  (
		SELECT accno, sum(isnull(ipo,0)) AS ipocomm
		FROM dbo.dailyipoadj
		WHERE adjdate>=''' + @fromDate + ''' AND adjdate <=''' + @toDate + '''
		GROUP BY accno
   ),
   tempcomm 
   AS(
	   SELECT c.aeno AS aeno, b.accno, isnull(d.scomm,0) + isnull(e.scomm_adj,0) AS scomm, isnull(f.sint,0) + isnull(g.int_adj,0) AS sint, isnull(h.ipocomm,0) AS ipocomm, 
				isnull(f.ipoint,0) AS ipoint
	   FROM
		 ( SELECT DISTINCT accno from
			(SELECT accno COLLATE Chinese_Taiwan_Stroke_CI_AS AS accno
			 FROM monthcomm
			 UNION SELECT accno COLLATE Chinese_Taiwan_Stroke_CI_AS AS accno
			 FROM monthcommadj
			 UNION SELECT accno COLLATE Chinese_Taiwan_Stroke_CI_AS AS accno
			 FROM monthint
			 UNION SELECT accno COLLATE Chinese_Taiwan_Stroke_CI_AS AS accno
			 FROM monthintadj
			 UNION SELECT accno COLLATE Chinese_Taiwan_Stroke_CI_AS AS accno
			 FROM dailyipoadj) a ) b
	   LEFT OUTER JOIN g2bs_client c ON b.accno=c.accno
	   LEFT OUTER JOIN monthcomm d ON b.accno=d.accno
	   LEFT OUTER JOIN monthcommadj e ON b.accno=e.accno
	   LEFT OUTER JOIN monthint f ON b.accno=f.accno
	   LEFT OUTER JOIN monthintadj g ON b.accno=g.accno
	   LEFT OUTER JOIN dailyipoadj h ON b.accno=h.accno
	),
	tempcommf 
	AS(
		SELECT c.aeno AS aeno, b.accno, isnull(d.fcomm,0)+isnull(e.fcomm_adj,0) AS fcomm
		FROM
			(SELECT DISTINCT accno
			FROM
			(SELECT accno COLLATE Chinese_Taiwan_Stroke_CI_AS AS accno
				FROM monthcommf
				UNION SELECT accno COLLATE Chinese_Taiwan_Stroke_CI_AS AS accno
				FROM monthcommfadj) a ) b
		LEFT OUTER JOIN g2bf_client c ON b.accno=c.accno
		LEFT OUTER JOIN monthcommf d ON b.accno=d.accno
		LEFT OUTER JOIN monthcommfadj e ON b.accno=e.accno
   )'
   SET @sqlStr = @sqlStr + '
	SELECT b.aeno,
       b.accno,
       isnull(c.scomm,0) AS scomm,
       isnull(d.fcomm,0) AS fcomm,
       isnull(c.sint,0) AS sint,
       isnull(c.scomm,0)+isnull(fcomm,0)+isnull(sint,0) AS total,
       isnull(c.ipocomm,0) AS ipocomm,
       isnull(c.ipoint,0) AS ipoint
	FROM g2b_client b
	LEFT OUTER JOIN tempcomm c ON b.aeno COLLATE Chinese_Taiwan_Stroke_CI_AS = c.aeno COLLATE Chinese_Taiwan_Stroke_CI_AS
	AND b.accno COLLATE Chinese_Taiwan_Stroke_CI_AS = c.accno COLLATE Chinese_Taiwan_Stroke_CI_AS
	LEFT OUTER JOIN tempcommf d ON b.aeno COLLATE Chinese_Taiwan_Stroke_CI_AS = d.aeno COLLATE Chinese_Taiwan_Stroke_CI_AS
	AND b.accno COLLATE Chinese_Taiwan_Stroke_CI_AS = d.accno COLLATE Chinese_Taiwan_Stroke_CI_AS
	WHERE 1=1 
   '
   
	IF ISNULL(@fromAECode,'') <> ''
	BEGIN
		SET @sqlStr = @sqlStr + ' AND  b.aeno>='''	+ @fromAECode + ''''
	END

	IF ISNULL(@toAECode,'') <> ''
	BEGIN
		SET @sqlStr = @sqlStr + ' AND  b.aeno<='''	+ @toAECode + ''''
	END

	SET @sqlStr = @sqlStr + ' ORDER BY b.aeno,b.accno'

	--PRINT @sqlStr

	EXECUTE  sp_ExecuteSql  @sqlStr

END
GO



--exec [dbo].s_Rpt_Comm 'LinkedServer97.g2bs_dev','LinkedServer97.g2bf_dev','ESL_Liq_Dev','2018-1-01','2018-1-31','0200','0200'


