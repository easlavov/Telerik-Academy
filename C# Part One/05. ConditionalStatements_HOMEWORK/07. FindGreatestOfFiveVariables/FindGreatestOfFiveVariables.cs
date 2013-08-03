// Write a program that finds the greatest of given 5 variables.

using System;

class FindGreatestOfFiveVariables
{
    static void Main()
    {
        // Print what the program does:
        Console.WriteLine("This program finds the greatest of given 5 variables.");

        // Instruct user to enter five variables.
        Console.Write("Please, enter the first variable: ");
        double numberA = double.Parse(Console.ReadLine());
        Console.Write("Please, enter the second variable: ");
        double numberB = double.Parse(Console.ReadLine());
        Console.Write("Please, enter the third variable: ");
        double numberC = double.Parse(Console.ReadLine());
        Console.Write("Please, enter the fourth variable: ");
        double numberD = double.Parse(Console.ReadLine());
        Console.Write("Please, enter the fifth variable: ");
        double numberE = double.Parse(Console.ReadLine());

        // Perform calculations and print result:
        double greatestAB = Math.Max(numberA, numberB);
        double greatestCD = Math.Max(numberC, numberD);
        double greatestABCD = Math.Max(greatestAB, greatestCD);
        double finalCompare = Math.Max(greatestABCD, numberE);
        Console.WriteLine("The biggest variable is {0}.", finalCompare);
    }
}