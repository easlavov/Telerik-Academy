// Write a program to convert from any numeral system of given base s 
// to any other numeral system of base d (2 ≤ s, d ≤  16).

using System;

class ConvertFromBaseSToBaseD
{
    static void Main()
    {
        // Explain the program to the user
        Console.WriteLine("This program converts from any numeral system of given base s to any other numeral system of base d (2 <= s, d <= 16).");
        Console.WriteLine();
        while (true)
        {
            // Instruct the user to enter s and d
            Console.Write("Please, enter s : ");
            int s = int.Parse(Console.ReadLine());
            Console.Write("Please, enter d : ");
            int d = int.Parse(Console.ReadLine());
            if (s == d || s < 2 || d > 16)
            {
                Console.WriteLine("Conversion obsolete, impossible or out of range.");
            }
            else
            {
                Console.Write("Enter base({0}) number to be converted to base({1}): ", s, d);
                string baseSNumber = Console.ReadLine();
                int number = 0;
                // Convert base(s) to base(10)
                if (s < 10)
                {
                    int integer = int.Parse(baseSNumber);
                    int power = 0;
                    while (integer > 0)
                    {
                        int digit = integer % 10;
                        number += digit * (int)(Math.Pow(s, power));
                        integer /= 10;
                        power++;
                    }
                    // Result is an integer 'number';
                }
                if (s > 10)
                {
                    for (int i = 0; i < baseSNumber.Length; i++)
                    {
                        char digit = baseSNumber[baseSNumber.Length - 1 - i];
                        switch (digit)
                        {
                            case '0': number += 0 * (int)(Math.Pow(s, i)); break;
                            case '1': number += 1 * (int)(Math.Pow(s, i)); break;
                            case '2': number += 2 * (int)(Math.Pow(s, i)); break;
                            case '3': number += 3 * (int)(Math.Pow(s, i)); break;
                            case '4': number += 4 * (int)(Math.Pow(s, i)); break;
                            case '5': number += 5 * (int)(Math.Pow(s, i)); break;
                            case '6': number += 6 * (int)(Math.Pow(s, i)); break;
                            case '7': number += 7 * (int)(Math.Pow(s, i)); break;
                            case '8': number += 8 * (int)(Math.Pow(s, i)); break;
                            case '9': number += 9 * (int)(Math.Pow(s, i)); break;
                            case 'A': number += 10 * (int)(Math.Pow(s, i)); break;
                            case 'B': number += 11 * (int)(Math.Pow(s, i)); break;
                            case 'C': number += 12 * (int)(Math.Pow(s, i)); break;
                            case 'D': number += 13 * (int)(Math.Pow(s, i)); break;
                            case 'E': number += 14 * (int)(Math.Pow(s, i)); break;
                            case 'F': number += 15 * (int)(Math.Pow(s, i)); break;
                            default: break;
                        }
                    }
                    // result is an integer 'number'
                }
                if (s == 10)
                {
                    number = int.Parse(baseSNumber);
                }

                // Convert base(10) to base(d)
                string result = "";
                if (d < 10)
                {
                    while (number > 0)
                    {
                        result += number % d;
                        number /= d;
                    }
                    // Display converted numbers
                    Console.Write("Number after conversion is ", number);
                    for (int i = result.Length - 1; i >= 0; i--)
                    {
                        Console.Write(result[i]);
                    }
                    Console.WriteLine();
                }
                if (d > 10)
                {
                    while (number > 0)
                    {
                        int digit = number % d;
                        if (digit < 10)
                        {
                            result += digit;
                        }
                        else
                        {
                            switch (digit)
                            {
                                case 10: result += "A"; break;
                                case 11: result += "B"; break;
                                case 12: result += "C"; break;
                                case 13: result += "D"; break;
                                case 14: result += "E"; break;
                                case 15: result += "F"; break;
                                default: break;
                            }
                        }
                        number /= d;
                    }
                    // Display converted numbers
                    Console.Write("Number after conversion is ");
                    for (int i = result.Length - 1; i >= 0; i--)
                    {
                        Console.Write(result[i]);
                    }
                    Console.WriteLine();
                }
                if (d == 10)
                {
                    Console.WriteLine("Number after conversion is {0}", number);
                }
            }
        }
    }
}