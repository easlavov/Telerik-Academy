// * We are given an array of integers and a number S. Write a program to find if 
// there exists a subset of the elements of the array that has a sum S. 
// Example: arr={2, 1, 2, 4, 3, 5, 2, 6}, S=14 -> yes (1+2+5+6)

using System;

class Program
{
    static void Main()
    {
        // Print what the program does
        Console.WriteLine("This program finds if there exists a subset of elements of an array that has a sum S.");
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

        // Read sum S
        Console.WriteLine("Please, enter sum S: ");
        int sum = int.Parse(Console.ReadLine());
        Console.WriteLine();
        int combination = 0;

        // Solve
        // Calculate all possible sums        
        int max = (int)((Math.Pow(2, array.Length) - 1));

        // This loop goes over all the possible combination of consecutive elements
        for (int i = 1; i <= max; i++)
        {
            long currentSum = 0;
            // We use the property of the binary numbers that they have either 1's or 0's
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
            if (currentSum == sum)
            {
                combination = i;
                break;
            }
        }

        if (combination > 0)
        {
            Console.WriteLine("This subset equals {0}: ", sum);
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
            Console.WriteLine("There is no subset that equals {0}.", sum);
        }
        Console.WriteLine();
    }
}