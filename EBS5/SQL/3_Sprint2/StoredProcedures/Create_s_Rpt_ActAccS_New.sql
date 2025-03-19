/****** Object:  StoredProcedure [dbo].[s_Rpt_ActAccS_New]    Script Date: 2017/11/27 10:41:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*-- =============================================
-- Author : HugoLaw
-- Create date : 2017/11/27 16:19
-- Last update : 2017/11/27 10:47
-- Description : Search Procedure FOR s_Rpt_ActAccS_New
-- ============================================= */

IF OBJECT_ID('[dbo].[s_Rpt_ActAccS_New]') > 0
BEGIN
	DROP PROCEDURE [dbo].s_Rpt_ActAccS_New
END
GO


CREATE PROCEDURE [dbo].s_Rpt_ActAccS_New	
	@g2sbDB nvarchar(100),
	@fromdate NVARCHAR(20),
	@todate NVARCHAR(20)
AS
BEGIN

	Set NOCOUNT ON;
    Set XACT_ABORT ON;

	DECLARE @sqlStr nvarchar(MAX)

	SET @sqlStr = '
		WITH it_client_all AS
		(
			SELECT clm.accno,
				   (CASE clms.[type]
						WHEN ''2'' THEN ''Cash''
						WHEN ''1'' THEN ''Margin''
					END)AS client_type,
				   clm.name_1,
				   ae.aeno,
				   clms.date_open
			FROM '+ @g2sbDB +'.[DBO].client_master AS clm
			LEFT OUTER JOIN '+ @g2sbDB +'.[DBO].client_master_s AS clms ON clms.aid = clm.aid
			LEFT OUTER JOIN '+ @g2sbDB +'.[DBO].ae_master AS ae ON ae.aeid = clms.aeid
			AND ae.cmid = clms.cmid
			WHERE clms.date_open >= ''' + @fromdate + ''' AND clms.date_open <= ''' + @todate + '''
		)'

	SET @sqlStr = @sqlStr + '
		SELECT ica.accno,
			   ica.client_type as acc_type,
			   ica.name_1 AS name_1,
			   ica.aeno,
			   date_open
		FROM it_client_all AS ica
		ORDER BY client_type,
				 ica.accno'

	PRINT @sqlStr

	EXECUTE  sp_ExecuteSql  @sqlStr

END

GO

--EXEC [s_Rpt_ActAccS_New] 'G2SB_UAT.g2sb_dev' ,'2016/10/12','2016/10/13'