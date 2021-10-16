SELECT * INTO EmployeeSalariesFilter
  FROM Employees
  WHERE Salary > 30000

DELETE 
  FROM EmployeeSalariesFilter
 WHERE ManagerID = 42

UPDATE EmployeeSalariesFilter
   SET Salary += 5000
 WHERE DepartmentID = 1

  SELECT DepartmentID,
         AVG(Salary)
    FROM EmployeeSalariesFilter
GROUP BY DepartmentID
