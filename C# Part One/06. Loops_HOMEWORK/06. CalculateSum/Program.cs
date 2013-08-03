// Write a program that, for a given two integer numbers N and X, calculates the sum
// S = 1 + 1!/X + 2!/X2 + … + N!/XN

using System;

class Program
{
    static void Main()
    {
        // Print what the program does:
        Console.WriteLine("This program calculates for a given two integer numbers N and X the sum S = 1 + 1!/X + 2!/X2 + ... + N!/XN.");
        Console.WriteLine();

        // Instruct user to enter N and X values:
        Console.Write("Please, enter N: ");
        ulong n = ulong.Parse(Console.ReadLine());
        Console.Write("Please, enter X: ");
        ulong x = ulong.Parse(Console.ReadLine());

        // Implement the formula: S = 1 + 1!/X + 2!/X2 + … + N!/XN
        decimal sum = 1; // Container for the final sum.
        decimal factorial = 1; // This variable is used in the loop to help calculate the factorial for every addition(loop)
        for (ulong i = 0, f = 1; i < n; i++, f++) // A full loop is one addition. The factorialed number (f) is increased by 1 with every addition.
        {
            factorial *= f; // The factorial is kept in a variable outside the loop.
            decimal toAdd = factorial / x * f; // In every next addend the the number which factorial is calculated is the same as the multiplier of X.
            sum += toAdd; // Finally the addition is performed.
        }
        Console.WriteLine(sum);
    }
}