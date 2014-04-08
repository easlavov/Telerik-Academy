// Write a program that finds the index of given element in a sorted array of 
// integers by using the binary search algorithm (find it in Wikipedia).

using System;

class FindIndexOfGivenElementByUsingBinarySearch
{
    static void Main()
    {
        // Print what the program does
        Console.WriteLine("This program finds the index of given element in a sorted array" +
            "of integers by using the binary search algorithm.");
        Console.WriteLine();

        // Instruct user to enter the elements of the array
        Console.Write("Please, enter the size of the array: ");
        int size = int.Parse(Console.ReadLine());
        // Declare the array
        int[] array = new int[size];
        // Fill the array
        Console.WriteLine("Please, enter {0} numbers. Array will be sorted!", size);
        for (int i = 0; i < size; i++)
        {
            Console.Write("Enter number {0}: ", i);
            array[i] = int.Parse(Console.ReadLine());
        }
        // Sort the array in order to make binary search possible
        Array.Sort(array);
        // Ask the user to enter the number which index he's looking for in the array
        Console.Write("Please, enter the number to find where it's located in the array: ");
        int wantedNumber = int.Parse(Console.ReadLine());

        // Initiate a binary search using a 'while' loop
        // Declare required variables
        int minIndex = 0;
        int maxIndex = size - 1;
        int result = -1;
        // Binary search algorithm
        while (minIndex <= maxIndex)
        {
            int currentIndex = minIndex + (maxIndex - minIndex) / 2;
            if (array[currentIndex] == wantedNumber)
            {
                result = currentIndex;
                break;
            }
            if (array[currentIndex] < wantedNumber)
            {
                minIndex = currentIndex + 1;
            }
            if (array[currentIndex] > wantedNumber)
            {
                maxIndex = currentIndex - 1;
            }
        }
        // Print result
        if (result < 0)
        {
            Console.WriteLine("Number not found in array.");
        }
        else
        {
            Console.WriteLine("The number {0} is located in array[{1}].", wantedNumber, result);
        }
    }
}