// Write a program that reads two numbers N and K and generates all the variations of K elements from the set [1..N]. 
// Example: N = 3, K = 2 -> {1, 1}, {1, 2}, {1, 3}, {2, 1}, {2, 2}, {2, 3}, {3, 1}, {3, 2}, {3, 3}

using System;

class GenerateAndPrintVariations1toN
{
    static void Main()
    {
        // Print what the program does
        Console.WriteLine("This program reads two numbers N and K and generates all the variations of K elements from the set [1..N].");
        Console.WriteLine();

        // Read N
        Console.Write("Please, enter N: ");
        int n = int.Parse(Console.ReadLine());
        
        //Read K
        Console.Write("Please, enter K: ");
        int k = int.Parse(Console.ReadLine());
        // The array will have K elements!
        int[] arr = new int[k];

        GenerateVariations(arr, k, n, 0);
    }

    private static void GenerateVariations(int[] arr, int k, int n, int index)
    {
        // Recursion bottom
        if (index >= k)
        {
            // Prints the variation on the console
            PrintResult(arr);
        }
        else
        {
            // i = 1 because [1..N], not [0..N]
            // the loop is executed n times - the numbers between 1 and n
            for (int i = 1; i <= n; i++)
            {
                arr[index] = i;
                // index + 1 ensures the loop in the next recursion will begin from the next element in the array
                GenerateVariations(arr, k, n, index + 1);
            }
        }
    }

    private static void PrintResult(int[] array)
    {        
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("{0} ", array[i]);
        }
        Console.WriteLine();
    }
}