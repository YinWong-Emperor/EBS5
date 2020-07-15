

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_Upd_CRSMaster]') AND TYPE IN (N'P', N'PC'))
	DROP PROCEDURE [dbo].[s_Upd_CRSMaster]
GO

/*-- =============================================
-- Author : DavidYang
-- Create date : 2017/10/19 16:19
-- Last update : 2017/11/21 15:00
-- Description : Add Procedure FOR ChequePrinting
-- ============================================= */
CREATE PROCEDURE [dbo].[s_Upd_CRSMaster]
(
	@Mid INT = 0,
	@Accno [nvarchar](72),
	@CrsType [nvarchar](20),	
	@AccType [nvarchar](20),
	@AccHolderType [nvarchar](20),
	@CPType [nvarchar](20),	
	@FirstName [nvarchar](70),	
	@LastName [nvarchar](70),	
	@ResCountryCode [nvarchar](10),
	@TIN [nvarchar](80),
	@TINIssueBy [nvarchar](10),
	@BirthDate SMALLDATETIME,
	@BirthCountryCode [nvarchar](10),
	@BirthCity NVARCHAR(70),
	@AddressCountryCode [nvarchar](10),
	@LegalAddressType [nvarchar](20),
	@AddressFree [nvarchar](4000)
)
AS

	IF EXISTS (SELECT 1 FROM [dbo].[CRSMaster] WHERE  Accno = @Accno AND CrsType = @CrsType AND FirstName = @FirstName AND LastName = @LastName AND Mid <> @Mid)
	BEGIN
		IF (@CrsType = 'CP')
		BEGIN
			SELECT 2
			RETURN
		END
	END

	DECLARE @result INT

	BEGIN TRY
	   BEGIN TRANSACTION

	   

		UPDATE [dbo].[CRSMaster]
		SET	  [AccHolderType] = @AccHolderType
			  ,[CPType] = @CPType
			  ,[FirstName] = @FirstName
			  ,[LastName] = @LastName
			  ,[ResCountryCode] = @ResCountryCode
			  ,[TIN] = @TIN
			  ,[TINIssueBy] = @TINIssueBy
			  ,[BirthDate] = @BirthDate
			  ,[BirthCountryCode] = @BirthCountryCode
			  ,[BirthCity] = @BirthCity
			  ,[AddressCountryCode] = @AddressCountryCode
			  ,[LegalAddressType] = @LegalAddressType
			  ,[AddressFree] = @AddressFree
		WHERE Mid = @Mid
		
		IF EXISTS (SELECT 1 FROM DBO.CRSACCOUNTINFO WHERE Accno = @Accno and AccType = @AccType and CrsType = @CrsType)
		BEGIN
			UPDATE [dbo].[CRSAccountInfo]
			SET 
				[ClientName] = (CASE @CrsType WHEN 'CP' THEN @FirstName + ' ' + @LastName ELSE [ClientName] END)
				,[FirstName] = @FirstName
				,[LastName] = @LastName
				,[AccHolderType] = @AccHolderType
				,[CPType] = @CPType
				,[ResCountryCode] = @ResCountryCode
				,[TIN] = @TIN
				,[TINIssueBy] = @TINIssueBy
				,[BirthDate] = @BirthDate
				,[BirthCountryCode] = @BirthCountryCode
				,[AddressCountryCode] = @AddressCountryCode
				,[LegalAddressType] = @LegalAddressType
				,[AddressFree] = @AddressFree
				,[BirthCity] = @BirthCity
			WHERE Accno = @Accno and AccType = @AccType and CrsType = @CrsType AND FirstName = @FirstName AND LastName = @LastName
		END 
			   
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
