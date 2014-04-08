// Write a program that replaces in a HTML document given as string all the tags
// <a href="…">…</a> with corresponding tags [URL=…]…/URL].

using System;
using System.IO;

class ReplaceTagsInAHTMLDocument
{
    static void Main()
    {
        Console.WriteLine("This program replaces in a HTML document given as string all the tags <a href=\"...\">...</a> with corresponding tags [URL=…]…/URL].");
        Console.WriteLine();

        // OPEN HTML FILE
        Console.WriteLine("Please, enter HTML file path. It's content will be extracted as a string.");
        string path = Console.ReadLine();
        StreamReader streamReader = new StreamReader(path);
        // EDIT HTML FILE
        using (streamReader)
        {
            string html = streamReader.ReadToEnd();
            Console.WriteLine(html);
            Console.WriteLine(new string('*', 40));
            Console.WriteLine("The above is the content of the HTML file as a string.");
            Console.WriteLine("Press any key to print an edited string ->");
            Console.ReadKey();
            string result = EditHtmlString(html);            
            Console.WriteLine(result);
        }
    }

    private static string EditHtmlString(string html)
    {
        string edition1 = html.Replace("<a href=\"", "[URL=");
        string edition2 = edition1.Replace("</a>", "[/URL]");
        string result = edition2.Replace("\">", "]");
        return result;
    }
}