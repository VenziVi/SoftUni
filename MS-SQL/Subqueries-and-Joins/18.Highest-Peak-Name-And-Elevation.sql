   SELECT TOP (5) 
          Country,
          ISNULL(PeakName, '(no highest peak)') AS [Highest Peak Name],
		  ISNULL(Elevation, 0) AS [Highest Peak Elevation],
	      ISNULL(MountainRange, '(no mountain)') AS [Mountain]
     FROM (
          SELECT c.CountryName AS [Country],
                 p.PeakName,
	             p.Elevation,
	             m.MountainRange,
	             DENSE_RANK() OVER(PARTITION BY CountryName ORDER BY Elevation DESC) AS [ElevationRank]
            FROM Countries AS c
       LEFT JOIN MountainsCountries AS mc
              ON c.CountryCode = mc.CountryCode
       LEFT JOIN Mountains AS m
              ON mc.MountainId = m.Id
       LEFT JOIN Peaks AS p
              ON mc.MountainId = p.MountainId
	      ) AS [HighestPeaks]
   WHERE [ElevationRank] = 1
ORDER BY Country,
         [Highest Peak Elevation]