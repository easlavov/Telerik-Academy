/*Write a program that reads a sequence of integers (List<int>) ending with an empty line and sorts them in an increasing order.*/

using System;
using System.Collections.Generic;

class SortIncreasing
{
    static void Main()
    {
        List<int> sequence = ReadIntegers();
        sequence.Sort(); // I'm not lazy! 
        Console.WriteLine("The sorted sequence is: ");
        foreach (var num in sequence)
        {
            Console.Write(num + ", ");
        }
        Console.WriteLine();
    }

    private static List<int> ReadIntegers()
    {
        Console.WriteLine("Please, enter as many integer numbers as you'd like and press Enter when finnished. Enter only one number per line:");
        List<int> sequence = new List<int>();
        string input = Console.ReadLine();
        while (input != string.Empty)
        {
            int num = -1;
            try
            {
                num = int.Parse(input);               
                sequence.Add(num);
                Console.WriteLine(input + " successfully added!");
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("You should only enter integer numbers!");
            }

            input = Console.ReadLine();
        }
        Console.WriteLine("The numbers you entered are: " + string.Join(", ", sequence));
        return sequence;
    }
}