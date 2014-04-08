// Write a program that reads two integer numbers N and K and an array of N elements from the console.
// Find in the array those K elements that have maximal sum.

using System;

class DeclareArrayNThenFindKBiggestElements
{
    static void Main()
    {
        // Print what the program does:
        Console.WriteLine("This program reads two integer numbers N and K and an array of N " +
            "elements from the console and finds in the array those K elements that have maximal sum.");
        Console.WriteLine();

        // Instruct user to enter N and K (K <= N)
        Console.Write("Please enter N > 0: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Please enter K <= {0}: ", n);
        int k = int.Parse(Console.ReadLine());

        // Instruct user to fill the array
        int[] array = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter array[{0}]: ", i);
            array[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine();

        // Print array for convenience
        Console.WriteLine("The elements in the array are: ");
        for (int i = 0; i < n; i++)
        {
            if (i == n - 1)
            {
                Console.Write("{0} ", array[i]);
            }
            else
            {
                Console.Write("{0}, ", array[i]);
            }
        }
        Console.WriteLine();
        Console.WriteLine();

        // Sort the array. The biggest numbers will be in the end
        Array.Sort(array);

        // Print the K biggest numbers (starting from the biggest)
        Console.WriteLine("The {0} biggest number(s) in the array are: ", k);
        for (int i = 0; i < k; i++)
        {
            if (i == k - 1)
            {
                Console.Write("{0}", array[array.Length - 1 - i]);
            }
            else
            {
                Console.Write("{0}, ", array[array.Length - 1 - i]);
            }            
        }
        Console.WriteLine();
        Console.WriteLine("They are the K({0}) elements that have the maximal sum.", k);
        Console.WriteLine();
    }
}