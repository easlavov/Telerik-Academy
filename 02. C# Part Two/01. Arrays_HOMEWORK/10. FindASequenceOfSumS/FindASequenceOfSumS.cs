// Write a program that finds in given array of integers a sequence of given sum S (if present). 
// Example:	{4, 3, 1, 4, 2, 5, 8}, S=11 -> {4, 2, 5}

using System;
using System.Collections.Generic;

class FindASequenceOfSumS
{
    static void Main()
    {
        // Print what the program does
        Console.WriteLine("This program finds in given array of integers a sequence of given sum S (if present)");
        Console.WriteLine();

        // Instruct user to enter array length, its elements and the sum S
        Console.Write("Enter array length: ");
        int length = int.Parse(Console.ReadLine());
        int[] array = new int[length];
        for (int i = 0; i < length; i++)
        {
            Console.Write("Enter element [{0}]: ", i);
            array[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine();
        Console.Write("Please, enter sum S: ");
        int s = int.Parse(Console.ReadLine());

        // Print the array for convenience
        if (array.Length > 0)
        {            
            Console.WriteLine("These are the elements of the array: ");
            foreach (var number in array)
            {
                Console.Write("{0} ", number);
            }
            Console.WriteLine();
        }

        // Calculate all possible sums of consecutive numbers only!
        // We use the property of the binary numbers that they have either 1's or 0's
        int max = (int)((Math.Pow(2, array.Length) - 1));

        // This list holds all combinations of consecutive numbers that add up to S
        List<int> result = new List<int>();

        // This loop goes over all the possible combination of consecutive elements
        for (int i = 1; i <= max; i++)
        {
            // This method checks if a binary number's 1 bits are consecutive. If not, we don't use that number and skip to the next.
            if (FindIfNumberHasOnlyConsecutive1Bits(i) == false)
            {
                continue;
            }
            else
            {
                long currentSum = 0;
                // Every bit with value 1 at position 'p' in number 'i' corresponds to the 'p' element in the numbers array.
                for (int p = 0; p < array.Length; p++)
                {
                    int mask = 1;
                    mask <<= p;
                    mask &= i;
                    mask >>= p;
                    if (mask == 1)
                    {
                        currentSum += array[p];
                    }
                }
                if (currentSum == s)
                {
                    result.Add(i);
                }
            }
        }

        if (result.Count > 0)
        {
            // We use the numbers stored in the 'result' List to print all sequences of consecutive numbers that add up to S
            Console.WriteLine("The sequence(s) with sum {0} in the array is/are: ", s);
            for (int i = 0; i < result.Count; i++)
            {
                int combination = result[i];
                Console.WriteLine("Sequence {0}:", i + 1);
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
            }
        }
        else if (array.Length == 0)
        {
            Console.WriteLine("The array is empty.");
        }
        else
        {
            Console.WriteLine("No sequence in the array sums up to {0}.", s);
        }
    }

    private static bool FindIfNumberHasOnlyConsecutive1Bits(int keyNumber)
    {
        string str = Convert.ToString(keyNumber, 2);
        string inversed = "";
        for (int i = 0; i < str.Length; i++)
        {
            inversed += str[str.Length - 1 - i];
        }
        bool hasOnlyConsecutive1Bits = true;
        for (int i = 0; i < inversed.Length; i++)
        {
            if (inversed[i] == '1')
            {
                for (int j = 0; j < inversed.Length - i; j++)
                {
                    if (inversed[i + j] == '0')
                    {
                        hasOnlyConsecutive1Bits = false;
                        break;
                    }
                }
                if (hasOnlyConsecutive1Bits == false)
                {
                    break;
                }
            }
        }
        return hasOnlyConsecutive1Bits;
    }
}