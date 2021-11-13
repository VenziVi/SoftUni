SELECT f2.Id,
       f2.[Name],
	   CONCAT(f2.Size, 'KB') AS Size
FROM Files AS f
RIGHT JOIN Files AS f2
ON f.ParentId= f2.Id
WHERE f.id IS NULL
ORDER BY f2.Id,
         f2.[Name],
		 f2.Size DESC