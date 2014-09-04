-- Add an index to speed-up the search by date. Test 
-- the search speed (after cleaning the cache).
USE Performance
GO

-- Adding index to the date column
CREATE INDEX IDX_OnLogsDateColumn ON Logs(LogDate);

--Emptying server cache
CHECKPOINT DBCC DROPCLEANBUFFERS

--Test search by date after adding index
SELECT LogText FROM Logs WHERE LogDate 
		BETWEEN CONVERT(datetime, '2010-01-01 11:00:00') AND CONVERT(datetime, '2014-09-04 21:40:00')
		-- Change date and time accordingly if not operational


