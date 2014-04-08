// Write a program that finds the sequence of maximal sum in given array.
// Example: {2, 3, -6, -1, 2, -1, 6, 4, -8, 8} -> {2, -1, 6, 4}
// Can you do it with only one loop (with single scan through the elements of the array)?

using System;

class FindSequenceOfMaximalSum
{
    static void Main()
    {
        // Print what the program does
        Console.WriteLine("This program finds the sequence of maximal sum in given array.");
        Console.WriteLine();

        // Instruct user to enter array length and numbers
        Console.Write("Enter array length: ");
        int length = int.Parse(Console.ReadLine());
        int[] array = new int[length];
        for (int i = 0; i < length; i++)
        {
            Console.Write("Enter element [{0}]: ", i);
            array[i] = int.Parse(Console.ReadLine());
        }

        // Print the array for convenience
        Console.WriteLine("These are the elements of the array: ");
        foreach (var number in array)
        {
            Console.Write("{0} ", number);
        }
        Console.WriteLine();

        // Calculate all possible sums of consecutive numbers only!
        // We use the property of the binary numbers that they have either 1's or 0's
        int max = (int)((Math.Pow(2, array.Length) - 1));
        long maxSum = 0;
        // This variable holds the combination of array elements (as 1's in its binary representation)
        // that has the biggest value.
        int combination = 0;

        // This loop goes over all the possible combination of consecutive elements
        for (int i = 1; i <= max; i++)
        {
            // This method checks if a binary number's 1 bits are consecutive. If not, we don't use it.
            if (FindIfNumberHasOnlyConsecutive1Bits(i) == false)
            {
                continue;
            }
            else
            {
                long currentSum = 0;
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
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    combination = i;
                }
            }
        }

        // We use the previously stored number in the 'combination' variable to print the same sequence as the result
        Console.WriteLine("The sequence with maximal sum in the array is: ");
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
    }

    // Find if a number has only one sequence of consecutive 1 bits
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