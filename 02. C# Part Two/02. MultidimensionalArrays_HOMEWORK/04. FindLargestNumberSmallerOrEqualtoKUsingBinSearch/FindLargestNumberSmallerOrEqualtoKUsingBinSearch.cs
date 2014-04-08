// Write a program, that reads from the console an array of N integers and an integer K,
// sorts the array and using the method Array.BinSearch() finds the largest number in the array which is ≤ K. 

using System;

class FindLargestNumberSmallerOrEqualtoKUsingBinSearch
{
    static void Main()
    {
        // Print what the program does
        Console.WriteLine("This program reads from the console an array of N integers and an integer K, sorts the array and using the method Array.BinSearch() finds the largest number in the array which is smaller than or equal to K.");
        Console.WriteLine();

        // Declare and fill an array of integers
        Console.Write("Please, enter size of the array: ");
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter array[{0}]: ", i);
            array[i] = int.Parse(Console.ReadLine());
        }
        // Read K
        Console.Write("Please, enter K: ");
        int k = int.Parse(Console.ReadLine());
        // Sort the array
        Array.Sort(array);
        // Print the array
        Console.WriteLine("This the sorted array:");
        foreach (var number in array)
        {
            Console.Write("{0} ", number);
        }
        Console.WriteLine();        
        // Search for k        
        int result = Array.BinarySearch(array, k);
        // If K is found, binary search returns a number >= 0 - the index of K
        if (result >= 0)
        {
            Console.WriteLine("The largest number in the array which is smaller than or equal to K is {0}", array[result]);
        }
        // Binary search returns a negative number if K can't be found.
        // The index of the smaller number is equal to the absoulte of return value minus 2:
        else
        {
            result = (int)(Math.Abs(result)-2);
            Console.WriteLine("The largest number in the array which is smaller or equal to K is {0}", array[result]);
        }        
    }
}