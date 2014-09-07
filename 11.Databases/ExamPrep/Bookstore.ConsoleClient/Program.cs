namespace Bookstore.ConsoleClient
{
    using Bookstore.Data;
    using Bookstore.Models;
    using Bookstore.XML;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main()
        {
            var bookstore = new BookstoreDbContext();

            string xmlPath = @"..\..\..\complex-books.xml";
            var importer = new XmlImporter(xmlPath, bookstore);
            importer.Import();
        }
    }
}
