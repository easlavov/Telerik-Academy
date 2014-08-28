//Implement appending new rows to the Excel file.
using System;
using System.Data.OleDb;
using System.Linq;

class TestProgram
{
    static void Main()
    {
        string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source='..\\..\\scoreBoard.xls';Extended Properties=Excel 8.0;";
        AddStudentScore(connectionString, "Tanas", "3.14");
    }

    static void AddStudentScore(string connectionString, string name, string score)
    {
        OleDbConnection dbCon = new OleDbConnection(connectionString);
        dbCon.Open();
        using (dbCon)
        {
            OleDbCommand xlCmd = new OleDbCommand(
                "INSERT INTO [Sheet1$] (Name, Score) VALUES (@Name, @Score)", dbCon);
            xlCmd.Parameters.AddWithValue("@Name", name);
            xlCmd.Parameters.AddWithValue("@Score", score);
            int affectedRows = xlCmd.ExecuteNonQuery();
            Console.WriteLine("Affected rows: " + affectedRows);
        }       
    }
}