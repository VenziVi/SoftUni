  SELECT Id AS AccountId,
         FullName,
	     MAX(TripDays) AS LongestTrip,
	     MIN(TripDays) AS SshortestTrip
    FROM (
			   SELECT a.id,
					  CONCAT(a.FirstName, ' ', a.LastName) AS  FullName,
					  DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate) AS TripDays
				 FROM Accounts AS a
			LEFT JOIN AccountsTrips AS ta
				   ON a.Id = ta.AccountId
			LEFT JOIN Trips AS t
				   ON ta.TripId = t.Id
				WHERE a.MiddleName IS NULL AND t.CancelDate IS NULL
					  AND t.ArrivalDate IS NOT NULL
	     ) AS CalculatedDays
GROUP BY Id, FullName
ORDER BY LongestTrip DESC,
         SshortestTrip