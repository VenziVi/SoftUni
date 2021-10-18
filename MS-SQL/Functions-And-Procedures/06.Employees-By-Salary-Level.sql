CREATE PROC usp_EmployeesBySalaryLevel(@salaryLevel VARCHAR(10))
AS
SELECT FirstName,
       LastName
  FROM (
	  SELECT FirstName,
	         LastName,
       	     dbo.ufn_GetSalaryLevel(Salary) AS [Salary Levle]
	    FROM Employees
	    ) AS EmpluyeesWithSalaryLevel
 WHERE [Salary Levle] = @salaryLevel


 EXEC usp_EmployeesBySalaryLevel[high]