// Define a class InvalidRangeException<T> that holds information about an error condition 
// related to invalid range. It should hold error message and a range definition [start … end].
// Write a sample application that demonstrates the InvalidRangeException<int> and InvalidRangeException<DateTime>
// by entering numbers in the range [1..100] and dates in the range [1.1.1980 … 31.12.2013].

using System;
using System.Linq;

class TestProgram
{
    static void Main()
    {
        Console.WriteLine("This program test the Exception project. Please follow the instructions and enter invalid input to test the Exception class.");
        Console.WriteLine();

        try
        {
            DateTime date = ReadDate();
            Console.WriteLine("Date {0} accepted!", date);
        }
        catch (InvalidRangeException<DateTime> e)
        {
            Console.WriteLine("{0}\nAllowed range is from {1} to {2}",e.Message, e.Start, e.End);
        }
        Console.WriteLine();
        try
        {
            int number = ReadNumber();
            Console.WriteLine("Number {0} accepted!", number);
        }
        catch (InvalidRangeException<int> e)
        {
            Console.WriteLine("{0}\nAllowed range is from {1} to {2}", e.Message, e.Start, e.End);
        }
    }

    static int ReadNumber()
    {
        int number;
        string input;
        int start = 1;
        int end = 100;

        do
        {
            Console.Write("Please, enter a number in the range [1...100]: ");
            input = Console.ReadLine();
        } while (!int.TryParse(input, out number));

        if (number < 1 || number > 100)
        {
            throw new InvalidRangeException<int>("You have entered an invalid number!", start, end);
        }
        return number;
    }

    static DateTime ReadDate()
    {
        DateTime date;
        string input;
        DateTime start = DateTime.Parse("1.1.1980");
        DateTime end = DateTime.Parse("31.12.2013");

        do
        {
            Console.Write("Please, enter a date in the range [1.1.1980...31.12.2013]: ");
            input = Console.ReadLine();
        } while (!DateTime.TryParse(input, out date));

        if (date < start || date > end)
        {
            throw new InvalidRangeException<DateTime>("You have entered an invalid date!", start, end);
        }
        return date;
    }
}