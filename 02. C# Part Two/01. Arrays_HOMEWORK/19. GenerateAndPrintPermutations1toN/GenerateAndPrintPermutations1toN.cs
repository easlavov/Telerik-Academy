// * Write a program that reads a number N and generates and prints all the permutations of the numbers [1 … N]. 
// Example: n = 3 -> {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2}, {3, 2, 1}

using System;

class GenerateAndPrintPermutations1toN
{
    static void Main()
    {
        // Print what the program does
        Console.WriteLine("This program reads a number N and generates and prints all the permutations of the numbers [1 … N].");
        Console.WriteLine();

        // Read N
        Console.Write("Please, enter N: ");
        int n = int.Parse(Console.ReadLine());
        // Fill an array with number 1 to N
        int[] arr = new int[n];
        for (int i = 1; i <= arr.Length; i++)
        {
            arr[i - 1] = i;
        }
        // Generate permutations and print them
        GeneratePermutations(arr, 0);
    }

    static void GeneratePermutations<T>(T[] arr, int k)
    {
        // k corresponds to the index
        if (k >= arr.Length)
        {
            Print(arr);
        }
        else
        {
            GeneratePermutations(arr, k + 1);
            for (int i = k + 1; i < arr.Length; i++)
            {
                Swap(ref arr[k], ref arr[i]);
                GeneratePermutations(arr, k + 1);
                Swap(ref arr[k], ref arr[i]);
            }
        }
    }

    static void Print<T>(T[] arr)
    {
        Console.WriteLine(string.Join(", ", arr));
    }

    static void Swap<T>(ref T first, ref T second)
    {
        T oldFirst = first;
        first = second;
        second = oldFirst;
    }
}