CREATE PROC usp_CalculateFutureValueForAccount 
AS
BEGIN
	SELECT ah.Id AS [Account Id],
	       FirstName AS [First Name],
	       LastName AS [Last Name],
		   Balance AS [Current Balance],
		   dbo.ufn_CalculateFutureValue(Balance, 0.1, 5) AS [Balance in 5 years]
	FROM AccountHolders AS ah
	JOIN Accounts AS a
	ON ah.Id = a.AccountHolderId
END

EXEC usp_CalculateFutureValueForAccount 