// * Write a program that calculates for given N how many trailing zeros present at the end of the number N!.

using System;
using System.Numerics;

class TaskTen
{

    static void Main()
    {
        // Print what the program does:
        Console.WriteLine("This program calculates for given N how many trailing zeros present at the end of the number N!.");
        Console.WriteLine();

        // Instruct user to enter N:
        Console.Write("Please, enter N: ");
        BigInteger n = BigInteger.Parse(Console.ReadLine());

        // Calculate the factorial:
        BigInteger factorial = 1;
        for (BigInteger i = 1; i <= n; i++)
        {
            factorial *= i;
        }

        Console.WriteLine("The factorial of {0} is {1}", n, factorial);

        // Calculate the count of trailing zeroes:
        BigInteger remainder = 0;
        int counter = 0;
        while (remainder == 0)
        {
            remainder = factorial % 10;
            if (remainder != 0)
            {
                break;
            }
            counter++;
            factorial /= 10;
        }

        Console.WriteLine("Number of trailing zeroes in {0}!: {1}", n, counter);
    }
}