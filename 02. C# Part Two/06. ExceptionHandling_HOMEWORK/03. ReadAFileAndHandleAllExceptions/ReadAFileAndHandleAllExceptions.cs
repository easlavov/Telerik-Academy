// Write a program that enters file name along with its full file path (e.g. C:\WINDOWS\win.ini),
// reads its contents and prints it on the console. Find in MSDN how to use System.IO.File.ReadAllText(…).
// Be sure to catch all possible exceptions and print user-friendly error messages.

using System;

class ReadAFileAndHandleAllExceptions
{
    static void Main(string[] args)
    {
        Console.WriteLine("This program reads the content of a file and print it on the console.");
        Console.WriteLine();
        Console.WriteLine("Please, enter below the path to the file:");
        string path = Console.ReadLine();
        // Read the text
        try
        {
            string text = System.IO.File.ReadAllText(path);
            Console.WriteLine(text);
        }        
        catch (ArgumentNullException)
        {
            Console.WriteLine("A null reference cannot be accepted by this method!");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("The path you entered is in incorrect format!");
        }
        catch (System.IO.PathTooLongException)
        {
            Console.WriteLine("The path you entered is longer than the system-defined maximum length!");
        }
        catch (System.IO.DirectoryNotFoundException)
        {
            Console.WriteLine("Part of a file or directory cannot be found!");
        }        
        catch (System.UnauthorizedAccessException)
        {
            Console.WriteLine("Access denied by the OS!");
        }
        catch (System.IO.FileNotFoundException)
        {
            Console.WriteLine("The file doesn't exist!");
        }
        catch (System.IO.IOException)
        {
            Console.WriteLine("An input/output error has occurred!");
        }
        catch (System.NotSupportedException)
        {
            Console.WriteLine("A method that has been invoked is not supported!");
        }
        catch (System.Security.SecurityException)
        {
            Console.WriteLine("Security error detected!");
        }
    }
}