// Write a program that reads a list of words, separated by spaces and prints the list in an alphabetical order.

using System;
using System.Text.RegularExpressions;

class ReadAListOfWordsExtractAndPrintInAlphOrder
{
    static void Main()
    {
        Console.WriteLine("This program reads a list of words, separated by spaces and prints the list in an alphabetical order.");
        Console.WriteLine();

        // Initialize a list of words
        string sampleList = "power city football zoo castle fraternity escape adventure";
        Console.WriteLine("The list is: {0}", sampleList);
        Console.WriteLine();
        // Extract words and print them
        Console.WriteLine("The list of words in alphabetical order is:");
        Console.WriteLine();
        ExtractAndPrintInWordsInAlphOrder(sampleList);
    }

    private static void ExtractAndPrintInWordsInAlphOrder(string sampleList)
    {
        // Extract words
        MatchCollection regexCollection = Regex.Matches(sampleList, @"[\S]+");

        // Print words
        string[] wordList = new string[regexCollection.Count];
        for (int i = 0; i < wordList.Length; i++)
        {
            wordList[i] = regexCollection[i].ToString();
        }
        Array.Sort(wordList);
        foreach (var word in wordList)
        {
            Console.WriteLine(word);
        }
    }
}