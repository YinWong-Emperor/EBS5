BEGIN TRANSACTION

IF NOT EXISTS
(
	SELECT 1
	FROM [ESL].[dbo].[misc_master] 
	WHERE misc_type = 'FUTURESREPORT' AND misc_code = 'COUNTERPARTY' AND misc_desc = 'ADV'
)
INSERT INTO [ESL].[dbo].[misc_master] VALUES ('FUTURESREPORT','COUNTERPARTY','ADV')
--SELECT * FROM [ESL].[dbo].[misc_master] WHERE misc_type = 'FUTURESREPORT' AND misc_code = 'COUNTERPARTY'

COMMIT