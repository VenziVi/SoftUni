 SELECT TOP(2)
        DepositGroup
   FROM (
              SELECT DepositGroup,
                     AVG(MagicWandSize) AS MagicWandaSize
                FROM WizzardDeposits
            GROUP BY DepositGroup
         ) AS GrupedDeposit
ORDER BY MagicWandaSize