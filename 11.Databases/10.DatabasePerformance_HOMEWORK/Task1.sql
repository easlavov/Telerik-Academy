-- Create a table in SQL Server with 10 000 000 log entries (date + text).
-- Search in the table by date range. Check the speed (without caching).
CREATE DATABASE Performance
GO

USE Performance
GO

CREATE TABLE Logs (
	LogID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	LogDate DATE,
	LogText VARCHAR(50)
)
GO

INSERT INTO Logs(LogDate, LogText) 
VALUES ('1990-01-01', 'Sample log ');
GO

--Insert records
DECLARE @Counter int = 0
WHILE (SELECT COUNT(*) FROM Logs) < 1000000
BEGIN
  INSERT INTO Logs(LogDate, LogText)
  SELECT DATEADD(MONTH, @Counter + 3, LogDate), LogText + CONVERT(varchar, @Counter) FROM Logs
  SET @Counter = @Counter + 1
END

--Emptying server cache
CHECKPOINT DBCC DROPCLEANBUFFERS
GO

--Test search by date before adding index
SELECT LogText FROM Logs WHERE LogDate 
		BETWEEN CONVERT(datetime, '1990-01-01') AND CONVERT(datetime, '1995-01-01')
GO