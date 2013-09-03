// Write a program that reads a text file and prints on the console its odd lines.

using System;
using System.IO;
using System.Text;

class PrintOddLinesOfATextFile
{
    static void Main()
    {
        Console.WriteLine("This program reads a text file and prints on the console its odd lines.");
        Console.WriteLine();

        // The path is hard-coded to allow easier testing
        Console.WriteLine("Reading file 'secret.txt': ");
        var path = "..\\..\\secret.txt";
        // Initialize a StreamReader instance
        StreamReader streamReader = new StreamReader(path, Encoding.GetEncoding("windows-1251"));
        using (streamReader)
        {            
            var lineNumber = 1; // Lines start from 1
            var line = streamReader.ReadLine();
            while (line != null)
            {
                // Print only odd lines
                if (lineNumber % 2 != 0)
                {
                    Console.WriteLine("Line {0}: {1}", lineNumber, line);
                }
                lineNumber++;
                line = streamReader.ReadLine();
            }
        }
    }
}