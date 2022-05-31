


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*-- =============================================
-- Author : HugoLaw
-- Create date : 2017/10/26 16:19
-- Last update : 2017/10/26 10:47
-- Description : Search Procedure FOR CRCDebitBalance
-- ============================================= */

IF OBJECT_ID('[dbo].[s_Get_CRSMaster]') > 0
BEGIN
	DROP PROCEDURE [dbo].[s_Get_CRSMaster]
END
GO

CREATE PROCEDURE [dbo].[s_Get_CRSMaster]
(
	@AccType [nvarchar](20),
	@CrsType [nvarchar](20),
	@Accno [nvarchar](72)
)
AS


	SELECT
		  m.[Mid],
		  m.[Accno],
		  m.[AccType],
		  m.[Firstname] + ' ' + m.[LastName] AS [ClientName],
		  m.[Firstname],
		  m.[LastName],
		  m.[AccHolderType],
		  m.[CPType],
		  m.[ResCountryCode],
		  m.[TIN],
		  m.[TINIssueBy],
		  m.BirthDate,
		  m.[BirthCountryCode],
		  m.[BirthCity],
		  m.[AddressCountryCode],
		  m.[LegalAddressType],
		  m.AddressFree,
		  (CASE m.[CrsType]
			WHEN 'I' THEN 'Individual'
			WHEN 'J' THEN 'Joint'
			WHEN 'E' THEN 'Entity'
			WHEN 'CP' THEN 'Controlling Person'
			ELSE ''
		  END) AS CrsType
	FROM [dbo].[CRSMaster] AS m
	WHERE m.[AccType] = @AccType
		AND (m.[Accno] LIKE '%' + @Accno + '%')
		AND (m.[CrsType] LIKE '%' + @CrsType + '%')
	ORDER BY M.Accno
GO



--EXEC [dbo].[s_Get_CRSMaster] 'Securities','',''