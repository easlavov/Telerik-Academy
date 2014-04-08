// Write a program that sorts an array of strings using the quick sort algorithm.

using System;

class SortStrArrayUsingQuickSort
{
    static void Main()
    {
        // Print what the program does
        Console.WriteLine("This program sorts an array of strings using the quick sort algorithm");
        Console.WriteLine();

        // Instruct user to fill the array
        Console.Write("Please, enter the number of strings you'd like to add to the array: ");
        int number = int.Parse(Console.ReadLine());
        string[] array = new string[number];
        for (int i = 0; i < number; i++)
        {
            Console.Write("Please, enter string {0}: ", i + 1);
            array[i] = Console.ReadLine();
        }

        sort(array, 0, array.Length - 1);

        Console.WriteLine("This is the sorted array: ");
        foreach (var item in array)
        {
            Console.WriteLine("{0}", item);
        }
    }

    private static void sort(string[] array, int lower, int higher)
    {
        if ((higher - lower) <= 0)
        {
            return;
        }
        int splitPoint = split(array, lower, higher);
        // Smaller numbers subarray
        sort(array, lower, splitPoint - 1);
        // Bigger numbers subarray
        sort(array, splitPoint + 1, higher);
    }

    private static int split(string[] array, int lower, int higher)
    {
        int left = lower + 1;
        int right = higher;
        string pivot = array[lower];

        while (true)
        {
            // Move left 'cursor'
            while (left <= right)
            {
                if (array[left].CompareTo(pivot) < 0)
                {
                    left++;
                }
                else
                {
                    break;
                }
            }
            // Move right cursor
            while (right > left)
            {
                if (array[right].CompareTo(pivot) < 0)
                {
                    break;
                }
                else
                {
                    right--;
                }
            }
            if (left >= right)
            {
                break;
            }
            // Swap bigger with smaller
            string temp = array[left];
            array[left] = array[right];
            array[right] = temp;
            // Advance one step
            left++; right--;
        }
        // Move pivot to correct position
        array[lower] = array[left - 1];
        array[left - 1] = pivot;
        // Return the split point
        return (left - 1);
    }
}