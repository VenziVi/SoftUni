CREATE PROC usp_GetHoldersWithBalanceHigherThan (@input DECIMAL(18, 4))
AS
BEGIN 
	SELECT FirstName,
      	   LastName
	  FROM (
			SELECT AccountHolderId,
				   SUM(Balance) AS Total 	
			  FROM Accounts
		  GROUP BY AccountHolderId 
			) AS ac
	  JOIN AccountHolders AS a
		ON ac.AccountHolderId = a.Id
	 WHERE Total > @input
  ORDER BY FirstName,
		   LastName
END

EXEC usp_GetHoldersWithBalanceHigherThan 28500