// Current project solves task 2

using System;
using System.Linq;
using System.Collections.Generic;

class TestProgram
{
    static void Main()
    {
        Console.WriteLine("This program tests extension methods from the Extension class. It will run a few tests to check if the code has been written correctly.");
        Console.WriteLine();

        // Testing with an int array
        int[] intList = { 1, 105, 3, -5, 16 };
        InvokeMethods(intList, "int array");

        // Testing with a float array
        float[] floatList = { 1.4f, 67.5f, 455.0008f, -45.61f };
        InvokeMethods(floatList, "float array");

        // Testing with a list of doubles
        List<double> doubleList = new List<double>();
        for (int i = -150; i < 10; i++)
        {
            doubleList.Add(i * 15);
        }
        InvokeMethods(doubleList, "double List");
        Console.WriteLine("Testing has completed successfully!");
    }

    static void InvokeMethods<T>(IEnumerable<T> list, string type) where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        Console.WriteLine("Collection: {0}", type);
        Console.Write("Collection content: ");
        foreach (var number in list)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine();
        Console.WriteLine("Sum: {0}", list.CustomSum());
        Console.WriteLine("Product: {0}", list.CustomProduct());
        Console.WriteLine("Min: {0}", list.CustomMin());
        Console.WriteLine("Max: {0}", list.CustomMax());
        Console.WriteLine("Average: {0}", list.CustomAverage());
        Console.WriteLine();
    }
}