// Write a program that finds the maximal increasing sequence in an array.  
// Example: {3, 2, 3, 4, 2, 2, 4} -> {2, 3, 4}.

using System;

class FindTheMaximalIncreasingSequenceInAnArray
{
    static void Main()
    {
        // Print what the program does:
        Console.WriteLine("This program finds the maximal increasing sequence in an array.");
        Console.WriteLine();

        // Instruct user to enter the length of the array:
        Console.Write("Please, write the length of the array: ");
        int arrayLength = int.Parse(Console.ReadLine());
        int[] array = new int[arrayLength];
        Console.Write("Please, enter all array elements: ");
        Console.WriteLine();
        for (int i = 0; i < arrayLength; i++)
        {
            Console.Write("array [{0}] = ", i);
            array[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("All elements have been entered.");
        Console.WriteLine();
        Console.Write("The elements of the array are: ");
        for (int i = 0; i < arrayLength; i++)
        {
            if (i == arrayLength - 1)
            {
                Console.Write("{0}", array[i]);
                continue;
            }
            Console.Write("{0}, ", array[i]);
        }
        Console.WriteLine();

        // This variable holds the count of the longest sequence
        int maxSequenceLength = 0;
        // This variable holds the index of the biggest element in the longest sequence
        int indexOfBiggestNumberInTheLongestSequence = 0;
        // This variable holds the length of the sequence the loop is currently processing
        int currentSequence = 0;

        // This loop scans the whole sequence.
        for (int i = 0; i < array.GetLength(0); i++)
        {
            // The first path is accessed only for the first element in the sequence
            if (i == 0)
            {
                maxSequenceLength++;
                indexOfBiggestNumberInTheLongestSequence = i;
                currentSequence++;
            }
            // The following code is executed for all other elements (with index > 0) 
            else
            {
                // Compare the current element (i) with the previous
                if (array[i] > array[i - 1])
                {
                    // The variable that counts the number of elements in a sequence is increased by 1 with each bigger consecutive element
                    currentSequence++;
                    // This conditional ensures we have the highest count stored in a variable
                    if (currentSequence > maxSequenceLength)
                    {
                        maxSequenceLength = currentSequence;
                        indexOfBiggestNumberInTheLongestSequence = i;
                    }
                }
                else
                // In case the current element is no bigger than the previous one, the current sequence is broken and a new one begins
                {
                    currentSequence = 1;
                }
            }
        }

        // Finally we print the longest sequence of increasing elements on the console:
        int startingIndex = (indexOfBiggestNumberInTheLongestSequence - maxSequenceLength) + 1;
        if (maxSequenceLength > 1)
        {
            Console.Write("The longest sequence of increasing elements is: ");
            for (int i = 0; i < maxSequenceLength; i++)
            {
                Console.Write("{0}, ", array[startingIndex + i]);
            }
        }
        else
        {
            Console.WriteLine("There is no sequence of increasing elements.");
        }
        Console.WriteLine();
    }
}