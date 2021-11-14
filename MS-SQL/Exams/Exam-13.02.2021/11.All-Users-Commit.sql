CREATE FUNCTION udf_AllUserCommits(@username VARCHAR(30))
RETURNS INT
AS
BEGIN 
	RETURN (SELECT COUNT(c.Id)
	       FROM Users AS u
		   RIGHT JOIN Commits AS c
		   ON u.Id = c.ContributorId
		   WHERE u.Username = @username)
END
