CREATE DATABASE [CarRental]

CREATE TABLE [Categories](
[Id] INT PRIMARY KEY IDENTITY NOT NULL,
[CategoryName] NVARCHAR(50) NOT NULL,
[DailyRate] TINYINT,
[WeeklyRate] TINYINT,
[MonthlyRate] SMALLINT,
[WeekEndRate] TINYINT
)

INSERT INTO [Categories] ([CategoryName], [DailyRate], [WeeklyRate], [MonthlyRate], [WeekEndRate]) VALUES
('Sedan', 3, 5, NULL, NULL),
('Coupe', 1, 13, 20, NULL),
('Combi', 6, 9, 21, 7)


CREATE TABLE [Cars](
[Id] INT PRIMARY KEY IDENTITY NOT NULL,
[PlateNumber] NVARCHAR(10) NOT NULL,
[Manufacturer] VARCHAR(20) NOT NULL,
[Model] VARCHAR(20) NOT NULL,
[CarYear] SMALLINT NOT NULL,
[CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]) NOT NULL,
[Doors] TINYINT,
[Picture] VARBINARY(MAX),
[Condition] NVARCHAR(MAX),
[Availible] BIT NOT NULL
)

INSERT INTO [Cars] ([PlateNumber], [Manufacturer], [Model], [CarYear], [CategoryId], [Doors], [Picture], [Condition], [Availible]) VALUES
('PB1745MN', 'BMW', '318IS', 1998, 2, 2, NULL, 'Perfect', 1),
('CA1245MN', 'TOYOTA', 'YARIS', 2008, 1, 2, NULL, NULL, 0),
('E1885MN', 'HONDA', 'ACCORD', 2010, 3, 5, NULL, NULL, 1)


CREATE TABLE [Employees](
[Id] INT PRIMARY KEY IDENTITY NOT NULL,
[FirstName] NVARCHAR(20) NOT NULL,
[LastName] NVARCHAR(20) NOT NULL,
[Title] NVARCHAR(100) NOT NULL,
[Notes] NVARCHAR(MAX)
)

INSERT INTO [Employees] ([FirstName], [LastName], [Title], [Notes]) VALUES
('Ivan', 'Ivanov', 'Sales', NULL),
('Ivan', 'Ivanov', 'Sales', NULL),
('Ivan', 'Ivanov', 'Sales', 'The Best')

CREATE TABLE [Customers] (
[Id] INT PRIMARY KEY IDENTITY NOT NULL,
[DrivingLicenseNumber] INT NOT NULL,
[FullName] NVARCHAR(100) NOT NULL,
[Address] NVARCHAR(100) NOT NULL,
[City] NVARCHAR(50) NOT NULL,
[ZIPCode] SMALLINT,
[Notes] NVARCHAR(MAX)
)

INSERT INTO [Customers] ([DrivingLicenseNumber], [FullName], [Address],[City], [ZIPCode], [Notes]) VALUES
(3214234, 'Stoqn Ivanov', 'str.34th', 'Sofia', 1002, NULL),
(3214234, 'Georgi Stefanov', 'str.Morski skali', 'Sozopol', 8045, NULL),
(3214234, 'Mimi Nedeva', 'blvd.7', 'Plovdiv', 4004, NULL)


CREATE TABLE [RentalOrders](
[Id] INT PRIMARY KEY IDENTITY NOT NULL,
[EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]),
[CustomerId] INT FOREIGN KEY REFERENCES [Customers]([Id]),
[CarId] INT FOREIGN KEY REFERENCES [Cars]([Id]),
[TankLevel] TINYINT NOT NULL,
[KilometrageStart] INT NOT NULL,
[KilometrageEnd] INT NOT NULL,
[TotalKilometrage] SMALLINT NOT NULL,
[StartDate] INT NOT NULL,
[EndDate] INT NOT NULL,
[TotalDays] TINYINT NOT NULL,
[RateApplied] NVARCHAR(100) NOT NULL,
[TaxRate] DECIMAL(5, 2) NOT NULL,
[OrderStatus] BIT NOT NULL,
[Notes] NVARCHAR(MAX)
)

INSERT INTO [RentalOrders] ([EmployeeId],[CustomerId], [CarId], [TankLevel], [KilometrageStart], [KilometrageEnd],
[TotalKilometrage], [StartDate], [EndDate], [TotalDays], [RateApplied], [TaxRate], [OrderStatus], [Notes])
VALUES
(3, 2, 2, 55, 123500, 123899, 399, 2016-10-23, 2016-10-28, 5, 'Sofiq- Plovdiv', 25.52, 1, NULL),
(3, 2, 2, 55, 123500, 123899, 399, 2016-10-23, 2016-10-28, 5, 'Sofiq- Plovdiv', 25.52, 1, NULL),
(3, 2, 2, 55, 123500, 123899, 399, 2016-10-23, 2016-10-28, 5, 'Sofiq- Plovdiv', 25.52, 1, NULL)