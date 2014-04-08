// Write a program to convert decimal numbers to their hexadecimal representation.

using System;

class ConvertDecimalToHex
{
    static void Main()
    {
        // Explain the program to the user
        Console.WriteLine("This program converts decimal numbers to their hexadecimal representation.");
        Console.WriteLine();
        // Instruct the user to enter number
        Console.Write("Please, enter decimal number to be converted to hexadecimal: ");
        int number = int.Parse(Console.ReadLine());
        // Conversion
        string hex = "";
        while (number > 0)
        {
            int digit = number % 16;
            if (digit < 10)
            {
                hex += digit;
            }
            else
            {
                switch (digit)
                {
                    case 10: hex += "A"; break;
                    case 11: hex += "B"; break;
                    case 12: hex += "C"; break;
                    case 13: hex += "D"; break;
                    case 14: hex += "E"; break;
                    case 15: hex += "F"; break;
                    default: break;
                }
            }
            number /= 16;
        }
        // Display converted numbers
        Console.Write("Hex is ");
        for (int i = hex.Length - 1; i >= 0; i--)
        {
            Console.Write(hex[i]);
        }
        Console.WriteLine();
    }
}