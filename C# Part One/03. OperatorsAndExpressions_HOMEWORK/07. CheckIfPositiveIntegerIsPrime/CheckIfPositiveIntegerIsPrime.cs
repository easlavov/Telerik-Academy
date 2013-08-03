// Write an expression that checks if given positive integer
// number n (n ≤ 100) is prime. E.g. 37 is prime.

using System;

class CheckIfPositiveIntegerIsPrime
{
    static void Main()
    {
        // Print what the program does:
        Console.WriteLine(
            "This program checks if a given integer (<=100) is prime and then prints the result.");
        Console.WriteLine();

        // Instruct the user to enter an integer:
        Console.Write("Please, enter an integer: ");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine();

        if (number == 0 || number == 1)
        {
            Console.WriteLine("{0} is not a prime number.", number);
            Console.ReadLine();
        }
        else
        {
            for (int a = 2; a <= number / 2; a++)
            {
                if (number % a == 0)
                {
                    Console.WriteLine("{0} is not a prime number.", number);
                    return;
                }
            }
            Console.WriteLine("{0} is a prime number.", number);
        }
    }
}