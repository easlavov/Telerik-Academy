using System;
using System.Collections.Generic;

public static class CombinationsGenerator
{
    static List<string[]> combinations;
    static string[] combination;

    public static List<string[]> GenerateCombinations(string[] array, int k)
    {
        combinations = new List<string[]>();
        combination = new string[k];
        GenerateNext(array, k, 0, 0);
        return combinations;
    }

    private static void GenerateNext(string[] array, int k, int index, int start)
    {
        if (index == k)
        {
            AddCombination(k);
            return;
        }

        for (int i = start; i < array.Length; i++)
        {
            combination[index] = array[i];
            GenerateNext(array, k, index + 1, i + 1);
        }
    }

    private static void AddCombination(int k)
    {
        string[] temp = new string[k];
        Array.Copy(combination, temp, k);
        combinations.Add(temp);
    }
}