USE [ESL]
GO

/****** Object:  StoredProcedure [dbo].[s_Upd_ExchangeRate]    Script Date: 2023/5/24 ¤U¤È 12:01:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[s_Upd_ExchangeRate]
	@system_type nvarchar(10) = '',
	@currency_in nvarchar(10) = '',
	@lupdtdate datetime = null,
	@ex_rate numeric(12,4) = 0.0,
	@exid bigint = 0
AS
BEGIN

	--IF EXISTS (select 1 from exchangerate where system_type = @system_type and currency_in = @currency_in and ex_rate = @ex_rate)
	--BEGIN
	--	SELECT '2' AS RESULT
	--	RETURN
	--END
	--ELSE
	--BEGIN
	BEGIN TRAN
	update DBO.exchangerate 
	set ex_rate = @ex_rate,
		lupdtdate = @lupdtdate
	where exid = @exid
	IF @@ROWCOUNT <> 1 OR @@ERROR <> 0
	BEGIN
		ROLLBACK TRAN
		SELECT '0' AS RESULT
	END
	ELSE
	BEGIN
		COMMIT TRAN
		SELECT '1' AS RESULT
	END
	--END
END

GO


