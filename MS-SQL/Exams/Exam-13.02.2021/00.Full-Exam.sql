CREATE DATABASE Bitbucket

GO

USE Bitbucket


GO

--01.DDL

CREATE TABLE Users(
Id INT PRIMARY KEY IDENTITY,
Username VARCHAR(30) UNIQUE NOT NULL,
[Password] VARCHAR(30) NOT NULL,
Email VARCHAR(50) NOT NULL
)

CREATE TABLE Repositories(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE RepositoriesContributors(
RepositoryId INT NOT NULL FOREIGN KEY REFERENCES Repositories(Id),
ContributorId INT NOT NULL FOREIGN KEY REFERENCES Users(Id),
PRIMARY KEY (RepositoryId, ContributorId)
)

CREATE TABLE Issues(
Id INT PRIMARY KEY IDENTITY,
Title VARCHAR(MAX) NOT NULL,
IssueStatus CHAR(6) NOT NULL,
RepositoryId INT NOT NULL FOREIGN KEY REFERENCES Repositories(Id),
AssigneeId INT NOT NULL FOREIGN KEY REFERENCES Users(Id)
)

CREATE TABLE Commits(
Id INT PRIMARY KEY IDENTITY,
[Message] VARCHAR(MAX) NOT NULL,
IssueId INT FOREIGN KEY REFERENCES Issues(Id),
RepositoryId INT NOT NULL FOREIGN KEY REFERENCES Repositories(Id),
ContributorId INT NOT NULL FOREIGN KEY REFERENCES Users(Id)
)

CREATE TABLE Files(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(100) NOT NULL,
Size DECIMAL(18, 2) NOT NULL,
ParentId INT FOREIGN KEY REFERENCES Files(Id),
CommitId INT NOT NULL FOREIGN KEY REFERENCES Commits(Id)
)


--02.Insert

INSERT INTO Files ([Name], Size, ParentId, CommitId)
VALUES
('Trade.idk', 2598.0, 1, 1),
('menu.net', 9238.31, 2, 2),
('Administrate.soshy', 1246.93, 3, 3),
('Controller.php', 7353.15, 4, 4),
('Find.java', 9957.86, 5, 5),
('Controller.json', 14034.87, 3, 6),
('Operate.xix', 7662.92, 7, 7)

INSERT INTO Issues(Title, IssueStatus, RepositoryId, AssigneeId)
VALUES
('Critical Problem with HomeController.cs file', 'open', 1, 4),
('Typo fix in Judge.html', 'open', 4, 3),
('Implement documentation for UsersService.cs', 'closed', 8, 2),
('Unreachable code in Index.cs', 'open', 9, 8)

--03.Update

UPDATE Issues
SET IssueStatus = 'closed'
WHERE AssigneeId = 6

--04.Delete

DELETE FROM Files
WHERE CommitId = 36

DELETE FROM Commits
WHERE RepositoryId = 3

DELETE FROM Issues
WHERE RepositoryId = 3

DELETE FROM RepositoriesContributors
WHERE RepositoryId = 3

DELETE FROM Repositories
WHERE Id = 3

--05.Commits

  SELECT Id,
         Message,
	     RepositoryId,
	     ContributorId
    FROM Commits
ORDER BY Id,
         Message,
		 RepositoryId,
		 ContributorId

--06.Front-end

  SELECT Id,
         [Name],
	     Size
    FROM Files
   WHERE Size > 1000
     AND [Name] LIKE '%html'
ORDER BY Size DESC,
         Id,
		 [Name]

--07.Issue Assignment

  SELECT i.Id,
         CONCAT(u.Username, ' ', ':', ' ', i.Title) AS IssueAssingment
    FROM Issues AS i
    JOIN Users AS u
      ON i.AssigneeId = u.Id
ORDER BY i.Id DESC,
         i.AssigneeId

--08.Single Files

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

--09.Commits in Repositories

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

--10.Average Size

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

--11.All Users Commit
GO

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

SELECT dbo.udf_AllUserCommits('UnderSinduxrein')

--12.Search for Files
GO

CREATE PROC usp_SearchForFiles(@fileExtension VARCHAR(10))
AS
BEGIN
	SELECT Id,
	       [Name],
		   CONCAT(Size, 'KB') AS Size
	 FROM Files
	WHERE [Name] LIKE '%' + @fileExtension
	ORDER BY Id,
	         [Name],
			 Size DESC
END

EXEC usp_SearchForFiles 'txt'