using System;
using System.Collections.Generic;
using System.Text;

public static class Methods
{
    public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
    {
        if (arr == null)
        {
            throw new ArgumentNullException("Array is null.");
        }

        if (startIndex < 0)
        {
            throw new ArgumentOutOfRangeException("Start index must be 0 or bigger.");
        }

        if (startIndex >= arr.Length)
        {
            throw new ArgumentOutOfRangeException("Start index must be smaller than the array length.");
        }

        if (count < 0)
        {
            throw new ArgumentOutOfRangeException("Count must be positive.");
        }

        if ((startIndex + count) > arr.Length)
        {
            throw new ArgumentOutOfRangeException(
                "The sum of the start index and count can't be bigger than the array length.");
        }

        List<T> result = new List<T>();
        for (int i = startIndex; i < startIndex + count; i++)
        {
            result.Add(arr[i]);
        }

        return result.ToArray();
    }

    public static string ExtractEnding(string str, int count)
    {
        if (count > str.Length)
        {
            throw new ArgumentOutOfRangeException(
                        "Count can't be bigger than the string's length.");
        }

        StringBuilder result = new StringBuilder();
        for (int i = str.Length - count; i < str.Length; i++)
        {
            result.Append(str[i]);
        }

        return result.ToString();
    }

    public static void CheckPrime(int number)
    {
        if (number < 0)
        {
            throw new ArgumentOutOfRangeException("Number must be positive.");
        }

        for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
        {
            if (number % divisor == 0)
            {
                Console.WriteLine("The number is not prime!");
                return;
            }
        }

        Console.WriteLine("The number is prime!");
    }
}