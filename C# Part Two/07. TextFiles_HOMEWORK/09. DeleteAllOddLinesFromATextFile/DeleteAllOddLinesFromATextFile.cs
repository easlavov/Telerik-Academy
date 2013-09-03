// Write a program that deletes from given text file all odd lines. The result should be in the same file.

using System;
using System.IO;
using System.Text;

class DeleteAllOddLinesFromATextFile
{
    static void Main()
    {
        Console.WriteLine("This program deletes from given text file all odd lines.");
        Console.WriteLine();

        // Some paths may be hard-coded to allow easier testing
        Console.WriteLine("Please, enter path to a txt file: ");
        var output = Console.ReadLine();

        StreamReader reader = new StreamReader(output, Encoding.GetEncoding("windows-1251"));
        StringBuilder builder = new StringBuilder();
        using (reader)
        {
            int lineNumber = 1;
            var line = reader.ReadLine();
            while (line != null)
            {
                if (lineNumber % 2 == 0)
                {
                    builder.AppendLine(line);
                }
                lineNumber++;
                line = reader.ReadLine();
            }
        }
        Console.WriteLine();
        StreamWriter writer = new StreamWriter(output);
        using (writer)
        {
            writer.Write(builder);
        }
        Console.WriteLine("Odd lines have been removed.");
    }
}