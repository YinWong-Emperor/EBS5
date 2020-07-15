

/****** Object:  StoredProcedure [dbo].[s_Rpt_TopCommF]    Script Date: 2018/01/08 10:41:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*-- =============================================
-- Author : HugoLaw
-- Create date : 2018/01/08 16:19
-- Last update : 2018/01/08 10:47
-- Description : Search Procedure FOR s_Rpt_TopCommS
-- ============================================= */

IF OBJECT_ID('[dbo].[s_Rpt_TopCommF]') > 0
BEGIN
	DROP PROCEDURE [dbo].s_Rpt_TopCommF
END
GO


CREATE PROCEDURE [dbo].s_Rpt_TopCommF	
	@topNo	nvarchar(10) = '0',
	@g2fbDB nvarchar(100),
	@liqDB nvarchar(100),
	@fromDate NVARCHAR(20) = '19000101',
	@toDate NVARCHAR(20) = '19000101'
AS
BEGIN

	Set NOCOUNT ON;
    Set XACT_ABORT ON;

	DECLARE @sqlStr nvarchar(MAX)

	SET @sqlStr = '
		WITH it_client_all AS
		( 
			SELECT distinct clm.accno, clm.name_1, ae.aeno
			FROM '+ @g2fbDB +'.[DBO].client_master AS clm
			LEFT OUTER JOIN '+ @g2fbDB +'.[DBO].client_master_f AS clms ON clms.aid = clm.aid
			LEFT OUTER JOIN '+ @g2fbDB +'.[DBO].ae_master AS ae ON ae.aeid = clms.aeid
			AND ae.cmid = clms.cmid
		),
		tmp AS
		( 
			SELECT accno COLLATE database_default AS accno,comm
			FROM '+ @liqDB +'.dbo.monthcommf
			WHERE mth >= ''' + @fromDate + ''' AND mth <= ''' + @toDate + '''
			UNION 
			SELECT accno COLLATE database_default AS accno,adj as comm
			FROM dbo.monthcommfadj
			WHERE adjDate >= ''' + @fromDate + ''' AND adjDate <= ''' + @toDate + ''' 
		)
		SELECT top ' + @topNo + ' tmp.accno,
				   sum(comm) AS comm,
				   name_1,
				   aeno
		FROM tmp,
			 it_client_all cm
		WHERE tmp.accno = cm.accno COLLATE database_default
		GROUP BY tmp.accno,
				 name_1,
				 aeno
		ORDER BY comm DESC
		'
		
	PRINT @sqlStr

	EXECUTE  sp_ExecuteSql  @sqlStr

END
GO

--EXEC [dbo].s_Rpt_TopCommf	'5','LinkedServer97.g2bf_dev','ESL_LIQ_dev','2016-02-01','2016-04-01'