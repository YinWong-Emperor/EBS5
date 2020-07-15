IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CRSMaster]') AND type in (N'U'))
    DROP TABLE [dbo].[CRSMaster]
GO


SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CRSMaster](
	[Mid] INT IDENTITY(1,1) PRIMARY KEY,
	[Accno] [nvarchar](72),
	[AccType] [nvarchar](20),
	[CrsType] [nvarchar](20),	
	[AccHolderType] [nvarchar](20),
	[CPType] [nvarchar](20),	
	[FirstName] [nvarchar](70),	
	[LastName] [nvarchar](70),	
	[ResCountryCode] [nvarchar](10),
	[TIN] [nvarchar](80),
	[TINIssueBy] [nvarchar](10),
	[BirthDate] SMALLDATETIME,
	[BirthCountryCode] [nvarchar](10),
	[BirthCity] NVARCHAR(70),
	[AddressCountryCode] [nvarchar](10),
	[LegalAddressType] [nvarchar](20),
	[AddressFree] [ntext]
)
GO


INSERT INTO [dbo].[CRSMaster]([Accno],[AccType],[CrsType],[AccHolderType],[CPType],[ResCountryCode],[FirstName],[LastName],[TIN],[TINIssueBy],[BirthDate] ,[BirthCountryCode],[BirthCity],[AddressCountryCode],[LegalAddressType],[AddressFree])
SELECT [Accno],[AccType],[CrsType],[AccHolderType],[CPType],[ResCountryCode],[FirstName],[LastName],[TIN],[TINIssueBy],[BirthDate] ,[BirthCountryCode],[BirthCity],[AddressCountryCode],[LegalAddressType],[AddressFree] FROM CRSACCOUNTINFO
WHERE ISNULL( CRSTYPE ,'') <> ''
GO




 
