// * Write a program that exchanges bits {p, p+1, …, p+k-1) with 
// bits {q, q+1, …, q+k-1} of given 32-bit unsigned integer.

using System;

class ExchangeSequenceOfBits
{
    static void Main()
    {
        // Print what the program does:
        Console.WriteLine(
            "This program exchanges bits {p, p+1, …, p+k-1) with bits {q, q+1, …, q+k-1} of given 32-bit unsigned integer.");
        Console.WriteLine();

        // Declare the required variables:
        uint number;
        byte k, p, q; // k is the number of consecutive bits that will be exchanged; p is the position of the first sequence of bits, q - of the second.


        // Instruct the user to enter the variables:
        Console.Write("Enter an integer: ");
        number = uint.Parse(Console.ReadLine()); // User enters the number whose bits are to be exchanged.
        string binary = Convert.ToString(number, 2);
        Console.WriteLine("The binary representation of the integer is {0}.", binary);
        Console.WriteLine();
        Console.WriteLine("p+k should be < q+1; q+k should be <=32");
        Console.Write("Enter the number of consecutive bits (k > 0) that will be exchanged in both bit sequences: ");
        k = byte.Parse(Console.ReadLine());
        Console.Write("Enter the position of the first bit of the first sequence (p >= 0): ");
        p = byte.Parse(Console.ReadLine());
        Console.Write("Enter the position of the first bit of the second sequence (q > 0): ");
        q = byte.Parse(Console.ReadLine());

        uint mask = 1;

        if (p + k < q + 1 && q + k <= 32 && k > 0 && p >= 0 && q > 0) // This check ensures correct execution of the program.
        {
            for (int i = 0; i < k; i++, p++, q++)
            {
                mask <<= p;
                uint valueP = (number & mask) >> p;
                mask = 1;

                mask <<= q;
                uint valueQ = (number & mask) >> q;
                mask = 1;

                if (valueP == 0)
                {
                    number = number & (~(mask << q));
                }
                else
                {
                    number = number | (mask << q);
                }

                if (valueQ == 0)
                {
                    number = number & (~(mask << p));
                }
                else
                {
                    number = number | (mask << p);
                }
            }

            Console.WriteLine("The new number is {0}", number);
            binary = Convert.ToString(number, 2);
            Console.WriteLine("Its binary representation is {0}", binary);
        }
        else
        {
            Console.WriteLine("Range is invalid. No exchanges will be made.");
        }
    }
}