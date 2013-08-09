// Write a program to convert decimal numbers to their binary representation.

using System;

class ConvertDecimalToBinary
{
    static void Main()
    {
        // Explain the program to the user
        Console.WriteLine("This program converts decimal numbers to their binary representation.");
        Console.WriteLine();
        // Instruct the user to enter number
        Console.Write("Please, enter decimal number to be converted to binary: ");
        int number = int.Parse(Console.ReadLine());
        // Convert to binary
        string binary = "";
        while (number > 0)
        {
            binary += number % 2;
            number /= 2;
        }
        // Display converted numbers
        Console.Write("Binary is ", number);
        for (int i = binary.Length - 1; i >= 0; i--)
        {
            Console.Write(binary[i]);
        }
        Console.WriteLine();
    }
}