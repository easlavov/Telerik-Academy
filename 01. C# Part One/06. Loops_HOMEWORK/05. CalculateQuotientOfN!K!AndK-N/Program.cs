// Write a program that calculates N!*K! / (K-N)! for given N and K (1<N<K).

using System;

class Program
{
    static void Main()
    {
        // Print what the program does:
        Console.WriteLine("This program calculates N!*K! / (K-N)! for given N and K (1<N<K).");
        Console.WriteLine();

        while (true)
        {
            // Instruct user to enter two integers for N and K:
            Console.Write("Please, enter N (should be > 1): ");
            ulong n = ulong.Parse(Console.ReadLine());
            Console.Write("Please, enter K (should be > N): ");
            ulong k = ulong.Parse(Console.ReadLine());

            // Declare a conditional that ensures correct user input:
            if (n >= k || n <= 1)
            {
                Console.WriteLine("Wrong input! Try again!");
            }
            else
            {
                // Calculate N!
                ulong nFactorial = 1;
                for (ulong i = 1; i <= n; i++)
                {
                    nFactorial *= (ulong)i;
                }
                // Calculate K!
                ulong kFactorial = 1;
                for (ulong i = 1; i <= k; i++)
                {
                    kFactorial *= (ulong)i;
                }

                // Print N! and K!:
                Console.WriteLine("N! is {0}", nFactorial);
                Console.WriteLine("K! is {0}", kFactorial);
                                
                // N!*K! and (K-N)!
                ulong product = kFactorial * nFactorial;
                ulong difference = k - n;
                // Calculate N!*K! / (K-N) and print the result:
                ulong quotient = product/difference;
                Console.WriteLine("{0} * {1} / {2} - {3} = {4}", kFactorial, nFactorial, k, n, quotient);
                Console.WriteLine();
            }
        }
    }
}
