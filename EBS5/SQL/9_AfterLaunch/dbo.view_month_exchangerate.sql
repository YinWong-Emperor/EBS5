USE [ESL]
GO
DROP VIEW [dbo].[view_month_exchangerate]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--SELECT * FROM [dbo].[view_month_exchangerate] ORDER BY txmonth desc, system_type, currency_in
CREATE view [dbo].[view_month_exchangerate] as

SELECT A.*, txmonth=CAST(DATEPART(yyyy,A.tdate) AS varchar(4)) + RIGHT('00' + CAST(DATEPART(mm,A.tdate) AS varchar(2)), 2)
FROM exchangerate A
JOIN 
(
	select system_type, year=year(tdate), month=month(tdate), currency_in, currency_out, tdate=max(tdate)
	from exchangerate 
	group by system_type, year(tdate), month(tdate), currency_in, currency_out
) B
ON A.system_type COLLATE DATABASE_DEFAULT = B.system_type COLLATE DATABASE_DEFAULT
AND A.tdate = B.tdate
AND A.currency_in COLLATE DATABASE_DEFAULT = B.currency_in COLLATE DATABASE_DEFAULT
AND A.currency_out COLLATE DATABASE_DEFAULT = B.currency_out COLLATE DATABASE_DEFAULT
--ORDER BY txmonth desc, system_type, currency_in

GO


