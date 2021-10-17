CREATE PROC usp_GetTownsStartingWith (@input VARCHAR(20))
AS
SELECT [Name] 
  FROM Towns
 WHERE @input = LEFT(Name, LEN(@input))


EXEC usp_GetTownsStartingWith b