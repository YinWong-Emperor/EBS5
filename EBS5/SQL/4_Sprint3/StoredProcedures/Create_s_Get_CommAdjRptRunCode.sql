IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_Get_CommAdjRptRunCode]') AND TYPE IN (N'P', N'PC'))
	DROP PROCEDURE [dbo].[s_Get_CommAdjRptRunCode]
GO

/*-- =============================================
-- Author : Eddie
-- Create date : 2017/10/19 16:19
-- Last update : 2017/10/20 10:47
-- Description : CheckExist Procedure FOR CommAdjRptRunCode
-- ============================================= */
CREATE PROCEDURE [dbo].[s_Get_CommAdjRptRunCode]
    @liqDB nvarchar(100)
AS
BEGIN
    Set NOCOUNT ON;
    Set XACT_ABORT ON;

    BEGIN TRAN
	  DECLARE @sqlStr NVARCHAR(1000)

	  SET @sqlStr = 
	  'SELECT 
	      DISTINCT run_code 
	   FROM ' +@liqDB+ '.DBO.stcltmaster 
	   WHERE 
	      run_code <> ''''
	   ORDER BY run_code' 

	  EXEC (@sqlStr)
	   
    COMMIT TRANSACTION  
  
    IF(@@ERROR <> 0) 
	    BEGIN 
		ROLLBACK TRANSACTION
		SELECT 0
		END

END

GO