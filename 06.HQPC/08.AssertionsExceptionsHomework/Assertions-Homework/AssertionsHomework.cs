using System;
using System.Linq;
using System.Diagnostics;
using System.Collections;

class AssertionsHomework
{
    /// <summary>
    /// Sorts the elements in an entire one-dimensional array using the IComparable<T> generic
    /// interface implementation of each element of the Array by using the Selection sort
    /// algorithm.
    /// </summary>
    /// <typeparam name="T">A type implementing the IComparable interface.</typeparam>
    /// <param name="arr">The array to sort.</param>
    public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
    {
        for (int index = 0; index < arr.Length - 1; index++)
        {
            int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
            Swap(ref arr[index], ref arr[minElementIndex]);
        }

        Debug.Assert(ArraySortedAscending(arr), "Array not sorted in ascending order!");
    }

    // Custom method. Checks if an array is sorted in ascending order.
    private static bool ArraySortedAscending<T>(T[] arr) where T : IComparable<T>
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            if ((dynamic)arr[i] > arr[i + 1])
            {
                return false;
            }
        }

        return true;
    }

    private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        Debug.Assert(startIndex >= 0, "Start index must be 0 or bigger!");
        Debug.Assert(startIndex < arr.Length, "Start index should be smaller than the array's length!");
        Debug.Assert(endIndex >= startIndex, "End index must be equal to or bigger than the start index!");
        Debug.Assert(endIndex < arr.Length, "End index should be smaller than the array's length!");

        int minElementIndex = startIndex;
        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (arr[i].CompareTo(arr[minElementIndex]) < 0)
            {
                minElementIndex = i;
            }
        }

        Debug.Assert(minElementIndex >= 0 && minElementIndex <= endIndex,
                    "Retruend index is outside the boundaries of the array!");
        return minElementIndex;
    }

    private static void Swap<T>(ref T x, ref T y)
    {
        T oldX = x;
        x = y;
        y = oldX;
    }

    /// <summary>
    /// Returns the index of an element in a sorted array.
    /// </summary>
    /// <typeparam name="T">An IComparable type.</typeparam>
    /// <param name="arr">The sorted array to search.</param>
    /// <param name="value">The element to search for.</param>
    /// <returns>An integer value indicating the index of the value or -1 if not found.</returns>
    public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
    {
        Debug.Assert(ArraySortedAscending(arr), "Input array not in ascending order!");
        return BinarySearch(arr, value, 0, arr.Length - 1);
    }

    private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        while (startIndex <= endIndex)
        {
            int midIndex = (startIndex + endIndex) / 2;
            if (arr[midIndex].Equals(value))
            {
                return midIndex;
            }
            if (arr[midIndex].CompareTo(value) < 0)
            {
                // Search on the right half
                startIndex = midIndex + 1;
            }
            else
            {
                // Search on the right half
                endIndex = midIndex - 1;
            }
        }

        // Searched value not found
        return -1;
    }

    static void Main()
    {
        int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
        Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
        SelectionSort(arr);
        Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

        SelectionSort(new int[0]); // Test sorting empty array
        SelectionSort(new int[1]); // Test sorting single element array

        Console.WriteLine(BinarySearch(arr, -1000));
        Console.WriteLine(BinarySearch(arr, 0));
        Console.WriteLine(BinarySearch(arr, 17));
        Console.WriteLine(BinarySearch(arr, 10));
        Console.WriteLine(BinarySearch(arr, 1000));
    }
}
