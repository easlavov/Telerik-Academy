// Write a program that extracts from given XML file all the text without the tags.

using System;
using System.IO;
using System.Text;

class ExtractTextFromXML
{
    static void Main()
    {
        Console.WriteLine("This program extracts from given XML file all the text without the tags.");
        Console.WriteLine();

        // Path is hard-coded to allow easier testing
        var path = @"..\..\sample.xml";

        // Open reading stream
        StreamReader reader = new StreamReader(path);
        StringBuilder sbuilder = new StringBuilder();
        using (reader)
        {
            // Read content of the xml file
            var text = reader.ReadToEnd();

            // Text is found between > and < tags
            for (int i = 0; i < text.Length - 1; i++)
            {
                // Find first and last index of the substring to be extracted
                if (text[i] == '>' && text[i + 1] != '<')
                {
                    int textFirstIndex = i + 1;
                    // Handle border case
                    if (textFirstIndex == text.Length - 1)
                    {
                        sbuilder.Append(text.Substring(textFirstIndex,1));
                        break;
                    }
                    int textLastIndex = text.IndexOf('<', textFirstIndex + 1);
                    // Extract substring
                    sbuilder.Append(text.Substring(textFirstIndex, textLastIndex - textFirstIndex) + " ");
                    i = textLastIndex;
                }
            }
            // Print result
            Console.WriteLine("This is the extracted text:");
            Console.WriteLine(sbuilder.ToString());
        }
    }
}