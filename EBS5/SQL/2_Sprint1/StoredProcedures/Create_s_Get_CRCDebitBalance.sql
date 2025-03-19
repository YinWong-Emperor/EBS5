
/****** Object:  StoredProcedure [dbo].[s_Get_CRCDebitBalance]    Script Date: 2017/10/26 10:41:20 ******/
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

IF OBJECT_ID('[dbo].[s_Get_CRCDebitBalance]') > 0
BEGIN
	DROP PROCEDURE [dbo].[s_Get_CRCDebitBalance]
END
GO

CREATE PROCEDURE [dbo].[s_Get_CRCDebitBalance]
	@acCode varchar(20),
	@LiqConn varchar(100)
AS
BEGIN

DECLARE @sqlStr NVARCHAR(4000)
  SET @sqlStr = N'WITH ae_db AS(
		SELECT   Ae.RUN_CODE, Ae.RUN_NAME, SUM(ISNULL(Mst.MKT_VALUE, 0)) AS ttl_mv, SUM(ISNULL(Mst.MC_DR_BAL, 0)) 
						AS ttl_dr
		FROM      '+@LiqConn+'.dbo.[STAEMASTER] AS Ae LEFT OUTER JOIN
						'+@LiqConn+'.dbo.[STCLTMASTER] AS Mst ON Mst.RUN_CODE  COLLATE DATABASE_DEFAULT = Ae.RUN_CODE  COLLATE DATABASE_DEFAULT
		WHERE	Ae.run_code  LIKE ''%' + @acCode + N'%''
		GROUP BY Ae.RUN_CODE, Ae.RUN_NAME
	),
	fbal AS (
		SELECT aeno AS run_code,
			   aename AS rname,
			   SUM(CASE cuid
					   WHEN ''3'' THEN (cash_bal * (-0.01) * lastex)
					   ELSE (cash_bal * (-1) * lastex)
				   END) AS bal
		FROM '+@LiqConn+'.dbo.STAEFUTBAL
		WHERE ROUND(cash_bal,2) < 0
		GROUP BY aeno,aename
	),
	crc_mst AS (
		SELECT ISNULL(ae_db.run_code, fbal.run_code) AS run_code,
			   ISNULL(ae_db.run_name, fbal.rname) AS rname,
			   ISNULL(ttl_mv,0) AS ttl_mv,
			   ISNULL(ttl_dr,0) AS ttl_dr,
			   ISNULL(bal,0) AS bal
		FROM	ae_db INNER JOIN fbal ON ae_db.run_code = fbal.run_code
	)

	
	 SELECT mst.run_code,
		   mst.rname AS rname,
		   ttl_mv AS mv,
		   ttl_dr AS dr,
		   dbo.[fn_Float2CRCStr](mst.ttl_mv) AS mv_str,
		   dbo.[fn_Float2CRCStr](mst.ttl_dr) AS dr_str,
		   (CASE mst.ttl_mv
				WHEN 0 THEN CONVERT(VARCHAR,CAST(mst.ttl_mv AS FLOAT))
				ELSE CONVERT(VARCHAR, ROUND(CAST(((mst.ttl_dr / mst.ttl_mv) * 100) AS FLOAT),2))
			END) + ''%'' AS actr,
		   mst.bal AS fdr,
		   dbo.[fn_Float2CRCStr](mst.bal) AS f_dr_bal,
		   ISNULL(std.deduct_b, 0) AS dd_b,
		   ISNULL(std.deduct_c, 0) AS dd_c,
		   dbo.[fn_Float2CRCStr](std.deduct_b) AS dd_b_str,
		   dbo.[fn_Float2CRCStr](std.deduct_c) AS dd_c_str,
		   (CASE ISNULL(std.setoff,0)
				WHEN 0 THEN ''No''
				ELSE ''Yes''
			END) AS seto,
		   std.remarks AS remarks,
		   ISNULL(std.deduct_b,0) AS b_type,
		   ISNULL(std.deduct_c,0) AS c_type
	FROM CRC_MST AS mst
	LEFT OUTER JOIN '+@LiqConn+'.dbo.STRUNOUTSTD AS std ON mst.run_code = std.run_code  COLLATE DATABASE_DEFAULT
	

'
	--print @sqlStr

	EXEC('' + @sqlStr)
END
GO


--exec s_Get_CRCDebitBalance '','ESL_Liq_Dev_EBS4'