   SELECT CONCAT(c.FirstName, ' ', c.LastName) AS FullName,
          a.Country,
	      a.ZIP,
	      CONCAT('$', MAX(ci.PriceForSingleCigar)) AS CigarPrice
     FROM Clients AS c
LEFT JOIN ClientsCigars AS cc ON c.Id = cc.ClientId
LEFT JOIN Cigars AS ci ON cc.CigarId = ci.Id
LEFT JOIN Addresses AS a ON c.AddressId = a.Id
	WHERE ISNUMERIC(a.[ZIP]) = 1
 GROUP BY c.FirstName, c.LastName, a.Country, a.ZIP
 ORDER BY FullName