CREATE TABLE Students (
	StudentID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL
)

INSERT INTO Students
VALUES ('Mila'),
       ('Toni'),
	   ('Ron')

CREATE TABLE Exams (
	ExamID INT PRIMARY KEY IDENTITY(101, 1),
	[Name] VARCHAR(50)
)

INSERT INTO Exams
VALUES ('SpringMVC'),
       ('Neo4j'),
	   ('Oracle 11g')

CREATE TABLE StudentsExams (
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID) NOT NULL,
	ExamID INT FOREIGN KEY REFERENCES Exams(ExamID) NOT NULL
	CONSTRAINT PK_Students_Exams
	PRIMARY KEY (StudentID, ExamID)
)

INSERT INTO StudentsExams
VALUES (1, 101),
       (1, 102),
	   (2, 101),
	   (3, 103),
	   (2, 102),
	   (2, 103)