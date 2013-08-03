// Write a program that gets a number n and after that gets more
// n numbers and calculates and prints their sum. 

using System;

class GetNNumbersAndPrintSum
{
    static void Main()
    {
        // Print what the program does:
        Console.WriteLine("This program gets a number n and after that gets more n numbers and calculates and prints their sum.");
        
        // We instruct the user to enter the first number:
        Console.Write("Please, enter a number: ");
        int numberN = int.Parse(Console.ReadLine());

        // We use a simple 'while' loop to perform the calculations.
        // Every time the loop is initiated, the user is promted to enter a new number.
        // It is then added to the numberN integer, that stays outside the loop and holds the sum of all previously entered numbers.
        while (true)
        {
            Console.Write("Please, enter a number you'd like to add to the prevoius one: ");
            int numberNext = int.Parse(Console.ReadLine());
            numberN += numberNext;
            Console.WriteLine("The sum of the numbers is {0}.", numberN);
        }  
    }
}