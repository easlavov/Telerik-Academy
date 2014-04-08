// * Write a program that converts a number in the range [0...999] to a 
// text corresponding to its English pronunciation.

using System;

class ConvertNumberToText
{
    // Declare some useful variables:
    static short number;
    static int groupOfDigits;
    static int toUseGroupOfDigitsOne;
    static int toUseGroupOfDigitsTwo;
    static int toUseGroupOfDigitsThree;
    static string numberName;

    static void DetectDigits()
    {
        if (number >= 0 && number <= 19)
        {
            groupOfDigits = 1; // This group is for the numbers from 1 to 19. These numbers have unique names.
        }
        if (number >= 20 && number <= 99)
        {
            groupOfDigits = 2;  // This group is for the numbers from 20 to 99.
        }
        if (number >= 100 && number <= 999)
        {
            groupOfDigits = 3; // This group is for the three-digit numbers.
        }
        if (number > 999 || number < 0)
        {
            Console.WriteLine("You have entered an invalid number.");
        }
    }

    static void PrintGroupOne()
    {
        switch (toUseGroupOfDigitsOne)
        {
            case 0: numberName += "zero"; break;
            case 1: numberName += "one"; break;
            case 2: numberName += "two"; break;
            case 3: numberName += "three"; break;
            case 4: numberName += "four"; break;
            case 5: numberName += "five"; break;
            case 6: numberName += "six"; break;
            case 7: numberName += "seven"; break;
            case 8: numberName += "eight"; break;
            case 9: numberName += "nine"; break;
            case 10: numberName += "ten"; break;
            case 11: numberName += "eleven"; break;
            case 12: numberName += "twelve"; break;
            case 13: numberName += "thirteen"; break;
            case 14: numberName += "fourteen"; break;
            case 15: numberName += "fifteen"; break;
            case 16: numberName += "sixteen"; break;
            case 17: numberName += "seventeen"; break;
            case 18: numberName += "eighteen"; break;
            case 19: numberName += "nineteen"; break;
            default: break;
        }
    }

    static void PrintGroupTwo()
    {
        toUseGroupOfDigitsOne = number % 10;
        toUseGroupOfDigitsTwo = (number / 10) % 10;
        switch (toUseGroupOfDigitsTwo)
        {
            case 2: numberName += "twenty"; break;
            case 3: numberName += "thirty"; break;
            case 4: numberName += "fourty"; break;
            case 5: numberName += "fifty"; break;
            case 6: numberName += "sixty"; break;
            case 7: numberName += "seventy"; break;
            case 8: numberName += "eighty"; break;
            case 9: numberName += "ninety"; break;
            default: break;
        }
        if (toUseGroupOfDigitsOne != 0)
        {
            numberName += " ";
            PrintGroupOne();
        }
    }

    static void PrintGroupThree()
    {
        toUseGroupOfDigitsOne = number % 10;
        toUseGroupOfDigitsTwo = (number / 10) % 10;
        toUseGroupOfDigitsThree = (number / 100) % 10;
        switch (toUseGroupOfDigitsThree)
        {
            case 1: numberName += "one hundred"; break;
            case 2: numberName += "two hundred"; break;
            case 3: numberName += "three hundred"; break;
            case 4: numberName += "four hundred"; break;
            case 5: numberName += "five hundred"; break;
            case 6: numberName += "six hundred"; break;
            case 7: numberName += "seven hundred"; break;
            case 8: numberName += "eight hundred"; break;
            case 9: numberName += "nine hundred"; break;
            default: break;
        }

        if (toUseGroupOfDigitsTwo > 1)
        {
            if (toUseGroupOfDigitsOne == 0)
            {
                numberName += " and ";
                PrintGroupTwo();
            }
            else
            {
                numberName += " ";
                PrintGroupTwo();
            }                     
        }
        else
        {
            if (toUseGroupOfDigitsTwo == 1)
            {                
                numberName += " and ";
                toUseGroupOfDigitsOne = (number - ((number / 100) * 100));
                PrintGroupOne();
            }
            else if (toUseGroupOfDigitsOne != 0)
            {
                numberName += " and ";
                PrintGroupOne();
            }
        }        
    }

    static void Main()
    {
        // Print what the program does:
        Console.WriteLine(
            "This program converts a number in the range [0...999] to a text corresponding to its English pronunciation.");
        Console.WriteLine();

        while (true)
        {
            // Istruct user to enter a number between 0 and 999:
            Console.Write("Please, enter a number from 0 to 999: ");
            
            try
            {
                number = short.Parse(Console.ReadLine());
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Invalid input. Try again.");
                continue;
            }
            
            DetectDigits();
            if (groupOfDigits == 1)
            {
                toUseGroupOfDigitsOne = number;
                PrintGroupOne();
                Console.WriteLine("The number {0} English pronunciation is '{1}'.", number, numberName);
            }
            if (groupOfDigits == 2)
            {
                PrintGroupTwo();
                Console.WriteLine("The number {0} English pronunciation is '{1}'.", number, numberName);
            }
            if (groupOfDigits == 3)
            {
                PrintGroupThree();
                Console.WriteLine("The number {0} English pronunciation is '{1}'.", number, numberName);
            }
            numberName = "";
            groupOfDigits = 0;
        }        
    }
}