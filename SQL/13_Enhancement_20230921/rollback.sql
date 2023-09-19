begin tran

delete from [ESL].[dbo].[opening_balance] where counterparty = 'ADV'

COMMIT tran