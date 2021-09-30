SELECT TOP (10) [ProjectID] 
			   ,[Name]
			   ,[Description]
			   ,[StartDate]
			   ,[EndDate]
FROM [Projects]
WHERE StartDate < GETDATE()
ORDER BY [StartDate]
        ,[Name]