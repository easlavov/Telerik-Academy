// You are given a text. Write a program that changes the text in all regions
// surrounded by the tags <upcase> and </upcase> to uppercase. The tags cannot be nested.

using System;
using System.Text;

class CapitalizeTagsSurroundedRegionsInAText
{
    static void Main()
    {
        Console.WriteLine("This porgram changes the text in all regions surrounded by the tags <upcase> and </upcase> to uppercase. The tags cannot be nested.");
        Console.WriteLine();

        string text = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";
        Console.WriteLine("Original text:");
        Console.WriteLine(text);
        Console.WriteLine();
        string editedText = CapitalizeSubstring(text);
        Console.WriteLine("Edited text: ");
        Console.WriteLine(editedText);
    }

    private static string CapitalizeSubstring(string text)
    {
        int startingIndex = text.IndexOf("<upcase>");
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(text);
        while (startingIndex != -1)
        {
            startingIndex += 8;
            int endingIndex = text.IndexOf("</upcase>", startingIndex) - 1;
            string toCapitalize = text.Substring(startingIndex, endingIndex - startingIndex + 1);
            string capitalized = toCapitalize.ToUpper();

            stringBuilder.Replace(toCapitalize, capitalized, startingIndex, endingIndex - startingIndex + 1);
            startingIndex = text.IndexOf("<upcase>", endingIndex);
        }
        stringBuilder.Replace("<upcase>", "");
        stringBuilder.Replace("</upcase>", "");
        string editedText = stringBuilder.ToString();
        return editedText;
    }
}
