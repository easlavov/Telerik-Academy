namespace Cars.ConsoleClient
{
    using Cars.Data;
    using Cars.JsonImporter;
    using Cars.Models;
    using Cars.XmlQueryExecutor;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Client
    {
        private static string path = @"..\..\..\..\Data.Json.Files";
        private static string xmlQueriesPath = @"..\..\..\..\Queries.xml";
        static void Main()
        {
            var carsContext = new CarsDataContext();
            var importer = new Importer(path, carsContext);
            Console.WriteLine("Importing cars and saving to db in batches of 100");
            importer.Import();
            Console.WriteLine("Cars imported");

            Console.WriteLine("PRESS ANY KEY TO EXECUTE XML QUERIES");
            Console.ReadKey();

            var xmlExec = new XmlExecutor(xmlQueriesPath, carsContext);
            xmlExec.Execute();
        }
    }
}
