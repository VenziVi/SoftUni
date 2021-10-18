CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(MAX), @word VARCHAR(MAX))
RETURNS BIT
AS
BEGIN
	DECLARE @counter INT = 1
	DECLARE @currChar VARCHAR(1)

	WHILE(LEN(@word) >= @counter)
		BEGIN

			SET @currChar = SUBSTRING(@word, @counter, 1)

			IF(@setOfLetters LIKE '%' + @currChar + '%')
				SET @counter += 1
			ELSE
				RETURN 0
		END
	RETURN 1
END
