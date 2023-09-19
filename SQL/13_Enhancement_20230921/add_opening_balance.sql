begin tran

IF NOT EXISTS
(
select 1 from [ESL].[dbo].[opening_balance] where counterparty = 'ADV'
)

insert into opening_balance (tdate,opnBal, NopnBal, counterparty) values ('2023-07-01 00:00:00.000','0','0','ADV') 

COMMIT tran