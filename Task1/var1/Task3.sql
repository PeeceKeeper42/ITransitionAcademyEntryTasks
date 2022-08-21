USE TESTDB;

SELECT Name FROM (
SELECT TOP 1 d.Name, SUM(e.Salary) AS SumSalary
FROM Employee e LEFT JOIN Department d ON e.DepartmentId = d.Id
GROUP BY d.Name
ORDER BY 2 DESC) as A;
