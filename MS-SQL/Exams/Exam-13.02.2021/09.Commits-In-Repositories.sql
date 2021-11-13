  SELECT TOP(5)
         r.Id,
         r.[Name],
	     COUNT(*) AS Commits
    FROM Repositories AS r
		 LEFT JOIN RepositoriesContributors As rc
		 ON r.Id = rc.RepositoryId
		 LEFT JOIN Commits AS c
		 ON r.Id = c.RepositoryId
GROUP BY r.Id, r.[Name]
ORDER BY Commits DESC,
         r.Id,
		 r.[Name]