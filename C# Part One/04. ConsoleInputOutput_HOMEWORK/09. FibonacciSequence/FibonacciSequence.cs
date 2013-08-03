// Write a program to print the first 100 members of the sequence
// of Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …

using System;

class FibonacciSequence
{
    static void Main()
    {
        // Print what the program does:
        Console.WriteLine("This program prints the first 100 members of the sequence of Fibonacci.");


        ulong a = 0;
        ulong b = 1;

        for (int i = 0; i <= 100; i++)
        {
            if (a == 0)
            {
                Console.WriteLine(a);
                Console.WriteLine(b);
            }
            ulong temp = a;
            a = b;
            b += temp;
            Console.WriteLine(b);
        }
    }
}