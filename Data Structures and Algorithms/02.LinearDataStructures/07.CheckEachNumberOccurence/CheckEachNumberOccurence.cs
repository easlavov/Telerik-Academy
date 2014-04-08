/*Write a program that finds in given array of integers (all belonging to the range [0..1000]) how many times each of them occurs.
Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2}*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CheckEachNumberOccurence
{
    static void Main()
    {
        int[] array = { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
        Console.Write("The array is: ");
        PrintArr(array);        
        DisplayOccurence(array);
    }

    private static void DisplayOccurence(int[] array)
    {
        int[] countArray = new int[1001];
        foreach (var num in array)
        {
            countArray[num]++;
        }
        for (int i = 0; i < countArray.Length; i++)
        {
            if (countArray[i] > 0)
            {
                string info = string.Format("Number {0} appears {1} time(s)", i, countArray[i]);
                Console.WriteLine(info);
            }
        }
    }

    private static void PrintArr(int[] array)
    {
        Console.Write("The array is: ");
        foreach (var num in array)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }
}