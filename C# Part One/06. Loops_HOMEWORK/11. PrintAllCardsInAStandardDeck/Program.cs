// Write a program that prints all possible cards from a standard deck of 52 cards (without jokers).
// The cards should be printed with their English names. Use nested for loops and switch-case.

using System;

class Program
{
    static void Main()
    {
        // Print what the program does:
        Console.WriteLine("This program prints all possible cards from a standard deck of 52 cards (without jokers).");
        Console.WriteLine();

        int color = 0;
        int number = 0;
        string cardNumber = "";
        string cardColor = "";


        for (int i = 1; i < 5; i++)
        {
            color += i;
            switch (color)
            {
                case 1: cardColor = " of Clubs"; break;
                case 2: cardColor = " of Hearts"; break;
                case 3: cardColor = " of Diamonds"; break;
                case 4: cardColor = " of Spades"; break;
                default: break;
            }
            for (int k = 1; k < 15; k++)
            {
                number += k;
                switch (number)
                {
                    case 1: cardNumber = "One"; break;
                    case 2: cardNumber = "Two"; break;
                    case 3: cardNumber = "Three"; break;
                    case 4: cardNumber = "Four"; break;
                    case 5: cardNumber = "Five"; break;
                    case 6: cardNumber = "Six"; break;
                    case 7: cardNumber = "Seven"; break;
                    case 8: cardNumber = "Eight"; break;
                    case 9: cardNumber = "Nine"; break;
                    case 10: cardNumber = "Ten"; break;
                    case 11: cardNumber = "Jack"; break;
                    case 12: cardNumber = "Queen"; break;
                    case 13: cardNumber = "King"; break;
                    case 14: cardNumber = "Ace"; break;
                    default: break;
                }
                string cardName = cardNumber + cardColor;
                Console.WriteLine(cardName);
                number = 0;
            }
            color = 0;
            Console.WriteLine();
        }
    }
}