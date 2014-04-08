using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        Console.WriteLine("For n=4 k=2");
        Console.WriteLine("Combinations with duplicates:");
        var combs = CombinationsGenerator.GenerateCombinations(4, 2, false);
        PrintCombs(combs);
        Console.WriteLine("Combinations without duplicates:");
        combs = CombinationsGenerator.GenerateCombinations(4, 2, true);
        PrintCombs(combs);
    }
  
    private static void PrintCombs(List<int[]> combs)
    {
        foreach (var combination in combs)
        {
            foreach (var number in combination)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}