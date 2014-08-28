//Write a program that retrieves the name and 
//description of all categories in the Northwind DB.
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

class TestProgram
{
    static void Main()
    {
        string northwindConnectionString = "Server=.\\SQLEXPRESS; " +
                                  "Database=Northwind; Integrated Security=true";
        string categoriesTable = "Categories";
        var namesAndDescriptions = GetCategoriesNameAndDescription(northwindConnectionString, categoriesTable);
        PrintCategoriesInfo(namesAndDescriptions);
    }

    private static Dictionary<string, string> GetCategoriesNameAndDescription(string connectionString, string table)
    {
        var namesAndDescriptions = new Dictionary<string, string>();
        SqlConnection dbCon = new SqlConnection(connectionString);
        dbCon.Open();
        using (dbCon)
        {
            var nameDescRetrieveCmd = new SqlCommand(
                "SELECT CategoryName, Description FROM " + table, dbCon);
            var reader = nameDescRetrieveCmd.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    string name = (string)reader["CategoryName"];
                    string description = (string)reader["Description"];
                    namesAndDescriptions.Add(name, description);
                }
            }
        }

        return namesAndDescriptions;
    }

    private static void PrintCategoriesInfo(Dictionary<string, string> dict)
    {
        string format = "Name: {0}, Description: {1}";
        foreach (var item in dict)
        {
            string description = string.Format(format, item.Key, item.Value);
            Console.WriteLine(description);
        }
    }
}