// Write a program that shows the sign (+ or -) of the product of three real numbers 
// without calculating it. Use a sequence of if statements.

using System;

class ShowTheSignOfTheProductOfThreeRealNumbers
{
    static void Main()
    {
        // Print what the program does:
        Console.WriteLine("This program shows the sign (+ or -) of the product of three real numbers without calculating it.");

        // Instruct user to enter three real numbers:
        Console.Write("Please enter the first real number: ");
        double numberA = double.Parse(Console.ReadLine());
        Console.Write("Please enter the second real number: ");
        double numberB = double.Parse(Console.ReadLine());
        Console.Write("Please enter the third real number: ");
        double numberC = double.Parse(Console.ReadLine());

        int counter = 0; // +1 is added to this counter for each negative number.

        if (numberA == 0 || numberB == 0 || numberC == 0)
        {
            Console.WriteLine("The product is 0.");
        }
        else
        {
            if (numberA < 0)
            {
                counter++;
            }
            if (numberB < 0)
            {
                counter++;
            }
            if (numberC < 0)
            {
                counter++;
            }

            // If the counter is an even number - then the product is positive.
            if (counter == 0 || ((counter % 2) == 0))            
            {
                Console.WriteLine("The product of these numbers is positive.");
            }
            else // it is negative
            {
                Console.WriteLine("The product of these numbers is negative.");
            }
        }        
    }
}