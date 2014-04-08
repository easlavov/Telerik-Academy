// * Write a program that sorts an array of integers using the 
// merge sort algorithm.

using System;

class SortIntArrayUsingMergeSortAlgorithm
{
    static void Main()
    {
        // Print what the program does
        Console.WriteLine("This program sorts an array of integers using the \"merge sort\" algorithm.");
        Console.WriteLine();

        // Declare an array. To test, edit the code directly!
        int[] array = { 3, 2, 5, 0, 4, 1, 6, -1, 15, -1, 3, 2, 4, 67, -56 };
        Console.WriteLine("This is the unsorted array:");
        foreach (var item in array)
        {
            Console.Write("{0} ", item);
        }
        Console.WriteLine();

        // Call the 'split' method
        array = Split(array, 0, array.Length);

        // Print result
        Console.WriteLine("This is the sorted array:");
        foreach (var item in array)
        {
            Console.Write("{0} ", item);
        }
        Console.WriteLine();

    }

    // Contains the splitting, sorting and merging algorithms
    static int[] Split(int[] arr, int low, int high)
    {
        // Splitting part:
        
        // This is the bottom of the recursion
        if (high == 1)
        {
            return arr;
        }

        // Arrays are split in two until only single element arrays remain. Recursion is used.
        int mid = high / 2;
        int lengthLow, lengthHigh;
        if (high % 2 == 0)
        {
            lengthLow = high / 2;
            lengthHigh = lengthLow;
        }
        else
        {
            lengthLow = high / 2 + 1;
            lengthHigh = high / 2;
        }
        int[] lowArray = new int[lengthLow];
        for (int i = 0; i < lowArray.Length; i++)
        {
            lowArray[i] = arr[i];
        }
        int[] highArray = new int[lengthHigh];
        for (int i = 0; i < highArray.Length; i++)
        {
            if (high % 2 == 0)
            {
                highArray[i] = arr[mid + i];
            }
            else
            {
                highArray[i] = arr[mid + i + 1];
            }
        }
        // Split the remaining arrays using recursion
        Split(lowArray, 0, lowArray.Length);
        Split(highArray, 0, highArray.Length);

        // Sorting part

        int index = 0;
        int pos1 = 0;
        int pos2 = 0;

        // Array elements from both arrays are compared and moved into the resulting array
        while (true)
        {
            if (lowArray[pos1] <= highArray[pos2])
            {
                arr[index] = lowArray[pos1];
                pos1++;
                if (pos1 == lowArray.Length)
                {
                    pos1--;
                    lowArray[pos1] = int.MaxValue;
                }
            }
            else
            {
                arr[index] = highArray[pos2];
                pos2++;
                if (pos2 == highArray.Length)
                {
                    pos2--;
                    highArray[pos2] = int.MaxValue;
                }
            }
            index++;
            if (index == arr.Length)
            {
                break;
            }

        }
        // Resulting array is returned to be compared to another until we have only one array left - the sorted one
        return arr;
    }
}