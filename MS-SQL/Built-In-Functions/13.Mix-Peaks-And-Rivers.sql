  SELECT PeakName, 
         RiverName, 
         LOWER((CONCAT(PeakName, SUBSTRING(RiverName,2,LEN(RiverName))))) AS Mix
    FROM Peaks, Rivers
   WHERE Right(PeakName, 1) = Left(RiverName, 1)
ORDER BY Mix ASC
