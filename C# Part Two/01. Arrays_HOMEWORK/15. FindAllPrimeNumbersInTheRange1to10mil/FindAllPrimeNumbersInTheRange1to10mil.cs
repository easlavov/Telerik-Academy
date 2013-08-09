// Write a program that finds all prime numbers in the range [1...10 000 000]. Use the sieve of Eratosthenes algorithm

using System;

class FindAllPrimeNumbersInTheRange1to10mil
{
    static void Main()
    {
        // Print what the program does
        Console.WriteLine("This program finds all prime numbers betwen 1 and 10 million uisng the Eratosthenes algorithm.");
        Console.WriteLine("This is slow. Please wait...");
        
        int[] array = new int[10000000];
        for (int i = 1; i <= array.Length; i++)
        {
            array[i - 1] = i;
        }

        // This variable holds the count of the prime numbers between 1 and 10 million
        int counter = 0;

        // The Sieve of Eratosthenes. Set all non-prime numbers to zero (cross them out)
        for (int i = 2; i < Math.Sqrt(array.Length); i++)
        {
            // This conditional greatly optimizes the speed of the program
            if (array[i-1] == 0)
            {
                continue;
            }
            for (int p = i + 1; p < array.Length; p++)
            {
                if (array[p] % i == 0)
                {
                    array[p] = 0;
                }
            }
        }

        foreach (var item in array)
        {
            if (item != 0 && item != 1)
            {
                counter++;
            }
        }
        
        Console.WriteLine("The count of prime numbers between 1 and 10 million is {0}", counter);

        Console.Write("Press any key to print the result: ");
        Console.ReadKey();

        foreach (var item in array)
        {
            if (item != 0)
            {
                Console.Write("{0}, ", item);
            }
        }
    }
}