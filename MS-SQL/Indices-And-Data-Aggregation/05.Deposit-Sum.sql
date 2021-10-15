  SELECT DepositGroup,
         SUM(DepositAmount) AS TotalSUM
    FROM WizzardDeposits
GROUP BY DepositGroup