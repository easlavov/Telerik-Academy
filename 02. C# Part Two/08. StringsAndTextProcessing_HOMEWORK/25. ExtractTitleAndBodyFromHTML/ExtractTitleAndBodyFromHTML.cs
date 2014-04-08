// Write a program that extracts from given HTML file its title (if available),
// and its body text without the HTML tags.

using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class ExtractTitleAndBodyFromHTML
{
    static void Main(string[] args)
    {
        Console.WriteLine("This program extracts from given HTML file its title (if available) and its body text without the HTML tags.");
        Console.WriteLine();

        // OPEN HTML FILE
        Console.WriteLine("Please, enter HTML file path. It's content will be extracted as a string.");
        string path = Console.ReadLine();
        StreamReader streamReader = new StreamReader(path);
        // Extract result
        using (streamReader)
        {
            string html = streamReader.ReadToEnd();
            Console.WriteLine(html);
            Console.WriteLine(new string('*', 40));
            Console.WriteLine("The above is the content of the HTML file as a string.");
            Console.WriteLine("Press any key to print title and body ->");
            Console.ReadKey();
            ExtractTitleAndBody(html);
        }
    }

    private static void ExtractTitleAndBody(string html)
    {
        MatchCollection regexCollection = Regex.Matches(html, "</?\\w+((\\s+\\w+(\\s*=\\s*(?:\".*?\"|'.*?'|[^'\">\\s]+))?)+\\s*|\\s*)/?>");
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(html);
        for (int i = 0; i < regexCollection.Count; i++)
        {
            string toRemove = regexCollection[i].ToString();
            stringBuilder.Replace(toRemove, " ");
        }
        //string result = stringBuilder.ToString();        
        //int index = result.IndexOf("  ");
        //while (index != -1)
        //{
        //    stringBuilder.Clear();
        //    stringBuilder.Append(result.Replace("  ", ""));
        //    result = stringBuilder.ToString();
        //    index = result.IndexOf("  ");
        //}
        Console.WriteLine(stringBuilder.ToString());
    }
}