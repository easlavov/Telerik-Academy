// Write a method that returns the last digit of given integer as an English word.
// Examples: 512 -> "two", 1024 -> "four", 12309 -> "nine".

using System;

class ReturnLastDigitNameMethod
{
    static void Main()
    {
        Console.WriteLine("This program tests a method that returns the last digit of given integer as an English word.");
        Console.WriteLine();
        while (true)
        {
            Console.Write("Please, enter an integer: ");
            int number = int.Parse(Console.ReadLine());
            string name = ReturnLastDigitName(number);
            Console.WriteLine("The last digit of {0} is {1}.", number, name);
        }        
    }

    static string ReturnLastDigitName(int number)
    {
        number %= 10;
        switch (number)
        {
            case 0: return "zero"; break;
            case 1: return "one"; break;
            case 2: return "two"; break;
            case 3: return "three"; break;
            case 4: return "four"; break;
            case 5: return "five"; break;
            case 6: return "six"; break;
            case 7: return "seven"; break;
            case 8: return "eight"; break;
            case 9: return "nine"; break;
            default: return ""; break;
        }
    }
}