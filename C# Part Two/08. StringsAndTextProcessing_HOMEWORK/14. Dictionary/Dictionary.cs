// A dictionary is stored as a sequence of text lines containing words and their explanations.
// Write a program that enters a word and translates it by using the dictionary. 

using System;

class Dictionary
{
    static void Main()
    {
        Console.WriteLine("This program translates a word by using a dictionary.");
        Console.WriteLine();

        // Initialize a sample dictionary
        string dictionary = ".NET – platform for applications from Microsoft CLR – managed execution environment for .NET namespace – hierarchical organization of classes";

        // Read a word from the console
        Console.Write("Please, enter a word: ");
        string word = Console.ReadLine();

        // Find and print word explanation
        string wordToFind = word + " –";        
        int wordStartIndex = dictionary.IndexOf(wordToFind);
        if (wordStartIndex != -1)
        {
            int firstDashIndex = dictionary.IndexOf("–", wordStartIndex);
            int nextDashIndex = dictionary.IndexOf(" –", firstDashIndex + 1);
            if (nextDashIndex == -1)
            {
                nextDashIndex = dictionary.Length;
            }
            int lastWhiteSpace = dictionary.LastIndexOf(" ", nextDashIndex - 1);
            if (nextDashIndex == dictionary.Length)
            {
                lastWhiteSpace = dictionary.Length - 1;
            }
            string explanation = dictionary.Substring(wordStartIndex, lastWhiteSpace - wordStartIndex + 1);

            Console.WriteLine(explanation);
        }
        else
        {
            Console.WriteLine("Word not found in dictionary.");
        }        
    }
}