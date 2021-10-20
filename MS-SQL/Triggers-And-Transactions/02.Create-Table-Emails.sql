CREATE TABLE NotificationEmails (
Id INT PRIMARY KEY IDENTITY,
Recipient INT NOT NULL,
[Subject] VARCHAR(MAX),
Body VARCHAR(MAX)
)

GO 

CREATE TRIGGER tr_CreateEmail
ON Logs FOR INSERT 
AS
BEGIN
	INSERT INTO NotificationEmails (Recipient, [Subject], Body)
	SELECT AccountId,
	       CONCAT('Balance change for account:', ' ', [AccountId]) AS [Subject],
		   CONCAT('On ', GETDATE(), ' ', 'your balance was changed from ', [OldSum], ' ', 'to ',[NewSum], '.') AS Body
	FROM Logs
END
