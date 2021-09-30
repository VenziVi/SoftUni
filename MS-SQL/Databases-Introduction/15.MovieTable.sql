CREATE DATABASE [Movies]

USE [Movies]

CREATE TABLE [Directors] (
[Id] INT PRIMARY KEY IDENTITY NOT NULL,
[DirectorName] NVARCHAR(50) NOT NULL,
[Notes] NVARCHAR(MAX)
)

INSERT INTO [Directors] ([DirectorName],[Notes]) VALUES
('Jhon', NULL),
('Mike', 'Cool'),
('Mimi', NULL),
('Stefan', 'The best'),
('Ivan', 'Looser')


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
[DirectorId] INT FOREIGN KEY REFERENCES [Directors]([Id]) NOT NULL,
[CopyrightYear] iNT NOT NULL,
[Length] SMALLINT,
[GenreId] INT FOREIGN KEY REFERENCES [Genres]([Id]) NOT NULL,
[CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]) NOT NULL,
[Rating] SMALLINT,
[Notes] NVARCHAR(MAX)
)

INSERT INTO Movies ([Title], [DirectorId], [CopyrightYear], [Length], [GenreId], [CategoryId]) VALUES
('MOvie', 3, 2019, 54, 2, 5),
('MOvie', 3, 2019, 86, 2, 5),
('MOvie', 3, 2019, NULL, 2, 5),
('MOvie', 3, 2019, NULL, 2, 5),
('MOvie', 3, 2019, NULL, 2, 5)