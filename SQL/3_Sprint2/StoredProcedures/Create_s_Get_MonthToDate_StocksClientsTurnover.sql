
/*-- =============================================
-- Author : DoraemonYu
-- Create date : 2017/12/05 11:07
-- Last update : 2017/12/05 11:07
-- ============================================= */


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_Get_MonthToDate_StocksClientsTurnover]') AND TYPE IN (N'P', N'PC'))
	DROP PROCEDURE [dbo].[s_Get_MonthToDate_StocksClientsTurnover]
GO


CREATE PROCEDURE [dbo].[s_Get_MonthToDate_StocksClientsTurnover]
	@GStrG2BSDB varchar(100),
	@fromDate varchar(15),
	@toDate varchar(15)
AS
BEGIN

	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	DECLARE @sqlStr  NVARCHAR(1000)

	--logics is moved from ESL_v4::ClsMonthToDate.vb
	SET @sqlStr = 
				'select rtrim(aeno) as aeno, rtrim(name) as name, rtrim(accno) as accno, rtrim(name_1) as name_1, sum(grossamt) as turnover '  +
				' from( ' +
				' select aid, accno, name_1, grossamt ' +
				' from ' + @GStrG2BSDB + '.dbo.view_ctrade_namt_order a ' + 
				' where tdate >= ''' + @fromDate + ''' and tdate <= ''' + @toDate + ''' '   + 
				' union all ' +
				' select aid, accno, name_1, grossamt ' +
				' from ' +  @GStrG2BSDB + '.dbo.view_hs_ctrade_namt_order ' +
				' where tdate >= ''' + @fromDate + ''' and tdate <= ''' + @toDate + ''' '   + 
				' ) trade, ' + @GStrG2BSDB + '.dbo.client_master_s cms, ' + @GStrG2BSDB + '.dbo.ae_master aem ' + 
				' where trade.aid = cms.aid ' + 
				' and cms.aeid = aem.aeid ' + 
				' group by aeno, name, accno, name_1 ' + 
				' order by accno '
	;


	PRINT @sqlStr
	EXEC (@sqlStr)

END
GO
