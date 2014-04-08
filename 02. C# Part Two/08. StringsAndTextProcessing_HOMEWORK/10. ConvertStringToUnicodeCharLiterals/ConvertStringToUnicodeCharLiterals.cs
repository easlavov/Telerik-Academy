// Write a program that converts a string to a sequence of C# Unicode character literals. Use format strings.

using System;
using System.Text;

class ConvertStringToUnicodeCharLiterals
{
    static void Main()
    {
        Console.WriteLine("This program converts a string to a sequence of C# Unicode character literals, using format strings.");
        Console.WriteLine();

        Console.Write("Enter string: ");
        string input = Console.ReadLine();
        string result = RepresentAsHex(input);
        Console.WriteLine("Converted string: {0}",result);
    }
  
    private static string RepresentAsHex(string input)
    {
        StringBuilder stringBuilder = new StringBuilder();
        string format = @"\u{0}{1}";
        for (int i = 0; i < input.Length; i++)
        {
            string hex = Convert.ToString(input[i], 16).ToUpper();
            string zeroes = "";
            int zeroesToAddInFront = 4 - hex.Length;
            for (int p = 0; p < zeroesToAddInFront; p++)
            {
                zeroes += "0";
            }
            stringBuilder.Append(string.Format(format, zeroes, hex));
        }
        string result = stringBuilder.ToString();
        return result;
    }
}