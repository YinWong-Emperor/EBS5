
/****** Object:  StoredProcedure [dbo].[s_Upd_CRCDebitBalance]    Script Date: 2017/10/26 10:41:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*-- =============================================
-- Author : HugoLaw
-- Create date : 2017/10/26 16:19
-- Last update : 2017/10/26 10:47
-- Description : Update Procedure FOR CRCDebitBalance
-- ============================================= */

IF OBJECT_ID('[dbo].[s_Upd_CRCDebitBalance]') > 0
BEGIN
	DROP PROCEDURE [dbo].[s_Upd_CRCDebitBalance]
END
GO

CREATE PROCEDURE [dbo].[s_Upd_CRCDebitBalance]
	@run_code varchar(20) = '',
	@setoff bit,
	@typeB NUMERIC(18,4) = 0.0,
	@typeC NUMERIC(18,4) = 0.0,
	@remark varchar(100) = '',
	@LiqConn varchar(100)
AS
BEGIN
	
	DECLARE @sqlStr NVARCHAR(4000)
  SET @sqlStr = N'IF EXISTS(SELECT 1 FROM '+@LiqConn+'.dbo.STRUNOUTSTD WHERE RUN_CODE = ''' + @run_code + ''')
	BEGIN
		UPDATE	'+@LiqConn+'.dbo.STRUNOUTSTD
		SET		SETOFF = ' + Convert(NVARCHAR(100), @setoff) + ',
				[DEDUCT_B] = ' + Convert(NVARCHAR(100), @typeB) + ',
				[DEDUCT_C] = ' + Convert(NVARCHAR(100), @typeC) + ',
				[REMARKS] = ''' + @remark + '''
		WHERE	RUN_CODE = ''' + @run_code + '''
	END
	ELSE
	BEGIN
		INSERT INTO '+@LiqConn+'.dbo.STRUNOUTSTD(RUN_CODE,SETOFF,DEDUCT_B,DEDUCT_C,REMARKS)
		VALUES(
		''' + @run_code + ''',
		' + Convert(NVARCHAR(100), @setoff) + ',
		' + Convert(NVARCHAR(100), @typeB) + ',
		' + Convert(NVARCHAR(100), @typeC) + ',
		''' + @remark + ''')
	END

	IF @@ROWCOUNT = 0
	BEGIN
		SELECT -1 AS Status, ''Fail to update the CRCDebitBalance.'' AS Msg
	END
	ELSE
	BEGIN
		SELECT 0 AS Status, ''CRCDebitBalance Updated.'' AS Msg		
	END
'
print @sqlStr
 EXEC('' + @sqlStr)
END
GO
