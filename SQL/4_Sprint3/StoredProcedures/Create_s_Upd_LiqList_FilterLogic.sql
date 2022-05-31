SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_Upd_LiqList_FilterLogic]') AND TYPE IN (N'P', N'PC'))
	DROP PROCEDURE [dbo].[s_Upd_LiqList_FilterLogic]
GO

/*-- =============================================
-- Author : Eddie
-- Create date : 2017/10/19 16:19
-- Last update : 2017/10/20 10:47
-- Description : Update Procedure FOR Liquidation Listing Filter Logic
-- ============================================= */
CREATE PROCEDURE [dbo].[s_Upd_LiqList_FilterLogic]
	@lstrSQL varchar(1000)
AS
BEGIN
    Set NOCOUNT ON;
    Set XACT_ABORT ON;

    BEGIN TRAN
	  UPDATE
		misc_master 
	  SET
		misc_desc = @lstrSQL
	  WHERE
		misc_type = 'LiqListLogic'
	  AND misc_code = 'liq_list_margin'
	 
	  SELECT 1

	COMMIT TRANSACTION  
  
    IF(@@ERROR <> 0) 
	    BEGIN 
		ROLLBACK TRANSACTION
		SELECT 0
		END

END

GO
