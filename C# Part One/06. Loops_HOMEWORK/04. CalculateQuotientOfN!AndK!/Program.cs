// Write a program that calculates N!/K! for given N and K (1<K<N).

using System;

class Program
{
    static void Main()
    {
        // Print what the program does:
        Console.WriteLine("This program calculates N!/K! for given N and K (1<K<N).");
        Console.WriteLine();

        while (true)
        {
            // Instruct user to enter two integers for N and K:
            Console.Write("Please, enter K (should be > 1): ");
            int k = int.Parse(Console.ReadLine());
            Console.Write("Please, enter N (should be > K): ");
            int n = int.Parse(Console.ReadLine());

            // Declare a conditional that ensures correct user input:
            if (k >= n || k <= 1)
            {
                Console.WriteLine("Wrong input! Try again!");
            }
            else
            {
                // Calculate K!
                ulong kFactorial = 1;
                for (int i = 1; i <= k; i++)
                {
                    kFactorial *= (ulong)i;
                }
                // Calculate N!
                ulong nFactorial = 1;
                for (int i = 1; i <= n; i++)
                {
                    nFactorial *= (ulong)i;
                }

                // Print N! and K!:
                Console.WriteLine("N! is {0}", nFactorial);
                Console.WriteLine("K! is {0}", kFactorial);

                // Calculate N!/K! and print the result:
                ulong quotient = nFactorial / kFactorial;
                Console.WriteLine("{0}! / {1}! = {2}", nFactorial, kFactorial, quotient);
                Console.WriteLine();
            }           
        }
    }
}
