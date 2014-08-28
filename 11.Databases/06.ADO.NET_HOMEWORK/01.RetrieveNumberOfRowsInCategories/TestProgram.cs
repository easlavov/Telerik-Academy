//Write a program that retrieves from the Northwind
//sample database in MS SQL Server the number of 
//rows in the Categories table. 
using System;
using System.Data.SqlClient;
using System.Linq;

class TestProgram
{
    static void Main()
    {
        string northwindConnectionString = "Server=.\\SQLEXPRESS; " +
                                  "Database=Northwind; Integrated Security=true";
        string categoriesTable = "Categories";
        int rowsInCategories = GetRowsCount(northwindConnectionString, categoriesTable);
        string messageFormat = "The rows in table {0} are {1}.";
        string message = string.Format(messageFormat, categoriesTable, rowsInCategories);
        Console.WriteLine(message);
    }

    private static int GetRowsCount(string connectionString, string table)
    {
        SqlConnection dbCon = new SqlConnection(connectionString);
        dbCon.Open();
        int rowsCount;
        using (dbCon)
        {
            var countRowsCmd = new SqlCommand(
                "SELECT COUNT(*) FROM " + table, dbCon);
            rowsCount = (int)countRowsCmd.ExecuteScalar();
        }

        return rowsCount;
    }
}