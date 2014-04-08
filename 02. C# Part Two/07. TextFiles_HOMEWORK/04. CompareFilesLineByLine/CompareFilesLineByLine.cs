// Write a program that compares two text files line by line and prints the number of lines that
// are the same and the number of lines that are different. Assume the files have equal number of lines.

using System;
using System.IO;
using System.Text;

class CompareFilesLineByLine
{
    static void Main(string[] args)
    {
        Console.WriteLine("This program concatenates two text files into another text file.");
        Console.WriteLine();

        // The paths are hard-coded to allow easier testing
        Console.WriteLine("Reading files 'secret.txt' and 'telerik.txt': ");
        var firstFilePath = "..\\..\\secret.txt";
        var secondFilePath = "..\\..\\telerik.txt";        
        // Initialize a StreamReader instance for the first file
        StreamReader readerOne = new StreamReader(firstFilePath, Encoding.GetEncoding("windows-1251"));
        StreamReader readerTwo = new StreamReader(secondFilePath, Encoding.GetEncoding("windows-1251"));
        int numberOfSameLines = 0;
        int numberOfDifferentLines = 0;

        // Compare line by line
        using (readerOne)
        {
            using (readerTwo)
            {
                string firstFileLine = readerOne.ReadLine();
                string secondFileLine = readerTwo.ReadLine();
                while (firstFileLine != null)
                {
                    if (firstFileLine == secondFileLine)
                    {
                        numberOfSameLines++;
                    }
                    else
                    {
                        numberOfDifferentLines++;
                    }
                    firstFileLine = readerOne.ReadLine();
                    secondFileLine = readerTwo.ReadLine();
                }                
            }
        }
        Console.WriteLine("Number of same lines in both files: {0}", numberOfSameLines);
        Console.WriteLine("Number of different lines in both files: {0}", numberOfDifferentLines);
    }
}