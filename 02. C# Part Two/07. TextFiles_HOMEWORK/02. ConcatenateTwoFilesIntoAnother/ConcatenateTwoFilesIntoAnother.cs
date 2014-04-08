// Write a program that concatenates two text files into another text file.

using System;
using System.IO;
using System.Text;

class ConcatenateTwoFilesIntoAnother
{
    static void Main()
    {
        Console.WriteLine("This program concatenates two text files into another text file.");
        Console.WriteLine();

        // The paths are hard-coded to allow easier testing
        Console.WriteLine("Reading files 'secret.txt' and 'telerik.txt': ");
        var firstFilePath = "..\\..\\secret.txt";
        var secondFilePath = "..\\..\\telerik.txt";
        Console.WriteLine("Please, enter path to a txt file which will keep the concatenated source files.");
        var output = Console.ReadLine();
        // Initialize a StreamWriter instance for the output file
        StreamWriter writer = new StreamWriter(output);
        // Initialize a StreamReader instance for the first file
        StreamReader readerOne = new StreamReader(firstFilePath, Encoding.GetEncoding("windows-1251"));
        StreamReader readerTwo = new StreamReader(secondFilePath, Encoding.GetEncoding("windows-1251"));

        using (writer)
        {
            using (readerOne)
            {
                var line = readerOne.ReadToEnd();
                writer.WriteLine(line);
            }

            using (readerTwo)
            {
                var line = readerTwo.ReadToEnd();
                writer.WriteLine(line);
            }
        }
    }
}