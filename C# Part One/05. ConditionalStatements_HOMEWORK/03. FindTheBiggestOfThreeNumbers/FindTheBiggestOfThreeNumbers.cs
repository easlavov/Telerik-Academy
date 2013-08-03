// Write a program that finds the biggest of three integers using nested if statements.

using System;

class FindTheBiggestOfThreeNumbers
{
    static void Main()
    {
        // Print what the program does:
        Console.WriteLine("This program finds the biggest of three integers using nested if statements.");

        // Instruct user to enter three integers:
        Console.Write("Please enter the first integer: ");
        int numberA = int.Parse(Console.ReadLine());
        Console.Write("Please enter the second integer: ");
        int numberB = int.Parse(Console.ReadLine());
        Console.Write("Please enter the third integer: ");
        int numberC = int.Parse(Console.ReadLine());

        if (numberA >= numberB)
        {
            if (numberA >= numberC)
            {
                Console.WriteLine("{0} is the biggest.", numberA);
            }
            else
            {
                Console.WriteLine("{0} is the biggest.", numberC);
            }
        }
        else if (numberB >= numberA)
        {
            if (numberB >= numberC)
            {
                Console.WriteLine("{0} is the biggest.", numberB);
            }
            else
            {
                Console.WriteLine("{0} is the biggest.", numberC);
            }
        }       
    }
}