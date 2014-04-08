// Write a program that reverses the words in given sentence.
// Example: "C# is not C++, not PHP and not Delphi!" -> "Delphi not and PHP, not C++ not is C#!".

using System;
using System.Collections.Generic;
using System.Text;

class ReverseWordsInASentence
{
    static void Main()
    {
        Console.WriteLine("This program reverses the words in given sentence.");
        Console.WriteLine();

        // Read a sentence from the console
        Console.Write("Please, enter a sentence: ");
        string sentence = Console.ReadLine();

        // Declare a StringBuilder. The StringBuilder will hold the reversed sentence
        StringBuilder stringBuilder = new StringBuilder();

        // Extract words one by one starting from the end of the sentence and going backwards
        // Search for whitespaces
        int wordFirstIndex = sentence.LastIndexOf(" ") + 1;
        int wordLastIndex = sentence.Length - 1;
        int lastWord = 0;
        while (wordFirstIndex != -1)
        {
            if (lastWord == 0)
            {
                stringBuilder.Append(sentence.Substring(wordFirstIndex, wordLastIndex - wordFirstIndex));
                lastWord++;
                wordLastIndex = wordFirstIndex - 2;
                wordFirstIndex = sentence.LastIndexOf(" ", wordLastIndex);
            }
            else
            {
                stringBuilder.Append(sentence.Substring(wordFirstIndex, wordLastIndex - wordFirstIndex + 1));
                wordLastIndex = wordFirstIndex - 1;
                wordFirstIndex = sentence.LastIndexOf(" ", wordLastIndex);
            }
        }
        // Append the first word and the punctuation mark in the end
        stringBuilder.Append(" " + sentence.Substring(0, sentence.IndexOf(" ")) + sentence[sentence.Length - 1]);
        stringBuilder.Replace(",", "");

        // Place commas properly
        // Find commas 'whitespace' locations
        List<int> commasWhitespaceIndexArray = new List<int>();
        int whiteSpaceIndex = sentence.IndexOf(" ");
        int whiteSpaceCounter = 0;
        while (whiteSpaceIndex != -1)
        {
            whiteSpaceCounter++;
            if (sentence[whiteSpaceIndex - 1] == ',')
            {
                commasWhitespaceIndexArray.Add(whiteSpaceCounter);
            }
            whiteSpaceIndex = sentence.IndexOf(" ", whiteSpaceIndex + 1);
        }
        // Insert the commas in the correct places
        if (commasWhitespaceIndexArray.Count > 0)
        {
            string temp = stringBuilder.ToString();
            int comma = 0;
            int offset = 0;
            int counter = 0;
            int whiteSpaceIndex2 = temp.IndexOf(" ");
            while (comma < commasWhitespaceIndexArray.Count)
            {
                counter++;
                if (counter == commasWhitespaceIndexArray[comma])
                {
                    stringBuilder.Insert(whiteSpaceIndex2 + offset, ",");
                    comma++;
                    offset++;
                }
                whiteSpaceIndex2 = temp.IndexOf(" ", whiteSpaceIndex2 + 1);
            }
        }
        Console.WriteLine();
        Console.WriteLine("This is the reversed sentence:");
        Console.WriteLine(stringBuilder.ToString());
    }
}