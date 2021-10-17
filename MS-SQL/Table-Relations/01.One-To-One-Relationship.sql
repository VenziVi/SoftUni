CREATE TABLE Passports (
	PassportID INT PRIMARY KEY IDENTITY(101, 1) NOT NULL,
	PassportNumber VARCHAR(10) NOT NULL
)

INSERT INTO Passports 
VALUES ('N34FG21B'),
	   ('K65LO4R7'),
       ('ZE657QP2')

CREATE TABLE Persons (
	PersonID INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	FirstName VARCHAR(30) NOT NULL,
	Salary DECIMAL(10, 2) NOT NULL,
	PassportID INT UNIQUE NOT NULL
	CONSTRAINT FK_PassportID_Passports 
	FOREIGN KEY (PassportID)
	REFERENCES Passports(PassportID)
)

INSERT INTO Persons
VALUES ('Roberto', 43300.00, 102),
       ('Tom', 56100.00, 103),
	   ('Yana', 60200.00, 101)