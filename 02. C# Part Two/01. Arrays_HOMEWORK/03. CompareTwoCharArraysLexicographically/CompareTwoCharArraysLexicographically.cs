// Write a program that compares two char arrays lexicographically (letter by letter).

using System;

class CompareTwoCharArraysLexicographically
{
    static void Main()
    {
        // Print what the program does:
        Console.WriteLine("This program compares two char arrays lexicographically.");
        Console.WriteLine();

        // Declare two char arrays with hard-coded elements:
        char[] firstArray = { 'A', '%', 'g', '<', '!' };
        char[] secondArray = { '5', '%', 'G', '~', '!' };

        // Print both arrays
        Console.Write("First array: ");
        for (int i = 0; i < firstArray.Length; i++)
        {
            Console.Write("{0} ", firstArray[i]);
        }
        Console.WriteLine();
        Console.Write("First array: ");
        for (int i = 0; i < secondArray.Length; i++)
        {
            Console.Write("{0} ", secondArray[i]);
        }
        Console.WriteLine();
        Console.WriteLine();

        // Compare the two char arrays. Return if same or different
        Console.WriteLine("Checking if chars in the same position are the same or different:");
        for (int i = 0; i < firstArray.Length; i++)
        {
            Console.Write("The characters with index [{0}] in the two arrays are ", i);
            if (firstArray[i] == secondArray[i])
            {
                Console.WriteLine("the same.");
            }
            else
            {
                Console.WriteLine("different.");
            }
        }
        Console.WriteLine();

        // Alternative approach
        // Compare char's codes
        Console.WriteLine("Comparing char's codes:");
        for (int i = 0; i < firstArray.Length; i++)
        {
            Console.Write("The characters with index [{0}] in the two arrays are ", i);
            if (firstArray[i] == secondArray[i])
            {
                Console.WriteLine("the same.");
            }
            if (firstArray[i] > secondArray[i])
            {
                Console.WriteLine("different - the first array's char code is bigger.");
            }
            if (firstArray[i] < secondArray[i])
            {
                Console.WriteLine("different - the second array's char code is bigger.");
            }
        }
    }
}