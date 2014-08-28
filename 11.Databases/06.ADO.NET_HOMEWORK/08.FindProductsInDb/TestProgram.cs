//Write a program that reads a string from the console 
//and finds all products that contain this string. Ensure 
//you handle correctly characters like ', %, ", \ and _. 
using System;
using System.Data.SqlClient;
using System.Linq;

class TestProgram
{
    static void Main()
    {
        string northwindConnectionString = "Server=.\\SQLEXPRESS; " +
                                  "Database=Northwind; Integrated Security=true";
        Console.WriteLine("Ctrl + C to terminate.");
        while (true)
        {
            Console.Write("Enter search pattern: ");
            string searchPattern = Console.ReadLine();
            PrintSearchQuery(northwindConnectionString, searchPattern);
        }
    }

    private static void PrintSearchQuery(string connectionString, string searchPattern)
    {
        SqlConnection dbCon = new SqlConnection(connectionString);
        dbCon.Open();
        using (dbCon)
        {
            var catRetrieveCmd = new SqlCommand(
                "SELECT ProductName FROM Products WHERE CHARINDEX(@match, ProductName) > 0 ",
                dbCon);
            catRetrieveCmd.Parameters.AddWithValue("@match", searchPattern);
            var reader = catRetrieveCmd.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    string product = (string)reader["ProductName"];
                    Console.WriteLine(product);
                }
            }
        }
    }
}