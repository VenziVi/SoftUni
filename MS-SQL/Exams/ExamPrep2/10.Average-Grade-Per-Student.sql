   SELECT s.[Name],
          AVG(ss.Grade) AS AverageGrade
     FROM Subjects AS s
LEFT JOIN StudentsSubjects AS ss ON s.Id = ss.SubjectId
 GROUP BY s.[Name], s.Id
   HAVING AVG(ss.Grade) IS NOT NULL
 ORDER BY S.Id