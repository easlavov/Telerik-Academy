using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        Console.Write("Please, enter N: ");
        int number = int.Parse(Console.ReadLine());
        var permutations = PermutationsGenerator.GeneratePermutations(number);
        PrintPerms(permutations);
    }
  
    private static void PrintPerms(List<int[]> permutations)
    {
        foreach (var permut in permutations)
        {
            Console.WriteLine(string.Join(", ", permut));
        }
    }
}