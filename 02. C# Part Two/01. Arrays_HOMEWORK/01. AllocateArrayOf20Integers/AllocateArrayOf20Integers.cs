/* TASK:
 * Write a program that allocates array of 20 integers and initializes each 
 * element by its index multiplied by 5. Print the obtained array on the console.
*/

using System;

class AllocateArrayOf20Integers
{
    static void Main()
    {
        // Declare an int array with 20 elements:
        int[] array = new int[20];

        /* Execute a 'for' loop to initialize the array's elements.
         * int i corresponds to the array index.
         * The value of each element is equal to its index value multiplied by 5.                 
        */
        for (int i = 0; i < 20; i++)
        {
            array[i] = i * 5;
        }

        // Print the entire array in a comprehensive format:
        Console.WriteLine("This program allocates array of 20 integers and " + 
            "initializes each element by its index multiplied by 5.");
        Console.WriteLine();

        for (int i = 0; i < 20; i++)
        {
            Console.WriteLine("array [{0}] = {1}", i, array[i]);
        }
    }
}