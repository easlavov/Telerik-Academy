//Write a program that retrieves the name and 
//description of all categories in the Northwind DB.
using System;
using System.Data.SqlClient;
using System.Linq;

class TestProgram
{
    static void Main()
    {
        string northwindConnectionString = "Server=.\\SQLEXPRESS; " +
                                  "Database=Northwind; Integrated Security=true";
        PrintCategoriesAndProdcuts(northwindConnectionString);
    }

    private static void PrintCategoriesAndProdcuts(string connectionString)
    {
        SqlConnection dbCon = new SqlConnection(connectionString);
        dbCon.Open();
        using (dbCon)
        {
            var catRetrieveCmd = new SqlCommand(
                "SELECT c.CategoryID, c.CategoryName, p.ProductName " + 
                "FROM Categories c JOIN Products p ON c.CategoryID = p.CategoryID "
                + "ORDER BY c.CategoryID",
                dbCon);
            var reader = catRetrieveCmd.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    string name = (string)reader["CategoryName"];
                    string product = (string)reader["ProductName"];
                    Console.WriteLine(name + ": " + product);
                }
            }
        }
    }
}