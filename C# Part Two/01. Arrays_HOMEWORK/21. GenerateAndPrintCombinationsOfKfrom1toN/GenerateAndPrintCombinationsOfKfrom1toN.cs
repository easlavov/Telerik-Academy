// Write a program that reads two numbers N and K and generates all 
// the combinations of K distinct elements from the set [1..N]. 
// Example:	N = 5, K = 2 -> {1, 2}, {1, 3}, {1, 4}, {1, 5}, {2, 3}, {2, 4}, {2, 5}, {3, 4}, {3, 5}, {4, 5}

using System;

class GenerateAndPrintCombinationsOfKfrom1toN
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

        GenerateCombinations(arr, n, k, 0, 1);
    }

    private static void GenerateCombinations(int[] arr, int n, int k, int index, int start)
    {
        if (index >= k)
        {
            PrintResult(arr);
        }
        else
        {
            for (int i = start; i <= n; i++)
            {
                arr[index] = i;
                GenerateCombinations(arr, n, k, index + 1, i + 1);
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