SELECT TOP(5) c.[Name] AS [CategoryName],
              COUNT(*) AS [ReportsNumber]
         FROM Reports AS r
         JOIN Categories As c
           ON r.CategoryId = c.Id
     GROUP BY c.[Name]
     ORDER BY [ReportsNumber] DESC,
              [CategoryName]