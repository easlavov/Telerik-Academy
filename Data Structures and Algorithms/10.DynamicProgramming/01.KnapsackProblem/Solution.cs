using System;
using System.Collections.Generic;

class Solution
{
    static void Main()
    {
        Product[] products =
        {
            new Product { Name = "beer", Weight = 3, Cost = 2 },
            new Product { Name = "vodka", Weight = 8, Cost = 12 },
            new Product { Name = "cheese", Weight = 4, Cost = 5 },
            new Product { Name = "nuts", Weight = 1, Cost = 4 },
            new Product { Name = "ham", Weight = 2, Cost = 3 },
            new Product { Name = "whiskey", Weight = 8, Cost = 13 },
        };

        var knapsackContent = SolveKnapsackProblem(products, 10);
        foreach (var product in knapsackContent)
        {
            Console.WriteLine("{0}, Cost: {1}", product.Name, product.Cost);
        }
    }

    public static List<Product> SolveKnapsackProblem(IList<Product> products, int capacity)
    {
        if (capacity == 0)
            return new List<Product>();

        if (products.Count == 0)
            return new List<Product>();

        int[,] valuesArray = new int[products.Count, capacity + 1];

        int[,] keepArray = new int[products.Count, capacity + 1];

        for (int x = 0; x <= products.Count - 1; x++)
        {
            valuesArray[x, 0] = 0;
            keepArray[x, 0] = 0;
        }

        for (int y = 1; y <= capacity; y++)
        {
            if (products[0].Weight <= y)
            {
                valuesArray[0, y] = products[0].Cost;
                keepArray[0, y] = 1;
            }
            else
            {
                valuesArray[0, y] = 0;
                keepArray[0, y] = 0;
            }
        }

        for (int x = 0; x <= products.Count - 2; x++)
        {
            for (int y = 1; y <= capacity; y++)
            {
                var currentItem = products[x + 1];

                if (currentItem.Weight > y)
                {
                    valuesArray[x + 1, y] = valuesArray[x, y];
                    continue;
                }

                int valueWhenDropping = valuesArray[x, y];
                int valueWhenTaking = valuesArray[x, y - currentItem.Weight] + currentItem.Cost;

                if (valueWhenTaking > valueWhenDropping)
                {
                    valuesArray[x + 1, y] = valueWhenTaking;
                    keepArray[x + 1, y] = 1;
                }
                else
                {
                    valuesArray[x + 1, y] = valueWhenDropping;
                    keepArray[x + 1, y] = 0;
                }
            }
        }

        var knapsack = new List<Product>();
        {
            int remainingSpace = capacity;
            int product = products.Count - 1;

            while (product >= 0 && remainingSpace >= 0)
            {
                if (keepArray[product, remainingSpace] == 1)
                {
                    knapsack.Add(products[product]);
                    remainingSpace -= products[product].Weight;
                    product -= 1;
                }
                else
                {
                    product -= 1;
                }
            }
        }

        return knapsack;
    }
}

class Product : IComparable
{
    public string Name { get; set; }

    public int Weight { get; set; }

    public int Cost { get; set; }

    public int CompareTo(object obj)
    {
        Product obj2 = obj as Product;
        if (this.Weight > obj2.Weight)
        {
            return 1;
        }
        else if (this.Weight < obj2.Weight)
        {
            return -1;
        }

        return 0;
    }
}