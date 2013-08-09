// Write a method that reverses the digits of given decimal number. 
// Example: 256 -> 652

using System;

class ReverseDigitsMethod
{
    // Test program
    static void Main()
    {
        Console.WriteLine("This program tests a method that reverses the digits of given decimal number.");
        Console.WriteLine();
        Console.Write("Please, enter a decimal number: ");
        decimal result = ReverseDigits(decimal.Parse(Console.ReadLine()));
        Console.WriteLine("The decimal number reversed: {0}.", result);
    }

    // Reversal method
    static decimal ReverseDigits(decimal number)
    {
        string numStr = number.ToString();
        string newNum = "";
        for (int i = numStr.Length-1; i >= 0; i--)
        {
            newNum += numStr[i];
        }
        return decimal.Parse(newNum);
    }
}