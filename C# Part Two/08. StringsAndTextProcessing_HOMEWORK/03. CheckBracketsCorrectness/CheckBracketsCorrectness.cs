// Write a program to check if in a given expression the brackets are put correctly.
// Example of correct expression: ((a+b)/5-d).
// Example of incorrect expression: )(a+b)).

using System;
using System.Collections.Generic;

class CheckBracketsCorrectness
{
    static void Main()
    {
        Console.WriteLine("This program checks if in a given expression the brackets are put correctly.");
        Console.WriteLine();

        // Input expression to be checked
        Console.Write("Please, enter the expression: ");
        string expression = "((a + b) / 5 - d*x-z(d))";
        Console.WriteLine(expression);

        // Check if brackets are correct by calling a method
        bool correctBrackets = CheckBrackets(expression);
        if (correctBrackets == true)
        {
            Console.WriteLine("The brackets are put correctly.");
        }
        else
        {
            Console.WriteLine("The brackets are put incorrectly.");
        }
    }

    private static bool CheckBrackets(string expression)
    {        
        List<char> list = new List<char>();
        for (int i = 0; i < expression.Length; i++)
        {
            if (expression[i] == '(' || expression[i] == ')')
            {
                list.Add(expression[i]);
            }
        }

        int startIndex = 0;
        while (startIndex < list.Count)
        {
            if (list[startIndex] == '(')
            {
                int closingIndex = startIndex + 1;
                while (closingIndex < list.Count)
                {
                    if (list[closingIndex] == ')')
                    {
                        list.RemoveAt(closingIndex);
                        list.RemoveAt(startIndex);
                        startIndex = -1;
                        break;
                    }
                    closingIndex++;
                }
            }
            startIndex++;
        }

        if (list.Count > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}