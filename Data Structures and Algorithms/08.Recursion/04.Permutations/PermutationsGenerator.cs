using System;
using System.Collections.Generic;

public static class PermutationsGenerator
{
    private static List<int[]> permutations;
    private static int[] numbers;
    public static List<int[]> GeneratePermutations(int number)
    {
        permutations = new List<int[]>();
        numbers = new int[number];
        Fill();
        GeneratePermutations<int>(numbers, 0);
        return permutations;
    }

    static void GeneratePermutations<T>(T[] arr, int k)
    {
        if (k >= arr.Length)
        {
            AddPermutation();
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

    static void Swap<T>(ref T first, ref T second)
    {
        T oldFirst = first;
        first = second;
        second = oldFirst;
    }

    private static void Fill()
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = i + 1;
        }
    }

    private static void AddPermutation()
    {
        int[] temp = new int[numbers.Length];
        Array.Copy(numbers, temp, numbers.Length);
        permutations.Add(temp);
    }
}