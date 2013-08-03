// Write a program that gets two numbers from the console and
// prints the greater of them. Don’t use if statements.

using System;

class ReadTwoNumbersThenPrintGreater
{
    static void Main()
    {
        // Print what the program does:
        Console.WriteLine("This program reads two different numbers, defined by the user, and prints the greater of them.");
        Console.WriteLine();

        // Instruct the user to enter two numbers:
        Console.Write("Please, enter the first number: ");
        string stringNumber1 = Console.ReadLine();
        double number1 = double.Parse(stringNumber1);

        Console.Write("Please, enter the second number: ");
        string stringNumber2 = Console.ReadLine();
        double number2 = double.Parse(stringNumber2);

        // Perform calculations and print result:
        double max = Math.Max(number1, number2);
        Console.WriteLine("The greater number is {0}.", max);
    }
}