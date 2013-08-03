//// Write a program that reads two positive integer numbers and prints
//// how many numbers p exist between them such that the reminder of the
//// division by 5 is 0 (inclusive). Example: p(17,25) = 2.

using System;

class Read2IntegersAndPrintCountOfNumbersDivisibleBy5
{
    static void Main()
    {
        // Print what the program does:
        Console.WriteLine("This program calculates how many numbers between two numbers, defined by the user, are divisible by 5.");
        Console.WriteLine();

        // Instruct the user to enter two positive integers.
        Console.WriteLine("You should enter two positive integers.");
        Console.Write("Please, enter the lower number: ");
        string stringNumber1 = Console.ReadLine();
        int numberLower = int.Parse(stringNumber1);

        Console.Write("Please, enter the bigger number: ");
        string stringNumber2 = Console.ReadLine();
        int numberBigger = int.Parse(stringNumber2);
        Console.WriteLine();

        // Perform a calculation and print the result:
        int result = (numberBigger / 5) - ((numberLower - 1) / 5);
        Console.WriteLine("There are {0} numbers between {1} and {2} which are divisible by 5. ", result, numberLower, numberBigger);
        Console.WriteLine();
    }
}