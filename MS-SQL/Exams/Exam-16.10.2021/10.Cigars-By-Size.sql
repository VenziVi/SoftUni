 SELECT *
   FROM (
	   SELECT c.LastName,
			   AVG(s.Length) AS CigarLength,
			   CEILING(AVG(s.RingRange)) AS CigarRingRange
		 FROM Clients AS c
		 JOIN ClientsCigars AS cc ON c.Id = cc.ClientId
		 JOIN Cigars AS ci ON cc.CigarId = ci.Id
		 JOIN Sizes AS s ON ci.SizeId = s.Id
		GROUP BY c.LastName
	        ) AS FilterdQuery
   WHERE CigarLength IS NOT NULL 	
ORDER BY CigarLength DESC