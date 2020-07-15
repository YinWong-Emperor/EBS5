/****** Object:  StoredProcedure [dbo].[s_Rpt_ActAccF_New]    Script Date: 2017/11/27 10:41:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*-- =============================================
-- Author : HugoLaw
-- Create date : 2017/11/27 16:19
-- Last update : 2017/11/27 10:47
-- Description : Search Procedure FOR s_Rpt_ActAccF_New
-- ============================================= */

IF OBJECT_ID('[dbo].[s_Rpt_ActAccF_New]') > 0
BEGIN
	DROP PROCEDURE [dbo].s_Rpt_ActAccF_New
END
GO


CREATE PROCEDURE [dbo].s_Rpt_ActAccF_New	
	@g2fbDB nvarchar(100),
	@fromdate NVARCHAR(20),
	@todate NVARCHAR(20)
AS
BEGIN

	Set NOCOUNT ON;
    Set XACT_ABORT ON;

	DECLARE @sqlStr nvarchar(MAX)

	SET @sqlStr = '		
			SELECT clm.accno,
				   clm.name_1,
				   ae.aeno,
				   clms.date_open
			FROM '+ @g2fbDB +'.[DBO].client_master AS clm
			LEFT OUTER JOIN '+ @g2fbDB +'.[DBO].client_master_f AS clms ON clms.aid = clm.aid
			LEFT OUTER JOIN '+ @g2fbDB +'.[DBO].ae_master AS ae ON ae.aeid = clms.aeid AND ae.cmid = clms.cmid
			WHERE clms.date_open >= ''' + @fromdate + ''' AND clms.date_open <= ''' + @todate + ''''

	PRINT @sqlStr

	EXECUTE  sp_ExecuteSql  @sqlStr


END

GO


--EXEC [s_Rpt_ActAccF_New] '[G2BF_UAT].g2fb_dev','2016/10/1','2016/10/30'