  SELECT t.Id,
         CONCAT(a.FirstName, ' ', ISNULL(a.MiddleName + ' ', ''), a.LastName) AS FullName,
	     (SELECT Name FROM Cities AS c WHERE a.CityId = c.Id) AS [From],
	     (SELECT Name FROM Cities AS c WHERE h.CityId = c.Id) AS [To],
	     CASE
			WHEN t.CancelDate IS NOT NULL THEN 'Canceled'
			ELSE CONCAT(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate), ' ', 'days')
	     END AS Duration
    FROM Trips AS t
    JOIN AccountsTrips AS at ON t.Id = at.TripId
    JOIN Accounts AS a ON at.AccountId = a.Id
    JOIN Rooms AS r ON t.RoomId = r.Id
    JOIN Hotels AS h ON r.HotelId = h.Id
ORDER BY FullName, t.Id