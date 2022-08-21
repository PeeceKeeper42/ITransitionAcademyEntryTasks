USE TESTDB;

WITH TempTable AS (
SELECT d.Name, SUM(e.Salary) AS SumSalary
FROM Employee e LEFT JOIN Department d ON e.DepartmentId = d.Id
GROUP BY d.Name)
SELECT Name FROM TempTable
WHERE SumSalary = (SELECT MAX(SumSalary) FROM TempTable)
ORDER BY 1 ASC;