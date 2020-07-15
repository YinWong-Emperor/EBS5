IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[st_stk_txn_lst]') AND type in (N'U'))
    DROP TABLE [dbo].[st_stk_txn_lst]
GO

CREATE TABLE [dbo].[st_stk_txn_lst](
	clt_code VARCHAR(20) NOT NULL,
	inv_no VARCHAR(1) NOT NULL,
	txn_date DATETIME NOT NULL,
	stk_code VARCHAR(10) NOT NULL,
	stk_price NUMERIC(38,6) NOT NULL,
	txn_qty NUMERIC(38,6) NOT NULL,
	txn_to NUMERIC(38,6) NOT NULL,
	clt_comm NUMERIC(38,6) NOT NULL,
	run_rbt_ibs NUMERIC(38,6) NOT NULL,
	stamp_duty NUMERIC(38,6) NOT NULL,
	levy NUMERIC(38,6) NOT NULL,
	ic_levy NUMERIC(38,6) NOT NULL,
	trading_fee NUMERIC(38,6) NOT NULL,
	ccass_fee NUMERIC(38,6) NOT NULL,
	credit NUMERIC(38,6) NOT NULL,
	debit NUMERIC(38,6) NOT NULL
)

GO
