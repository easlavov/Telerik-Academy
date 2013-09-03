// Write a program that reads a string from the console and lists all different 
// words in the string along with information how many times each word is found.

using System;
using System.Collections.Generic;
using System.Text;

class ExtractWordsAndTheirCountInAString
{
    static void Main()
    {
        Console.WriteLine("This program reads a string from the console and lists all different words in the string along with information how many times each word is found.");
        Console.WriteLine();

        // Read string from the console
        Console.Write("Please, enter a text: ");
        string text = Console.ReadLine();
        // Call method
        string[] result = ExtractWordsAndTheirCount(text);
        // Print result
        foreach (var word in result)
        {
            Console.WriteLine(word);
        }
    }

    private static string[] ExtractWordsAndTheirCount(string text)
    {
        List<string> result = new List<string>();
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(text.ToLower());
        // Go over the whole text
        for (int i = 0; i < stringBuilder.Length; i++)
        {
            // Find a word
            if (char.IsLetter(stringBuilder[i]))
            {
                // Initialize the word's first index in the text
                int wordFirstIndex = i;
                for (int p = i + 1; p < stringBuilder.Length; p++)
                {
                    // Find and initialize the word's last index in the text
                    if (char.IsLetter(stringBuilder[p]) == false)
                    {
                        int wordLastIndex = p - 1;
                        // Extract the word
                        string word = stringBuilder.ToString(wordFirstIndex, wordLastIndex - wordFirstIndex + 1);
                        // Scan text for the word
                        int wordCount = 0;
                        string textTemp = stringBuilder.ToString();
                        int wordIndex = textTemp.IndexOf(word);
                        while (wordIndex != -1)
                        {
                            wordCount++;
                            wordIndex = textTemp.IndexOf(word, wordIndex + 1);
                        }
                        // Add word and it's appearances count to the result list
                        result.Add(word + " appears " + wordCount + " time(s)");
                        // Remove word from text
                        stringBuilder.Replace(word, "");
                        // Start searching for a new word
                        break;
                    }
                }
            }
        }
        return result.ToArray();
    }
}