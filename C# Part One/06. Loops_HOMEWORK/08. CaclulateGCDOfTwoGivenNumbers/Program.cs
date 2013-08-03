// Write a program that calculates the greatest common divisor (GCD) of two given numbers. 
// Use the Euclidean algorithm (find it in Internet).

using System;

class Program
{
    static void Main()
    {
        // Print what the program does:
        Console.WriteLine("This program calculates the greatest common divisor (GCD) of two given numbers.");

        // Instruct the user to enter two integers:
        Console.Write("Please, enter the first number: ");
        int a = int.Parse(Console.ReadLine());
        int aConst = a; // We keep it here so we can use it in the end.
        Console.Write("Please, enter the second number: ");
        int b = int.Parse(Console.ReadLine());
        int bConst = b;// We keep it here so we can use it in the end.

        int GCD = 1;
        int temp;
        if (a < b) // Ensure a is the bigger number.
        {
            temp = b;
            b = a;
            a = temp;
        }

        while (b != 0) // The Euclidean algorithm
        {
            GCD = a % b;
            a = b;
            b = GCD;
        }
        Console.WriteLine("The greatest common divisor of {0} and {1} is {2}.", aConst, bConst, a);
    }
}