using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

class TestProgram
{
    static void Main()
    {
        OrderedBag<Product> products = new OrderedBag<Product>();
        
        for (int i = 0; i < 2000000; i++)
        {
            products.Add(new Product(((i + 5) * 0.37m)));
        }

        int searchesCount = 10000;
        for (int i = 0; i < searchesCount; i++)
        {
            var prodsRange = products.Range(new Product(15), true, new Product(75), true);
        }
    }
}