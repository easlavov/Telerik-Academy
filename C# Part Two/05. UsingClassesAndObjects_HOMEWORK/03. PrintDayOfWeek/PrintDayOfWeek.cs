// Write a program that prints to the console which day of the week is today. Use System.DateTime.

using System;

class PrintDayOfWeek
{
    static void Main()
    {
        // Explain the program
        Console.WriteLine("This program prints to the console which day of the week is today.");
        Console.WriteLine();

        // Print day of week
        Console.WriteLine("Today is {0}.", DateTime.Now.DayOfWeek);
    }
}