CREATE FUNCTION udf_ClientWithCigars(@name NVARCHAR(30))
RETURNS INT
AS
BEGIN
	RETURN (SELECT COUNT(cc.CigarId) FROM Clients AS c
	        LEFT JOIN ClientsCigars AS cc ON c.Id = cc.ClientId
	        LEFT JOIN Cigars AS ci On cc.CigarId = ci.Id
	        WHERE c.FirstName = @name)
END