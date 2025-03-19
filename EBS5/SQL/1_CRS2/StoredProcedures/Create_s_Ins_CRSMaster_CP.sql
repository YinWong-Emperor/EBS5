




SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_Ins_CRSMaster_CP]') AND TYPE IN (N'P', N'PC'))
	DROP PROCEDURE [dbo].s_Ins_CRSMaster_CP
GO

/*-- =============================================
-- Author : DavidYang
-- Create date : 2017/10/19 16:19
-- Last update : 2017/11/21 15:00
-- Description : Add Procedure FOR ChequePrinting
-- ============================================= */
CREATE PROCEDURE [dbo].[s_Ins_CRSMaster_CP]
(
	@Accno [nvarchar](72),
	@AccType [nvarchar](20),
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

	IF EXISTS (SELECT 1 FROM [dbo].[CRSMaster] WHERE  [Accno] = @Accno AND CrsType = 'CP' AND FirstName = @FirstName AND LastName = @LastName)
	BEGIN
		SELECT 2
		RETURN
	END

	BEGIN TRY
	   BEGIN TRANSACTION

	   

		INSERT INTO [dbo].[CRSMaster]([Accno],[AccType],[CrsType],[CPType],[FirstName],[LastName],[ResCountryCode],[TIN],[TINIssueBy],[BirthDate],[BirthCountryCode]
										,[BirthCity],[AddressCountryCode],[LegalAddressType],[AddressFree])
		VALUES (@Accno,@AccType,'CP',@CPType,@FirstName,@LastName,@ResCountryCode,@TIN,@TINIssueBy,@BirthDate,@BirthCountryCode
										,@BirthCity,@AddressCountryCode,@LegalAddressType,@AddressFree)

		DECLARE @return_year INT
		select top 1 @return_year = [ReturnYear] FROM [CRSAccountInfo] WHERE [Accno] = @Accno AND CrsType = 'E'

		INSERT INTO [dbo].[CRSAccountInfo]([AccType],[ReturnYear],[Accno],[CrsType],[ClientName],[FirstName],[LastName],[NameType],[CPType],[ResCountryCode],[TIN],[TINIssueBy]
										,[BirthDate],[BirthCountryCode],[BirthCity],[AddressCountryCode],[LegalAddressType],[AddressFree])
		VALUES(@AccType,@return_year,@Accno,'CP',@FirstName+' '+@LastName,@FirstName,@LastName ,'OECD202',@CPType,@ResCountryCode,@TIN,@TINIssueBy,@BirthDate,@BirthCountryCode,@BirthCity,@AddressCountryCode,@LegalAddressType,@AddressFree)
     


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
	
