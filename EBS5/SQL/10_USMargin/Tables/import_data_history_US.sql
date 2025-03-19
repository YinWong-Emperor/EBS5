USE [ESL]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[import_data_history_US](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[group] [varchar](100) NOT NULL,
	[current_step] [int] NOT NULL,
	[totle_step] [int] NOT NULL,
	[message] [varchar](4000) NOT NULL,
	[effect_count] [int] NOT NULL,
	[error] [varchar](max) NOT NULL,
	[create_user] [varchar](30) NOT NULL,
	[create_date] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[import_data_history_US] ADD  DEFAULT ((0)) FOR [effect_count]
GO

ALTER TABLE [dbo].[import_data_history_US] ADD  DEFAULT ('') FOR [error]
GO


