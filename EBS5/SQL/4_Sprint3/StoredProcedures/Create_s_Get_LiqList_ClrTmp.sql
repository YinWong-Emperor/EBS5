SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_Get_LiqList_ClrTmp]') AND TYPE IN (N'P', N'PC'))
	DROP PROCEDURE [dbo].[s_Get_LiqList_ClrTmp]
GO

/*-- =============================================
-- Author : Eddie
-- Create date : 2017/10/19 16:19
-- Last update : 2017/10/20 10:47
-- Description : Search Procedure FOR Liquidation Listing Clear Template
-- ============================================= */
CREATE PROCEDURE [dbo].[s_Get_LiqList_ClrTmp]
	@Rad varchar(10)
AS
BEGIN
    Set NOCOUNT ON;
    Set XACT_ABORT ON;

    BEGIN TRAN
	  DECLARE @sqlStr NVARCHAR(1000)

	  IF OBJECT_ID('tempdb..##stcltmaster'+@Rad) IS NOT NULL
		BEGIN
			EXEC('DROP TABLE ##stcltmaster'+@Rad)
		END

	  IF OBJECT_ID('tempdb..##margin_tmp'+@Rad) IS NOT NULL
		BEGIN
			EXEC('DROP TABLE ##margin_tmp'+@Rad)
		END

	  IF OBJECT_ID('tempdb..##clt_tmp'+@Rad) IS NOT NULL
		BEGIN
			EXEC('DROP TABLE ##clt_tmp'+@Rad)
		END

	  IF OBJECT_ID('tempdb..##cashin_tmp'+@Rad) IS NOT NULL
		BEGIN
			EXEC('DROP TABLE ##cashin_tmp'+@Rad)
		END

	  IF OBJECT_ID('tempdb..##os_tmp'+@Rad) IS NOT NULL
		BEGIN
			EXEC('DROP TABLE ##os_tmp'+@Rad)
		END

      SELECT 1
	COMMIT TRANSACTION  
  
    IF(@@ERROR <> 0) 
	    BEGIN 
		ROLLBACK TRANSACTION
		SELECT 0
		END

END


GO
