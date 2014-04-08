// Write a program that generates and prints to the console 10 random values in the range [100, 200].

using System;

class GenerateAndPrint10RandomValuesRange100to200
{
    static void Main()
    {
        // Explain the program
        Console.WriteLine("This program generates and prints to the console 10 random values in the range [100, 200].");
        Console.WriteLine();

        // Declare a random data type
        Random rndm = new Random();
        // Initiate a loop that will print 10 random values (possible numbers between 100 and 200)
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine("Random value {0}: {1}", i, rndm.Next(100,201));
        }
    }
}