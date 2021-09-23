CREATE TABLE [Employees]
(
[Id] INT PRIMARY KEY IDENTITY,
[FirstName] VARCHAR(100) NOT NULL,
[LastName] VARCHAR(100) NOT NULL,
[Title] VARCHAR(100) NOT NULL,
[Notes] VARCHAR(MAX)
)
INSERT INTO [Employees] VALUES
('Stefan','Ivanov','Cleaner',NULL),
('Minko','Stoqnov','IT',NULL),
('Gancho','Ivanov','Driver',NULL)


CREATE TABLE [Customers]
(
[AccountNumber] INT PRIMARY KEY,
[FirstName] VARCHAR(100) NOT NULL,
[LastName] VARCHAR(100) NOT NULL,
[PhoneNumber] VARCHAR(10) NOT NULL,
[EmergencyName] VARCHAR(100) NOT NULL,
[EmergencyNumber] VARCHAR(10) NOT NULL,
[Notes] VARCHAR(MAX)
)
INSERT INTO [Customers] VALUES
(895215,'Mimi','Stoqnova','0895163547','Georgi','0896874563',NULL),
(894268,'Stefan','Ivanov','0896874563','Dara','0897459871',NULL),
(632548,'Gogo','Mogo','0897459871','Bogo','0895163547',NULL)


CREATE TABLE [RoomStatus]
(
[RoomStatus] VARCHAR(100) NOT NULL,
[Notes] VARCHAR(MAX)
)
INSERT INTO [RoomStatus] VALUES
('Empty',NULL),
('Cleaning',NULL),
('InUse',NULL)


CREATE TABLE [RoomTypes] 
(
[RoomType] VARCHAR(100) NOT NULL,
[Notes] VARCHAR(MAX)
)
INSERT INTO [RoomTypes] VALUES
('Big',NULL),
('Small',NULL),
('Apartment',NULL)


CREATE TABLE [BedTypes] 
(
[BedType] VARCHAR(100) NOT NULL,
[Notes] VARCHAR(MAX)
)
INSERT INTO [BedTypes] VALUES
('Singel bed',NULL),
('Double bed',NULL),
('Big bed',NULL)


CREATE TABLE [Rooms] 
(
[RoomNumber] INT PRIMARY KEY,
[RoomType] VARCHAR(100) NOT NULL,
[BedType] VARCHAR(100) NOT NULL,
[Rate] DECIMAL(10,2),
[RoomStatus] VARCHAR(100) NOT NULL,
[Notes] VARCHAR(MAX)
)
INSERT INTO [Rooms] VALUES
(101,'Big','Singel bed',NULL,'Empty',NULL),
(102,'Small','Double bed',NULL,'Cleaning',NULL),
(103,'Apartment','Child bed',NULL,'InUse',NULL)


CREATE TABLE [Payments] 
(
[Id] INT PRIMARY KEY IDENTITY,
[EmployeeId] INT NOT NULL,
[PaymentDate] DATE NOT NULL,
[AccountNumber] INT NOT NULL,
[FirstDateOccupied] DATETIME NOT NULL,
[LastDateOccupied] DATETIME NOT NULL,
[TotalDays] INT NOT NULL,
[AmountCharged] DECIMAL(38,2) NOT NULL,
[TaxRate] DECIMAL(38,2) NOT NULL,
[TaxAmount] DECIMAL(38,2) NOT NULL,
[PymentTotal] DECIMAL(38,2) NOT NULL,
[Notes] VARCHAR(MAX)
)
INSERT INTO [Payments] VALUES
(1,GETDATE(),632548,GETDATE(),GETDATE(),10,236.69,563.23,189.36,25698,NULL),
(2,GETDATE(),894268,GETDATE(),GETDATE(),10,236.69,563.23,189.36,25698,NULL),
(3,GETDATE(),895215,GETDATE(),GETDATE(),10,236.69,563.23,189.36,25698,NULL)


CREATE TABLE Occupancies
(
[Id] INT PRIMARY KEY IDENTITY,
[EmployeeId] INT NOT NULL,
[DateOccupied] DATETIME NOT NULL,
[AccountNumber] INT NOT NULL,
[RoomNumber] INT NOT NULL,
[RateApplied] DECIMAL(10,2),
[PhoneCharge] DECIMAL(10,2),
[Notes] VARCHAR(MAX)
)
INSERT INTO [Occupancies] VALUES
(1,GETDATE(),895215,101,7.96,NULL,NULL),
(2,GETDATE(),632548,102,NULL,2.56,NULL),
(3,GETDATE(),894268,103,9.6,0.65,NULL)
SELECT * FROM Occupancies