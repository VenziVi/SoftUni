CREATE DATABASE Bakery

--01.DDL

CREATE TABLE Countries(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Customers(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(25),
LastName NVARCHAR(25),
Gender CHAR(1)
CHECK (Gender IN ('M', 'F')),
Age INT,
PhoneNumber CHAR(10)
CHECK (LEN(PhoneNumber) = 10),
CountryId INT FOREIGN KEY REFERENCES Countries(Id)
)

CREATE TABLE Products (
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(25) UNIQUE NOT NULL,
[Description] NVARCHAR(250),
Recipe NVARCHAR(MAX),
Price DECIMAL(18,2) NOT NULL
CHECK (Price > 0)
)

CREATE TABLE Feedbacks(
Id INT PRIMARY KEY IDENTITY,
[Description] NVARCHAR(255),
Rate DECIMAL(12,2),
ProductId INT FOREIGN KEY REFERENCES Products(Id),
CustomerId INT FOREIGN KEY REFERENCES Customers(Id)
)

CREATE TABLE Distributors(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(25) UNIQUE,
AddressText NVARCHAR(30),
Summary NVARCHAR(200),
CountryId INT FOREIGN KEY REFERENCES Countries(Id)
)

CREATE TABLE Ingredients(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(30),
[Description] NVARCHAR(200),
OriginCountryId INT FOREIGN KEY REFERENCES Countries(Id),
DistributorId INT FOREIGN KEY REFERENCES Distributors(Id)
)

CREATE TABLE ProductsIngredients(
ProductId INT NOT NULL FOREIGN KEY REFERENCES Products(Id),
IngredientId INT NOT NULL FOREIGN KEY REFERENCES Ingredients(Id),
PRIMARY KEY (ProductId, IngredientId)
)

--02.Insert

INSERT INTO Distributors([Name], CountryId, AddressText, Summary)
VALUES
('Deloitte & Touche', 2, '6 Arch St #9757', 'Customizable neutral traveling'),
('Congress Title', 13, '58 Hancock St', 'Customer loyalty'),
('Kitchen People', 1, '3 E 31st St #77', 'Triple-buffered stable delivery'),
('General Color Co Inc', 21, '6185 Bohn St #72', 'Focus group'),
('Beck Corporation', 23, '21 E 64th Ave', 'Quality-focused 4th generation hardware')

INSERT INTO Customers(FirstName, LastName, Age, Gender,PhoneNumber,CountryId)
VALUES
('Francoise', 'Rautenstrauch', 15, 'M', '0195698399', 5),
('Kendra', 'Loud', 22, 'F', '0063631526', 11),
('Lourdes', 'Bauswell', 50, 'M', '0139037043', 8),
('Hannah', 'Edmison', 18, 'F', '0043343686', 1),
('Tom', 'Loeza', 31, 'M', '0144876096', 23),
('Queenie', 'Kramarczyk', 30, 'F', '0064215793', 29),
('Hiu', 'Portaro', 25, 'M', '0068277755', 16),
('Josefa', 'Opitz', 43, 'F', '0197887645', 17)

--03.Update

UPDATE Ingredients
SET DistributorId = 35
WHERE [Name] IN ('Bay Leaf', 'Paprika', 'Poppy')

UPDATE Ingredients
SET OriginCountryId = 14 
WHERE OriginCountryId = 8

--04.Delete

DELETE Feedbacks 
WHERE CustomerId = 14 OR ProductId = 5

--05.Products by Price

  SELECT [Name], 
         Price,
		 [Description]
    FROM Products
ORDER BY Price DESC,
         [Name]

--06.Negative feedback

  SELECT f.ProductId,
         f.Rate,
		 f.[Description],
		 f.CustomerId,
		 c.Age,
		 c.Gender
    FROM Feedbacks AS f
    JOIN Customers AS c
      ON F.CustomerId = c.Id
   WHERE f.Rate < 5.00
ORDER BY f.ProductId DESC,
         f.Rate

--07.Customers without feedback

   SELECT CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName,
          c.PhoneNumber,
		  c.Gender
     FROM Customers AS c
LEFT JOIN Feedbacks AS f
       ON c.Id = f.CustomerId
    WHERE f.Id IS NULL
 ORDER BY c.Id

 --08.Customers by criteria

   SELECT FirstName,
          Age,
	  	  PhoneNumber
     FROM Customers
    WHERE (Age >= 21 AND FirstName LIKE '%an%')
       OR (PhoneNumber LIKE '%38' AND CountryId <> 31)
 ORDER BY FirstName,
          Age DESC

--09.Middle range distributors

   SELECT d.[Name] AS DistributorName,
          i.[Name] As IngredientName,
	      p.[Name] AS ProductName,
	      AverageRate
     FROM (
			  SELECT ProductId,
					 AVG(Rate) AS AverageRate
				FROM Feedbacks
			GROUP BY ProductId
     ) AS AverageRate
     JOIN ProductsIngredients AS pp
       ON pp.ProductId = AverageRate.ProductId
     JOIN Ingredients AS i
       ON pp.IngredientId = i.Id
     JOIN Distributors AS d
       ON d.Id = i.DistributorId
     JOIN Products AS p
       ON p.Id = pp.ProductId
    WHERE AverageRate >= 5 AND AverageRate <= 8
 ORDER BY DistributorName,
          IngredientName,
	  	  ProductName

--10.Country representaitve

SELECT r.CName,
       r.DName
	FROM (SELECT c.Name AS CName,r.Name AS DName,DENSE_RANK() OVER (PARTITION BY c.Name ORDER BY r.count DESC) AS Rank
	FROM (SELECT *,(SELECT COUNT(*) FROM Ingredients AS i  WHERE i.DistributorId = d.Id) AS Count
	FROM Distributors AS d) AS r
 JOIN Countries AS c  ON c.Id = r.CountryId) AS r
 WHERE r.Rank = 1
 ORDER BY r.CName,r.DName

 --11.Customers with Countries

 CREATE VIEW v_UserWithCountries 
 AS
 SELECT CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName,
        Age,
		Gender,
		co.Name AS CountryName
 FROM Customers AS c
 JOIN Countries AS co
 ON c.CountryId = co.Id

 SELECT TOP 5 *
  FROM v_UserWithCountries
 ORDER BY Age

 --12.Delete Products

 CREATE TRIGGER dbo.tr_OnDelete
 ON Products INSTEAD OF DELETE
 AS
	DELETE FROM Feedbacks
	WHERE ProductId IN (SELECT Id FROM deleted)

	DELETE FROM ProductsIngredients
	WHERE ProductId IN (SELECT Id FROM deleted)

	DELETE FROM Products
	WHERE Id IN (SELECT Id FROM deleted)


