  SELECT c.[Name] AS City,
         COUNT(c.Id) AS Hotels
    FROM Cities AS c
    JOIN Hotels AS h
      ON c.Id = h.CityId
GROUP BY c.[Name]
ORDER BY Hotels DESC,
         City