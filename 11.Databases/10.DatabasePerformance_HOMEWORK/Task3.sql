-- Add a full text index for the text column. Try to
-- search with and without the full-text index and 
-- compare the speed.
USE Performance
GO

DROP INDEX Logs.IDX_Logs_LogDate
CREATE INDEX IDX_Logs_MsgText ON Logs(LogText)

SELECT l.LogText
FROM Logs l
WHERE YEAR(l.LogDate) < 2012 AND YEAR(l.LogDate) > 2001