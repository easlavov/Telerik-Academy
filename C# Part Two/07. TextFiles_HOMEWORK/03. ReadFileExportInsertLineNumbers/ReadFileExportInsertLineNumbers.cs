// Write a program that reads a text file and inserts line numbers in front of each of its lines.
// The result should be written to another text file.

using System;
using System.IO;
using System.Text;

class ReadFileExportInsertLineNumbers
{
    static void Main()
    {
        Console.WriteLine(
            "This program reads a text file and inserts line numbers in front of each" +
            "of its lines and writes the result to another to another text file.");
        Console.WriteLine();

        // The paths are hard-coded to allow easier testing
        Console.WriteLine("Reading file 'secret.txt': ");
        var filePath = "..\\..\\secret.txt";
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
                var lineNumber = 1; // Lines start from 1
                var line = reader.ReadLine();
                while (line != null)
                {
                    writer.WriteLine("{0} {1}", lineNumber, line);
                    lineNumber++;
                    line = reader.ReadLine();
                }
            }
        }
    }
}