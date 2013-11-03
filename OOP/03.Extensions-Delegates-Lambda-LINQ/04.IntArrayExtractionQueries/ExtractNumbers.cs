// Current project solves task 6:
// Write a program that prints from given array of integers all numbers that are divisible by 7 
// and 3. Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.

// Write a program that prints from given array of integers all numbers that are divisible by 7 and 3. 
// Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.

using System;
using System.Linq;

class ExtractNumbers
{
    static void Main()
    {
        Console.WriteLine("This test program will create an array containing the numbers from 1 to 100.");
        Console.WriteLine("Then it will extract all number that ar divisable by 3 and 7 at the same time.");
        // Declare an array
        int[] numbers = new int[100];
        // Populate array
        for (int i = 1; i <= numbers.Length; i++)
        {
            numbers[i - 1] = i;
        }

        Console.WriteLine("Extract numbers using Lamdba expression:");
        ExtractLambda(numbers);
        Console.WriteLine("Extract numbers using LINQ:");
        ExtractLinq(numbers);
    }

    static void ExtractLambda(int[] numbers)
    {
        var matches = numbers.Where(x => (x % 3) == 0 && (x % 7) == 0);
        foreach (var number in matches)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine();
    }

    static void ExtractLinq(int[] numbers)
    {
        var matches = (
            from n in numbers
            where n % 3 == 0 && n % 7 == 0
            select n);
        foreach (var number in matches)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine();
    }
}