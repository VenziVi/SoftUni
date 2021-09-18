CREATE TABLE [People](
[Id] BIGINT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[Name] VARCHAR(200) NOT NULL,
[Picture] VARBINARY(MAX),
[Height] DECIMAL(38, 2),
[Weight] DECIMAL(38, 2),
[Gender] CHAR(1) NOT NULL,
[Birthdate] DATE NOT NULL,
[Biography] NVARCHAR(MAX)
)

INSERT INTO [People] ([Name], [Height], 
[Weight], [Gender], [Birthdate], [Biography]) VALUES
('Petar', 175, 85, 'm', '1598.02.24', 'ipsum lorem'),
('Stoqn', 189, 105, 'm', '1999.12.22', 'ipsum lorem'),
('Ivan', 164, 77, 'm', '1999.12.22', 'ipsum lorem'),
('Gancho', 187, 112, 'm', '1999.11.22', 'ipsum lorem'),
('Mimi', 154, 55, 'f', '1999.10.22', 'ipsum lorem')