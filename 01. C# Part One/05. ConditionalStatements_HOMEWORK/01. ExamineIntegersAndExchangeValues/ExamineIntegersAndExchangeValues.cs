// Write an if statement that examines two integer variables and exchanges
// their values if the first one is greater than the second one.

using System;

class ExamineIntegersAndExchangeValues
{
    static void Main()
    {
        // Print what the program does:
        Console.WriteLine("This program examines two integer variables and exchanges their values if the first one is greater than the second one.");

        // Instruct user to enter two integers:
        Console.Write("Please enter the first integer: ");
        int numberA = int.Parse(Console.ReadLine());
        Console.Write("Please enter the second integer: ");
        int numberB = int.Parse(Console.ReadLine());

        if (numberA > numberB)
        {
            Console.WriteLine("The first number is bigger than the second. Their values will be exchanged.");
            numberA += numberB;
            numberB = numberA - numberB;
            numberA -= numberB;
            Console.WriteLine("The first number is now {0}.", numberA);
            Console.WriteLine("The second number is now {0}.", numberB);
        }
        else
        {
            Console.WriteLine("The first number is not bigger than the second. Their values will not be exchanged.");
        }
        
    }
}