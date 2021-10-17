CREATE OR ALTER FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @salaryLevel VARCHAR(10)

	IF(@salary < 30000)
		SET @salaryLevel = 'Low'
	ELSE IF(@salary <= 50000)
		SET @salaryLevel = 'Average'
	ELSE
		SET @salaryLevel = 'High'

	RETURN @salaryLevel
END

GO

SELECT FirstName,
       Salary,
	   dbo.ufn_GetSalaryLevel(Salary) AS [Salary Level]
FROM Employees