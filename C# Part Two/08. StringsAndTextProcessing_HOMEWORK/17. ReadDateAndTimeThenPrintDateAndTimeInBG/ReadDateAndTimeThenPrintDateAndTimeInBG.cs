// Write a program that reads a date and time given in the format: day.month.year hour:minute:second 
// and prints the date and time after 6 hours and 30 minutes (in the same format) along with the day of week in Bulgarian.

using System;
using System.Globalization;

class ReadDateAndTimeThenPrintDateAndTimeInBG
{
    static void Main()
    {
        Console.WriteLine("This program reads a date and time given in the format: day.month.year hour:minute:second"
        + "and prints the date and time after 6 hours and 30 minutes (in the same format) along with the day of week in Bulgarian.");
        Console.WriteLine();

        Console.WriteLine("Please, enter date and time in the format: day.month.year hour:minute:second");
        Console.Write("-> ");
        DateTime date = DateTime.Parse(Console.ReadLine());
        DateTime newDate = date.AddHours(6).AddMinutes(30);
        string dayOfWeek = newDate.ToString("dddd", new CultureInfo("bg-BG"));
        Console.WriteLine("After 6 hours 30 minutes the date and time will be: ");
        Console.WriteLine("{0}.{1}.{2} {3} {4}", newDate.Day, newDate.Month, newDate.Year, newDate.TimeOfDay, dayOfWeek);
    }
}