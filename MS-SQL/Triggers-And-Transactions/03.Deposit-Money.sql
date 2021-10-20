CREATE PROC usp_DepositMoney (@accountId INT, @moneyAmount DECIMAL(18,4))
AS
BEGIN TRANSACTION
	IF NOT EXISTS(SELECT * FROM Accounts WHERE Id = @AccountId)
		ROLLBACK;
	IF (@AccountId) <= 0
		ROLLBACK;
	UPDATE Accounts
		SET Balance += @MoneyAmount
		WHERE Id = @AccountId
COMMIT