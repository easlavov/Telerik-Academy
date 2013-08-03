// Declare five variables choosing for each of them the most appropriate
// of the types byte, sbyte, short, ushort, int, uint, long, ulong to 
// represent the following values: 52130, -115, 4825932, 97, -10000.

using System;

class DeclareFiveVariables
{
    static void Main()
    {
        // The most appropriate data type is the one that stores a number in the least ammount of memory possible:
        ushort number1 = 52130;
        sbyte number2 = -115;
        int number3 = 4825932;
        byte number4 = 97;
        short number5 = -10000;

        // Check:
        Console.WriteLine("{0}\n{1}\n{2}\n{3}\n{4}", number1, number2, number3, number4, number5);
    }
}