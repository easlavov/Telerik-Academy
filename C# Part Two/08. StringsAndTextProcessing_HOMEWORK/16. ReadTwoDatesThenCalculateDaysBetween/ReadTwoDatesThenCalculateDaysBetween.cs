// Write a program that reads two dates in the format: day.month.year and calculates the number of days between them.

using System;

class ReadTwoDatesThenCalculateDaysBetween
{
    static void Main()
    {
        Console.WriteLine("This program reads two dates in the format: day.month.year and calculates the number of days between them.");
        Console.WriteLine();

        // Read user input
        Console.WriteLine("You will be now prompted to enter two dates in the format day.month.year.");
        Console.Write("Please, enter a date in the format dd.mm.yyyy: ");
        DateTime firstDate = DateTime.Parse(Console.ReadLine());
        Console.Write("Please, enter a second date in the format dd.mm.yyyy: ");
        DateTime secondDate = DateTime.Parse(Console.ReadLine());

        // Calculate and print difference in days
        TimeSpan dayDiff = firstDate - secondDate;
        Console.WriteLine("The difference in days between {0} and {1} is {2}", firstDate.ToShortDateString(), secondDate.ToShortDateString(), Math.Abs(dayDiff.Days));
    }
}