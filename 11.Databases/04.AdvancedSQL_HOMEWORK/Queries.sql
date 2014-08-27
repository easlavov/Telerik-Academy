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

--Write a SQL query to find the average salary in the 
--"Sales" department.
SELECT AVG(Salary) AS AvgSalaryInSales
FROM Employees e
	INNER JOIN Departments d
		ON (e.DepartmentID = d.DepartmentID
			AND d.Name = 'Sales')

--Write a SQL query to find the number of employees 
--in the "Sales" department.
SELECT Count(*) AS [Number of Employees in Sales]
FROM Employees e
	INNER JOIN Departments d
		ON (e.DepartmentID = d.DepartmentID
			AND d.Name = 'Sales')

--Write a SQL query to find the number of all 
--employees that have manager.
SELECT Count(*) AS [Employees with manager]
FROM Employees 
WHERE ManagerID IS NOT NULL

--Write a SQL query to find the number of all 
--employees that have no manager.
SELECT Count(*) AS [Employees without manager]
FROM Employees 
WHERE ManagerID IS NULL

--Write a SQL query to find all departments and the 
--average salary for each of them.
SELECT d.Name, AVG(e.Salary) AS [Average Salary]
FROM Departments d
	JOIN Employees e
		ON d.DepartmentID = e.DepartmentID
GROUP BY d.Name

--Write a SQL query to find the count of all employees 
--in each department and for each town.
SELECT d.Name [Department], t.Name [Town], COUNT(*) [Employee count]
FROM Departments d
	JOIN Employees e
		ON d.DepartmentID = e.DepartmentID
	JOIN Addresses ad
		ON e.AddressID = ad.AddressID
	JOIN Towns t
		ON ad.TownID = t.TownID
GROUP BY d.Name, t.Name
ORDER BY d.Name

--Write a SQL query to find all managers that have 
--exactly 5 employees. Display their first name and 
--last name.
SELECT em.FirstName, em.LastName
FROM Employees e
	JOIN Employees em
		ON e.ManagerID = em.EmployeeID
GROUP BY em.FirstName, em.LastName
HAVING Count(*) = 5

--Write a SQL query to find all employees along with 
--their managers. For employees that do not have 
--manager display the value "(no manager)".
SELECT e.FirstName, 
	   e.LastName, 
	   ISNULL(em.FirstName + ' ' + em.LastName, 'no manager') AS ManagerFullName
FROM Employees e
	LEFT JOIN Employees em	
		ON e.ManagerID = em.EmployeeID

--Write a SQL query to find the names of all 
--employees whose last name is exactly 5 characters 
--long. Use the built-in LEN(str) function.
SELECT FirstName, LastName
FROM Employees
WHERE LEN(LastName) = 5

--Write a SQL query to display the current date and 
--time in the following format "day.month.year 
--hour:minutes:seconds:milliseconds". Search in 
--Google to find how to format dates in SQL Server.
SELECT FORMAT(GETDATE(), 'dd.MM.yyyy HH:mm:ss:fff');

--Write a SQL statement to create a table Users. 
--Users should have username, password, full name 
--and last login time. Choose appropriate data types 
--for the table fields. Define a primary key column 
--with a primary key constraint. Define the primary 
--key column as identity to facilitate inserting records. 
--Define unique constraint to avoid repeating 
--usernames. Define a check constraint to ensure the 
--password is at least 5 characters long.
CREATE TABLE Users
(
    UserId INT IDENTITY PRIMARY KEY,
    Username VARCHAR(32) NOT NULL UNIQUE,
    Password VARCHAR(32) CHECK(LEN(Password) >= 5),
    FullName VARCHAR(32) NOT NULL,
    LastLogin DATETIME
)

-- Write a SQL statement to create a view that displays the users from the
-- Users table that have been in the system today. Test if the view works
-- correctly.
SELECT FullName, Username
FROM Users 
WHERE CONVERT(VARCHAR(10),LastLogin,120) = CONVERT(VARCHAR(10), GETDATE(), 120)

-- Write a SQL statement to create a table Groups. Groups should have
-- unique name (use unique constraint). Define primary key and identity
-- column.
CREATE TABLE Groups
(
    GroupId INT IDENTITY PRIMARY KEY,
	Name VARCHAR(16) UNIQUE NOT NULL
)

-- Write a SQL statement to add a column GroupID to the table Users. Fill
-- some data in this new column and as well in the Groups table. Write a SQL
-- statement to add a foreign key constraint between tables Users and Groups
-- tables.
ALTER TABLE Users
ADD GroupId INT FOREIGN KEY REFERENCES Groups(GroupId);
UPDATE Users SET GroupId = 1;

-- Write SQL statements to insert several records in the Users and Groups
-- tables.
INSERT Users VALUES ('admin', '78956das', 'Jon Doe', GETDATE(), 2);
INSERT Users VALUES ('simpleuser', '121d2sa', 'Jane Doe', GETDATE(), 2);
INSERT Users VALUES ('poweruser', '8520gfs', 'Batman', GETDATE(), 3);

-- Write SQL statements to update some of the records in the Users and
-- Groups tables
UPDATE Groups SET Name = UPPER(Name);
Update Users SET FullName = REVERSE(FullName) 
	WHERE Username Like 'Simp%'

-- Write SQL statements to delete some of the records from the Users and
-- Groups tables.
DELETE FROM Users WHERE FullName LIKE '% %';
DELETE FROM Groups WHERE GroupId = 3;

-- Write SQL statements to insert in the Users table the names of all
-- employees from the Employees table. Combine the first and last names as a
-- full name. For username use the first letter of the first name + the last
-- name (in lowercase). Use the same for the password, and NULL for last login
-- time.
INSERT INTO Users(Username, [Password], Fullname, GroupID)
SELECT LOWER(LEFT(FirstName, 3) + LastName),
                LOWER(LEFT(FirstName, 3) + LastName),
                FirstName + ' ' + LastName, 1
FROM Employees

-- Write a SQL statement that changes the password to NULL for
-- all users that have not been in the system since 10.03.2010. 
UPDATE Users
SET [Password] = NULL
FROM Users
WHERE LastLogin < CONVERT(datetime, '10-03-2010') AND [Password] IS NOT NULL

-- Write a SQL statement that deletes all users without
-- passwords (NULL password).
BEGIN TRAN
DELETE FROM Users
WHERE [Password] IS NULL 
ROLLBACK TRAN

-- Write a SQL query to display the average employee salary by
-- department and job title.
SELECT e.JobTitle, AVG(e.Salary) AS [Average Salary]
FROM Employees e JOIN Departments d 
	ON e.DepartmentId = d.DepartmentId 
GROUP BY d.Name, e.JobTitle 
ORDER BY [Average Salary] DESC

-- Write a SQL query to display the minimal employee salary by
-- department and job title along with the name of some of the
-- employees that take it.

SELECT e.FirstName + ' ' + e.LastName AS FullName,
	   e.JobTitle, 
	   MIN(e.Salary) AS [Min Salary]
FROM Employees e JOIN Departments d 
	ON e.DepartmentId = d.DepartmentId 
GROUP BY d.Name, e.JobTitle, e.FirstName, e.LastName 
ORDER BY [Min Salary] DESC;

-- Write a SQL query to display the town where
-- maximal number of employees work.
SELECT TOP(1) t.Name, COUNT(e.EmployeeID) AS WorkingEmployees
FROM Towns t
	JOIN Addresses a
		ON t.TownID = a.TownID
	JOIN Employees e
		ON e.AddressID = a.AddressID
GROUP BY t.Name
ORDER BY WorkingEmployees DESC

-- Write a SQL query to display the number of
-- managers from each town.
SELECT COUNT(DISTINCT e.ManagerID), t.Name
FROM Employees e
	JOIN Employees m
		ON e.ManagerID = m.EmployeeID
	JOIN Addresses a
		ON a.AddressID = m.AddressID
	JOIN Towns t
		ON a.TownID = t.TownID
GROUP BY t.Name

-- Write a SQL to create table WorkHours to store work
-- reports for each employee (employee id, date, task, hours,
-- comments). Don't forget to define  identity, primary key and
-- appropriate foreign key.
-- Issue few SQL statements to insert, update and delete of
-- some data in the table.
-- Define a table WorkHoursLogs to track all changes in the
-- WorkHours table with triggers. For each change keep the old
-- record data, the new record data and the command
-- (insert / update / delete).
CREATE TABLE Tasks
(
	TaskID INT IDENTITY(1, 1) PRIMARY KEY,
	NAME nvarchar(50) NOT NULL
)
 
CREATE TABLE WorkHours 
(
	WorkHoursID INT IDENTITY(1 ,1) PRIMARY KEY,
	EmployeeID INT FOREIGN KEY(EmployeeID) REFERENCES Employees(EmployeeID) NOT NULL,
	[DATE] datetime NOT NULL,
	TaskID INT FOREIGN KEY(TaskID) REFERENCES Tasks(TaskID) NOT NULL,
	[Hours] INT NULL,
	Comments nvarchar(250) NULL,
)
 
INSERT INTO WorkHours
	VALUES(5, '2013-07-12', 4, NULL, NULL)
 
CREATE TABLE WorkHoursLog
(
	LogID INT IDENTITY(1,1) PRIMARY KEY,
	ExecutedCommand nvarchar(20) NULL,
	WorkHoursID INT NULL,
	OldEmployeeID INT FOREIGN KEY(OldEmployeeID) REFERENCES Employees(EmployeeID) NULL,
	[OldDate] datetime NULL,
	OldTaskID INT FOREIGN KEY(OldTaskID) REFERENCES Tasks(TaskID) NULL,
	[OldHours] INT NULL,
	OldComments nvarchar(250) NULL,
	NewEmployeeID INT FOREIGN KEY(NewEmployeeID) REFERENCES Employees(EmployeeID) NULL,
	[NewDate] datetime NULL,
	NewTaskID INT FOREIGN KEY(NewTaskID) REFERENCES Tasks(TaskID) NULL,
	[NewHours] INT NULL,
	NewComments nvarchar(250) NULL
)
GO

ALTER TRIGGER TR_WorkHoursDelete
	ON WorkHours
FOR DELETE
	AS
		INSERT INTO WorkHoursLog
    SELECT 'DELETE', *, NULL, NULL, NULL, NULL, NULL
        FROM deleted 
GO
 
ALTER TRIGGER TR_WorkHoursInsert
	ON WorkHours
FOR INSERT
	AS
    INSERT INTO WorkHoursLog
    SELECT 'INSERT', WorkHoursID, NULL, NULL, NULL, NULL, NULL,
                EmployeeID, [DATE], TaskID, [Hours], Comments
        FROM inserted
 
GO
 
ALTER TRIGGER TR_WorkHoursUpdate
ON WorkHours
FOR UPDATE
	AS
    INSERT INTO WorkHoursLog
    SELECT 'UPDATE', d.WorkHoursID, d.EmployeeID, d.[DATE], d.TaskID, d.[Hours], d.Comments,
		i.EmployeeID, i.[DATE], i.TaskID, i.[Hours], i.Comments  
    FROM inserted i, deleted d
GO 
 
-- TRIGGERS TEST --
DELETE FROM WorkHours WHERE WorkHoursID = 3
 
INSERT INTO WorkHours
	VALUES(5, '2013-07-12', 4, NULL, NULL)
 
UPDATE WorkHours
SET Hours = 123
FROM WorkHours
WHERE WorkHoursID = 8

-- Start a database transaction, delete all employees from the 'Sales'
-- department along with all dependent records from the other tables. At the
-- end rollback the transaction.
BEGIN TRAN
ALTER TABLE EmployeesProjects
ADD CONSTRAINT FK_CASCADE_1 FOREIGN KEY (EmployeeID)
REFERENCES Employees (EmployeeID)
ON DELETE CASCADE

ALTER TABLE Departments
ADD CONSTRAINT FK_CASCADE_2 FOREIGN KEY (ManagerId)
REFERENCES Employees (EmployeeID)
ON DELETE SET NULL;

DELETE FROM Employees
WHERE DepartmentId IN (SELECT DepartmentId FROM Departments WHERE Name = 'Sales')

ROLLBACK TRAN
GO

-- Start a database transaction and drop the table EmployeesProjects. Now
-- how you could restore back the lost table data?

-- SNAPSHOTS NOT SUPPORTED IN EXPRESS

BEGIN TRAN
CREATE DATABASE TelerikAcademy_snapshot
ON (NAME = TelerikAcademy_Data, FILENAME = 'TelerikAcademy_snapshot.ss')
AS SNAPSHOT OF TelerikAcademy;
DROP TABLE EmployeesProjects
ROLLBACK TRAN
GO

BEGIN TRAN
ALTER DATABASE TelerikAcademy
SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
USE master;
RESTORE DATABASE TeleikAcademy FROM DATABASE_SNAPSHOT = 'TelerikAcademy_snapshot';
GO

-- Find how to use temporary tables in SQL Server. Using temporary tables
-- backup all records from EmployeesProjects and restore them back after
-- dropping and re-creating the table.
BEGIN TRAN
SELECT * INTO #TempEmployeesProjects
FROM EmployeesProjects
DROP TABLE EmployeesProjects
SELECT * INTO EmployeesProjects
FROM #TempEmployeesProjects
DROP TABLE #TempEmployeesProjects
GO