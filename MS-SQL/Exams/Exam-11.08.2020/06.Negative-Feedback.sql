  SELECT f.ProductId,
         f.Rate,
		 f.[Description],
		 f.CustomerId,
		 c.Age,
		 c.Gender
    FROM Feedbacks AS f
    JOIN Customers AS c
      ON F.CustomerId = c.Id
   WHERE f.Rate < 5.00
ORDER BY f.ProductId DESC,
         f.Rate