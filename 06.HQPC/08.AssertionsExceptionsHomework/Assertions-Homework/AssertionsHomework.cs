using System;
using System.Linq;
using System.Diagnostics;

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
        for (int index = 0; index < arr.Length-1; index++)
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
        int minElementIndex = startIndex;
        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (arr[i].CompareTo(arr[minElementIndex]) < 0)
            {
                minElementIndex = i;
            }
        }

        Debug.Assert();
        return minElementIndex;
    }

    private static void Swap<T>(ref T x, ref T y)
    {
        T oldX = x;
        x = y;
        y = oldX;
    }

    public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
    {
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
