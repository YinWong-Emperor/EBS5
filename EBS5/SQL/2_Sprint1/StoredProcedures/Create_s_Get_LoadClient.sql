
/****** Object:  StoredProcedure [dbo].[s_Get_LoadClient]    Script Date: 2017/10/26 10:41:20 ******/
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

IF OBJECT_ID('[dbo].[s_Get_LoadClient]') > 0
BEGIN
	DROP PROCEDURE [dbo].[s_Get_LoadClient]
END
GO

CREATE PROCEDURE [dbo].[s_Get_LoadClient]
	@LiqConn varchar(100),
	@groupStr varchar(500)
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @sqlStr NVARCHAR(1500)

	IF(ISNULL(@groupStr,'')<> '') BEGIN
	SET @sqlStr = 'SELECT clt_code FROM  [contran] WHERE list_name = ''' + @groupStr + '''ORDER BY seq_no' END ELSE BEGIN
	SET @sqlStr = 'select distinct clt_code from ' + @LiqConn + '.[dbo].STCLTMASTER order by clt_code' END

	PRINT @sqlStr

	EXECUTE  sp_ExecuteSql  @sqlstr
	
END

--EXEC [dbo].[s_Get_LoadClient] 'ESL_Dev','EIHL Group'

--SELECT clt_code,seq_no,list_name FROM ESL_Dev.[dbo].[contran]