
/*-- =============================================
-- Author : DoraemonYu
-- Create date : 2017/12/04 14:28
-- Last update : 2017/12/04 14:28
-- ============================================= */


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_Get_MonthToDate_EIEHK]') AND TYPE IN (N'P', N'PC'))
	DROP PROCEDURE [dbo].[s_Get_MonthToDate_EIEHK]
GO


CREATE PROCEDURE [dbo].[s_Get_MonthToDate_EIEHK]
	@GStrG2BSDB varchar(100)
AS
BEGIN

	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	DECLARE @sqlStr  NVARCHAR(1000)

	SET @sqlStr = 
	'SELECT		accno, '  +
				'name_1, ' +
				'aeno, ' +
				'branch_master.name, ' +
				'date_open ' +
	'FROM		' + @GStrG2BSDB + '.dbo.client_master as client_master, ' +
				  + @GStrG2BSDB + '.dbo.client_master_s as client_master_s, ' +
				  + @GStrG2BSDB + '.dbo.branch_master as branch_master, ' +
				  + @GStrG2BSDB + '.dbo.ae_master as ae_master ' +
	'WHERE		client_master.aid = client_master_s.aid ' +
				'AND client_master_s.bhid = branch_master.bhid ' +
				'AND client_master_s.aeid = ae_master.aeid ' +
				'AND branch_master.name LIKE ''%EIEHK%''  ' +
	'ORDER BY	branch_master.name, ' +
				'date_open '
	;



	PRINT @sqlStr
	EXEC (@sqlStr)

END
GO
