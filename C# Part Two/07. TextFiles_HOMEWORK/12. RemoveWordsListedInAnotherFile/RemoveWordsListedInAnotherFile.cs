// Write a program that removes from a text file all words listed in given another text file. 
// Handle all possible exceptions in your methods.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class RemoveWordsListedInAnotherFile
{
    static void Main()
    {
        Console.WriteLine("This program removes from a text file all words listed in given another text file. ");
        Console.WriteLine();

        // Print explanations
        Console.WriteLine("Source files are hard-coded. The content of the word list is:");

        // The paths to both files are hard-coded to allow easier testing
        var wordlistPath = @"..\..\wordlist.txt";
        var sampleTextPath = @"..\..\sampletext.txt";

        // Read word list and add words to a collection
        string[] wordList = ReadWordList(wordlistPath);
        foreach (var word in wordList)
        {
            Console.WriteLine(word);
        }
        Console.WriteLine();

        // Read the text file
        string text = ReadText(sampleTextPath);
        Console.WriteLine("The content of the text file is:");
        Console.WriteLine(text);
        Console.WriteLine();

        // Extract edited text
        string editedText = RemoveListedWords(wordList, text);
        
        // Print the modified text
        Console.WriteLine("This is the modified text:");
        Console.WriteLine(editedText.Trim().Replace("  ", " "));
        Console.WriteLine();

        // Print explanation
        Console.WriteLine("For testing convenience the edited text will only be displayed, not applied.");
        Console.WriteLine("If you want to apply the edited text to a text file, uncomment the last lines of the code in the Main method");

        //Console.WriteLine();
        //Console.WriteLine("Enter where you want the edited text saved: ");
        //Console.Write("Path: ");
        //var newPath = Console.ReadLine();
        //StreamWriter writer = new StreamWriter(newPath);
        //using (writer)
        //{
        //    writer.Write(editedText.Trim().Replace("  ", " "));
        //}
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
            Console.WriteLine("The method ReadText indicates that the directory cannot be found at the specified location!"); // bad
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

    static string RemoveListedWords(string[] words, string text)
    {
        for (int i = 0; i < words.Length; i++)
        {
            text = RemoveWord(words[i], text);
        }
        return text;
    }

    static string RemoveWord(string word, string text)
    {
        try
        {
            string regexPattern = @"\b" + word + @"\b";
            Regex expression = new Regex(regexPattern);
            text = expression.Replace(text, "");
            return text;
        }
        catch (RegexMatchTimeoutException)
        {
            Console.WriteLine("The method RemoveWord indicates a Regex match timeout!");
            throw;
        }
        catch (Exception)
        {
            Console.WriteLine("The method RemoveWord indicates an unspecified exception!");
            throw;
        }
    }
}