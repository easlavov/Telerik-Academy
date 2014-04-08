// Sort 3 real values in descending order using nested if statements.

using System;

class SortRealValuesInDescendingOrder
{
    static void Main()
    {
        // Print what the program does:
        Console.WriteLine("This program sorts 3 real values in descending order using nested if statements.");

        // Instruct user to enter three real numbers:
        Console.Write("Please enter the first real number: ");
        double numberA = double.Parse(Console.ReadLine());
        Console.Write("Please enter the second real number: ");
        double numberB = double.Parse(Console.ReadLine());
        Console.Write("Please enter the third real number: ");
        double numberC = double.Parse(Console.ReadLine());

        if (numberA >= numberB)
        {
            if (numberA >= numberC)
            {
                if (numberB >= numberC)
                {
                    Console.WriteLine(numberA);
                    Console.WriteLine(numberB);
                    Console.WriteLine(numberC);
                }
                else
                {
                    Console.WriteLine(numberA);
                    Console.WriteLine(numberC);
                    Console.WriteLine(numberB);
                }
                
            }
            else
            {
                Console.WriteLine(numberC);
                Console.WriteLine(numberA);
                Console.WriteLine(numberB);
            }
        }
        else if (numberB >= numberA)
        {
            if (numberB >= numberC)
            {
                if (numberA > numberC)
                {
                    Console.WriteLine(numberB);
                    Console.WriteLine(numberA);
                    Console.WriteLine(numberC);
                }
                else
                {
                    Console.WriteLine(numberB);
                    Console.WriteLine(numberC);
                    Console.WriteLine(numberA);
                }                
            }
            else
            {
                Console.WriteLine(numberC);
                Console.WriteLine(numberB);
                Console.WriteLine(numberA);
            }
        }       
    }
}