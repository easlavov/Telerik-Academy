using System;
using System.Data.SqlClient;
using System.Linq;

class TestProgram
{
    static void Main()
    {
        string northwindConnectionString = "Server=.\\SQLEXPRESS; " +
                                  "Database=Northwind; Integrated Security=true";
        
        AddNewProduct(northwindConnectionString, "Beer Astika");
        AddNewProduct(northwindConnectionString, "Beer Ledenika");
        AddNewProduct(northwindConnectionString, "Beer Ariana");
    }

    private static void AddNewProduct(string connectionString, string productName)
    {
        Console.WriteLine("Adding " + productName);
        SqlConnection dbCon = new SqlConnection(connectionString);
        dbCon.Open();
        using (dbCon)
        {
            var addNewProdCmd = new SqlCommand(
                "INSERT INTO Products(ProductName) VALUES(@prodName)",
                dbCon);
            addNewProdCmd.Parameters.AddWithValue("@prodName", productName);
            var affectedRows = addNewProdCmd.ExecuteNonQuery();
            Console.WriteLine("Affected rows: " + affectedRows);
        }
    }
}