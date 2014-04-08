using System;
using System.Linq;

class TestProgram
{
    static void PrintDateTime()
    {
        Console.WriteLine(DateTime.Now);
    }

    static void PrintRandomNumber()
    {
        Random rndm = new Random();
        Console.WriteLine(rndm.Next(1, 1001));
    }

    static void Main()
    {
        Console.WriteLine("This program tests the Timer class that takes two arguments in its first contructor - a delegate and an integer number that represents a time interval in seconds. An instance method is then executed which calls the delegate, passed as a parameter each s seconds. Another constructor allows the user to set the number of calls.");
        Console.WriteLine("The test Timer instance will run 3 times on 5 seconds interval between each. It will call a delegate which contains 2 methods - one that prints the current date and time and another that prints a random number.");
        Console.WriteLine();
        PrinterDelegate d = new PrinterDelegate(PrintDateTime);
        d += PrintRandomNumber;
        Timer t = new Timer(d, 5, 4);
        t.RunTimer();
    }
}