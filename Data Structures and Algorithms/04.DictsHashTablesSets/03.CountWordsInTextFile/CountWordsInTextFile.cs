/*Write a program that counts how many times each word from given text file words.txt appears in it. The character casing differences should be ignored. The result words should be ordered by their number of occurrences in the text.*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class CountWordsInTextFile
{
    static void Main()
    {
        Console.BufferHeight += 20;
        string testFilePath = "..\\..\\test.txt";
        PrintWords(testFilePath);
    }

    private static void PrintWords(string filePath)
    {
        // Extract text from file
        string text = ExtractText(filePath);

        // Print text to console
        Console.WriteLine("The text is the following:");
        Console.WriteLine(text);

        // Extract words from text
        string[] words = ExtractWords(text.ToLower());

        // Count words
        IDictionary<string, int> dict = CountWords(words);

        // Order pairs by value
        var ordered = dict.OrderBy(word => word.Value);

        // Print words
        PrintWords(ordered);
    }

    private static void PrintWords(IOrderedEnumerable<KeyValuePair<string, int>> ordered)
    {
        // Print words
        Console.WriteLine("The words are the following:");
        foreach (var word in ordered)
        {
            Console.WriteLine("{0} -> {1} time(s)", word.Key, word.Value);
        }
    }
  
    private static string[] ExtractWords(string text)
    {
        // Extract words from text
        char[] separators = { ' ', ',', '.', '!', '?', ':' };
        string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        return words;
    }
  
    private static string ExtractText(string filePath)
    {
        // Extract text from file
        string text = string.Empty;
        try
        {            
            StreamReader sr = new StreamReader(filePath);
            using (sr)
            {
                text = sr.ReadToEnd();
            }            
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        return text;
    }
  
    private static IDictionary<string, int> CountWords(string[] words)
    {
        IDictionary<string, int> dict = new Dictionary<string, int>();
        try
        {
            foreach (var item in words)
            {
                if (!dict.ContainsKey(item))
                {
                    dict[item] = 1;
                }
                else
                {
                    dict[item]++;
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
        return dict;
    }
}