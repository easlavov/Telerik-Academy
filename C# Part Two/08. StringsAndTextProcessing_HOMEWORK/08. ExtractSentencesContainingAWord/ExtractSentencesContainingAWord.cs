// Write a program that extracts from a given text all sentences containing given word.

using System;
using System.Text;

class ExtractSentencesContainingAWord
{
    static void Main()
    {
        Console.WriteLine("This program extracts from a given text all sentences containing a given word.");
        Console.WriteLine("The search is case insensitive!");
        Console.WriteLine();

        // Read a text and a word from the console
        Console.Write("Please, enter a text: ");
        string text = Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine("Please, enter a word to search for in sentences: ");
        string input = Console.ReadLine();
        string word = input.ToLower();

        string sentences = ExtractSentences(text, ref word);

        if (sentences.Length > 0)
        {
            Console.WriteLine("The program found the following sentences: ");
            Console.WriteLine(sentences);
        }
        else
        {
            Console.WriteLine("No sentences contain the word '{0}'.", word);
        }
    }

    private static string ExtractSentences(string text, ref string word)
    {
        string textLowerCase = text.ToLower();
        StringBuilder stringBuilder = new StringBuilder();
        int wordIndex = textLowerCase.IndexOf(word);
        while (wordIndex != -1)
        {
            int startingIndex = wordIndex;
            while (startingIndex >= 0)
            {
                if (textLowerCase[startingIndex] == '.' || textLowerCase[startingIndex] == '?' || textLowerCase[startingIndex] == '!')
                {
                    startingIndex++;
                    break;
                }
                else
                {
                    if (startingIndex == 0)
                    {
                        break;
                    }
                    startingIndex--;
                }
            }

            int endingIndex = startingIndex + 1;
            while (endingIndex < text.Length)
            {
                if (textLowerCase[endingIndex] == '.' || textLowerCase[endingIndex] == '?' || textLowerCase[endingIndex] == '!')
                {
                    break;
                }
                else
                {
                    if (endingIndex == textLowerCase.Length - 1)
                    {
                        break;
                    }
                    endingIndex++;
                }
            }
            if (wordIndex == 0)
            {
                // possible bug for single-word sentences without punctuation mark in the end of the sentece
                if (textLowerCase[wordIndex + word.Length] == ' ' || textLowerCase[wordIndex + word.Length] == '.' ||
                    textLowerCase[wordIndex + word.Length] == '!' || textLowerCase[wordIndex + word.Length] == '?')
                {
                    string sentence = text.Substring(startingIndex, endingIndex - startingIndex + 1);
                    stringBuilder.Append(sentence);
                }
            }
            else if ((wordIndex + word.Length) > textLowerCase.Length - 1)
            {
                if (textLowerCase[wordIndex - 1] == ' ')
                {
                    string sentence = text.Substring(startingIndex, endingIndex - startingIndex + 1);
                    stringBuilder.Append(sentence);
                }
            }
            else
            {
                if ((textLowerCase[wordIndex + word.Length] == ' ' || textLowerCase[wordIndex + word.Length] == '.' ||
                    textLowerCase[wordIndex + word.Length] == '!' || textLowerCase[wordIndex + word.Length] == '?') &&
                    (textLowerCase[wordIndex - 1] == ' '))
                {
                    string sentence = text.Substring(startingIndex, endingIndex - startingIndex + 1);
                    stringBuilder.Append(sentence);
                }
                else
                {
                    wordIndex = textLowerCase.IndexOf(word, wordIndex + 1);
                    continue;
                }
            }

            wordIndex = textLowerCase.IndexOf(word, endingIndex + 1);
        }
        string sentences = stringBuilder.ToString().Trim();
        return sentences;
    }
}