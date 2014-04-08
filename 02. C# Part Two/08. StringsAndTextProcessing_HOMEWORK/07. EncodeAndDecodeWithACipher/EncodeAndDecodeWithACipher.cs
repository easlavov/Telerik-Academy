// Write a program that encodes and decodes a string using given encryption key (cipher).
// The key consists of a sequence of characters. The encoding/decoding is done by performing 
// XOR (exclusive or) operation over the first letter of the string with the first of the key,
// the second – with the second, etc. When the last key character is reached, the next is the first.

using System;
using System.Collections.Generic;

class EncodeAndDecodeWithACipher
{
    static void Main()
    {
        Console.WriteLine("This program encodes and decodes a string using given encryption key (cipher).");
        Console.WriteLine();
                
        Console.WriteLine("The program will first encode a text. Please enter the text you want to encode:");
        string textToEncode = Console.ReadLine();
        Console.WriteLine();
        Console.Write("Please, enter a cipher to encode with: ");
        string cipher = Console.ReadLine();
        // Encode text
        Console.WriteLine("Encoded text: ");

        List<char> encodedText = EncodeText(textToEncode, cipher);
        foreach (var item in encodedText)
        {
            Console.Write(item);
        }
        Console.WriteLine();

        // Decode text
        List<char> decodedText = DecodeText(cipher, encodedText);
        Console.WriteLine("Decoded text: ");
        foreach (var item in decodedText)
        {
            Console.Write(item);
        }
        Console.WriteLine();
    }

    private static List<char> DecodeText(string cipher, List<char> encodedText)
    {
        List<char> decodedText = new List<char>();
        for (int i = 0, p = 0; i < encodedText.Count; i++, p++)
        {
            decodedText.Add((char)(encodedText[i] ^ cipher[p]));
            if (p == cipher.Length - 1)
            {
                p = -1;
            }
        }
        return decodedText;
    }

    private static List<char> EncodeText(string textToEncode, string cipher)
    {
        List<char> encodedText = new List<char>();
        for (int i = 0, p = 0; i < textToEncode.Length; i++, p++)
        {
            encodedText.Add((char)(textToEncode[i] ^ cipher[p]));
            if (p == cipher.Length - 1)
            {
                p = -1;
            }
        }
        return encodedText;
    }
}