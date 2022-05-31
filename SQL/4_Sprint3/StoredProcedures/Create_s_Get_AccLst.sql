SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_Get_AccLst]') AND TYPE IN (N'P', N'PC'))
	DROP PROCEDURE [dbo].[s_Get_AccLst]
GO

/*-- =============================================
-- Author : Eddie
-- Create date : 2017/10/19 16:19
-- Last update : 2017/10/20 10:47
-- Description : Search Procedure FOR Account Listing
-- ============================================= */
CREATE PROCEDURE [dbo].[s_Get_AccLst]
	@liqDB varchar(100),
	@runFrm nvarchar(20),
    @runTo nvarchar(20),
    @strType nvarchar(20)
AS
BEGIN
    Set NOCOUNT ON;
    Set XACT_ABORT ON;

    BEGIN TRAN

	  DECLARE @sqlStr NVARCHAR(1000)

	  SET @sqlStr = 'SELECT
		mst.clt_code, 
		mst.clt_name, 
		run_code, 
		mst.clt_type, 
		dr_bal, 
		cr_bal, 
		mst.interest, 
		mc_act_ratio, 
		margin_ratio,mc_due, 
		mc_t2, 
		mc_total, 
		net_trade, 
		mkt_value, 
		CASE WHEN liq.liq_day IS NULL THEN 0 ELSE liq.liq_day END liq_day, 
		CASE WHEN mst_v.ava_bal IS NULL THEN 0 ELSE mst_v.ava_bal END ava_bal, 
		t1_trade, 
		t2_trade,
		mst_v.bal + mst.interest AS ledger_bal 
	FROM 
		' + @liqDB + '.DBO.stcltmaster mst 
	LEFT outer JOIN 
		' + @liqDB + '.DBO.testbal mst_v 
	ON mst.clt_code = mst_v.clt_code 
	LEFT OUTER JOIN  
		' + @liqDB + '.DBO.stcltliq liq 
	ON  mst.clt_code = liq.clt_code  
	WHERE  
	NOT (mst.cr_bal = 0 
		AND mst.dr_bal = 0  
		AND mst.mkt_value = 0  
		AND mst.mc_due = 0  
		AND mst.mc_t2 = 0  
		AND mst.mc_total = 0  
		AND mst.net_trade = 0)'

	  IF (@runFrm <> '')
	    BEGIN
		  SET @sqlStr = @sqlStr + 'AND run_code >= '''+@runFrm+ ''''
		END

	  IF (@runTo <> '')
	    BEGIN
		    SET @sqlStr = @sqlStr + 'AND run_code <= '''+@runTo+ ''''
		END
	  

	  IF (@strType = 'CASH')
		BEGIN
			SET @sqlStr = @sqlStr + 'AND mst.clt_type = ''C'' '
		END
	  ELSE IF (@strType = 'MARGIN')
		BEGIN
			SET @sqlStr = @sqlStr + 'AND mst.clt_type = ''M'' '
		END
	  ELSE
	    BEGIN
		    SET @sqlStr = @sqlStr + 'AND mst.clt_type in (''M'', ''C'') '
		END


	  SET @sqlStr = @sqlStr + ' ORDER BY mst.run_code, mst.clt_type DESC, ledger_bal '
	  EXEC (@sqlStr)
    
	COMMIT TRANSACTION  
  
    IF(@@ERROR <> 0) 
	    BEGIN 
		ROLLBACK TRANSACTION
		SELECT 0
		END

END

GO
