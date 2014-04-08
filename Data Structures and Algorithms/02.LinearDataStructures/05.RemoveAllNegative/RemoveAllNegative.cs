/*Write a program that removes from given sequence all negative numbers.*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class RemoveAllNegative
{
    static void Main()
    {
        List<int> t = new List<int>() { 1, 5, -3, 4, 1, -14, -14, -7 };
        Console.WriteLine("The original list is:");
        PrintList(t);        
        t = RemoveNegativeNumbers(t);
        Console.WriteLine("The list without negative elements is:");
        PrintList(t);
    }

    static T[] RemoveNegativeNumbers<T>(T[] sequence) where T : IComparable<T>
    {
        LinkedList<T> result = new LinkedList<T>();
        foreach (var number in sequence)
        {
            result.AddLast(number);
        }
        dynamic comparator = 0;
        var current = result.First;
        while (current != null)
        {
            if (current.Value < comparator)
            {
                var next = current.Next;
                result.Remove(current);
                current = next;
                continue;
            }
            current = current.Next;
        }        
        return result.ToArray<T>();
    }

    static List<T> RemoveNegativeNumbers<T>(List<T> sequence) where T : IComparable<T>
    {
        return RemoveNegativeNumbers(sequence.ToArray()).ToList<T>();
    }

    private static void PrintList(List<int> testList1Longest)
    {
        foreach (var number in testList1Longest)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine();
    }
}