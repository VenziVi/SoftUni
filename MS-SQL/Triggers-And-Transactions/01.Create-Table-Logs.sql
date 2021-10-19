CREATE TABLE Logs (
LogId INT PRIMARY KEY IDENTITY,
AccountId INT NOT NULL,
OldSum DECIMAL(18, 2),
NewSum DECIMAL(18, 2) NOT NULL
)

GO

CREATE TRIGGER tr_SetNewSum 
ON Accounts
FOR UPDATE
AS
BEGIN 
	INSERT INTO Logs(AccountId, OldSum, NewSum)
	SELECT i.Id,
	       d.Balance,
		   i.Balance
      FROM inserted As i
	  JOIN deleted AS d
	    ON i.Id = d.Id
	 WHERE i.Balance != d.Balance
END


SELECT * FROM Accounts 

SELECT * FROM Logs

UPDATE Accounts
SET Balance = 113.12
WHERE Id = 1