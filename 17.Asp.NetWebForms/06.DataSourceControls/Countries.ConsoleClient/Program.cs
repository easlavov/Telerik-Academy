using Countries.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Countries.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ICountriesData countriesData = new CountriesData(CountriesDbContext.Create());
            var conts = countriesData.Continents.All();
            Console.WriteLine(conts);
            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
