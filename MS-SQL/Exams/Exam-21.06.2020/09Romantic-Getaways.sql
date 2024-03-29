   SELECT a.Id,
          a.Email,
	      c.Name AS City,
	      COUNT(a.Id) AS Trips
     FROM Accounts AS a
     JOIN Cities AS c
       ON a.CityId = c.Id
LEFT JOIN AccountsTrips AS at
       ON a.Id = at.AccountId
LEFT JOIN Trips AS t
       ON at.TripId = t.Id
     JOIN Rooms AS r
       ON t.RoomId = r.Id
     JOIN Hotels AS h
       ON r.HotelId = h.Id
    WHERE a.CityId = h.CityId
 GROUP BY a.Id, a.CityId, c.Name, a.Email
 ORDER BY Trips DESC,
          a.Id