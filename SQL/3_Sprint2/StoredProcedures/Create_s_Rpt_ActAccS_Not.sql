
/****** Object:  StoredProcedure [dbo].[s_Rpt_ActAccS_Not]    Script Date: 2017/11/27 10:41:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*-- =============================================
-- Author : HugoLaw
-- Create date : 2017/11/27 16:19
-- Last update : 2017/11/27 10:47
-- Description : Search Procedure FOR s_Rpt_ActAccS_Not
-- ============================================= */

IF OBJECT_ID('[dbo].[s_Rpt_ActAccS_Not]') > 0
BEGIN
	DROP PROCEDURE [dbo].[s_Rpt_ActAccS_Not]
END
GO


CREATE PROCEDURE [dbo].[s_Rpt_ActAccS_Not]	
	@g2sbDB nvarchar(100),
	@lastday NVARCHAR(20)
AS
BEGIN

	Set NOCOUNT ON;
    Set XACT_ABORT ON;

	DECLARE @sqlStr nvarchar(max)

	
	SET @sqlStr = '
		WITH hs_ctrade_namt_order AS
		( 
			SELECT h.tdate,
				   c.accno
			FROM '+ @g2sbDB +'.[DBO].histcltradeh AS h
			LEFT JOIN '+ @g2sbDB +'.[DBO].client_master AS c ON h.aid = c.aid
			WHERE h.cctype <> ''1'' AND h.tdate >= ''' + @lastday + '''
		)
		,ctrade_namt_order AS
		(
			SELECT	c.tdate,
					d.accno
			FROM
			  (SELECT tdate,aid
			   FROM '+ @g2sbDB +'.[DBO].daycltradehd
			   UNION SELECT tdate,aid
			   FROM '+ @g2sbDB +'.[DBO].daycltradehd_bond) AS c
			LEFT JOIN '+ @g2sbDB +'.[DBO].client_master AS d ON c.aid = d.aid
			WHERE c.tdate >= ''' + @lastday + '''
		)
		,it_client_last_trade_day AS
		(
			SELECT TEMP.accno AS client_code
			FROM
			  ( SELECT accno, tdate
			   FROM ctrade_namt_order
			   UNION SELECT accno, tdate
			   FROM hs_ctrade_namt_order ) AS TEMP
			GROUP BY temp.accno
		)
		,it_client_all AS
		(
			SELECT clm.accno,
				   (CASE clms.[type]
						WHEN ''2'' THEN ''Cash''
						WHEN ''1'' THEN ''Margin''
					END)AS client_type,
				   clm.name_1,
				   ae.aeno
			FROM '+ @g2sbDB +'.[DBO].client_master AS clm
			LEFT OUTER JOIN '+ @g2sbDB +'.[DBO].client_master_s AS clms ON clms.aid = clm.aid
			LEFT OUTER JOIN '+ @g2sbDB +'.[DBO].ae_master AS ae ON ae.aeid = clms.aeid
			AND ae.cmid = clms.cmid
			WHERE clms.date_close IS NULL
		)
		SELECT ica.accno,
			   ica.client_type,
			   ica.name_1 AS accname,
			   ica.aeno,
			   GETDATE() AS lastTradeDate
		FROM it_client_all AS ica
		WHERE ica.accno NOT IN (SELECT client_code FROM it_client_last_trade_day)
		ORDER BY client_type,
				 ica.accno'

	PRINT @sqlStr

	EXECUTE  sp_ExecuteSql  @sqlStr

END

GO


--EXEC [s_Rpt_ActAccS_Not] 'G2SB_UAT.g2sb_dev' ,'20040101'

      