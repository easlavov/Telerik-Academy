// We are given a string containing a list of forbidden words and a text containing some of these words. 
// Write a program that replaces the forbidden words with asterisks.

using System;
using System.Text;

class ReplaceForbiddenWordsWithAsterisks
{
    static void Main()
    {
        Console.WriteLine("This program replaces predefined forbidden words in a text with asterisks.");
        Console.WriteLine();

        // Initialize an array with forbidden words
        string[] forbiddenWords = { "PHP", "CLR", "Microsoft" };
        string[] replacement = new string[forbiddenWords.Length];
        
        for (int i = 0; i < replacement.Length; i++)
        {
            for (int p = 0; p < forbiddenWords[i].Length; p++)
            {
                replacement[i] += '*';
                
            }
        }

        Console.WriteLine();
        // Prompt user the user to enter a text
        Console.WriteLine("Please, enter a text: ");
        string text = Console.ReadLine();
        string result = ReplaceForbiddenWords(text, forbiddenWords, replacement);
        Console.WriteLine(result);
    }
  
    private static string ReplaceForbiddenWords(string text, string[] forbiddenWords, string[] replacement)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(text);
        // Find and replace
        for (int i = 0; i < forbiddenWords.Length; i++)
        {
            sb.Replace(forbiddenWords[i], replacement[i]);          
        }
        string result = sb.ToString();
        return result;
    }
}