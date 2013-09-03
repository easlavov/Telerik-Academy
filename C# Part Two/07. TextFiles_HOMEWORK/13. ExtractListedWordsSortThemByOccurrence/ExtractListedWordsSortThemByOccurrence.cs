// Write a program that reads a list of words from a file words.txt and finds how many times
// each of the words is contained in another file test.txt. The result should be written in the 
// file result.txt and the words should be sorted by the number of their occurrences in descending order.
// Handle all possible exceptions in your methods.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class ExtractListedWordsSortThemByOccurrence
{
    static void Main()
    {
        Console.WriteLine("This program reads a list of words from a file words.txt and finds how many times " +
            "each of the words is contained in another file test.txt. The result will be written in the " +
            "file result.txt and the words will be sorted by the number of their occurrences in descending order.");
        Console.WriteLine();

        // Some paths are hard-coded to allow easier testing
        Console.WriteLine("Source files are hard-coded on purpose.");
        Console.WriteLine();
        var wordListPath = @"..\..\words.txt";
        var textPath = @"..\..\test.txt";

        // Read output file path
        Console.Write("Please, enter output file path: ");
        var output = Console.ReadLine();

        // Extract list of words
        string[] wordList = ReadWordList(wordListPath);

        // Extract text case insensitive
        string text = ReadText(textPath).ToLower();

        // Count words
        string[] wordCount = CountListedWords(wordList,text); // returns ascending list

        // Export list
        ExportToFile(output, wordCount);
    }
  
    private static void ExportToFile(string output, string[] wordCount)
    {
        try
        {
            StreamWriter writer = new StreamWriter(output);
            using (writer)
            {
                for (int i = wordCount.Length - 1; i >= 0; i--)
                {
                    writer.WriteLine(wordCount[i]);
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("The method ExportToFile indicates that the file cannot be found at the specified location!");
            throw;
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("The method ExportToFile indicates that the directory cannot be found at the specified location!");
            throw;
        }
        catch (IOException)
        {
            Console.WriteLine("The method ExportToFile indicates that an IO error has occurred!");
            throw;
        }
        catch (Exception)
        {
            Console.WriteLine("The method ExportToFile indicates an unspecified exception!");
            throw;
        }        
    }

    static string[] ReadWordList(string path)
    {
        try
        {
            List<string> wordList = new List<string>();
            StreamReader reader = new StreamReader(path);
            using (reader)
            {
                string word = reader.ReadLine();
                while (word != null)
                {
                    wordList.Add(word);
                    word = reader.ReadLine();
                }
            }
            return wordList.ToArray();
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("The method ReadWordList indicates that the file cannot be found at the specified location!");
            throw;
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("The method ReadWordList indicates that the directory cannot be found at the specified location!");
            throw;
        }
        catch (IOException)
        {
            Console.WriteLine("The method ReadWordList indicates that an IO error has occurred!");
            throw;
        }
        catch (Exception)
        {
            Console.WriteLine("The method ReadWordList indicates an unspecified exception!");
            throw;
        }
    }

    static string ReadText(string path)
    {
        try
        {
            string text;
            StreamReader reader = new StreamReader(path);
            using (reader)
            {
                text = reader.ReadToEnd();
            }
            return text;
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("The method ReadText indicates that the file cannot be found at the specified location!");
            throw;
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("The method ReadText indicates that the directory cannot be found at the specified location!"); 
            throw;
        }
        catch (IOException)
        {
            Console.WriteLine("The method ReadText indicates that an IO error has occurred");
            throw;
        }
        catch (Exception)
        {
            Console.WriteLine("The method ReadText indicates an unspecified exception!");
            throw;
        }
    }

    static string[] CountListedWords(string[] words, string text)
    {
        try
        {
            List<string> wordCount = new List<string>();
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                string regexPattern = @"\b" + word + @"\b";
                Regex expression = new Regex(regexPattern);
                MatchCollection totalWords = expression.Matches(text);
                int count = totalWords.Count;
                wordCount.Add(count + " - " + word);
            }
            string[] result = wordCount.ToArray();
            Array.Sort(result);
            return result;
        }
        catch (RegexMatchTimeoutException)
        {
            Console.WriteLine("The method CountListedWords indicates a Regex match timeout!");
            throw;
        }
        catch (Exception)
        {
            Console.WriteLine("The method CountListedWords indicates an unspecified exception!");
            throw;
        }
    }
}