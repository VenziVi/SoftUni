  SELECT i.Id,
         CONCAT(u.Username, ' ', ':', ' ', i.Title) AS IssueAssingment
    FROM Issues AS i
    JOIN Users AS u
      ON i.AssigneeId = u.Id
ORDER BY i.Id DESC,
         i.AssigneeId