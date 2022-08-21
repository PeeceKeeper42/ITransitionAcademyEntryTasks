USE TESTDB;

SELECT TOP 1 d.Name
FROM Employee e LEFT JOIN Department d ON e.DepartmentId = d.Id
ORDER BY Salary DESC;