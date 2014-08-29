using System;
using System.Collections.Generic;

class ReverseIntegers
{
    static void Main()
    {
        Console.Write("Please, enter the number of integers you want read from the console: ");
        int total = int.Parse(Console.ReadLine());
        Stack<int> stack = new Stack<int>();
        for (int i = 0; i < total; i++)
        {
            Console.Write(String.Format("Number {0}: ", i+1));
            stack.Push(int.Parse(Console.ReadLine()));
        }

        Console.Write("The reversed numbers are: ");
        for (int i = 0; i < total; i++)
        {
            Console.Write(stack.Pop() + ", ");
        }

        Console.WriteLine();
    }
}