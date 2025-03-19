IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[test_port]') AND type in (N'U'))
    DROP TABLE [dbo].[test_port]
GO

CREATE TABLE [dbo].[test_port](
	clt_code VARCHAR(20) NOT NULL,
	stk_code VARCHAR(10) NOT NULL,
	qty NUMERIC(38,6) NOT NULL,
	bt_qty NUMERIC(38,6) NOT NULL,
	st_qty NUMERIC(38,6) NOT NULL
)

GO
