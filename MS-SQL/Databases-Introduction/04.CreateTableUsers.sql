CREATE TABLE [Users](
[Id] BIGINT PRIMARY KEY IDENTITY,
[Username] VARCHAR(30) UNIQUE NOT NULL,
[Password] VARCHAR(26) NOT NULL,
[ProfilePicture] VARBINARY(MAX),
CHECK (DATALENGTH([ProfilePicture]) <= 900000),
[LastLoginTime] DATETIME2,
[IsDeleted] BIT NOT NULL
)

INSERT INTO [Users] ([Username], [Password], [IsDeleted]) VALUES
('Gogo','SipiO6teEnda', 0),
('Pesho','BugBe', 1),
('Toto','YesBaby', 1),
('EmiNema','SipiPak', 1),
('Metin','NaiSeriozniq', 0)