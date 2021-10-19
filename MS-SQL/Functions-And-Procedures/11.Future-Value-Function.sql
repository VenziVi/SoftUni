CREATE FUNCTION ufn_CalculateFutureValue (@sum DECIMAL(18, 4), @interest FLOAT, @years INT)
RETURNS DECIMAL(18, 4)
AS
BEGIN
	DECLARE @result DECIMAL(18, 4)

	SET @result = @sum * (POWER(1 + @interest, @years))

	RETURN @result
END

GO

SELECT dbo.ufn_CalculateFutureValue (1000, 0.1, 5)