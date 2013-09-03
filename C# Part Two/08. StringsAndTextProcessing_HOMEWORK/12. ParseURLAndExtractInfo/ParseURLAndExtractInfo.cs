/*Write a program that parses an URL address given in the format: [protocol]://[server]/[resource]
 and extracts from it the [protocol], [server] and [resource] elements. 
 For example from the URL http://www.devbg.org/forum/index.php the following information should be extracted:
 [protocol] = "http"
 [server] = "www.devbg.org"
 [resource] = "/forum/index.php"
 */
using System;

class ParseURLAndExtractInfo
{
    static void Main()
    {
        Console.WriteLine("This program parses an URL address given in the format: [protocol]://[server]/[resource] and extracts from it the [protocol], [server] and [resource] elements.");
        Console.WriteLine();

        // Read URL from the console
        Console.Write("Please, enter URL: ");
        string url = Console.ReadLine();

        // Extract and print
        PrintUrlProtServRes(url);
    }
  
    private static void PrintUrlProtServRes(string url)
    {
        // Get and print protocol
        int colonIndex = url.IndexOf(":");
        Console.WriteLine("[protocol] = {0}", url.Substring(0, colonIndex));

        // Get and print server
        int serverStartIndex = colonIndex + 3;
        int serverEndIndex = url.IndexOf("/", serverStartIndex) - 1;
        Console.WriteLine("[server] = {0}", url.Substring(serverStartIndex, serverEndIndex - serverStartIndex + 1));

        // Get and print resource
        int resourceStartIndex = serverEndIndex + 1;
        Console.WriteLine("[resource] = {0}", url.Substring(resourceStartIndex, url.Length - resourceStartIndex));
    }
}