// Write a program to convert hexadecimal numbers to binary numbers (directly).

using System;

class ConvertHexToBinaryDirectly
{
    static void Main()
    {
        // Explain the program to the user
        Console.WriteLine("This program converts hexadecimal numbers to binary directly.");
        Console.WriteLine();
        // Instruct the user to enter number
        Console.Write("Please, enter hexadecimal number to be converted to binary: ");
        string hex = Console.ReadLine().ToUpper();
        // Conversion
        string binary = "";
        for (int i = 0; i < hex.Length; i++)
        {
            char digit = hex[i];
            switch (digit)
            {
                case '0': binary += "0000"; break;
                case '1': binary += "0001"; break;
                case '2': binary += "0010"; break;
                case '3': binary += "0011"; break;
                case '4': binary += "0100"; break;
                case '5': binary += "0101"; break;
                case '6': binary += "0110"; break;
                case '7': binary += "0111"; break;
                case '8': binary += "1000"; break;
                case '9': binary += "1001"; break;
                case 'A': binary += "1010"; break;
                case 'B': binary += "1011"; break;
                case 'C': binary += "1100"; break;
                case 'D': binary += "1101"; break;
                case 'E': binary += "1110"; break;
                case 'F': binary += "1111"; break;
                default: break;
            }
        }
        // Display converted numbers
        Console.Write("Binary is ");
        for (int i = 0; i < binary.Length; i++)
        {
            Console.Write(binary[i]);
        }
        Console.WriteLine();
    }
}