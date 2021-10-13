  SELECT DepositGroup,
         MAX(MagicWandSize) AS longestMagicWand
    From WizzardDeposits
GROUP BY DepositGroup