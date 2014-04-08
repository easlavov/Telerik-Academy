// Modify the solution of the previous problem to replace only whole words (not substrings).

using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class ReplaceOnlyWholeWords
{
    static void Main()
    {
        Console.WriteLine("This program replaces all occurrences of the word \"start\" with the word \"finish\" in a text file.");
        Console.WriteLine();

        Console.WriteLine("IMPORTANT: If you want to create a 100 MB text file, uncomment the code bellow!!!");
        Console.WriteLine();


        // The paths are hard-coded to allow easier testing
        Console.WriteLine("Please, enter path to a txt file OR edit the code to create a 100 MB txt file then rerun the program: ");
        var output = @"D:\Downloads\test.txt";        

        //// OPTIONAL:
        //// Create a 100 MB text file
        //StreamWriter writer = new StreamWriter(output);
        //using (writer)        
        //{
        //    for (int i = 0; i < 3600000; i++)
        //    {
        //        writer.Write("startstart start startstart");
        //    }            
        //}

        StreamReader reader = new StreamReader(output, Encoding.GetEncoding("windows-1251"));
        StringBuilder builder = new StringBuilder();
        using (reader)
        {
            // Replace words
            //builder.Append(reader.ReadToEnd());
            //builder.Replace("start", "finish");
            Regex expression = new Regex(@"\bstart\b");
            string edit = expression.Replace(reader.ReadToEnd(), "finish");
            builder.Append(edit);
        }
        
        StreamWriter writerTwo = new StreamWriter(output);
        using (writerTwo)
        {
            // Export the text with the replaced words
            writerTwo.Write(builder.ToString());
        }
    }
}