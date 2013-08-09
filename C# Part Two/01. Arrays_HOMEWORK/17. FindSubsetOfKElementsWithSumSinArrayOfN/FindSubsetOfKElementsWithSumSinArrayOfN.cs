// * Write a program that reads three integer numbers N, K and S and 
// an array of N elements from the console. Find in the array a subset 
// of K elements that have sum S or indicate about its absence.

using System;

class FindSubsetOfKElementsWithSumSinArrayOfN
{
    static void Main()
    {
        // Print what the program does
        Console.WriteLine("This program finds a subset of K elements that have sum S.");
        Console.WriteLine();

        // Instruct user to enter array length and numbers
        Console.Write("Enter array length N: ");
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter element [{0}]: ", i);
            array[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("Enter number of elements (K): ");
        int k = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter sum (S): ");
        int s = int.Parse(Console.ReadLine());

        
        // Calculate all possible sums of K numbers only!
        // We use the property of the binary numbers that they have either 1's or 0's
        int max = (int)((Math.Pow(2, array.Length) - 1));

        // This variable holds the combination of K elements 
        int combination = 0;

        // This loop goes over all the possible combination of K elements
        for (int i = 1; i <= max; i++)
        {
            // This method checks if a binary number's 1 bits are K. If not, we don't use it.
            if (FindIfNumberHasOnlyK1Bits(i, k) == false)
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
                if (currentSum == s)
                {
                    combination = i;
                    break;
                }
            }
        }

        if (combination > 0)
        {
            // We use the previously stored number in the 'combination' variable to print the same sequence as the result
            Console.WriteLine("Array elements that add up to {0} are are: ", s);
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
        else
        {
            Console.WriteLine("There are no {0} elements that add up to {1}.", k, s);
        }
        
    }

    // Find if a number has only one sequence of consecutive 1 bits
    private static bool FindIfNumberHasOnlyK1Bits(int keyNumber, int k)
    {
        string str = Convert.ToString(keyNumber, 2);
        
        bool hasK1Bits = true;
        int countOf1 = 0;
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] == '1')
            {
                countOf1++;
            }
        }
        if (countOf1 != k)
        {
            hasK1Bits = false;
        }
        return hasK1Bits;
    }
}