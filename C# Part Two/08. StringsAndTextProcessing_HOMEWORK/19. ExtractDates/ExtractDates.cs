// Write a program that extracts from a given text all dates that match the format DD.MM.YYYY. 
// Display them in the standard date format for Canada.

using System;
using System.Collections.Generic;
using System.Globalization;

class ExtractDates
{
    static void Main()
    {
        Console.WriteLine(
            "This program extracts from a given text all dates that match the format DD.MM.YYYY"
            + " and then displays them in the standard date format for Canada.");
        Console.WriteLine();

        // Read input
        string text = "Today is 01.02.2013. Tomorrow will be 02.02.2013. In two weeks the date will be 16.02.2013.";
        DateTime[] dates = ExtractDatesAsArray(text);
        CultureInfo provider = new CultureInfo("en-CA", false);        
        foreach (var date in dates)
        {
            Console.WriteLine("{0}", date.ToString("d", provider));
        }
    }

    private static DateTime[] ExtractDatesAsArray(string text)
    {
        List<DateTime> dates = new List<DateTime>();
        // Loop goes over the whole string looking for parsable date
        string format = "dd.MM.yyyy";
        for (int i = 0; i < text.Length - 10; i++)
        {
            string substring = text.Substring(i, 10);
            CultureInfo provider = new CultureInfo("en-CA");
            // If digit check is not made, parsing will return an invalid date
            if (char.IsDigit(text[i]))
            {
                try
                {
                    DateTime date = DateTime.ParseExact(substring, format, provider);
                    dates.Add(date);
                    i += 9;
                }
                catch (FormatException)
                {
                    continue;
                }
            }
        }
        return dates.ToArray();
    }
}