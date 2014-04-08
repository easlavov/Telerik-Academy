// Write a program that replaces all occurrences of the substring "start" with the substring
// "finish" in a text file. Ensure it will work with large files (e.g. 100 MB).

using System;
using System.IO;
using System.Text;

class ReplaceStartWithFinishInATextFile
{
    static void Main()
    {
        Console.WriteLine("This program replaces all occurrences of the substring \"start\" with the substring \"finish\" in a text file.");
        Console.WriteLine("IMPORTANT: If you want to create a 100 MB text file, uncomment the code bellow!!!");
        Console.WriteLine();


        // The paths are hard-coded to allow easier testing
        Console.WriteLine("Please, enter path to a txt file OR edit the code to create a 100 MB txt file then rerun the program: ");
        var output = @"D:\Downloads\bigfile.txt";

        //// OPTIONAL:
        //// Create a 100 MB text file
        //StreamWriter writer = new StreamWriter(output);
        //using (writer)
        //{
        //    for (int i = 0; i < 18000000; i++)
        //    {
        //        writer.Write("start ");
        //    }
        //}

        StreamReader reader = new StreamReader(output, Encoding.GetEncoding("windows-1251"));
        StringBuilder builder = new StringBuilder();
        using (reader)
        {
            // Replace substrings
            builder.Append(reader.ReadToEnd());
            builder.Replace("start", "finish");
            
        }
        StreamWriter writerTwo = new StreamWriter(output);
        using (writerTwo)
        {
            // Export the htext with the replaced substrings
            writerTwo.Write(builder.ToString());
        }
    }
}