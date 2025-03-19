USE [ESL]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[temp_stock_option_bal](
	[accno_org] [varchar](25) NOT NULL,
	[accno_map] [varchar](20) NULL,
	[cfbal] [numeric](18, 2) NOT NULL,
	[tdate] [smalldatetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[accno_org] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


