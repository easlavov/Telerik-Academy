// You are given an array of strings. Write a method that sorts the array by the 
// length of its elements (the number of characters composing them).

using System;

class MethodToSortAStringArrayByTheLengthOfItsElements
{
    static void Main()
    {
        // Print what the program does
        Console.WriteLine("This program tests the funcitonality of a method that sorts a string array by the length of its elements.");
        Console.WriteLine();

        // Declare and array of strings and print it
        string[] strArr = 
        {
            "advocate", "do", "while", "ball", "me", "I", "sport", "lemon", "no", "Africa", "self"
        };
        Console.WriteLine("Unsorted array: ");
        foreach (var str in strArr)
        {
            Console.WriteLine("{0}({1}) ", str, str.Length);
        }
        Console.WriteLine();

        // The sorting method uses the 'selection sort' algorithm        
        SortStringArrayByLengthOfElements(strArr);
        Console.WriteLine("Sorted array: ");
        foreach (var str in strArr)
        {
            Console.WriteLine("{0}({1}) ", str, str.Length);
        }
        Console.WriteLine();
    }

    static void SortStringArrayByLengthOfElements(string[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            for (int p = 1; p < array.Length - i; p++)
            {
                if (array[i].Length > array[i+p].Length)
                {
                    string temp = array[i];
                    array[i] = array[i + p];
                    array[i + p] = temp;
                }
            }
        }
    }
}