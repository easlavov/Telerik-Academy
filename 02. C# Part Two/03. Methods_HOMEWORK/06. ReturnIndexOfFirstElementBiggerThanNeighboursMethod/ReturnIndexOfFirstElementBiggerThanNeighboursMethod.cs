// Write a method that returns the index of the first element in array that is
// bigger than its neighbors, or -1, if there’s no such element.
// Use the method from the previous exercise.

using System;

class ReturnIndexOfFirstElementBiggerThanNeighboursMethod
{
    static void Main()
    {
        Console.WriteLine("This program tests  a method that returns the index of the first element in array that is bigger than its neighbors, or -1, if there’s no such element.");
        Console.WriteLine();
        Console.Write("Please, enter array size: ");
        int[] array = new int[int.Parse(Console.ReadLine())];
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("Enter array[{0}]: ", i);
            array[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine();
        int index = ReturnIndexOfFirstElementBiggerThanNeighbours(array);
        if (index == -1)
        {
            Console.WriteLine("There is no element in the array that is bigger than its neighbors!");
        }
        else
        {
            Console.WriteLine("The first element in the array that is bigger than its neighbors is the element with index {0}.", index);
        }
    }

    // New method
    static int ReturnIndexOfFirstElementBiggerThanNeighbours(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            bool isBigger = IsBiggerBool(array, i);
            if (isBigger == true)
            {
                return i;
            }
        }
        return -1;
    }

    // Method form the previous exercise
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