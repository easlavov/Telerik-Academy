// Write a program that downloads a file from Internet (e.g. http://www.devbg.org/img/Logo-BASD.jpg) 
// and stores it the current directory. Find in Google how to download files in C#. Be sure to catch 
// all exceptions and to free any used resources in the finally block.

using System;
using System.Net;

class DownloadAndStoreAFile
{
    static void Main()
    {
        WebClient webClient = new WebClient();
        Console.WriteLine("Enter file url: ");
        string downloadSource = Console.ReadLine();
        Console.WriteLine("Enter destination on local hard drive. Specify file name and extension: ");
        string downloadDestination = Console.ReadLine();
        try
        {
            webClient.DownloadFile(downloadSource, downloadDestination);
        }
        catch (System.Net.WebException)
        {
            Console.WriteLine("Error accessing the network.");
        }
        catch (System.NotSupportedException)
        {
            Console.WriteLine("Method not supported or failed attempt to read, seek or write to a stream.");
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("A null reference cannot be accepted by this method!");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("The path you entered is invalid.");
        }
        finally
        {
            webClient.Dispose();
        }
    }
}