SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_Get_LiqList_Prc]') AND TYPE IN (N'P', N'PC'))
	DROP PROCEDURE [dbo].[s_Get_LiqList_Prc]
GO

/*-- =============================================
-- Author : Eddie
-- Create date : 2017/10/19 16:19
-- Last update : 2017/10/20 10:47
-- Description : Procedure FOR Liquidation Listing Print
-- ============================================= */
CREATE PROCEDURE [dbo].[s_Get_LiqList_Prc]
            @amtCR DECIMAL(12, 2),
            @amtDR DECIMAL(12, 2),
            @amtMktMore DECIMAL(12, 2),
            @amtMktLess DECIMAL(12, 2),
            @amtActRatio DECIMAL(12, 2),
            @amtMarRatio DECIMAL(12, 2),
            @amtDue DECIMAL(12, 2),
            @amtUndue DECIMAL(12, 2),
            @amtTotal DECIMAL(12, 2),
            @amtLimit DECIMAL(12, 2),
            @amtOverDraft DECIMAL(12, 2),
            @cBoRunFrom varchar(20),
            @cBoRunTo varchar(20),
            @clientFrom varchar(20),
            @clientTo varchar(20),
            @name varchar(20),
            @amtOSDay DECIMAL(12, 2),
            @lstrCltType varchar(20),
			@Rad varchar(10)
AS
BEGIN
    Set NOCOUNT ON;
    Set XACT_ABORT ON;

    BEGIN TRAN
	 
	 DECLARE @sqlStr NVARCHAR(1000)

	 SET @sqlStr = 'SELECT 
	    *, mst.liq_day AS liq_day
	 FROM
		##stcltmaster'+@Rad+' mst
	 INNER JOIN 
		##clt_tmp'+@Rad+' liq 
	 ON mst.clt_code = liq.clt_code
	 WHERE 1 = 1 '

	 IF(@amtCR IS NOT NULL)
	   BEGIN
		  SET @sqlStr = @sqlStr + ' AND mc_cr_bal > '+ CAST(@amtCR AS NVARCHAR(15))
	   END

	 IF(@amtDR IS NOT NULL)
	   BEGIN
		  SET @sqlStr = @sqlStr + ' AND mc_dr_bal > '+ CAST(@amtDR AS NVARCHAR(15))
	   END

	 IF(@amtMktMore IS NOT NULL)
	   BEGIN
		  SET @sqlStr = @sqlStr + ' AND mkt_value > '+ CAST(@amtMktMore AS NVARCHAR(15))
	   END

	 IF(@amtMktLess IS NOT NULL)
	   BEGIN
		  SET @sqlStr = @sqlStr + ' AND mkt_value < '+ CAST(@amtMktLess AS NVARCHAR(15))
	   END

	 IF(@amtActRatio IS NOT NULL)
	   BEGIN
		  SET @sqlStr = @sqlStr + ' AND mc_act_ratio > '+ CAST(@amtActRatio AS NVARCHAR(15))
	   END

	 IF(@amtMarRatio IS NOT NULL)
	   BEGIN
		  SET @sqlStr = @sqlStr + ' AND margin_ratio > '+ CAST(@amtMarRatio AS NVARCHAR(15))
	   END

	 IF(@amtDue IS NOT NULL)
	   BEGIN
		  SET @sqlStr = @sqlStr + ' AND mc_due > '+ CAST(@amtDue AS NVARCHAR(15))
	   END

	 IF(@amtUndue IS NOT NULL)
	   BEGIN
		  SET @sqlStr = @sqlStr + ' AND mc_t2 > '+ CAST(@amtUndue AS NVARCHAR(15))
	   END

	 IF(@amtTotal IS NOT NULL)
	   BEGIN
		  SET @sqlStr = @sqlStr + ' AND mc_total > '+ CAST(@amtTotal AS NVARCHAR(15))
	   END

	 IF(@amtLimit IS NOT NULL)
	   BEGIN
		  SET @sqlStr = @sqlStr + ' AND cr_limit > '+ CAST(@amtLimit AS NVARCHAR(15))
	   END

	 IF(@amtOverDraft IS NOT NULL)
	   BEGIN
		  SET @sqlStr = @sqlStr + ' AND mc_overdraft > '+ CAST(@amtOverDraft AS NVARCHAR(15))
	   END

	 IF(@cBoRunFrom IS NOT NULL)
	   BEGIN
		  SET @sqlStr = @sqlStr + ' AND run_code >= '''+@cBoRunFrom + ''''
	   END

	 IF(@cBoRunTo IS NOT NULL)
	   BEGIN
		  SET @sqlStr = @sqlStr + ' AND run_code <= '''+@cBoRunTo + ''''
	   END

	 IF(@clientFrom IS NOT NULL)
	   BEGIN
		  SET @sqlStr = @sqlStr + ' AND mst.clt_code >= '''+@clientFrom + ''''
	   END

	 IF(@clientTo IS NOT NULL)
	   BEGIN
		  SET @sqlStr = @sqlStr + ' AND mst.clt_code <= '''+@clientTo + ''''
	   END

	 IF(@name IS NOT NULL)
	   BEGIN
		  SET @sqlStr = @sqlStr + ' AND UPPER(clt_name) LIKE ''%'+@name+'%'''
	   END

	 IF(@amtOSDay IS NOT NULL)
	   BEGIN
		  SET @sqlStr = @sqlStr + ' AND OS_DAY > '+ CAST(@amtOSDay AS NVARCHAR(15))
	   END

	 IF(@lstrCltType IS NOT NULL)
	   BEGIN
		  SET @sqlStr = @sqlStr + ' AND clt_type = '''+@lstrCltType+''''
	   END
	 ELSE
	   BEGIN
	      SET @sqlStr = @sqlStr + ' AND clt_type IN (''M'', ''C'')'
	   END

	SET @sqlStr = @sqlStr + ' ORDER BY 
	    mst.run_code, 
		mst.clt_type DESC, 
		mst.mc_act_ratio DESC, 
		mst.clt_code'
	EXEC(@sqlStr)
    
	COMMIT TRANSACTION  
  
    IF(@@ERROR <> 0) 
	    BEGIN 
		ROLLBACK TRANSACTION
		SELECT 0
		END

END

GO
