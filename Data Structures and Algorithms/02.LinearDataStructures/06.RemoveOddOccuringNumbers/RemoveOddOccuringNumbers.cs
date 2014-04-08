/*Write a program that removes from given sequence all numbers that occur odd number of times. Example:
{4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2}  {5, 3, 3, 5}*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class RemoveOddOccuringNumbers
{
    static void Main()
    {
        int[] array = { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };
        PrintArr(array);
        Console.WriteLine("Applying algorithm to remove odd-occuring numbers from the array.");
        RemoveOddOccuringNums(ref array);
        PrintArr(array);
    } 
    
  
    private static void RemoveOddOccuringNums(ref int[] array)
    {
        // Check and store how many times each number appears in the array.
        Dictionary<int, int> counter = new Dictionary<int, int>();
        foreach (var num in array)
        {
            if (counter.ContainsKey(num))
            {
                counter[num]++;
            }
            else
            {
                counter.Add(num, 1);
            }
        }
        // Copying each number from the original array to a new list if it appears odd number of times (checking in the dict)
        List<int> newArr = new List<int>();
        foreach (var num in array)
        {
            if (counter[num] % 2 == 0)
            {
                newArr.Add(num);
            }
        }

        array = newArr.ToArray();
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