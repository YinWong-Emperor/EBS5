
/*-- =============================================
-- Author : DoraemonYu
-- Create date : 2017/12/05 14:05
-- Last update : 2017/12/05 15:40
-- ============================================= */


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_Get_MonthToDate_FuturesClientsTurnover]') AND TYPE IN (N'P', N'PC'))
	DROP PROCEDURE [dbo].[s_Get_MonthToDate_FuturesClientsTurnover]
GO


CREATE PROCEDURE [dbo].[s_Get_MonthToDate_FuturesClientsTurnover]
	@GStrG2BFDB varchar(100),
	@fromDate varchar(15),
	@toDate varchar(15)
AS
BEGIN

	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	DECLARE @sqlStr  NVARCHAR(1000)

	--logics is moved from ESL_v4::ClsMonthToDate.vb
	SET @sqlStr = 
					'select rtrim(accno) as accno, rtrim(name_1) as name_1, rtrim(aeno) as aeno, sum(amt) as turnover '  +
					' from ' + 
					@GStrG2BFDB + '.dbo.dayclfee df, ' + 
					@GStrG2BFDB + '.dbo.client_master cm, ' + 
					@GStrG2BFDB + '.dbo.feenature_master fnm, ' + 
					@GStrG2BFDB + '.dbo.client_master_f cmf, ' +
					@GStrG2BFDB + '.dbo.ae_master aem, ' + 
					' (select oid, tdate, aid, mkid from ' + @GStrG2BFDB + '.dbo.histcltradeh union all select oid, tdate, aid, mkid from ' +
					@GStrG2BFDB + '.dbo.daycltradehd) trade ' + 
					' where df.fuid = fnm.fuid and cmf.aeid = aem.aeid and cm.aid = cmf.aid and df.oid = trade.oid and trade.aid = cm.aid and catagory = 4 ' + 
					' and date_chrg >= ''' + @fromDate + ''' ' + 
					' and date_chrg <= ''' + @toDate + ''' ' + 
					' group by accno, name_1, aeno ' + 
					' order by accno '
	;


	PRINT @sqlStr
	EXEC (@sqlStr)

END
GO
