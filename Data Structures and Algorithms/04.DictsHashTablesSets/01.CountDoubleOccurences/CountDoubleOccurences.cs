/*Write a program that counts in a given array of double values the number of occurrences of each value. Use Dictionary<TKey,TValue>.*/

using System;
using System.Collections.Generic;

class CountDoubleOccurences
{
    static void Main()
    {
        double[] doubleArray = { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };
        PrintNumberOccurenceInArray(doubleArray);
    }

    private static void PrintNumberOccurenceInArray(double[] doubleArray)
    {
        Dictionary<double, int> occurences = new Dictionary<double, int>();
        GetOccurences(doubleArray, ref occurences);
        foreach (var number in occurences)
        {
            Console.WriteLine("{0} -> {1} time(s)", number.Key, number.Value);
        }
    }

    private static void GetOccurences(double[] doubleArray, ref Dictionary<double, int> occurences)
    {
        foreach (var number in doubleArray)
        {
            if (!occurences.ContainsKey(number))
            {
                occurences.Add(number, 1);
            }
            else
            {
                occurences[number]++;
            }
        }
    }
}