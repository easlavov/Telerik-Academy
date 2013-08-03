// Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 
// of given 32-bit unsigned integer.

using System;

class ExchangeBits
{
    static void Main()
    {
        // Print what the program does:
        Console.WriteLine(
            "This program exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer.");
        Console.WriteLine();

        // Instruct the user to enter an integer:
        Console.Write("Enter an integer: ");
        uint number = uint.Parse(Console.ReadLine());
        string binary = Convert.ToString(number, 2);
        Console.WriteLine("The binary representation of the integer is {0}.", binary);

        // Extract values (print check):
        uint bitPosition3Value = ((1 << 3) & number) >> 3;
        Console.WriteLine("The 3rd bit is {0}", bitPosition3Value);
        uint bitPosition24Value = ((1 << 24) & number) >> 24;
        Console.WriteLine("The 24th bit is {0}", bitPosition24Value);
        uint bitPosition4Value = ((1 << 4) & number) >> 4;
        Console.WriteLine("The 4th bit is {0}", bitPosition4Value);
        uint bitPosition25Value = ((1 << 25) & number) >> 25;
        Console.WriteLine("The 25th bit is {0}", bitPosition25Value);
        uint bitPosition5Value = ((1 << 5) & number) >> 5;
        Console.WriteLine("The 5th bit is {0}", bitPosition5Value);
        uint bitPosition26Value = ((1 << 26) & number) >> 26;
        Console.WriteLine("The 26th bit is {0}", bitPosition26Value);
        // Exchange values:
        uint mask = 1;

        if (bitPosition3Value == 0)
        {
            number = number & (~(mask << 24));
            Console.WriteLine("We set the 24th bit with the value of the 3rd. The new number is {0}.", number);
        }
        else
        {
            number = number | (mask << 24);
            Console.WriteLine("We set the 24th bit with the value of the 3rd. The new number is {0}.", number);
        }

        if (bitPosition24Value == 0)
        {
            number = number & (~(mask << 3));
            Console.WriteLine("We set the 3rd bit with the value of the 24th. The new number is {0}.", number);
        }
        else
        {
            number = number | (mask << 3);
            Console.WriteLine("We set the 3rd bit with the value of the 24th. The new number is {0}.", number);
        }

        if (bitPosition4Value == 0)
        {
            number = number & (~(mask << 25));
            Console.WriteLine("We set the 25th bit with the value of the 4th. The new number is {0}.", number);
        }
        else
        {
            number = number | (mask << 25);
            Console.WriteLine("We set the 25th bit with the value of the 4th. The new number is {0}.", number);
        }

        if (bitPosition25Value == 0)
        {
            number = number & (~(mask << 4));
            Console.WriteLine("We set the 4th bit with the value of the 25th. The new number is {0}.", number);
        }
        else
        {
            number = number | (mask << 4);
            Console.WriteLine("We set the 4th bit with the value of the 25th. The new number is {0}.", number);
        }

        if (bitPosition5Value == 0)
        {
            number = number & (~(mask << 26));
            Console.WriteLine("We set the 26th bit with the value of the 5th. The new number is {0}.", number);
        }
        else
        {
            number = number | (mask << 26);
            Console.WriteLine("We set the 26th bit with the value of the 5th. The new number is {0}.", number);
        }

        if (bitPosition26Value == 0)
        {
            number = number & (~(mask << 5));
            Console.WriteLine("We set the 5th bit with the value of the 26th. The new number is {0}.", number);
        }
        else
        {
            number = number | (mask << 5);
            Console.WriteLine("We set the 5th bit with the value of the 26th. The new number is {0}.", number);
        }

        Console.WriteLine("The final integer is {0}.", number);
        string binary2 = Convert.ToString(number, 2);
        Console.WriteLine("The binary representation of the final integer is {0}.", binary2);
    }
}