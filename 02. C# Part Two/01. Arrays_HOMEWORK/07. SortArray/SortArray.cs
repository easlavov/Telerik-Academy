// Write a program to sort an array. Use the "selection sort" algorithm: 
// Find the smallest element, move it at the first position, find the smallest from the rest, 
// move it at the second position, etc.

using System;

class SortArray
{
    static void Main()
    {
        // Print what the program does
        Console.WriteLine("This program sorts an array using the \"selection sort\" algorithm.");

        // Instruct user to enter variables
        Console.Write("Please, enter the numebr of elements: ");
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];
        Console.WriteLine();

        for (int i = 0; i < n; i++)
        {
            Console.Write("Please, enter element [{0}]: ", i);
            array[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine();        

        // Print the unsorted array
        Console.WriteLine("This is the unsorted array: ");
        foreach (var item in array)
        {
            Console.Write("{0} ", item);
        }
        Console.WriteLine();

        // The first loop 'selects' the element at index i (starting from 0)
        for (int i = 0; i < array.Length; i++)
        {
            // The second loop compares element at index i to all elements after it (therefore p = i + 1)
            for (int p = i + 1; p < array.Length; p++)
            {
                // If the p element is bigger than i then its value is swapped with the value of i 
                if (array[i] > array[p])
                {
                    int temp = array[i];
                    array[i] = array[p];
                    array[p] = temp;
                }
            }
        }

        // Print the sorted array
        Console.WriteLine("This is the sorted array: ");
        foreach (var item in array)
        {
            Console.Write("{0} ", item);
        }
        Console.WriteLine();
    }
}