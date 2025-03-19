USE [ESL]
GO
DROP PROCEDURE IF EXISTS [dbo].[s_Import_CRSAccountInfo]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--EXEC [dbo].[s_Import_CRSAccountInfo] 2019
CREATE PROCEDURE [dbo].[s_Import_CRSAccountInfo]
	@year int
AS
BEGIN

BEGIN TRAN

	BEGIN TRY

		EXEC dbo.s_Import_CRSAccountInfo_s @year
		EXEC dbo.s_Import_CRSAccountInfo_f @year
	END TRY
	BEGIN CATCH
		ROLLBACK
		DECLARE @ErrorMessage NVARCHAR(4000);  
		DECLARE @ErrorSeverity INT;  
		DECLARE @ErrorState INT;  
		SELECT  @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE(); 
		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState)
	END CATCH

COMMIT

END
GO


