   SELECT [Description],
          [Name] AS [CategoryName]
     FROM Reports AS r
     JOIN Categories As c
       ON r.CategoryId = c.Id
 ORDER BY [Description],
          [Name]