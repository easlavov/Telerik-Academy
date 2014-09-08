USE Company
GO

SELECT dep.Name, (SELECT COUNT(*)
FROM Departments d
	INNER JOIN Employees e
		ON d.Id = DepartmentId
	WHERE dep.Id = d.Id) AS [EmployeesCount]
FROM Departments dep
ORDER BY EmployeesCount DESC