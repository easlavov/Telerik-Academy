/*Write a method that finds the longest subsequence of equal numbers in given List<int> and returns the result as new List<int>. Write a program to test whether the method works correctly.*/

using System;
using System.Collections.Generic;
using System.Linq;

class FindLongestSubsequenceOfEqualNumbers
{
    static void Main()
    {
        // first test
        List<int> testList1 = new List<int>() { 5, 7, 3, 1, 1, 3, 3, 4, 5, 12, 12, 3, 3, 3, 3, 4, 2, 2, 3, 3, 33, 5, 6, 6, 6, 6, 6 };
        Console.WriteLine("The first test list is:");
        PrintList(testList1);
        List<int> testList1Longest = LongSubsEqEl(testList1);
        Console.WriteLine("The longest sequence of equal elements is:");
        PrintList(testList1Longest);
        Console.WriteLine();

        // second test
        List<int> testList2 = new List<int>() { 2 };
        Console.WriteLine("The second test list is:");
        PrintList(testList2);
        List<int> testList2Longest = LongSubsEqEl(testList2);
        Console.WriteLine("The longest sequence of equal elements is:");
        PrintList(testList2Longest);
        Console.WriteLine();

        // third test
        List<int> testList3 = new List<int>() { -4, 15, 23, 8, 10, 16, 23 };
        Console.WriteLine("The third test list is:");
        PrintList(testList3);
        List<int> testList3Longest = LongSubsEqEl(testList3);
        Console.WriteLine("The longest sequence of equal elements is:");
        PrintList(testList3Longest);
        Console.WriteLine();

        // first test
        List<int> testList4 = new List<int>() { 5, 7, 3, 1, 1, 3, 3, 4, 5, 12, 12, 3, 3, 3, 3, 4, 2, 2, 3, 3, 33, 5, 6, 6 };
        Console.WriteLine("The fourth test list is:");
        PrintList(testList4);
        List<int> testList4Longest = LongSubsEqEl(testList4);
        Console.WriteLine("The longest sequence of equal elements is:");
        PrintList(testList4Longest);
        Console.WriteLine();
    }

    private static void PrintList(List<int> testList1Longest)
    {
        foreach (var number in testList1Longest)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine();
    }

    static List<int> LongSubsEqEl(List<int> list)
    {
        if (list.Count == 0)
        {
            throw new ArgumentException("The list is empty");
        }

        int currentNumber = list[0];
        int currentSequence = 0;
        int numberInLongestSequence = 0;
        int longestSequence = 0;

        foreach (var number in list)
        {
            if (number == currentNumber)
            {
                currentSequence++;
                if (currentSequence > longestSequence)
                {
                    longestSequence = currentSequence;
                    numberInLongestSequence = currentNumber;
                }
            }
            else
            {
                currentNumber = number;
                currentSequence = 1;
            }
        }

        List<int> result = new List<int>();
        for (int i = 0; i < longestSequence; i++)
        {
            result.Add(numberInLongestSequence);
        }

        return result;
    }
}