CREATE PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT) 
 AS
 BEGIN 
	DECLARE @employeeDepartment INT = (SELECT DepartmentId 
	                                   FROM Employees
	                                  WHERE Id = @EmployeeId)

	DECLARE @reportDepartment INT = (SELECT c.DepartmentId
	                              FROM Reports As r
								  JOIN Categories AS c
								  ON r.CategoryId = c.Id
								  WHERE r.Id = @ReportId)
	
	IF (@employeeDepartment != @reportDepartment)
		BEGIN
			;THROW 60000, 'Employee doesn''t belong to the appropriate department!', 1
		END

	ELSE
		BEGIN
			UPDATE Reports
			SET EmployeeId = @EmployeeId
			WHERE Id = @ReportId
		END
 END

 EXEC usp_AssignEmployeeToReport 30, 1

 EXEC usp_AssignEmployeeToReport 17, 2