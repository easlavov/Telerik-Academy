// Write a program that reads a text file containing a list of strings, sorts them and saves them to another text file.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class ReadListOfStringsExportSortSave
{
    static void Main()
    {
        Console.WriteLine(
            "This program reads a text file and inserts line numbers in front of each" +
            "of its lines and writes the result to another to another text file.");
        Console.WriteLine();

        // The paths are hard-coded to allow easier testing
        Console.WriteLine("Reading file 'secret.txt': ");
        var filePath = "..\\..\\names.txt";
        Console.WriteLine("Please, enter path to a txt file which will keep the output file.");
        var output = Console.ReadLine();
        // Initialize a StreamWriter instance for the output file
        StreamWriter writer = new StreamWriter(output);
        // Initialize a StreamReader instance for the source file
        StreamReader reader = new StreamReader(filePath, Encoding.GetEncoding("windows-1251"));

        using (reader)
        {
            using (writer)
            {
                // Extract
                List<string> export = new List<string>();
                var line = reader.ReadLine();
                while (line != null)
                {
                    export.Add(line);
                    line = reader.ReadLine();
                }

                // Sort
                export.Sort();

                // Export sorted strings to output file
                for (int i = 0; i < export.Count; i++)
                {
                    writer.WriteLine(export[i]);
                }
            }
        }
    }
}