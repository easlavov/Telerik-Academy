// Write a program that reads a string from the console and prints all different letters 
// in the string along with information how many times each letter is found. 

using System;
using System.Collections.Generic;
using System.Text;

class ExtractLettersAndTheirCountInAString
{
    static void Main()
    {
        Console.WriteLine("This program reads a string from the console and prints all different letters " +
            "in the string along with information how many times each letter is found. ");
        Console.WriteLine();

        // Read string from the console
        Console.Write("Enter string: ");
        string text = Console.ReadLine();
        string[] result = ExtractLettersCount(text);
        foreach (var letter in result)
        {
            Console.WriteLine(letter);
        }
    }

    private static string[] ExtractLettersCount(string text)
    {
        List<string> result = new List<string>();
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(text.ToLower());
        // Go over the whole string
        for (int i = 0; i < stringBuilder.Length; i++)
        {
            // A letter is found
            if (char.IsLetter(stringBuilder[i]))
            {
                int letterCount = 1;
                char letter = stringBuilder[i];
                // Start counting
                for (int p = i + 1; p < stringBuilder.Length; p++)
                {
                    if (stringBuilder[p] == letter)
                    {
                        letterCount++;
                    }
                }
                // Add letter and its count to the result string array
                string toAdd = ("Letter " + letter + " appears " + letterCount + " time(s)");
                result.Add(toAdd);
                // Remove all counted letters from the string builder
                stringBuilder.Replace(letter.ToString(), "0");
            }
        }
        return result.ToArray();
    }
}