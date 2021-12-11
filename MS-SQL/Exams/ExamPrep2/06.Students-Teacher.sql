   SELECT s.FirstName,
          s.LastName,
	      COUNT(t.Id) AS TeachersCount
     FROM Students AS s
LEFT JOIN StudentsTeachers AS st ON s.Id = st.StudentId
LEFT JOIN Teachers As t ON st.TeacherId = t.Id
 GROUP BY s.FirstName, s.LastName
 ORDER BY s.LastName