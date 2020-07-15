

/****** Object:  StoredProcedure [dbo].[s_Rpt_ActAccF]    Script Date: 2017/11/27 10:41:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*-- =============================================
-- Author : HugoLaw
-- Create date : 2017/11/27 16:19
-- Last update : 2017/11/27 10:47
-- Description : Search Procedure FOR s_Rpt_ActAccF
-- ============================================= */

IF OBJECT_ID('[dbo].[s_Rpt_ActAccF]') > 0
BEGIN
	DROP PROCEDURE [dbo].[s_Rpt_ActAccF]
END
GO

CREATE PROCEDURE [dbo].[s_Rpt_ActAccF]	
	@g2fbDB nvarchar(100),
	@lastday NVARCHAR(50)
AS
BEGIN
	
	Set NOCOUNT ON;
    Set XACT_ABORT ON;

	DECLARE @sqlStr nvarchar(MAX)

	
	SET @sqlStr = '
		WITH client_trade_dt_with_comm AS
		( 
			SELECT tdate,
				   c.accno
			FROM '+ @g2fbDB +'.[DBO].histcltradeh a
			LEFT OUTER JOIN '+ @g2fbDB +'.[DBO].client_master c ON a.aid = c.aid
			WHERE tdate >= ''' + @lastday + '''
			UNION ALL
			SELECT tdate,
				   c.accno
			FROM '+ @g2fbDB +'.[DBO].daycltradehd a
			LEFT OUTER JOIN '+ @g2fbDB +'.[DBO].client_master c ON a.aid = c.aid
			WHERE tdate >= ''' + @lastday + '''
		)'
	
	SET @sqlStr = @sqlStr + '
		,it_client_last_trade_day AS
		(
			SELECT TEMP.accno AS client_code,
				   max(TEMP.tdate) AS lastday 
			FROM client_trade_dt_with_comm AS TEMP
			GROUP BY temp.accno
		)'

	SET @sqlStr = @sqlStr + '
		,it_client_all AS
		(
			SELECT clm.accno,
				   clm.name_1,
				   ae.aeno
			FROM '+ @g2fbDB +'.[DBO].client_master AS clm
			LEFT OUTER JOIN '+ @g2fbDB +'.[DBO].client_master_f AS clms ON clms.aid = clm.aid
			LEFT OUTER JOIN '+ @g2fbDB +'.[DBO].ae_master AS ae ON ae.aeid = clms.aeid AND ae.cmid = clms.cmid
			WHERE clms.date_close IS NULL
		)'

	SET @sqlStr = @sqlStr + '
		SELECT ica.accno,
			   ica.name_1 AS accname,
			   ica.aeno,
			   ict.lastday AS lastTradeDate
		FROM it_client_all AS ica
		INNER JOIN it_client_last_trade_day AS ict ON ica.accno = ict.client_code
		ORDER BY ica.accno'
	
	PRINT @sqlStr

	EXECUTE  sp_ExecuteSql  @sqlStr

END
GO


--EXEC [s_Rpt_ActAccF] '[G2BF_UAT].g2fb_dev' ,'20150101'

--select * from  G2BF_UAT.g2fb_dev.dbo.View_it_client_all
