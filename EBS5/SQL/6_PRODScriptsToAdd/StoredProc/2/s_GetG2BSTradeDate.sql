USE [ESL]
GO
DROP PROCEDURE [dbo].[s_Get_G2BSTradeDate]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--EXEC [dbo].[s_Get_G2BSTradeDate] 'G2BS_RET.G2BS_RET'
CREATE PROCEDURE [dbo].[s_Get_G2BSTradeDate]
	@G2BSDB nvarchar(100)
AS
BEGIN

	EXEC ('SELECT trade_date FROM ' +  @G2BSDB + '.dbo.View_er_system_parameter WITH(NOLOCK)')

END

GO


