USE [ESL_LIQ]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SELECT * INTO [ESL_LIQ].[dbo].[client_liq_master_US] FROM [ESL_LIQ].[dbo].[client_liq_master];
GO

ALTER TABLE [dbo].[client_liq_master_US] ADD  CONSTRAINT [DF_client_liq_master_US_CR_LIMIT]  DEFAULT (0) FOR [CR_LIMIT]
GO

ALTER TABLE [dbo].[client_liq_master_US] ADD  CONSTRAINT [DF_client_liq_master_US_CR_BAL]  DEFAULT (0) FOR [CR_BAL]
GO

ALTER TABLE [dbo].[client_liq_master_US] ADD  CONSTRAINT [DF_client_liq_master_US_DR_BAL]  DEFAULT (0) FOR [DR_BAL]
GO

ALTER TABLE [dbo].[client_liq_master_US] ADD  CONSTRAINT [DF_client_liq_master_US_DEPOSIT]  DEFAULT (0) FOR [DEPOSIT]
GO

ALTER TABLE [dbo].[client_liq_master_US] ADD  CONSTRAINT [DF_client_liq_master_US_WITHDRAWAL]  DEFAULT (0) FOR [WITHDRAWAL]
GO

ALTER TABLE [dbo].[client_liq_master_US] ADD  CONSTRAINT [DF_client_liq_master_US_AVAIL_BAL]  DEFAULT (0) FOR [AVAIL_BAL]
GO

ALTER TABLE [dbo].[client_liq_master_US] ADD  CONSTRAINT [DF_client_liq_master_US_MKT_VALUE]  DEFAULT (0) FOR [MKT_VALUE]
GO

ALTER TABLE [dbo].[client_liq_master_US] ADD  CONSTRAINT [DF_client_liq_master_US_MARGIN_VALUE]  DEFAULT (0) FOR [MARGIN_VALUE]
GO

ALTER TABLE [dbo].[client_liq_master_US] ADD  CONSTRAINT [DF_client_liq_master_US_MARGIN_RATIO]  DEFAULT (0) FOR [MARGIN_RATIO]
GO

ALTER TABLE [dbo].[client_liq_master_US] ADD  CONSTRAINT [DF_client_liq_master_US_NET_TRADE]  DEFAULT (0) FOR [NET_TRADE]
GO

ALTER TABLE [dbo].[client_liq_master_US] ADD  CONSTRAINT [DF_client_liq_master_US_T1_UNREALIZED]  DEFAULT (0) FOR [T1_UNREALIZED]
GO

ALTER TABLE [dbo].[client_liq_master_US] ADD  CONSTRAINT [DF_client_liq_master_US_T2_UNREALIZED]  DEFAULT (0) FOR [T2_UNREALIZED]
GO

ALTER TABLE [dbo].[client_liq_master_US] ADD  CONSTRAINT [DF_client_liq_master_US_INTEREST]  DEFAULT (0) FOR [INTEREST]
GO

ALTER TABLE [dbo].[client_liq_master_US] ADD  CONSTRAINT [DF_client_liq_master_US_MC_CR_BAL]  DEFAULT (0) FOR [MC_CR_BAL]
GO

ALTER TABLE [dbo].[client_liq_master_US] ADD  CONSTRAINT [DF_client_liq_master_US_MC_DR_BAL]  DEFAULT (0) FOR [MC_DR_BAL]
GO

ALTER TABLE [dbo].[client_liq_master_US] ADD  CONSTRAINT [DF_client_liq_master_US_MC_ACT_RATIO]  DEFAULT (0) FOR [MC_ACT_RATIO]
GO

ALTER TABLE [dbo].[client_liq_master_US] ADD  CONSTRAINT [DF_client_liq_master_US_MC_DUE]  DEFAULT (0) FOR [MC_DUE]
GO

ALTER TABLE [dbo].[client_liq_master_US] ADD  CONSTRAINT [DF_client_liq_master_US_MC_T2]  DEFAULT (0) FOR [MC_T2]
GO

ALTER TABLE [dbo].[client_liq_master_US] ADD  CONSTRAINT [DF_client_liq_master_US_MC_OVERDRAFT]  DEFAULT (0) FOR [MC_OVERDRAFT]
GO

ALTER TABLE [dbo].[client_liq_master_US] ADD  CONSTRAINT [DF_client_liq_master_US_MC_TOTAL]  DEFAULT (0) FOR [MC_TOTAL]
GO

ALTER TABLE [dbo].[client_liq_master_US] ADD  CONSTRAINT [DF_client_liq_master_US_OS_DAY]  DEFAULT (0) FOR [OS_DAY]
GO

ALTER TABLE [dbo].[client_liq_master_US] ADD  CONSTRAINT [DF_client_liq_master_US_SHORT]  DEFAULT (0) FOR [SHORT]
GO


