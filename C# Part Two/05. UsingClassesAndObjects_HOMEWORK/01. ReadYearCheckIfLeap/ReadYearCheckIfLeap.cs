// Write a program that reads a year from the console and checks whether it is a leap. Use DateTime.

using System;

class ReadYearCheckIfLeap
{
    static void Main()
    {
        // Explain the program
        Console.WriteLine("This program reads a year from the console and checks whether it is a leap.");
        Console.WriteLine();

        // Read input
        Console.Write("Please, enter a year (>0): ");
        int input = int.Parse(Console.ReadLine());
        // Check year and print result
        bool isLeapYear = DateTime.IsLeapYear(input);
        if (isLeapYear == true)
        {
            Console.WriteLine("The year {0} is leap.", input);
        }
        else
        {
            Console.WriteLine("The year {0} is not leap.", input);
        }
    }
}