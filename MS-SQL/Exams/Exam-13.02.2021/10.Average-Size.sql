   SELECT u.Username,
          AVG(Size) AS Size
     FROM FIles AS f
LEFT JOIN Commits AS c
       ON f.CommitId = c.Id
LEFT JOIN Users AS u
       ON c.ContributorId = u.Id
 GROUP BY u.Username
 ORDER BY AVG(Size) DESC,
          u.Username