CREATE DATABASE [Service]

--01.DDL

CREATE TABLE Users (
Id INT PRIMARY KEY IDENTITY,
Username VARCHAR(30) UNIQUE NOt NULL,
[Password] VARCHAR(50) NOT NULL,
[Name] VARCHAR(50),
Birthdate DATE,
Age INT,
Email VARCHAR(50) NOT NULL,
CHECK (Age >= 14 AND AGE <= 110)
)

CREATE TABLE Departments (
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY,
FirstName VARCHAR(25),
LastName VARCHAR(25),
Birthdate DATE,
Age INT,
DepartmentId INT FOREIGN KEY REFERENCES Departments(Id),
CHECK (Age >= 18 AND Age <= 110)
)

CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL,
DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL
)

CREATE TABLE [Status](
Id INT PRIMARY KEY IDENTITY,
[Label] VARCHAR(30) NOT NULL
)

CREATE TABLE Reports(
Id INT PRIMARY KEY IDENTITY,
CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
StatusId INT FOREIGN KEY REFERENCES Status(Id) NOT NULL,
OpenDate DATE NOT NULL,
CloseDate DATE,
[Description] VARCHAR(200) NOT NULL,
UserId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
)

--02.Insert

INSERT INTO Employees (FirstName, LastName, Birthdate, DepartmentId)
VALUES
('Marlo', 'O''Malley', '1958-9-21' , 1),
('Niki', 'Stanaghan', '1969-11-26', 4),
('Ayrton', 'Senna', '1960-03-21', 9),
('Ronnie', 'Peterson', '1944-02-14', 9),
('Giovanna', 'Amati', '1959-07-20', 5)


INSERT INTO Reports (CategoryId, StatusId, OpenDate, CloseDate, [Description], UserId, EmployeeId)
VALUES
(1, 1, '2017-04-13', NULL, 'Stuck Road on Str.133', 6, 2),
(6, 3, '2015-09-05', '2015-12-06', 'Charity trail running', 3, 5),
(14, 2, '2015-09-07', NULL, 'Falling bricks on Str.58', 5, 2),
(4, 3, '2017-07-03', '2017-07-06', 'Cut off streetlight on Str.11', 1, 1)

--03.Update

UPDATE Reports
SET CloseDate = GETDATE()
WHERE CloseDate IS NULL

--04.Delete

DELETE FROM Reports
WHERE StatusId = 4

--05.Unassigned Reports

  SELECT [Description],
	     FORMAT(OpenDate, 'dd-MM-yyyy')
    FROM Reports
   WHERE EmployeeId IS NULL
ORDER BY OpenDate, [Description]

--06.Reports & Categories

   SELECT [Description],
          [Name] AS [CategoryName]
     FROM Reports AS r
     JOIN Categories As c
       ON r.CategoryId = c.Id
 ORDER BY [Description],
          [Name]

--07.Most Reported Category

SELECT TOP(5) c.[Name] AS [CategoryName],
              COUNT(*) AS [ReportsNumber]
         FROM Reports AS r
         JOIN Categories As c
           ON r.CategoryId = c.Id
     GROUP BY c.[Name]
     ORDER BY [ReportsNumber] DESC,
              [CategoryName]

--08.Birthday Report

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
 
--09.Users per Employee 

   SELECT CONCAT(e.FirstName, ' ', e.LastName) AS FullName,
	      ISNULL(COUNT(u.Name), 0) AS UsersCount
     FROM Employees As e
LEFT JOIN Reports AS r
       ON e.Id = r.EmployeeId
LEFT JOIN Users AS u
       ON r.UserId = u.Id
 GROUP BY e.FirstName, e.LastName
 ORDER BY UsersCount DESC, FullName

--10.Full Info

    SELECT CASE
			    WHEN e.FirstName IS NULL THEN 'None'
			    ELSE CONCAT(e.FirstName, ' ', e.LastName)
		   END  AS Employee,
           ISNULL(d.[Name], 'None') AS Department,
		   c.[Name] AS Category,
		   r.[Description],
		   FORMAT(r.OpenDate, 'dd.MM.yyyy') AS OpenDate,
		   s.[Label] AS [Status],
	   	   u.[Name] As [User]
      FROM Reports AS r
 LEFT JOIN Employees AS e
        ON r.EmployeeId = e.Id
 LEFT JOIN Departments AS d
        ON e.DepartmentId = d.Id
 LEFT JOIN Categories AS c
        ON r.CategoryId = c.Id
 LEFT JOIN Status AS s
        ON r.StatusId = s.Id
 LEFT JOIN Users AS u
        ON r.UserId = u.Id
  ORDER BY e.FirstName DESC,
           e.LastName DESC,
	 	   d.[Name],
		   c.[Name],
		   r.[Description],
		   r.OpenDate,
		   s.[Label],
		   u.[Name]
 
 GO
 --11.Houts to Complete

 CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME2, @EndDate DATETIME2)
 RETURNS INT
 AS
 BEGIN
	RETURN DATEDIFF(HOUR,@StartDate, @EndDate)
 END

 GO
 --12.Assign Employee

 CREATE PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT) 
 AS
 BEGIN 
	DECLARE @employeeDepartment INT = (SELECT DepartmentId 
	                                   FROM Employees
	                                  WHERE Id = @EmployeeId)

	DECLARE @reportDepartment INT = (SELECT c.DepartmentId
	                              FROM Reports As r
								  JOIN Categories AS c
								  ON r.CategoryId = c.Id
								  WHERE r.Id = @ReportId)
	
	IF (@employeeDepartment != @reportDepartment)
		BEGIN
			;THROW 60000, 'Employee doesn''t belong to the appropriate department!', 1
		END

	ELSE
		BEGIN
			UPDATE Reports
			SET EmployeeId = @EmployeeId
			WHERE Id = @ReportId
		END
 END

 EXEC usp_AssignEmployeeToReport 30, 1

 EXEC usp_AssignEmployeeToReport 17, 2