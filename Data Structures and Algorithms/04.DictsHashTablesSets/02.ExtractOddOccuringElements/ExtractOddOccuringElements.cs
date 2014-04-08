/*Write a program that extracts from a given sequence of strings all elements that present in it odd number of times.*/

using System;
using System.Collections.Generic;

class ExtractOddOccuringElements
{
    static void Main()
    {
        string[] testSequence1 = { "Pesho", "Gosho", "Pesho", "Gosho", "Gosho", "Mimi" };
        string[] testSequence2 = { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };
        PrintOddElements(testSequence1);
        PrintOddElements(testSequence2);
    }

    private static void PrintOddElements(ICollection<string> sequence)
    {
        Console.WriteLine("The original collections is: ");
        PrintCollection<string>(sequence);
        ICollection<string> occurences = ExtractOddElements(sequence);
        Console.WriteLine("The odd occuring strings are: ");
        PrintCollection<string>(occurences);
    }

    private static ICollection<string> ExtractOddElements(ICollection<string> sequence)
    {
        // Extract all strings from the collection and count their occurences
        IDictionary<string, int> extractedStrings = new Dictionary<string, int>();
        foreach (var str in sequence)
        {
            if (!extractedStrings.ContainsKey(str))
            {
                extractedStrings[str] = 1;
            }
            else
            {
                extractedStrings[str]++;
            }
        }

        // Put all odd occuring strings in a new List<string>
        ICollection<string> oddStrings = new List<string>();
        foreach (var str in extractedStrings)
        {
            if (str.Value % 2 != 0)
            {
                oddStrings.Add(str.Key);
            }
        }

        return oddStrings;
    }

    private static void PrintCollection<T>(ICollection<T> collection)
    {
        Console.WriteLine(string.Join(", ", collection));
        Console.WriteLine();
    }
}