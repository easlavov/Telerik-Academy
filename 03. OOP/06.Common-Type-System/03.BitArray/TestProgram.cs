using System;
using System.Linq;

class TestProgram
{
    static void Main()
    {
        Console.WriteLine("Testing the BitArray project.");
        Console.WriteLine("Creating a new instance of the BitArray64 class.");
        BitArray64 num = new BitArray64(415645645645456);
        Console.WriteLine("The number in base(10) is: {0}", num.Value);
        Console.WriteLine("The binary represenation of the number is: ");
        foreach (var bit in num.BitArray)
        {
            Console.Write(bit);
        }
        Console.WriteLine();

        Console.WriteLine("The hash code is: " + num.GetHashCode());
        Console.WriteLine("The bit value in position 63 is: {0}", num[63]);
        Console.WriteLine();

        Console.WriteLine("Creating a new instance of the BitArray64 class.");
        BitArray64 num2 = new BitArray64(ulong.MaxValue);
        Console.WriteLine("The number in base(10) is: {0}", num2.Value);
        Console.WriteLine("Number one == number two: {0}", num == num2);
        Console.WriteLine();

        Console.WriteLine("Test complete.");
    }
}