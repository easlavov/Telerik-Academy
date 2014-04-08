/*    * The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times. Write a program to find the majorant of given array (if exists). Example:
{2, 2, 3, 3, 2, 3, 4, 3, 3}  3*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class FindMajorant
{
    static void Main()
    {
        Console.Write("First array is: ");
        int[] array = { 2, 2, 3, 3, 2, 3, 4, 3, 3 };
        PrintArr(array);
        PrintMajorant(array);

        Console.Write("Second array is: ");
        int[] array2 = { 2, 2, 3, 2, 3, 4, 3, 3 };
        PrintArr(array2);
        PrintMajorant(array2);
    }
  
    private static void PrintMajorant(int[] array)
    {
        int majorant;
        bool majorantExists = FindMaj(array, out majorant);
        if (majorantExists)
        {
            Console.WriteLine("The majorant is: " + majorant);
        }
        else
        {
            Console.WriteLine("There is no majorant in the array.");
        }
    }

    private static bool FindMaj(int[] array, out int majorant)
    {
        int length = array.Length;
        Dictionary<int, int> counter = new Dictionary<int, int>();
        foreach (var num in array)
        {
            if (counter.ContainsKey(num))
            {
                counter[num]++;
                if (counter[num] > length/2)
                {
                    majorant = num;
                    return true;
                }
            }
            else
            {
                counter.Add(num, 1);
            }
        }
        majorant = 0;
        return false;
    }

    private static void PrintArr(int[] array)
    {
        foreach (var num in array)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }
}