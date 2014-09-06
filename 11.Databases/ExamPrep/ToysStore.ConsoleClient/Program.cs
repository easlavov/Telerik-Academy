using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToysStore.Seeder;

namespace ToysStore.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ManufacturerGenerator gen = new ManufacturerGenerator();
            var coll = gen.GetGeneratedItems(100);
            foreach (var item in coll)
            {
                Console.WriteLine(item.Country);
            }
        }
    }
}
