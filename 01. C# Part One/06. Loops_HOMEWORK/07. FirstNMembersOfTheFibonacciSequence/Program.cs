// Write a program that reads a number N and calculates the sum of the first N 
// members of the sequence of Fibonacci.

using System;
using System.Collections.Generic;
using System.Linq;

class FibonacciSequence
{
    static void Main()
    {
        // Print what the program does:
        Console.WriteLine("This program reads a number N and calculates the sum of the first N members of the sequence of Fibonacci.");

        // Instruct user to enter number N:
        Console.Write("Please, enter an integer: ");
        long n = long.Parse(Console.ReadLine());

        // Create a list:
        List<long> fibList = new List<long>();

        // We use a standard Fibonacci loop but instead of printing the numbers we add them to the list:
        ulong a = 0;
        ulong b = 1;

        if (n < 3)
        {
            if (n == 1)
            {
                fibList.Add((long)a);
            }
            if (n == 2)
            {
                fibList.Add((long)a);
                fibList.Add((long)b);
            }
        }

        for (int i = 0; i < n - 2; i++)
        {
            if (a == 0)
            {
                fibList.Add((long)a);
                fibList.Add((long)b);
            }
            ulong temp = a;
            a = b;
            b += temp;
            fibList.Add((long)b);
        }

        Console.WriteLine("In the list.");
        foreach (var item in fibList)
        {
            Console.WriteLine(item);
        }

        ulong sum = (ulong)fibList.Sum();
        Console.WriteLine("The sum of the first {0} members of the Fibonacci sequence is: {1}", n, sum);
    }
}