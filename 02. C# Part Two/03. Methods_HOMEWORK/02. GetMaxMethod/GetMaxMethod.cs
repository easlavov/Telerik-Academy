// Write a method GetMax() with two parameters that returns the bigger of two integers.
// Write a program that reads 3 integers from the console and prints the biggest of them using the method GetMax().

using System;

class GetMaxMethod
{
    // Program
    static void Main()
    {
        Console.WriteLine("This program reads 3 integers from the console and prints the biggest of them using the method GetMax().");
        Console.WriteLine();
        Console.Write("Enter integer 1: ");
        int result = int.Parse(Console.ReadLine());
        Console.Write("Enter integer 2: ");
        result = GetMax(result, int.Parse(Console.ReadLine()));
        Console.Write("Enter integer 3: ");
        result = GetMax(result, int.Parse(Console.ReadLine()));
        Console.WriteLine();
        Console.WriteLine("The biggest number is {0}.", result);
    }

    // Method
    static int GetMax(int first, int second)
    {
        if (first < second)
        {
            first = second;
        }
        return first;
    }
}