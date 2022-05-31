IF  EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[future_product_master]') AND type in (N'U'))
    DROP TABLE [dbo].[future_product_master]
GO

CREATE TABLE [dbo].[future_product_master](
	[id] [int] identity(1,1) not null,
	[counter_party] [nvarchar](10) not null,
	[product_code] [nvarchar](10) not null,
	[product_name] [nvarchar](60) not null,
	[is_option] bit not null,
	[strike_dec_pla] int not null,
	[price_dec_pla] int not null,
	[contract_size] int not nULL,
	PRIMARY KEY CLUSTERED 
	(
		[id] ASC
	)
) ON [PRIMARY]

GO
