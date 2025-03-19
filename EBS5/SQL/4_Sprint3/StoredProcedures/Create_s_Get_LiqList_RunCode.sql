SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_Get_LiqList_RunCode]') AND TYPE IN (N'P', N'PC'))
	DROP PROCEDURE [dbo].[s_Get_LiqList_RunCode]
GO


/*-- =============================================
-- Author : Eddie
-- Create date : 2017/10/19 16:19
-- Last update : 2017/10/20 10:47
-- Description : Search Procedure FOR Liquidation Listing Runer Code
-- ============================================= */
CREATE PROCEDURE [dbo].[s_Get_LiqList_RunCode]
	@liqDB varchar(100)
AS
BEGIN
    Set NOCOUNT ON;
    Set XACT_ABORT ON;

    BEGIN TRAN
	  DECLARE @sqlStr NVARCHAR(1000)
	  SET @sqlStr = 'SELECT
	     DISTINCT ' + @liqDB + '.DBO.stcltmaster.run_code
      FROM
	     ' + @liqDB + '.DBO.stcltmaster, 
		 ' + @liqDB + '.DBO.stcltliq
	  WHERE
	      ' + @liqDB + '.DBO.stcltmaster.clt_code =  ' + @liqDB + '.DBO.stcltliq.clt_code 
      AND  ' + @liqDB + '.DBO.stcltliq.liq_day > 0
	  ORDER BY  ' + @liqDB + '.DBO.stcltmaster.run_code'
	  
	  EXEC(@sqlStr)
    
	COMMIT TRANSACTION  
  
    IF(@@ERROR <> 0) 
	    BEGIN 
		ROLLBACK TRANSACTION
		SELECT 0
		END

END

GO
