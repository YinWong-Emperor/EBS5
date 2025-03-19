BEGIN TRANSACTION

DELETE FROM [ESL].[dbo].[misc_master] WHERE misc_type = 'FUTURESREPORT' AND misc_code = 'COUNTERPARTY' AND misc_desc = 'ADV'

COMMIT