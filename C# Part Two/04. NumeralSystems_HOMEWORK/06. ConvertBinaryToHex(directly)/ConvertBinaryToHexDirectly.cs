// Write a program to convert binary numbers to hexadecimal numbers (directly).

using System;

class ConvertBinaryToHexDirectly
{
    static void Main()
    {
        // Explain the program to the user
        Console.WriteLine("This program converts binary numbers to hexadecimal directly.");
        Console.WriteLine();
        // Instruct the user to enter number
        Console.Write("Please, enter binary number to be converted to hexadecimal: ");
        string binary = Console.ReadLine();
        // Conversion
        string hex = "";
        if (binary.Length % 4 == 1)
        {
            binary = "0" + binary;
        }
        if (binary.Length % 4 == 2)
        {
            binary = "0" + binary;
        }
        if (binary.Length % 4 == 3)
        {
            binary = "0" + binary;
        }
        for (int i = 0; i < binary.Length; i += 4)
        {
            string digit = string.Format("{0}{1}{2}{3}", binary[i], binary[i + 1], binary[i + 2], binary[i + 3]);
            switch (digit)
            {
                case "0000": hex += "0"; break;
                case "0001": hex += "1"; break;
                case "0010": hex += "2"; break;
                case "0011": hex += "3"; break;
                case "0100": hex += "4"; break;
                case "0101": hex += "5"; break;
                case "0110": hex += "6"; break;
                case "0111": hex += "7"; break;
                case "1000": hex += "8"; break;
                case "1001": hex += "9"; break;
                case "1010": hex += "A"; break;
                case "1011": hex += "B"; break;
                case "1100": hex += "C"; break;
                case "1101": hex += "D"; break;
                case "1110": hex += "E"; break;
                case "1111": hex += "F"; break;
                default: break;
            }
        }
        Console.WriteLine("Hexadecimal {0}", hex);
    }
}