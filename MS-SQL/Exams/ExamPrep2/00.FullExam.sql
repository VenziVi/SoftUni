CREATE DATABASE School

--01.DDL

CREATE TABLE Students(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(30) NOT NULL,
MiddleName NVARCHAR(25),
LastName NVARCHAR(30) NOT NULL,
Age INT NOT NULL
CHECK (Age > 0),
Address NVARCHAR(50),
Phone NVARCHAR(10)
)

CREATE TABLE Subjects(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(20) NOT NULL,
Lessons INT NOT NULL
)

CREATE TABLE StudentsSubjects(
Id INT PRIMARY KEY IDENTITY,
StudentId INT NOT NULL FOREIGN KEY REFERENCES Students(Id),
SubjectId INT NOT NULL FOREIGN KEY REFERENCES Subjects(ID),
Grade DECIMAL(15, 2) NOT NULL
CHECK (Grade >= 2 AND Grade <= 6 ),
)

CREATE TABLE Exams(
Id INT PRIMARY KEY IDENTITY,
[Date] DATE,
SubjectId INT NOT NULL FOREIGN KEY REFERENCES Subjects(ID)
)

CREATE TABLE StudentsExams(
StudentId INT NOT NULL FOREIGN KEY REFERENCES Students(Id),
ExamId INT NOT NULL FOREIGN KEY REFERENCES Exams(Id),
Grade DECIMAL(3, 2) NOT NULL
CHECK (Grade >= 2 AND Grade <= 6 ),
PRIMARY KEY (StudentId, ExamId)
)

CREATE TABLE Teachers(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(20) NOT NULL,
LastName NVARCHAR(20) NOT NULL,
Address NVARCHAR(20) NOT NULL,
Phone NVARCHAR(10),
SubjectId INT NOT NULL FOREIGN KEY REFERENCES Subjects(ID)
)

CREATE TABLE StudentsTeachers(
StudentId INT NOT NULL FOREIGN KEY REFERENCES Students(Id),
TeacherId INT NOT NULL FOREIGN KEY REFERENCES Teachers(Id),
PRIMARY KEY (StudentId, TeacherId)
)

--02.Insert

INSERT INTO Teachers
VALUES
('Ruthanne', 'Bamb', '84948 Mesta Junction', '3105500146', 6),
('Gerrard', 'Lowin', '370 Talisman Plaza', '3324874824', 2),
('Merrile', 'Lambdin', '81 Dahle Plaza', '4373065154', 5),
('Bert', 'Ivie', '2 Gateway Circle', '4409584510', 4)

INSERT INTO Subjects
VALUES
('Geometry', 12),
('Health', 10),
('Drama', 7),
('Sports', 9)

--03.Update

UPDATE StudentsSubjects
SET Grade = 6.00
WHERE SubjectId IN (1, 2) AND Grade >= 5.50

--04.Delete

DELETE StudentsTeachers
WHERE TeacherId IN (7, 12, 15, 18, 24, 26)

DELETE Teachers
WHERE Phone LIKE '%72%'

--05.Teen Students

  SELECT FirstName,
         LastName,
	     Age
    FROM Students
   WHERE Age >= 12
ORDER BY FirstName,
         LastName

--06.Students teacher

   SELECT s.FirstName,
          s.LastName,
	      COUNT(t.Id) AS TeachersCount
     FROM Students AS s
LEFT JOIN StudentsTeachers AS st ON s.Id = st.StudentId
LEFT JOIN Teachers As t ON st.TeacherId = t.Id
 GROUP BY s.FirstName, s.LastName
 ORDER BY s.LastName

--07.Students to go

    SELECT CONCAT(s.FirstName, ' ', s.LastName) AS [Full Name]
      FROM Students AS s
 LEFT JOIN StudentsExams AS se ON s.Id = se.StudentId
     WHERE se.Grade IS NULL
  ORDER BY [Full Name]

--08.Top Students

    SELECT TOP(10)
           s.FirstName,
           s.LastName,
		   FORMAT(AVG(se.Grade), 'N2') AS Grade
      FROM Students AS s
 LEFT JOIN StudentsExams AS se ON s.Id = se.StudentId
  GROUP BY s.FirstName, s.LastName
  ORDER BY Grade DESC,
           s.FirstName,
		   s.LastName

--09.Not so in the studying

   SELECT CONCAT(s.FirstName, ' ', ISNULL(s.MiddleName + ' ', ''), s.lastName) AS [Full Name]
     FROM Students AS s 
LEFT JOIN StudentsSubjects AS ss ON s.Id = ss.StudentId
    WHERE ss.SubjectId IS NULL
 ORDER BY [Full Name]

--10.Average Grade Per Subject

   SELECT s.[Name],
          AVG(ss.Grade) AS AverageGrade
     FROM Subjects AS s
LEFT JOIN StudentsSubjects AS ss ON s.Id = ss.SubjectId
 GROUP BY s.[Name], s.Id
   HAVING AVG(ss.Grade) IS NOT NULL
 ORDER BY S.Id

--11.Exam Grades
GO
CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(15, 2))
RETURNS NVARCHAR(100)
AS
BEGIN
	DECLARE @studentName NVARCHAR(30) = (SELECT FirstName FROM Students WHERE id = @studentId)

	IF LEN(@studentName) = 0
		BEGIN
			RETURN 'The student with provided id does not exist in the school!'
		END
	IF (@grade > 6.00)
		BEGIN
			RETURN 'Grade cannot be above 6.00!'
		END

	DECLARE @gradeCount INT = (SELECT COUNT(Grade) FROM StudentsExams WHERE StudentId = 12 AND (Grade >= @grade AND Grade <= (@grade + 0.50)))

	RETURN CONCAT('You have to update ', @gradeCount, ' grades for the student ', @studentName)
END
