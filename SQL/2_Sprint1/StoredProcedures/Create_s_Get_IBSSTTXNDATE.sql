
/****** Object:  StoredProcedure [dbo].[s_Get_IBSSTTXNDATE]    Script Date: 2017/10/26 10:41:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*-- =============================================
-- Author : HugoLaw
-- Create date : 2017/10/26 16:19
-- Last update : 2017/10/26 10:47
-- Description : Search Procedure FOR CRCDebitBalance
-- ============================================= */

IF OBJECT_ID('[dbo].[s_Get_IBSSTTXNDATE]') > 0
BEGIN
	DROP PROCEDURE [dbo].[s_Get_IBSSTTXNDATE]
END
GO

CREATE PROCEDURE [dbo].[s_Get_IBSSTTXNDATE]
	@LiqConn varchar(100)
AS
BEGIN

	EXEC (' SELECT TOP 1 t2_date from ' + @LiqConn + '.[DBO].[IBSSTTXNDATE]')

END
GO

--EXEC [dbo].[s_Get_IBSSTTXNDATE] 'ESL_lIQ_DEV'