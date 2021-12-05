CREATE PROC usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
BEGIN 
	DECLARE @targetRoomHotelId INT = (SELECT HotelId FROM Rooms WHERE Id = @TargetRoomId)
	DECLARE @tripHotelId INT = (SELECT HotelId FROM Trips AS t JOIN Rooms AS r ON t.RoomId = r.Id WHERE t.Id = @TripId)
	DECLARE @targetRoomBeds INT = (SELECT Beds FROM Rooms WHERE Id = @TargetRoomId)
	DECLARE @tripAccounts INT = (SELECT COUNT(*) FROM Trips AS t LEFT JOIN AccountsTrips AS at ON t.Id = at.TripId 
	                                                             LEFT JOIN Accounts AS a ON at.AccountId = a.Id 
																 WHERE t.Id = @TripId)

	IF (@targetRoomHotelId <> @tripHotelId)
		BEGIN
		    ;THROW 60000, 'Target room is in another hotel!', 1
		END
	ELSE IF (@tripAccounts > @targetRoomBeds)
		BEGIN 
			;THROW 60001, 'Not enough beds in target room!', 2
		END
	ELSE
		BEGIN
			UPDATE Trips
			SET RoomId = @TargetRoomId
			WHERE Id = @TripId
		END
END