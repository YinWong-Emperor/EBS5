SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_Get_AccLst_Runner]') AND TYPE IN (N'P', N'PC'))
	DROP PROCEDURE [dbo].[s_Get_AccLst_Runner]
GO

/*-- =============================================
-- Author : Eddie
-- Create date : 2017/10/19 16:19
-- Last update : 2017/10/20 10:47
-- Description : Search Procedure FOR Account Listing Runer Code
-- ============================================= */
CREATE PROCEDURE [dbo].[s_Get_AccLst_Runner]
	@liqDB varchar(100)
AS
BEGIN
    Set NOCOUNT ON;
    Set XACT_ABORT ON;

    BEGIN TRAN
	  DECLARE @sqlStr NVARCHAR(1000)
	  SET @sqlStr = 'SELECT * FROM ' + @liqDB + '.DBO.staemaster ORDER BY run_code'
	  
	  EXEC(@sqlStr)
    
	COMMIT TRANSACTION  
  
    IF(@@ERROR <> 0) 
	    BEGIN 
		ROLLBACK TRANSACTION
		SELECT 0
		END

END

GO
