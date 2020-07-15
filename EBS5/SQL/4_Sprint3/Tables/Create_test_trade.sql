IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[test_trade]') AND type in (N'U'))
    DROP TABLE [dbo].[test_trade]
GO

CREATE TABLE [dbo].[test_trade](
	clt_code VARCHAR(20) NOT NULL,
	t1_trade NUMERIC(16,2) NOT NULL,
	t2_trade NUMERIC(16,2) NOT NULL,
	mkt_value NUMERIC(16,2) NOT NULL,
	margin_value NUMERIC(16,2) NOT NULL,
	t2_margin NUMERIC(16,2) NOT NULL
)

GO
