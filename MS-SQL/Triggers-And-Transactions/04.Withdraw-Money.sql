CREATE PROC usp_WithdrawMoney (@accountId INT, @moneyAmount DECIMAL(18, 4))
AS
BEGIN TRANSACTION
	IF NOT EXISTS(SELECT * 
	                FROM Accounts  
				   WHERE Id = @accountId)
		ROLLBACK
	IF (@accountId) <= 0
		ROLLBACK
	UPDATE Accounts
	   SET Balance -= @moneyAmount
	 WHERE Id = @accountId
COMMIT

EXEC usp_WithdrawMoney 5, 25
