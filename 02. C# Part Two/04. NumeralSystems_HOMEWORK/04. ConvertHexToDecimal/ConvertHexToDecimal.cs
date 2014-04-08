// Write a program to convert hexadecimal numbers to their decimal representation.

using System;

class ConvertHexToDecimal
{
    static void Main()
    {
        // Explain the program to the user
        Console.WriteLine("This program converts hexadecimal numbers to their decimal representation.");
        Console.WriteLine();
        // Instruct the user to enter number
        Console.Write("Please, enter hexadecimal number to be converted to decimal: ");
        string hex = Console.ReadLine().ToUpper();
        // Conversion
        int number = 0;
        for (int i = 0; i < hex.Length; i++)
        {
            char digit = hex[hex.Length - 1 - i];
            switch (digit)
            {
                case '0': number += 0 * (int)(Math.Pow(16, i)); break;
                case '1': number += 1 * (int)(Math.Pow(16, i)); break;
                case '2': number += 2 * (int)(Math.Pow(16, i)); break;
                case '3': number += 3 * (int)(Math.Pow(16, i)); break;
                case '4': number += 4 * (int)(Math.Pow(16, i)); break;
                case '5': number += 5 * (int)(Math.Pow(16, i)); break;
                case '6': number += 6 * (int)(Math.Pow(16, i)); break;
                case '7': number += 7 * (int)(Math.Pow(16, i)); break;
                case '8': number += 8 * (int)(Math.Pow(16, i)); break;
                case '9': number += 9 * (int)(Math.Pow(16, i)); break;
                case 'A': number += 10 * (int)(Math.Pow(16, i)); break;
                case 'B': number += 11 * (int)(Math.Pow(16, i)); break;
                case 'C': number += 12 * (int)(Math.Pow(16, i)); break;
                case 'D': number += 13 * (int)(Math.Pow(16, i)); break;
                case 'E': number += 14 * (int)(Math.Pow(16, i)); break;
                case 'F': number += 15 * (int)(Math.Pow(16, i)); break;
                default: break;
            }
        }
        Console.WriteLine("Decimal is {0}", number);
    }
}