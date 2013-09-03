// Write a program that deletes from a text file all words that start with the prefix "test".
// Words contain only the symbols 0...9, a...z, A…Z, _.

using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class DeleteAllWordsWithPrefixTest
{
    static void Main()
    {
        Console.WriteLine("This program deletes from a text file all words that start with the prefix \"test\".");
        Console.WriteLine();

        // Ask the user to enter the path to the file
        Console.WriteLine("A sample file has been hard-coded. Its content is displayed bellow:");
        var path = @"..\..\sample.txt";

        // Read the file content and extract it
        StreamReader reader = new StreamReader(path);
        string text;
        using (reader)
        {
            // Extract the content of the text file
            text = reader.ReadToEnd();
            Console.WriteLine(text);
            Console.WriteLine();
        }

        // Delete all words with the prefix 'test' in the extracted text
        StringBuilder sbuilder = new StringBuilder();
        Regex expression = new Regex(@"\btest[A-Za-z0-9-]+\w");
        sbuilder.Append(expression.Replace(text, ""));
        sbuilder.Replace("  ", "");
        Console.WriteLine("For testing convenience the edited text will only be displayed, not applied.");
        Console.WriteLine("If you want to apply the edited text to a text file, uncomment the last lines of the code");
        Console.WriteLine();
        Console.WriteLine("Edited text bellow: ");
        Console.WriteLine(sbuilder.ToString().Trim());

        //Console.WriteLine();
        //Console.WriteLine("Enter where you want the edited text saved: ");
        //Console.Write("Path: ");
        //var newPath = Console.ReadLine();
        //StreamWriter writer = new StreamWriter(newPath);
        //using (writer)
        //{
        //    writer.Write(sbuilder.ToString().Trim());
        //}
    }
}