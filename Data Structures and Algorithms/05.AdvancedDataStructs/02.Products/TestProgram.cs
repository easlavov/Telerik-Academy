using System;
using Wintellect.PowerCollections;

class TestProgram
{
    static void Main()
    {
        OrderedBag<Product> bag = new OrderedBag<Product>();
        int numOfProducts = 500000;
        for (int i = 0; i < numOfProducts; i++)
        {
            bag.Add(new Product(((i+5)*0.37m)));
        }

        Console.WriteLine("Bag of products created.");
        
        int searchesCount = 10000;
        for (int i = 0; i < searchesCount; i++)
        {
            var prodsRange = bag.Range(new Product(15), true, new Product(75), true);
        }
    }
}