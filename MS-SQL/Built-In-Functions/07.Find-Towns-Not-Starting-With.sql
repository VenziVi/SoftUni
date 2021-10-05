  SELECT TownID, [Name]
    FROM Towns
   WHERE CHARINDEX('R', [Name]) <> 1
     AND CHARINDEX('B', [Name]) <> 1
     AND CHARINDEX('D', [Name]) <> 1
ORDER BY [Name] ASC