SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_Get_LiqList]') AND TYPE IN (N'P', N'PC'))
	DROP PROCEDURE [dbo].[s_Get_LiqList]
GO

/*-- =============================================
-- Author : Eddie
-- Create date : 2017/10/19 16:19
-- Last update : 2017/10/20 10:47
-- Description : Search Procedure FOR Liquidation Listing
-- ============================================= */
CREATE PROCEDURE [dbo].[s_Get_LiqList]
	@CltType varchar(100),
	@Rad varchar(10)
AS
BEGIN
    Set NOCOUNT ON;
    Set XACT_ABORT ON;

    BEGIN TRAN
	 DECLARE @sqlStr NVARCHAR(1000)
	 
	 SET @sqlStr = 'SELECT 
		mst.run_code, 
		mst.clt_code, 
		mst.mc_dr_bal, 
		mst.mkt_value,  
		STR(mst.mc_act_ratio, 10, 2) + '' %'' as aratio, 
		STR(mst.margin_ratio, 10, 2) + '' %'' as mratio, 
		mst.mc_due, mst.mc_t2, 
		mst.mc_total, 
		mst.os_day, 
		mst.net_trade, 
		mst.cr_limit, 
		mst.clt_name 
	FROM 
		##stcltmaster'+@Rad+' mst, ##clt_tmp'+@Rad+' liq 
	WHERE 
		mst.clt_code = liq.clt_code'

	IF (@CltType = '')
	  BEGIN
		EXEC(@sqlStr +  ' AND mst.clt_type in (''M'', ''F'', ''C'') ORDER BY mst.clt_code')
	  END
	ELSE
	  BEGIN
	    EXEC(@sqlStr +  ' AND mst.clt_type ='''+@CltType+ ''' ORDER BY mst.clt_code')
	  END

    SET @sqlStr = 'SELECT 
		''Total'' AS ttl_desc, 
		COUNT(*) AS ttl_rec, 
		SUM(mst.mc_dr_bal) AS s_mc_dr_bal, 
		SUM(mst.mkt_value) AS s_mkt_value,  
		SUM(mst.mc_due) AS s_mc_due, 
		SUM(mst.mc_t2) AS s_mc_t2, 
		SUM(mst.mc_total) AS s_mc_total, 
		SUM(mst.net_trade) AS s_net_trade,
		SUM(mst.cr_limit) AS s_cr_limit  
		FROM ##stcltmaster'+@Rad+' mst, ##clt_tmp'+@Rad+' liq 
	WHERE mst.clt_code = liq.clt_code'

	IF (@CltType = '')
	  BEGIN
		EXEC(@sqlStr +  ' AND mst.clt_type in (''M'', ''F'', ''C'')')
	  END
	ELSE
	  BEGIN
	    EXEC(@sqlStr +  ' AND mst.clt_type ='''+@CltType+'''')
	  END
    
	COMMIT TRANSACTION  
  
    IF(@@ERROR <> 0) 
	    BEGIN 
		ROLLBACK TRANSACTION
		SELECT 0
		END
END

GO
