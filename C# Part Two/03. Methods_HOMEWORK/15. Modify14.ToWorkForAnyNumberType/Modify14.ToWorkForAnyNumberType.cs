// * Modify your last program and try to make it work for any number type, not just 
// integer (e.g. decimal, float, byte, etc.). Use generic method.

using System;

class Modify14ToWorkForAnyNumberType
{
    // Test program
    static void Main()
    {
        Console.WriteLine("This program tests methods that calculate minimum, maximum, average, sum and product of given set of numbers.");
        Console.WriteLine();
        int[] integers = { 2, 3, };
        Console.WriteLine("Results for integers array: {0}, {1}", integers[0], integers[1]);
        Call(integers);
        Console.WriteLine();
        float[] floats = { 0.2f, 242, -0.1f, 232.4214f };
        Console.WriteLine("Results for float arrays: {0}, {1}, {2}, {3}", floats[0],floats[1],floats[2],floats[3]);
        Call(floats);

    }

    // Call methods
    static void Call<T>(T[] array)
    {
        Console.WriteLine("The smallest element in the given set of integers is {0}", Min(array));
        Console.WriteLine("The biggest element in the given set of integers is {0}", Max(array));
        Console.WriteLine("The average of the given set of integers is {0}", Average(array));
        Console.WriteLine("The sum of the given set of integers is {0}", Sum(array));
        Console.WriteLine("The product of the given set of integers is {0}", Product(array));
    }

    // Method to calculate the minimum
    static T Min<T>(params T[] numbers)
    {
        dynamic min = numbers[0];
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] < min)
            {
                min = numbers[i];
            }
        }
        return min;
    }

    // Method to calculate the maximum
    static T Max<T>(params T[] numbers)
    {
        dynamic max = numbers[0];
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] > max)
            {
                max = numbers[i];
            }
        }
        return max;
    }

    // Method to calculate the average
    static double Average<T>(params T[] numbers)
    {
        dynamic average = 0;
        foreach (var number in numbers)
        {
            average += number;
        }
        average /= (double)numbers.Length;
        return average;
    }

    // Method to calculate the sum
    static T Sum<T>(params T[] numbers)
    {
        dynamic sum = 0;
        foreach (var number in numbers)
        {
            sum += number;
        }
        return sum;
    }

    // Method to calculate the product
    static T Product<T>(params T[] numbers)
    {
        dynamic product = 1;
        foreach (var number in numbers)
        {
            product *= number;
        }
        return product;
    }
}