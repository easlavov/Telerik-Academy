// Write a program that reads 3 integer numbers from
// the console and prints their sum.

using System;

class Read3IntegersAndPrintSum
{
    static void Main()
    {
        Console.WriteLine("This program calculates the sum of three integers.");
        Console.WriteLine();
        
        // User enters 3 integers        
        Console.Write("Please, enter the first integer: ");
        string string1 = Console.ReadLine();
        int number1 = int.Parse(string1);
        
        Console.Write("Please, enter the second integer: ");
        string string2 = Console.ReadLine();
        int number2 = int.Parse(string2);
        
        Console.Write("Please, enter the third integer: ");
        string string3 = Console.ReadLine();
        int number3 = int.Parse(string3);
        Console.WriteLine();

        // Calculate and print sum
        int sum = number1 + number2 + number3;
        Console.WriteLine("The sum of {0}, {1} and {2} is {3}.",
            number1, number2, number3, sum);
        Console.WriteLine();
    }
}