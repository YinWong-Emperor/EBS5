IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[client_cheque]') AND type in (N'U'))
    DROP TABLE [dbo].[client_cheque]
GO

CREATE TABLE [dbo].[client_cheque](
	[sequence] int NOT NULL,
	[client_code] [varchar](8) NOT NULL,
	[txn_date] [datetime] NOT NULL,
	[amount] numeric(18,2) NOT NULL,
	[name] [nvarchar](120) NOT NULL,
	create_user [varchar](30) NOT NULL,
	create_date [datetime] NOT NULL,
	last_upd_user [varchar](30) NOT NULL,
	last_upd_date  [datetime] NOT NULL
) ON [PRIMARY]

ALTER TABLE [dbo].[client_cheque] ADD  CONSTRAINT [DF_client_cheque_create_user]  DEFAULT ('') FOR create_user
ALTER TABLE [dbo].[client_cheque] ADD  CONSTRAINT [DF_client_cheque_create_date]  DEFAULT (getdate()) FOR create_date
ALTER TABLE [dbo].[client_cheque] ADD  CONSTRAINT [DF_client_cheque_last_upd_user]  DEFAULT ('') FOR last_upd_user
ALTER TABLE [dbo].[client_cheque] ADD  CONSTRAINT [DF_client_cheque_last_upd_date]  DEFAULT (getdate()) FOR last_upd_date

GO
