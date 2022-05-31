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

IF OBJECT_ID('[dbo].[s_Get_CRSCountryCode_CMB]') > 0
BEGIN
	DROP PROCEDURE [dbo].[s_Get_CRSCountryCode_CMB]
END
GO

IF OBJECT_ID('[dbo].[s_Get_CRSCountryCode]') > 0
BEGIN
	DROP PROCEDURE [dbo].[s_Get_CRSCountryCode]
END
GO


CREATE PROCEDURE [dbo].[s_Get_CRSCountryCode]
AS

	SELECT CCode + ' - ' + CName AS [TEXT] , CCode as VALUE
	FROM DBO.CRSCountryCode
	WHERE NeedCRS = 1
	ORDER BY CCode
GO

--EXEC [dbo].[s_Get_CRSCountryCode_CMB]