/* Write a program that reads two arrays from the console and
 * compares them element by element.
 */

using System;

class CompareElementsOfTwoArrays
{
    static void Main()
    {
        // Print what the program does:
        Console.WriteLine("This program reads two arrays from the console and " +
        "compares them element by element.");
        Console.WriteLine();

        // Both arrays must be of the same length if we are to compare them element by element.
        // Instruct the user to enter the size of both arrays:
        Console.Write("Please, enter the length of the arrays: ");
        int arraySize = int.Parse(Console.ReadLine());
        Console.WriteLine();

        // Declare two double arrays. We use double in order to cover maximum range of comparable elements:
        double[] firstArray = new double[arraySize];
        double[] secondArray = new double[arraySize];

        // Instruct the user to enter the elements of the first array:
        Console.WriteLine("Please, enter the elements of the first array:");
        for (int i = 0; i < arraySize; i++)
        {
            Console.Write("firstArray [{0}] = ", i);
            firstArray[i] = double.Parse(Console.ReadLine());
        }
        Console.WriteLine();

        // Instruct the user to enter the elements of the second array:
        Console.WriteLine("Please, enter the elements of the second array:");
        for (int i = 0; i < arraySize; i++)
        {
            Console.Write("secondArray [{0}] = ", i);
            secondArray[i] = double.Parse(Console.ReadLine());
        }
        Console.WriteLine();

        // Compare the array's elements one by one:
        for (int i = 0; i < arraySize; i++)
        {
            Console.WriteLine("firstArray [{0}] = {1}, secondArray [{0}] = {2}. ", i, firstArray[i], secondArray[i]);
            if (firstArray[i] == secondArray[i])
            {
                Console.WriteLine("Both elements are equal.");
            }
            if (firstArray[i] > secondArray[i])
            {
                Console.WriteLine("The element of the first array is bigger.");
            }
            if (firstArray[i] < secondArray[i])
            {
                Console.WriteLine("The element of the second array is bigger.");
            }
            Console.WriteLine();
        }
    }
}