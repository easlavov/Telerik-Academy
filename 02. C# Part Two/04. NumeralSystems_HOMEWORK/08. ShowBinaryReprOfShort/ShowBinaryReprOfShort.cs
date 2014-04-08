// Write a program that shows the binary representation of given 
// 16-bit signed integer number (the C# type short).

using System;

class ShowBinaryReprOfShort
{
    static void Main()
    {
        // Explain the program
        Console.WriteLine("This program shows the binary representation of given 16-bit signed integer number.");
        Console.WriteLine();
        // Instruct user input
        Console.Write("Please, enter a number between -32,768 and 32,767: ");
        short number = short.Parse(Console.ReadLine());
        string result = Convert.ToString(number,2);
        int zeroesToAdd = 16 - result.Length;
        for (int i = 0; i < zeroesToAdd; i++)
        {
            result = "0" + result;
        }
        Console.WriteLine("The binary representation is {0}", result);
    }
}