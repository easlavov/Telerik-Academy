// Write methods to calculate minimum, maximum, average, sum and product 
// of given set of integer numbers. Use variable number of arguments.

using System;

class ArithmeticOperationsMethods
{
    // Test program
    static void Main()
    {
        Console.WriteLine("This program tests methods that calculate minimum, maximum, average, sum and product of given set of integer numbers.");
        Console.WriteLine();
        Console.Write("Please, enter set size: ");
        int size = int.Parse(Console.ReadLine());
        int[] array = new int[size];
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("Enter integer {0}: ", i + 1);
            array[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine();
        Console.WriteLine("The smallest element in the given set of integers is {0}", Min(array));
        Console.WriteLine("The biggest element in the given set of integers is {0}", Max(array));
        Console.WriteLine("The average of the given set of integers is {0}", Average(array));
        Console.WriteLine("The sum of the given set of integers is {0}", Sum(array));
        Console.WriteLine("The product of the given set of integers is {0}", Product(array));
    }

    // Method to calculate the minimum
    static int Min(int[] integers)
    {
        int min = int.MaxValue;
        for (int i = 0; i < integers.Length; i++)
        {
            if (integers[i] < min)
            {
                min = integers[i];
            }
        }
        return min;
    }

    // Method to calculate the maximum
    static int Max(int[] integers)
    {
        int max = int.MinValue;
        for (int i = 0; i < integers.Length; i++)
        {
            if (integers[i] > max)
            {
                max = integers[i];
            }
        }
        return max;
    }

    // Method to calculate the average
    static decimal Average(int[] integers)
    {
        decimal average = 0;
        foreach (var number in integers)
        {
            average += number;
        }
        average /= integers.Length;
        return average;
    }

    // Method to calculate the sum
    static int Sum(int[] integers)
    {
        int sum = 0;
        foreach (var number in integers)
        {
            sum += number;
        }
        return sum;
    }

    // Method to calculate the product
    static long Product(int[] integers)
    {
        long product = 1;
        foreach (var number in integers)
        {
            product *= number;
        }
        return product;
    }
}