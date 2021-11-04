   SELECT d.[Name] AS DistributorName,
          i.[Name] As IngredientName,
	      p.[Name] AS ProductName,
	      AverageRate
     FROM (
			  SELECT ProductId,
					 AVG(Rate) AS AverageRate
				FROM Feedbacks
			GROUP BY ProductId
     ) AS AverageRate
     JOIN ProductsIngredients AS pp
       ON pp.ProductId = AverageRate.ProductId
     JOIN Ingredients AS i
       ON pp.IngredientId = i.Id
     JOIN Distributors AS d
       ON d.Id = i.DistributorId
     JOIN Products AS p
       ON p.Id = pp.ProductId
    WHERE AverageRate >= 5 AND AverageRate <= 8
 ORDER BY DistributorName,
          IngredientName,
	  	  ProductName