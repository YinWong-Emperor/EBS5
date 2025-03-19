IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[st_clt_portfolio]') AND type in (N'U'))
    DROP TABLE [dbo].[st_clt_portfolio]
GO

CREATE TABLE [dbo].[st_clt_portfolio](
	[clt_code]		[varchar](8) NULL,
	[stk_code]		[varchar](20) NULL, -- 出现长度大于5的数据，改成20
	[txn_date]		[datetime] NULL,
	[qty_underreg]	NUMERIC(38,6) NULL,
	[qty_onhand]	NUMERIC(38,6) NULL,
	[qty_total]		NUMERIC(38,6) NULL,
	[mkt_price]		NUMERIC(38,6) NULL,
	[mkt_value]		NUMERIC(38,6) NULL,
	[margin_ratio] NUMERIC(38,6) NULL,
	[margin_value] NUMERIC(38,6) NULL,
	[suspend_flag] [varchar](1) NULL
) ON [PRIMARY]

GO
