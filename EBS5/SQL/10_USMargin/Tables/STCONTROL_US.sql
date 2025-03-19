USE [ESL_LIQ]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SELECT * INTO [ESL_LIQ].[dbo].[stcontrol_US] FROM [ESL_LIQ].[dbo].[stcontrol];
GO

UPDATE [ESL_LIQ].[dbo].[stcontrol_US] SET TradeDate = (SELECT MAX(tdate) FROM G2BS_RET.G2SB_UAT_DT.dbo.view_G2B_client_trade_dt_with_comm WHERE market = 'US');
GO


