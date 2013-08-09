// Write a method that checks if the element at given position in given 
// array of integers is bigger than its two neighbors (when such exist).

using System;

class CheckIfBiggerThanNeighboursMethod
{
    static void Main()
    {
        Console.WriteLine("This program tests a method that checks if the element at given position in given array of integers is bigger than its two neighbors (when such exist).");
        Console.WriteLine();

        Console.Write("Please, enter array size: ");
        int[] array = new int[int.Parse(Console.ReadLine())];
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("Enter array[{0}]: ", i);
            array[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine();
        Console.Write("Please, enter the index of the element you want checked: ");
        int index = int.Parse(Console.ReadLine());
        // Void method
        Console.WriteLine("Void method: ");
        IsBiggerVoid(array, index);
        Console.WriteLine();

        // Boolean method
        bool isBigger = IsBiggerBool(array, index);
        Console.WriteLine("The element is bigger than its neighbours: {0}", isBigger);
    }

    // Prints the result
    static void IsBiggerVoid(int[] array, int index)
    {
        if (index < 0 || index >= array.Length)
        {
            Console.WriteLine("The specified index is outside the array.");
            return;
        }
        if (index == 0 || index == array.Length-1)
        {
            Console.WriteLine("The element has only one neighbour.");
            return;
        }

        if (array[index] > array[index-1] && array[index] > array[index+1])
        {
            Console.WriteLine("The element at position {0} is bigger than its neighbour elements.", index);
            return;
        }
        else
        {
            Console.WriteLine("The element at position {0} is not bigger than its neighbour elements.", index);
            return;
        }
    }

    // Returns a result
    static bool IsBiggerBool(int[] array, int index)
    {
        if (index < 0 || index >= array.Length)
        {
            return false;
        }
        if (index == 0 || index == array.Length - 1)
        {
            return false;
        }

        if (array[index] > array[index - 1] && array[index] > array[index + 1])
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}