USE [esl]
GO

/****** Object:  StoredProcedure [dbo].[s_Get_CRSAccount_20180530]    Script Date: 09/19/2019 14:46:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[s_Get_CRSAccount_20180530]
(
	@g2bDB nvarchar(100)
)
AS

	Set NOCOUNT ON;
    Set XACT_ABORT ON;

	DECLARE @sqlStr nvarchar(MAX)

	SET @sqlStr = 'WITH 
		country_table as (
			select CCode,BeginDate,EndDate FROM dbo.[CRSCountryCode] WHERE NeedCRS = 1
		),
		stock_option AS(
		SELECT 
			sob.accno_map,
			sob.cfbal as bal
		FROM dbo.temp_stock_option_bal AS sob
		),
		crs_info AS(
			SELECT 
				a.[Crs_ID],a.[AccType],a.[ReturnYear],a.[Accno],
				(CASE WHEN ISNULL(a.[CloseDate],''1900-01-01'') = ''1900-01-01''  THEN ''false'' WHEN YEAR(a.[CloseDate]) > YEAR(GETDATE()) -1 THEN ''false'' ELSE ''true'' END) AS IS_Close,
				''false'' AS IS_Undocumented,''OECD604'' as AcctNumberType,
				a.[CrsType],a.[ClientName],a.[FirstName],a.[LastName],a.[NameType],a.[AccHolderType],a.[CPType],a.[ResCountryCode]
				   ,a.[TIN],a.[TINIssueBy],a.[BR_ID],a.[BirthDate],ISNULL(a.[BirthCountryCode],'''') AS BirthCountryCode,a.[AddressCountryCode],a.[AddressFree],ISNULL(a.[AccBal],0) + ISNULL(so.bal,0) AS AccBal,
				   (CASE WHEN a.CrsType IN (''I'',''E'',''J'') THEN ''OECD301 '' ELSE a.[LegalAddressType] END) AS [LegalAddressType],
				   (CASE WHEN [Dividend] <> 0 THEN ''CRS501'' WHEN [Interest] <> 0 THEN ''CRS502'' WHEN [Redemption] <> 0 THEN ''CRS503'' WHEN [OtherPayment] <> 0 THEN ''CRS504''  ELSE '''' END) AS payment_type,
				   (CASE WHEN [Dividend] <> 0 THEN [Dividend] WHEN [Interest] <> 0 THEN [Interest] WHEN [Redemption] <> 0 THEN [Redemption] WHEN [OtherPayment] <> 0 THEN [OtherPayment]  ELSE 0 END) AS payment_value,
				ct.begindate,ct.enddate
			FROM CRSAccountInfo AS a
			INNER JOIN country_table AS ct ON a.[ResCountryCode] = ct.CCode
			LEFT OUTER JOIN stock_option AS so ON a.[AccBal] = so.accno_map collate database_default
			WHERE AccType = ''Securities''
		)
		select 
			[Crs_ID],[AccType],[ReturnYear],crs_info.[Accno],IS_Close,IS_Undocumented,AcctNumberType,
			[CrsType],[ClientName],[FirstName],[LastName],[NameType],[AccHolderType],[CPType],[ResCountryCode],
			[TIN],[TINIssueBy],[BR_ID],[BirthDate],[BirthCountryCode],[AddressCountryCode],[AddressFree] as [AddressFree],[AccBal],
			[LegalAddressType],payment_type, (CASE WHEN payment_value < 0 THEN 0 ELSE payment_value END) as payment_value
		 from crs_info where [ReturnYear]=' + @g2bDB + '
			ORDER BY crs_info.[Accno]
		'
		PRINT @sqlStr

		EXECUTE  sp_ExecuteSql  @sqlStr
	



GO

