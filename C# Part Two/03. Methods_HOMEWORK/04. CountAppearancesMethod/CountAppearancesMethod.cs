// Write a method that counts how many times given number appears in given array. 
// Write a test program to check if the method is working correctly.

using System;

class CountAppearancesMethod
{
    // Test program
    static void Main(string[] args)
    {
        Console.WriteLine("This program tests a method that checks how many times a given number appears in a given array.");
        Console.WriteLine();
        Console.Write("Please, enter array size: ");
        int[] array = new int[int.Parse(Console.ReadLine())];
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("Enter array[{0}]: ", i);
            array[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine();
        Console.Write("Please, enter the number which appearences you want counted: ");
        int number = int.Parse(Console.ReadLine());
        int appearances = CountAppear(array, number);
        Console.WriteLine("The number {0} appears {1} times in the array.", number, appearances);
    }

    // Method
    static int CountAppear(int[] array, int number)
    {
        int counter = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == number)
            {
                counter++;
            }
        }
        return counter;
    }
}