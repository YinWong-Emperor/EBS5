
/****** Object:  StoredProcedure [dbo].[s_Get_ExchangeRate_Type]    Script Date: 2017/11/2 15:10:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*-- =============================================
-- Author : HugoLaw
-- Create date : 2017/11/2
-- Last update : 
-- Description : Search Procedure FOR exchangerate type
-- ============================================= */


IF OBJECT_ID('[dbo].[s_Get_ExchangeRate_Type]') > 0
BEGIN
	DROP PROCEDURE [dbo].s_Get_ExchangeRate_Type
END
GO

CREATE PROCEDURE [dbo].[s_Get_ExchangeRate_Type]
AS
BEGIN

	SELECT system_type
	FROM exchangerate
	GROUP BY system_type
	ORDER BY system_type

END
GO