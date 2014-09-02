using SQLiteTutorial.Data;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteTutorial.ConsoleClient
{
    class ConsoleClient
    {
        static void Main()
        {
            //string connString = @"Data Source=D:\Downloads\SqLiteTutorial\Databases\Students.db;Version=3;";
            //SQLiteConnection dbConn = new SQLiteConnection(connString);
            //dbConn.Open();
            //using (dbConn)
            //{
            //    string query = "select * from Students";
            //    var command = new SQLiteCommand(query, dbConn);
            //    var result = command.ExecuteReader();

            //    using (result)
            //    {
            //        while (result.Read())
            //        {
            //            string firstName = (string)result["FirstName"];
            //            string lastName = (string)result["LastName"];
            //            //string courseId = (string)result["CourseID"];
            //            Console.WriteLine("{0} {1}", firstName, lastName);
            //        }
            //    }
            //}

            var context = new StudentsDdContext();
            var st = context.Students.First();
            Console.WriteLine(st.FirstName);
        }
    }
}
