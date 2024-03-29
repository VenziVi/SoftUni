CREATE DATABASE [Minions]

USE [Minions]

CREATE TABLE [Minions] (
	[Id] INT NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL,
	[Age] INT NOT NULL
)

CREATE TABLE [Town] (
	[Id] INT PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL
)

ALTER TABLE [Minions]
ADD [TownId] INT

ALTER TABLE [Minions]
ADD CONSTRAINT [FK_MinionsTownId] FOREIGN KEY (TownId) REFERENCES [Town]([Id])