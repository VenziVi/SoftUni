   SELECT COUNT(*) AS [Count]
     FROM Countries AS c
LEFT JOIN MountainsCountries m 
       ON m.CountryCode = c.CountryCode
    WHERE m.MountainId IS NULL