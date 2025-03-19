IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[hsbc]') AND type in (N'U'))
    DROP TABLE [dbo].[hsbc]
GO

CREATE TABLE [dbo].[hsbc](
	[vdate] [nvarchar](20) NOT NULL CONSTRAINT [DF_HSBC_vdate]  DEFAULT (''),
	[accno] [nvarchar](20) NOT NULL CONSTRAINT [DF_HSBC_accno]  DEFAULT (''),
	[ccy] [nvarchar](3) NOT NULL CONSTRAINT [DF_HSBC_ccy]  DEFAULT (''),
	[amount] [decimal](14, 2) NOT NULL CONSTRAINT [DF_HSBC_amount]  DEFAULT ((0)),
	[ctype] [nvarchar](50) NOT NULL CONSTRAINT [DF_HSBC_ctype]  DEFAULT (''),
	[cdate] [nvarchar](20) NOT NULL CONSTRAINT [DF_HSBC_cdate]  DEFAULT (''),
	[description] [nvarchar](2500) NOT NULL CONSTRAINT [DF_HSBC_description]  DEFAULT (''),
	[create_user] [nvarchar](20) NOT NULL CONSTRAINT [DF_HSBC_create_user]  DEFAULT (''),
	[create_date] [datetime] NOT NULL CONSTRAINT [DF_HSBC_create_date]  DEFAULT (getdate())
) ON [PRIMARY]

GO