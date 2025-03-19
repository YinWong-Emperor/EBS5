SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*-- =============================================
-- Author : HugoLaw
-- Create date : 2017/10/26 16:19
-- Last update : 2017/11/07 14:47
-- Description : Search Procedure FOR CRCDebitBalance
-- ============================================= */

IF OBJECT_ID('[dbo].[s_Upd_ConTran]') > 0
BEGIN
	DROP PROCEDURE [dbo].[s_Upd_ConTran]
END
GO

CREATE PROCEDURE [dbo].[s_Upd_ConTran]
	@groupStr VARCHAR(20),
	@cltCodes	VARCHAR(max),
	@oldGroupName VARCHAR(20)
AS
BEGIN
	
	IF	EXISTS (SELECT 1 FROM DBO.contran WHERE list_name = @groupStr) -- 与其他重名
		AND (  
				(@oldGroupName <> '' AND @groupStr <> @oldGroupName)  -- 编辑时, 名称有修改, 
			OR	@oldGroupName = '' -- 新建时
		)
	BEGIN
		DECLARE @message varchar(100)
		SET @message = 'The List ['+ @groupStr+ '] already exist!'
		RAISERROR (@message, 16, 1)
        RETURN @@ERROR
	END

	SET XACT_ABORT ON

	BEGIN TRAN 
	IF EXISTS (SELECT 1 FROM DBO.contran WHERE list_name = @groupStr)
	BEGIN
		DELETE FROM DBO.contran where list_name = @groupStr

		IF @@ERROR <> 0
		BEGIN
			SELECT '2'
			ROLLBACK TRAN
		END
	END

	INSERT INTO DBO.contran(LIST_NAME,CLT_CODE,SEQ_NO)
	SELECT @groupStr,ITEM,LISTID from dbo.[fnSplit](@cltCodes,',')

	IF @@ERROR <> 0
	BEGIN
		SELECT '0'
		ROLLBACK TRAN
	END
	ELSE
	BEGIN
		SELECT '1'
		COMMIT TRAN
	END
END
GO

--EXEC [dbo].[s_ConTran_Save] 'TESTGROUP',''

--SELECT * FROM DBO.contran WHERE list_name = 'TESTGROUP'