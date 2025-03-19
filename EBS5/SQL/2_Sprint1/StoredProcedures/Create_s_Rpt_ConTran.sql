
/****** Object:  StoredProcedure [dbo].[s_Get_ConTran_GenRpt]    Script Date: 2017/10/26 10:41:20 ******/
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

IF OBJECT_ID('[dbo].[s_Rpt_ConTran]') > 0
BEGIN
	DROP PROCEDURE [dbo].[s_Rpt_ConTran]
END
GO

CREATE PROCEDURE [dbo].[s_Rpt_ConTran]
	@LiqConn varchar(100),
	@tin1 VARCHAR(20) ,
	@tin2 VARCHAR(20) ,
	@groupStr varchar(500)
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @sqlStr nvarchar(2500)
	SET @sqlStr = '
		WITH scomm AS
		(
			select accno, sum(isnull(comm,0)) as scomm, sum(isnull(ipo,0)) as sipo
			from  '+ @LiqConn +'.[DBO].[monthcomm] where mth>= ''' + @tin1 + '''  and mth<= ''' + @tin2 + ''' group by accno
		)'
	SET @sqlStr = @sqlStr + '
		,fcomm AS 
		(
			select accno, sum(isnull(comm,0)) as fcomm, sum(isnull(ipo,0)) as fipo
			from  '+ @LiqConn +'.[DBO].[monthcommf] where mth>= ''' + @tin1 + '''  and mth<= ''' + @tin2 + ''' group by accno
		)'
	SET @sqlStr = @sqlStr + '
		,iint AS
		(
			select accno, sum(isnull(interest,0)) as iint 
			from '+ @LiqConn +'.[DBO].[monthint] where mth>= ''' + @tin1 + '''  and mth<= ''' + @tin2 + ''' group by accno
		)'
	SET @sqlStr = @sqlStr + '
		,scommadj AS
		(
			select accno, sum(isnull(adj,0)) as sadj
			from monthcommadj where adjdate>= ''' + @tin1 + ''' and adjdate<=''' + @tin2 + ''' group by accno
		)'
	SET @sqlStr = @sqlStr + '
		,fcommadj AS
		(
			select accno, sum(isnull(adj,0)) as fadj
			from monthcommfadj where adjdate>= ''' + @tin1 + ''' and adjdate<=''' + @tin2 + ''' group by accno
		)'
	SET @sqlStr = @sqlStr + '
		,intadj AS
		(
			select accno, sum(isnull(adj,0)) as iadj
			from monthintadj where adjdate>= ''' + @tin1 + ''' and adjdate<=''' + @tin2 + ''' group by accno
		)'
	SET @sqlStr = @sqlStr + '
		,ipo AS
		(
			select accno, sum(isnull(ipo,0)) as ipo
			from dailyipoadj where adjdate>= ''' + @tin1 + ''' and adjdate<=''' + @tin2 + ''' group by accno
		)'
	SET @sqlStr = @sqlStr + '
		select list_name as list, clt_code as client,
			ISNULL(scomm.scomm,0) as sComm, ISNULL(fcomm.fcomm,0) as fComm, 0.0 as interest, 0.00 as creditInterest,
			ISNULL(ipo.ipo,0) as ipo,ISNULL(scommadj.sadj,0) as sadj, ISNULL(scomm.sipo,0) as sipo, ISNULL(fcommadj.fadj,0) as fadj, 
			ISNULL(fcomm.fipo,0) as fipo, ISNULL(intadj.iadj,0) as iadj, ISNULL(iint.iint,0) as iint 
		from [dbo].contran 
		LEFT JOIN scomm ON contran.clt_code = scomm.accno COLLATE Chinese_Taiwan_Stroke_CI_AS
		LEFT JOIN fcomm ON contran.clt_code = fcomm.accno COLLATE Chinese_Taiwan_Stroke_CI_AS
		LEFT JOIN iint ON contran.clt_code = iint.accno COLLATE Chinese_Taiwan_Stroke_CI_AS
		LEFT JOIN ipo ON contran.clt_code = ipo.accno
		LEFT JOIN scommadj ON contran.clt_code = scommadj.accno 
		LEFT JOIN fcommadj ON contran.clt_code = fcommadj.accno 
		LEFT JOIN intadj ON contran.clt_code = intadj.accno WHERE 1 = 1 ' IF(ISNULL(@groupStr,'')<> '') BEGIN
	SET @sqlStr = @sqlStr + ' AND list_name = ''' + @groupStr + '''' END
	SET @sqlStr = @sqlStr + ' order by list_name'

	PRINT @sqlStr

	EXECUTE  sp_ExecuteSql  @sqlStr

END
GO




