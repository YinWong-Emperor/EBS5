
/*-- =============================================
-- Author : DoraemonYu
-- Create date : 2017/12/05 17:08
-- Last update : 2017/12/05 17:08
-- ============================================= */


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_Get_MonthToDate_FuturesNewClients]') AND TYPE IN (N'P', N'PC'))
	DROP PROCEDURE [dbo].[s_Get_MonthToDate_FuturesNewClients]
GO


CREATE PROCEDURE [dbo].[s_Get_MonthToDate_FuturesNewClients]
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
					'select rtrim(accno) as accno, rtrim(name_1) as name_1, rtrim(aeno) as aeno, rtrim(cm.br_id) as idno, date_open '  +
					' from ' + 
					@GStrG2BFDB + '.dbo.client_master cm,  ' + 
					@GStrG2BFDB + '.dbo.client_master_f cmf, ' + 
					@GStrG2BFDB + '.dbo.ae_master aem ' + 					
					' where cm.aid = cmf.aid and cmf.aeid = aem.aeid ' + 
					' and date_open >= ''' + @fromDate + ''' ' + 
					' and date_open <= ''' + @toDate + ''' ' + 
					' order by date_open '
	;


	PRINT @sqlStr
	EXEC (@sqlStr)

END
GO
