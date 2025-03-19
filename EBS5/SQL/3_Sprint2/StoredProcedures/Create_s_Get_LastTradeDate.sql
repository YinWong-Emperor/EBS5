
/*-- =============================================
-- Author : DoraemonYu
-- Create date : 2017/11/28 10:32
-- Last update : 2017/11/28 10:32
-- ============================================= */


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[s_Get_LastTradeDate]') AND TYPE IN (N'P', N'PC'))
	DROP PROCEDURE [dbo].[s_Get_LastTradeDate]
GO


CREATE PROCEDURE [dbo].[s_Get_LastTradeDate]
	@LiqConn varchar(100)
AS
BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	DECLARE @sqlStr  NVARCHAR(1000)
	SET @sqlStr = 'WITH hd as (	SELECT tdate FROM ' + @LiqConn + '.[dbo].[histcltradeh] ' + 
				  'UNION ALL ' +
				  'SELECT tdate FROM ' + @LiqConn + '.[dbo].[daycltradehd] ) ' +

				  'SELECT MAX(tdate) as lasttrade FROM hd '
	PRINT @sqlStr
	EXEC (@sqlStr)


	--Œ¨ª§”√Õæ£¨«Î±£¡Ù£∫
	--WITH hd as 
	--(
	--	SELECT tdate FROM ' + @LiqConn + '.[dbo].[histcltradeh] 
	--	UNION ALL
	--	SELECT tdate FROM ' + @LiqConn + '.[dbo].[daycltradehd]
	--)

	--SELECT MAX(tdate) as lasttrade 
	--FROM hd

END
GO
