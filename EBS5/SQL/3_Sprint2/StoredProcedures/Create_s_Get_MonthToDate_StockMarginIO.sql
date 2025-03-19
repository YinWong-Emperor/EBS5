
/*-- =============================================
-- Author : DoraemonYu
-- Create date : 2017/12/07 16:10
-- Last update : 2017/12/07 16:10
-- ============================================= */


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_Get_MonthToDate_StockMarginIO]') AND TYPE IN (N'P', N'PC'))
	DROP PROCEDURE [dbo].[s_Get_MonthToDate_StockMarginIO]
GO


CREATE PROCEDURE [dbo].[s_Get_MonthToDate_StockMarginIO]
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
				'select date as tdate, rtrim(accno) as accno, rtrim(name_1) as name_1,  '  +
				' case hf.type when ''0'' then ''Deposit'' else ''Withdraw'' end as type, amt ' +
				' from ' + 
				@GStrG2BSDB + '.dbo.histcl_fund hf, ' + 
				@GStrG2BSDB + '.dbo.client_master cm, ' + 
				@GStrG2BSDB + '.dbo.client_master_s cms' + 
				' where date >= ''' + @fromDate + ''' and date <= ''' + @toDate + ''' '   + 
				' and hf.aid = cms.aid and bhid = ''1019'' and cm.aid = cms.aid and purpose not in (''1'',''3'',''5'',''C'')  ' +
				' order by  accno, date '
	;


	PRINT @sqlStr
	EXEC (@sqlStr)

END
GO
