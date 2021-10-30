   SELECT CONCAT(e.FirstName, ' ', e.LastName) AS FullName,
	      ISNULL(COUNT(u.Name), 0) AS UsersCount
     FROM Employees As e
LEFT JOIN Reports AS r
       ON e.Id = r.EmployeeId
LEFT JOIN Users AS u
       ON r.UserId = u.Id
 GROUP BY e.FirstName, e.LastName
 ORDER BY UsersCount DESC, FullName