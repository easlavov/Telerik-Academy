using System;
using System.IO;

class TraverseCWindows
{
    static void Main()
    {
        string winRoot = @"C:\Windows";
        string searchItem = "*.exe";
        PrintExes(winRoot, searchItem);
    }
  
    private static void PrintExes(string directory, string searchItem)
    {
        try
        {
            var files = Directory.GetFiles(directory, searchItem);
            foreach (var file in files)
            {
                int index = file.LastIndexOf('\\') + 1;
                string fileName = file.Substring(index, file.Length - index);
                Console.WriteLine(fileName);
            }

            var dirs = Directory.GetDirectories(directory);
            foreach (var dir in dirs)
            {
                PrintExes(dir, searchItem);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}