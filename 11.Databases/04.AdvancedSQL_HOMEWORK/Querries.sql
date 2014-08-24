USE TelerikAcademy
GO

--Write a SQL query to find the names and salaries of 
--the employees that take the minimal salary in the 
--company. Use a nested SELECT statement.
SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary = 
	(SELECT MIN(Salary) FROM Employees)

--Write a SQL query to find the names and salaries of 
--the employees that have a salary that is up to 10% 
--higher than the minimal salary for the company.
SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary <=  1.1 *
	(SELECT MIN(Salary) 
	 FROM Employees)

--Write a SQL query to find the full name, salary and 
--department of the employees that take the minimal 
--salary in their department. Use a nested SELECT
--statement.
SELECT e.FirstName, e.LastName, e.Salary, e.DepartmentID
FROM Employees e
WHERE Salary =
	(SELECT MIN(Salary)
	 FROM Employees m
	 WHERE m.DepartmentID = e.DepartmentID)

--Write a SQL query to find the average salary in the 
--department #1.
SELECT AVG(Salary) AS AvgSalaryInDep1
FROM Employees
WHERE EmployeeID = 1

