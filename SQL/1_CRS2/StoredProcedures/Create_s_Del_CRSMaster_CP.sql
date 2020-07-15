

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_Del_CRSMaster_CP]') AND TYPE IN (N'P', N'PC'))
	DROP PROCEDURE [dbo].[s_Del_CRSMaster_CP]
GO

/*-- =============================================
-- Author : DavidYang
-- Create date : 2017/10/19 16:19
-- Last update : 2017/11/21 15:00
-- Description : Add Procedure FOR ChequePrinting
-- ============================================= */
CREATE PROCEDURE [dbo].[s_Del_CRSMaster_CP]
(
	@Mid INT = 0,
	@Accno [nvarchar](72),
	@AccType [nvarchar](20),
	@FirstName [nvarchar](70),	
	@LastName [nvarchar](70)
)
AS

	
	BEGIN TRY
	   BEGIN TRANSACTION

		IF EXISTS (SELECT 1 FROM DBO.CRSACCOUNTINFO WHERE Accno = @Accno AND AccType = @AccType AND CrsType = 'CP' AND FirstName = @FirstName AND LastName = @LastName)
		BEGIN
			DELETE FROM DBO.CRSACCOUNTINFO WHERE  Accno = @Accno AND AccType = @AccType AND CrsType = 'CP' AND FirstName = @FirstName AND LastName = @LastName
		END 

		DELETE FROM DBO.CRSMASTER WHERE MID = @Mid

	   COMMIT 
	   SELECT 1
	END TRY
	BEGIN CATCH
	   IF @@TRANCOUNT > 0
		 ROLLBACK

	  DECLARE @ErrMsg nvarchar(4000), @ErrSeverity int
	  SELECT @ErrMsg = ERROR_MESSAGE(),
			 @ErrSeverity = ERROR_SEVERITY()

	  RAISERROR(@ErrMsg, @ErrSeverity, 1)
	  SELECT 0
	END CATCH

GO