// Write a program that finds the most frequent number in an array.
// Example:	{4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3} -> 4 (5 times)

using System;

class FindMostFrequentNumberInAnArray
{
    static void Main()
    {
        // Print what the program does:
        Console.WriteLine("This program finds the most frequent number in an array.");
        Console.WriteLine();

        // Instruct user to fill an array
        Console.Write("Please, enter array size: ");
        int size = int.Parse(Console.ReadLine());
        int[] array = new int[size];
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("Enter element [{0}]: ", i);
            array[i] = int.Parse(Console.ReadLine());
        }

        // Sort the array
        Array.Sort(array);

        // Find the most frequent number
        int currentNumber = array[0];
        int currentSequence = 1;
        // The value of this variable corresponds to the frequency of the number
        int longestSequence = 0;
        int mostFrequentNumber = 0;

        // Consecutive numbers are counted. 
        // If a sequence of numbers is the longest, it's 
        // member and length are stored in the variables above.
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] == currentNumber)
            {
                currentSequence++;
                // Every time a longer sequence is found it becomes the longest
                if (currentSequence > longestSequence)
                {
                    longestSequence = currentSequence;
                    mostFrequentNumber = array[i];
                }
            }
            else
            {
                // Restarts the counting for the new sequence.
                currentSequence = 1;
            }
            currentNumber = array[i];
        }

        // Print the result
        if (longestSequence > 1)
        {
            Console.WriteLine("The most frequent number in the array is {0}", mostFrequentNumber);
            Console.WriteLine("It appears {0} times.", longestSequence);
        }
        else
        {
            Console.WriteLine("No number appears more times than the others.");
        }
    }
}