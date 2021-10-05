  SELECT TownID, [Name]
    FROM Towns
   WHERE CHARINDEX('M', [Name]) = 1
      OR CHARINDEX('K', [Name]) = 1
      OR CHARINDEX('B', [Name]) = 1
      OR CHARINDEX('E', [Name]) = 1
ORDER BY [Name] ASC