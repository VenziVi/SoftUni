SELECT Username,
       [Name] AS CategoryName
FROM (
				SELECT DATEPART(DAY, u.Birthdate) AS BirthDay,
					   DATEPART(DAY, r.OpenDate) AS OpenDay,
					   DATEPART(MONTH, u.Birthdate) AS BirthMonth,
					   DATEPART(MONTH, r.OpenDate) AS OpenMonth,
					   u.Username,
					   c.[Name]
				FROM Reports As r
				JOIN Users AS u
				ON r.UserId = u.Id
				JOIN Categories As c
				ON R.CategoryId = c.Id
	   ) AS DayTable
   WHERE BirthDay = OpenDay AND BirthMonth = OpenMonth
ORDER BY Username, [Name]