// * Write a program that reads an array of integers and removes from it 
// a minimal number of elements in such way that the remaining array is sorted in 
// increasing order. Print the remaining sorted array. Example:
// {6, 1, 4, 3, 0, 3, 6, 4, 5} -> {1, 3, 3, 4, 5}

using System;
using System.Collections.Generic;

class RemoveMinNumberOfElementsToMakeArrayIncreasingOrder
{
    static void Main()
    {
        // Print what the program does
        Console.WriteLine("This program reads an array of integers and removes from it a minimal number of elements in such way that the remaining array is sorted in increasing order.");
        Console.WriteLine();        

        // Declare and fill an array of integers
        Console.Write("Please, enter the size of the array: ");
        int size = int.Parse(Console.ReadLine());
        int[] array = new int[size];
        for (int i = 0; i < size; i++)
        {
            Console.Write("Please, enter array [{0}]: ", i);
            array[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine();

        // This will hold the combination of removed elements that fulfills the reqirement of the task
        int combination = 0;

        // The less, the better. This variable's initial value is set to the maximum possible
        // During the execution of the program it will progressively decrease.
        int countOfRemovedElements = array.Length;

        // Solve
        // Calculate all possible sums        
        int max = (int)((Math.Pow(2, array.Length) - 1));

        // This loop goes over all the possible combination
        for (int i = 1; i <= max; i++)
        {
            // Create a list that will hold the sequence with remove elements
            List<int> test = new List<int>();
            // We use the property of the binary numbers that they have either 1's or 0's
            // in order to go through all possible combinations of removed numbers
            for (int p = 0; p < array.Length; p++)
            {
                int mask = 1;
                mask <<= p;
                mask &= i;
                mask >>= p;
                if (mask == 1)
                {
                    test.Add(array[p]);
                }
            }
            bool isListInIncreasingOrder = CheckIfListIsInIncreasingOrder(test);
            // If the numbers are in increasing order...
            if (isListInIncreasingOrder == true)
            {
                // ... we compare the size of the new array with the size of the original
                // in order to determine the count of removed elements.
                int difference = array.Length - test.Count;
                // If it is less than the previously achieved minimum, the minimum is changed
                if (difference < countOfRemovedElements)
                {
                    countOfRemovedElements = difference;
                    combination = i;
                }
            }
        }

        Console.WriteLine("The program removed {0} elements.", countOfRemovedElements);
        Console.WriteLine("The new sequence looks like this: ");
        for (int p = 0; p < array.Length; p++)
        {
            int mask = 1;
            mask <<= p;
            mask &= combination;
            mask >>= p;
            if (mask == 1)
            {
                Console.Write("{0} ", array[p]);
            }
        }
        Console.WriteLine();
        // END
    }

    private static bool CheckIfListIsInIncreasingOrder(List<int> test)
    {
        bool legit = true;
        for (int i = 1; i < test.Count; i++)
        {
            // Consecutive equal elements are considered to be in increasing order (see example!)
            if (test[i] < test[i - 1])
            {
                legit = false;
                break;
            }
        }
        return legit;
    }
}
