// Write a program to calculate the Nth Catalan number by given N.

using System;
using System.Numerics;

class Program
{
    static void Main()
    {
        // Print what the program does:
        Console.WriteLine("This program calculates the Nth Catalan number by given N.");

        // Instruct the user to enter number N:
        Console.Write("Please, enter number N: ");
        BigInteger n = BigInteger.Parse(Console.ReadLine());

        BigInteger partOne = 2 * n;
        BigInteger partOneFactorial = 1;

        for (ulong i = 1; i <= partOne; i++)
        {
            partOneFactorial *= (ulong)i;
        }

        BigInteger partTwo = n + 1;
        BigInteger partTwoFactorial = 1;
        for (ulong i = 1; i <= partTwo; i++)
        {
            partTwoFactorial *= (ulong)i;
        }

        BigInteger partThree = n;
        BigInteger partThreeFactorial = 1;
        for (ulong i = 1; i <= partThree; i++)
        {
            partThreeFactorial *= (ulong)i;
        }

        Console.WriteLine("Part1!: {0}", partOneFactorial);
        Console.WriteLine("Part2!: {0}", partTwoFactorial);
        Console.WriteLine("Part3!: {0}", partThreeFactorial);
        BigInteger test1 = partTwoFactorial * partThreeFactorial;
        Console.WriteLine("Part2! * Part3!: {0}", test1);
        BigInteger test2 = partOneFactorial / test1;
        Console.WriteLine("Part1! / above: {0}", test2);
        BigInteger catalanNumber = partOneFactorial / (partTwoFactorial * partThreeFactorial);
        Console.WriteLine("The N={0} Catalan number is {1}.", n, catalanNumber);
    }
}