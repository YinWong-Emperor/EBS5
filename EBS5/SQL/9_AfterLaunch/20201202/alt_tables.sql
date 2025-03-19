BEGIN TRAN
ALTER TABLE ESL.[dbo].[st_clt_portfolio]
ADD net_qty_onhand numeric(38,6) null,
	net_market_value numeric(38,6) null;
COMMIT