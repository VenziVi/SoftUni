    SELECT CONCAT(s.FirstName, ' ', s.LastName) AS [Full Name]
      FROM Students AS s
 LEFT JOIN StudentsExams AS se ON s.Id = se.StudentId
     WHERE se.Grade IS NULL
  ORDER BY [Full Name]