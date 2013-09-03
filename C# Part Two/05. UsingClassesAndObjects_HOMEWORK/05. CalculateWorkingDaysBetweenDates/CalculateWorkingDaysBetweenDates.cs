// Write a method that calculates the number of workdays between today and given date,
// passed as parameter. Consider that workdays are all days from Monday to Friday except 
// a fixed list of public holidays specified preliminary as array.

using System;

class CalculateWorkingDaysBetweenDates
{
    static void Main()
    {
        Console.WriteLine("This program calculates the number of workdays between today and a given date.");
        Console.WriteLine();

        // Read input
        Console.Write("Please, enter a future date (after {0}): ", DateTime.Now.Date);
        DateTime date = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Work days: {0}", WorkDays(date));
    }

    static int WorkDays(DateTime date)
    {
        int skipped = 0;
        int counter = 0;
        DateTime start = DateTime.Now;

        // Initialize an array of holidays
        int[,] holidays =
        {
            { 1, 3, 1, 6, 24, 6, 22, 24, 25, 26 }, // day
            { 1, 3, 5, 5, 5, 9, 9, 12, 12, 12 }, // month
        };

        while (start < date)
        {
            bool isHoliday = false;
            start = start.AddDays(1);
            if (start.DayOfWeek == DayOfWeek.Saturday || start.DayOfWeek == DayOfWeek.Sunday)
            {
                skipped++;
                isHoliday = true;
                continue;
            }
            else
            {
                for (int i = 0; i < holidays.GetLength(0); i++)
                {
                    if (start.Day == holidays[0,i] && start.Month == holidays[1,i])
                    {
                        skipped++;
                        isHoliday = true;
                        break;
                    }
                }
            }
            if (isHoliday == false)
            {
                counter++;
            }            
        }
        Console.WriteLine("Holidays: {0}", skipped);
        return counter;
    }
}