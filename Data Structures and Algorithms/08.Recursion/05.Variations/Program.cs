using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        string[] elements = { "hi", "a", "b" };
        var variations = VariationsGenerator<string>.GenerateVariations(elements, 2);
        PrintVars(variations);
    }

    private static void PrintVars(List<string[]> variations)
    {
        foreach (var variation in variations)
        {
            Console.WriteLine(string.Join(", ", variation));
        }
    }
}