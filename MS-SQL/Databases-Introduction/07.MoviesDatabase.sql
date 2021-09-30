CREATE DATABASE [Movies]

USE [Movies]

CREATE TABLE [Directors] (
[Id] INT PRIMARY KEY IDENTITY NOT NULL,
[DirectorName] NVARCHAR(50) NOT NULL,
[Notes] NVARCHAR(MAX)
)

INSERT INTO [Directors] ([DirectorName]) VALUES
('Jhon'),
('Mike'),
('Mimi'),
('Stefan'),
('Ivan')


CREATE TABLE [Genres] (
[Id] INT PRIMARY KEY IDENTITY NOT NULL,
[GenreName] NVARCHAR(50) NOT NULL,
[Notes] NVARCHAR(MAX)
)

INSERT INTO [Genres] ([GenreName]) VALUES
('Pesho'),
('Bobo'),
('Vesi'),
('Kiko'),
('Jan')


CREATE TABLE [Categories] (
[Id] INT PRIMARY KEY IDENTITY NOT NULL,
[CategoryName] NVARCHAR(50) NOT NULL,
[Notes] NVARCHAR(MAX)
)

INSERT INTO Categories ([CategoryName]) VALUES
('Horror'),
('Comedy'),
('Drama'),
('Mistery'),
('Fantastic')


CREATE TABLE [Movies] (
[Id] INT PRIMARY KEY IDENTITY NOT NULL,
[Title] NVARCHAR(50) NOT NULL,
[DirectorId] INT NOT NULL,
[CopyrightYear] iNT NOT NULL,
[Length] TIME NOT NULL,
[GenreId] INT NOT NULL,
[CategoryId] INT NOT NULL,
[Rating] DECIMAL(1,1),
[Notes] NVARCHAR(MAX)
)

INSERT INTO Movies ([Title], [DirectorId], [CopyrightYear], [Length], [GenreId], [CategoryId]) VALUES
('MOvie', 3, 2019, '86:25:26', 2, 5),
('MOvie', 3, 2019, '86:25:26', 2, 5),
('MOvie', 3, 2019, '86:25:26', 2, 5),
('MOvie', 3, 2019, '86:25:26', 2, 5),
('MOvie', 3, 2019, '86:25:26', 2, 5)