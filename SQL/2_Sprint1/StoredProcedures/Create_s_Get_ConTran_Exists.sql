SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*-- =============================================
-- Author : David Yang
-- Create date : 2017/11/13 14:19
-- Last update : 2017/11/13 14:47
-- Description : Search Procedure FOR Client
-- ============================================= */

IF OBJECT_ID('[dbo].[s_ConTran_Exists]') > 0
BEGIN
	DROP PROCEDURE [dbo].[s_ConTran_Exists]
END
GO

CREATE PROCEDURE [dbo].[s_ConTran_Exists]
	@LiqConn varchar(100),
	@clt_code varchar(500)
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @sqlStr NVARCHAR(1500)

	SET @sqlStr = 'select 1 from ' + @LiqConn + '.[dbo].STCLTMASTER where clt_code = ''' + @clt_code + ''''

	PRINT @sqlStr

	EXECUTE  sp_ExecuteSql  @sqlstr
	
END

