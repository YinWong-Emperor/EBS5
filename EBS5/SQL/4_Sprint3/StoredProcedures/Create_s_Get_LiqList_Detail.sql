SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_Get_LiqList_Detail]') AND TYPE IN (N'P', N'PC'))
	DROP PROCEDURE [dbo].[s_Get_LiqList_Detail]
GO

/*-- =============================================
-- Author : Eddie
-- Create date : 2017/10/19 16:19
-- Last update : 2017/10/20 10:47
-- Description : Search Procedure FOR Liquidation Listing
-- ============================================= */
CREATE PROCEDURE [dbo].[s_Get_LiqList_Detail]
    @lstrCltType varchar(20),
	@Rad varchar(10)
AS
BEGIN
    Set NOCOUNT ON;
    Set XACT_ABORT ON;

    BEGIN TRAN

	 DECLARE @sqlStr NVARCHAR(1000)
	 
	 SET @sqlStr = 'SELECT
		mst.*
	  FROM
		##stcltmaster'+@Rad+' mst, ##clt_tmp'+@Rad+' liq 
	  WHERE
		mst.clt_code = liq.clt_code'
		
	 IF (@lstrCltType IS NULL)
	   BEGIN
	     EXEC(@sqlStr + ' AND clt_type IN (''M'', ''F'', ''C'') ORDER BY mst.clt_code')
	   END
	 ELSE
	   BEGIN
	     EXEC(@sqlStr + ' AND clt_type = '''+@lstrCltType+''' ORDER BY mst.clt_code')
	   END
	  
	  EXEC(@sqlStr)

	COMMIT TRANSACTION  
  
    IF(@@ERROR <> 0) 
	    BEGIN 
		ROLLBACK TRANSACTION
		SELECT 0
		END

END

GO
