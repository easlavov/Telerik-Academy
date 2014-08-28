//Create an Excel file with 2 columns: name and score: 
//Write a program that reads your MS Excel file 
//through the OLE DB data provider and displays the 
//name and score row by row.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

class TestProgram
{
    static void Main()
    {        

        OleDbConnection dbCon = new OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;Data Source='..\\..\\scoreBoard.xls';Extended Properties=Excel 8.0;");
        dbCon.Open();
        using (dbCon)
        {
            OleDbCommand myCommand = new OleDbCommand("select * from [Sheet1$]", dbCon);            
            OleDbDataReader reader = myCommand.ExecuteReader();
            while (reader.Read())
            {
                string name = (string)reader["Name"];
                double score = (double)reader["Score"];
                Console.WriteLine("{0} - {1}", name, score);
            }
        }        
    }
}