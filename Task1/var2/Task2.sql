USE TESTDB;

SELECT d.Name
FROM Employee e LEFT JOIN Department d ON e.DepartmentId = d.Id
WHERE Salary = (SELECT MAX(Salary) FROM Employee)
ORDER BY 1 ASC;
