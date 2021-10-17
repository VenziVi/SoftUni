   SELECT TOP(10) 
          e.FirstName,
          e.LastName,
          e.DepartmentID
     FROM Employees AS e
LEFT JOIN (
            SELECT DepartmentID,
                   AVG(Salary) AS AverageSalary
              FROM Employees
          GROUP BY DepartmentID
		  ) AS g
       ON g.DepartmentID = e.DepartmentID
    WHERE e.Salary > g.AverageSalary
 ORDER BY e.DepartmentID