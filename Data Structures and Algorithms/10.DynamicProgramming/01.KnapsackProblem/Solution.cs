using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        Array.Sort(products);
        string format = "{0} W:{1}, C:{2}";
        foreach (var item in products)
        {
            Console.WriteLine(string.Format(format, item.Name, item.Weight, item.Cost));
        }

        // Input:
        // Values (stored in array v)
        // Weights (stored in array w)
        // Number of distinct items (n)
        // Knapsack capacity (W)

        //for j from 0 to W do
        //  m[0, j] := 0
        //end for 
        //for i from 1 to n do
        //  for j from 0 to W do
        //    if w[i] <= j then
        //      m[i, j] := max(m[i-1, j], m[i-1, j-w[i]] + v[i])
        //    else
        //      m[i, j] := m[i-1, j]
        //    end if
        //  end for
        //end for
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