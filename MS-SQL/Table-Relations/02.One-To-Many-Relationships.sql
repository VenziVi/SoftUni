CREATE TABLE Manufacturers (
	ManufacturerID INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(30) NOT NULL,
	EstablishedOn VARCHAR(10) NOT NULL
)

INSERT INTO Manufacturers
VALUES ('BMW', '07/03/1916'),
       ('Tesla', '01/01/2003'),
	   ('Lada', '01/05/1966')

CREATE TABLE Models (
	ModelID INT PRIMARY KEY IDENTITY(101, 1) NOT NULL,
	[Name] VARCHAR(20) NOT NULL,
	ManufacturerID INT NOT NULL
	CONSTRAINT FK_ManufacturerId_Manufacturers
	FOREIGN KEY (ManufacturerID)
	REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO Models
VALUES ('X1', 1),
       ('i6', 1),
	   ('ModelS', 2),
	   ('ModelX', 2),
	   ('Model3', 2),
	   ('Nova', 3)
