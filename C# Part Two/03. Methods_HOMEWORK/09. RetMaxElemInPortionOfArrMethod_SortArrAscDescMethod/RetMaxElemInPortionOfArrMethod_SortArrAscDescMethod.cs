// Write a method that return the maximal element in a portion of array of 
// integers starting at given index. Using it write another method that sorts 
// an array in ascending / descending order.

using System;

class RetMaxElemInPortionOfArrMethod_SortArrAscDescMethod
{
    static void Main()
    {
        Console.WriteLine("This program tests a method that return the maximal element in a portion of array of integers starting at given index.");
        Console.WriteLine();
        Console.Write("Please, enter array size: ");
        int[] array = new int[int.Parse(Console.ReadLine())];
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("Enter array[{0}]: ", i);
            array[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine();
        Console.Write("Enter starting index: ");
        int k = int.Parse(Console.ReadLine());
        int index = GetMax(array, k);
        Console.WriteLine("The index of the biggest element in the array ({0}), starting from {1}, is {2}.", array[index], k, index);
        Console.WriteLine();
        Console.WriteLine("The next line shows the result of a method that sorts the array in descending order, using the GetMax method: ");
        SortDescending(array);
        foreach (var item in array)
        {
            Console.Write("{0} ", item);
        }
        Console.WriteLine();
        Console.WriteLine("The next line shows the result of a method that sorts the array in ascending order, using the GetMax method: ");
        SortAscending(array);
        foreach (var item in array)
        {
            Console.Write("{0} ", item);
        }
    }

    // Returns the index of the biggest element in an array between certain index and the end of the array
    static int GetMax(int[] array, int index)
    {
        int max = int.MinValue;
        if (index < 0 || index >= array.Length)
        {
            Console.WriteLine("Out of range.");
            return -1;
        }
        for (int i = index; i < array.Length; i++)
        {
            if (array[i] > max)
            {
                max = array[i];
                index = i;
            }
        }
        return index;
    }

    static void SortDescending(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            int index = GetMax(array, i);
            SwapElements(array, i, index);
        }
    }

    static void SortAscending(int[] array)
    {
        // The GatMax method is called indirectly!
        SortDescending(array);
        int[] temp = new int[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            temp[i] = array[array.Length - 1 - i]; 
        }
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = temp[i];
        }
    }

    static void SwapElements(int[] array, int first, int second)
    {
        int temp = array[first];
        array[first] = array[second];
        array[second] = temp;
    }
}