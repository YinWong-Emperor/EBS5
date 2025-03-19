USE [ESL]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[menuDisable](
	[MnAMenuCode] [nvarchar](100) NOT NULL,
	[disableFlag] [int] NOT NULL,

	CONSTRAINT pk_menuDisable PRIMARY KEY (MnAMenuCode)
)
GO
