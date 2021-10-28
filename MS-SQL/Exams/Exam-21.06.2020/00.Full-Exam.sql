CREATE DATABASE TripService

--01.DDL

CREATE TABLE Cities(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(20) NOT NULL,
CountryCode CHAR(2) NOT NULL,
)

CREATE TABLE Hotels(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(30) NOT NULL,
CityId INT NOT NULL FOREIGN KEY REFERENCES Cities(Id),
EmployeeCount INT NOT NULL,
BaseRate DECIMAL(18,2)
)

CREATE TABLE Rooms(
Id INT PRIMARY KEY IDENTITY,
Price DECIMAL(18,2) NOT NULL,
[Type] NVARCHAR(20) NOT NULL,
Beds INT NOT NULL,
HotelId INT NOT NULL FOREIGN KEY REFERENCES Hotels(Id)
)

CREATE TABLE Trips(
Id INT PRIMARY KEY IDENTITY,
RoomId INT NOT NULL FOREIGN KEY REFERENCES Rooms(Id),
BookDate DATE NOT NULL,
ArrivalDate DATE NOT NULL,
ReturnDate DATE NOT NULL,
CancelDate DATE,
CHECK (BookDate < ArrivalDate),
CHECK (ArrivalDate < ReturnDate)
)

CREATE TABLE Accounts(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(50) NOT NULL,
MiddleName NVARCHAR(20),
LastName NVARCHAR(50) NOT NULL,
CityId INT NOT NULL FOREIGN KEY REFERENCES Cities(Id),
BirthDate DATE NOT NULL,
Email VARCHAR(100) NOT NULL UNIQUE
)

CREATE TABLE AccountsTrips(
AccountId INT NOT NULL FOREIGN KEY REFERENCES Accounts(Id),
TripId INT NOT NULL FOREIGN KEY REFERENCES Trips(Id),
Luggage INT NOT NULL
CHECK (Luggage >= 0),
PRIMARY KEY (AccountId, TripId)
)

--02.Insert

INSERT INTO Accounts(FirstName, MiddleName, LastName, CityId, BirthDate, Email)
VALUES
('John', 'Smith', 'Smith', 34, '1975-07-21', 'j_smith@gmail.com'),
('Gosho', NULL, 'Petrov', 11, '1978-05-16', 'g_petrov@gmail.com'),
('Ivan', 'Petrovich', 'Pavlov', 59, '1849-09-26', 'i_pavlov@softuni.bg'),
('Friedrich', 'Wilhelm', 'Nietzsche', 2, '1844-10-15', 'f_nietzsche@softuni.bg')

INSERT INTO Trips(RoomId, BookDate, ArrivalDate, ReturnDate, CancelDate)
VALUES
(101, '2015-04-12', '2015-04-14', '2015-04-20', '2015-02-02'),
(102, '2015-07-07', '2015-07-15', '2015-07-22', '2015-04-29'),
(103, '2013-07-17', '2013-07-23', '2013-07-24', NULL),
(104, '2012-03-17', '2012-03-31', '2012-04-01', '2012-01-10'),
(109, '2017-08-07', '2017-08-28', '2017-08-29', NULL)

--03.Update

UPDATE Rooms
SET Price *= 1.14
WHERE HotelId IN (5, 7, 9)

--04.Delete

DELETE AccountsTrips
WHERE AccountId = 47

DELETE Accounts
WHERE Id = 47

--05.EEE-Mails

  SELECT a.FirstName,
         a.LastName,
	     FORMAT(a.BirthDate, 'MM-dd-yyyy'),
	     c.[Name] AS NomeTown,
	     a.Email
    FROM Accounts AS a
    JOIN Cities AS c
      ON a.CityId = c.Id
   WHERE Email LIKE 'e%'
ORDER BY c.[Name]

--06.City Statistic

  SELECT c.[Name] AS City,
         COUNT(c.Id) AS Hotels
    FROM Cities AS c
    JOIN Hotels AS h
      ON c.Id = h.CityId
GROUP BY c.[Name]
ORDER BY Hotels DESC,
         City

--07.Longest and shortest trips

  SELECT Id AS AccountId,
         FullName,
	     MAX(TripDays) AS LongestTrip,
	     MIN(TripDays) AS SshortestTrip
    FROM (
			   SELECT a.id,
					  CONCAT(a.FirstName, ' ', a.LastName) AS  FullName,
					  DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate) AS TripDays
				 FROM Accounts AS a
			LEFT JOIN AccountsTrips AS ta
				   ON a.Id = ta.AccountId
			LEFT JOIN Trips AS t
				   ON ta.TripId = t.Id
				WHERE a.MiddleName IS NULL AND t.CancelDate IS NULL
					  AND t.ArrivalDate IS NOT NULL
	     ) AS CalculatedDays
GROUP BY Id, FullName
ORDER BY LongestTrip DESC,
         SshortestTrip

--08.Metropolis

  SELECT TOP(10)
         c.Id,
         c.[Name] AS City,
	     c.CountryCode AS Country,
         COUNT(c.Id) AS Accounts
    FROM Accounts AS a
    JOIN Cities AS c 
      ON c.Id = a.CityId
GROUP BY c.Id, c.[Name], c.CountryCode
ORDER BY Accounts DESC

--09.Romantic getaweys

   SELECT a.Id,
          a.Email,
	      c.Name AS City,
	      COUNT(a.Id) AS Trips
     FROM Accounts AS a
     JOIN Cities AS c
       ON a.CityId = c.Id
LEFT JOIN AccountsTrips AS at
       ON a.Id = at.AccountId
LEFT JOIN Trips AS t
       ON at.TripId = t.Id
     JOIN Rooms AS r
       ON t.RoomId = r.Id
     JOIN Hotels AS h
       ON r.HotelId = h.Id
    WHERE a.CityId = h.CityId
 GROUP BY a.Id, a.CityId, c.Name, a.Email
 ORDER BY Trips DESC,
          a.Id

--10.GDPR Violation

  SELECT t.Id,
         CONCAT(a.FirstName, ' ', ISNULL(a.MiddleName + ' ', ''), a.LastName) AS FullName,
	     (SELECT Name FROM Cities AS c WHERE a.CityId = c.Id) AS [From],
	     (SELECT Name FROM Cities AS c WHERE h.CityId = c.Id) AS [To],
	     CASE
			WHEN t.CancelDate IS NOT NULL THEN 'Canceled'
			ELSE CONCAT(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate), ' ', 'days')
	     END AS Duration
    FROM Trips AS t
    JOIN AccountsTrips AS at ON t.Id = at.TripId
    JOIN Accounts AS a ON at.AccountId = a.Id
    JOIN Rooms AS r ON t.RoomId = r.Id
    JOIN Hotels AS h ON r.HotelId = h.Id
ORDER BY FullName, t.Id

--11.Available Room
GO 
CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS VARCHAR(MAX)
AS
BEGIN 
	DECLARE @RoomId INT = 
	(
		SELECT TOP(1) r.Id 
			FROM Rooms AS r
			JOIN Trips AS t ON t.RoomId = r.Id
			WHERE r.HotelId = @HotelId 
				  AND r.Beds > @People
				  AND ((@Date >= t.ArrivalDate AND @Date <= t.ReturnDate AND t.CancelDate IS NOT NULL) 
				  OR (@Date < t.ArrivalDate OR @Date > t.ReturnDate))
			ORDER BY r.Price DESC

	)

	IF(SELECT COUNT(Id) FROM Rooms WHERE Id = @RoomId) < 1
		RETURN 'No rooms available'

	DECLARE @HotelBaseRate DECIMAL(15,2) = (SELECT BaseRate FROM Hotels WHERE Id = @HotelId)
	DECLARE @RoomPrice DECIMAL(15,2) = (SELECT Price FROM Rooms WHERE Id = @RoomId)
	DECLARE @RoomType NVARCHAR(MAX) = (SELECT [Type] FROM Rooms WHERE Id = @RoomId)
	DECLARE @RoomBeds INT = (SELECT Beds FROM Rooms WHERE Id = @RoomId)
	DECLARE @TotalPrice DECIMAL(15,2) = (@HotelBaseRate + @RoomPrice) * @People

	RETURN CONCAT('Room ',@RoomId,': ',@RoomType,' (',@RoomBeds,' beds) - $',@TotalPrice)
END

--12.Switch Room
GO
CREATE PROC usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
BEGIN 
	DECLARE @targetRoomHotelId INT = (SELECT HotelId FROM Rooms WHERE Id = @TargetRoomId)
	DECLARE @tripHotelId INT = (SELECT HotelId FROM Trips AS t JOIN Rooms AS r ON t.RoomId = r.Id WHERE t.Id = @TripId)
	DECLARE @targetRoomBeds INT = (SELECT Beds FROM Rooms WHERE Id = @TargetRoomId)
	DECLARE @tripAccounts INT = (SELECT COUNT(*) FROM Trips AS t LEFT JOIN AccountsTrips AS at ON t.Id = at.TripId 
	                                                             LEFT JOIN Accounts AS a ON at.AccountId = a.Id 
																 WHERE t.Id = @TripId)

	IF (@targetRoomHotelId <> @tripHotelId)
		BEGIN
		    ;THROW 60000, 'Target room is in another hotel!', 1
		END
	ELSE IF (@tripAccounts > @targetRoomBeds)
		BEGIN 
			;THROW 60001, 'Not enough beds in target room!', 2
		END
	ELSE
		BEGIN
			UPDATE Trips
			SET RoomId = @TargetRoomId
			WHERE Id = @TripId
		END
END
