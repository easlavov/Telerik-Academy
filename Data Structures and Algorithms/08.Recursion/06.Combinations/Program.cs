using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] elements = { "test", "rock", "fun" };
        var combinations = CombinationsGenerator.GenerateCombinations(elements, 2);
        PrintVars(combinations);
    }

    private static void PrintVars(List<string[]> combinations)
    {
        foreach (var comb in combinations)
        {
            Console.WriteLine(string.Join(", ", comb));
        }
    }
}