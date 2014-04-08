// Write a program to convert binary numbers to their decimal representation.

using System;

class ConvertBinaryToDecimal
{
    static void Main()
    {
        // Explain the program to the user
        Console.WriteLine("This program converts binary numbers to their decimal representation.");
        Console.WriteLine();
        // Instruct the user to enter number
        Console.Write("Please, enter binary number to be converted to decimal: ");
        int binary = int.Parse(Console.ReadLine());
        // Convert
        int number = 0;
        int power = 1;
        while (binary > 0)
        {
            int digit = binary % 10;
            number += digit * power;
            binary /= 10;
            power <<= 1;
        }
        Console.WriteLine("Decimal is {0}",number);
    }
}