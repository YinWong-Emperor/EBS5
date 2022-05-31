
IF OBJECT_ID('dbo.fn_Float2CRCStr') > 0
BEGIN
	DROP FUNCTION dbo.fn_Float2CRCStr
END
GO

CREATE FUNCTION [dbo].[fn_Float2CRCStr](
	@num DECIMAL(18,4)
) RETURNS VARCHAR(22)
AS
BEGIN
	IF(@num IS NULL)
	BEGIN
		RETURN '0'
	END

	DECLARE @result VARCHAR(21)

	DECLARE @convertValue DECIMAL(18,2)

	SET @num = ROUND(@num,2)
	SET @convertValue = CONVERT(DECIMAL,@num)

	

	IF(ABS(@convertValue) >= 10000.00)
	BEGIN
		
		SET @result = Convert(varchar(20), CAST((@num/1000000) AS DECIMAL(18,2)))
		SET @result = ISNULL(@result,'0') + 'M'
	END
	ELSE
	BEGIN
		SET @result = CONVERT(varchar(20),CAST( @num AS DECIMAL(18,2)))
	END
	RETURN @result
END
GO
