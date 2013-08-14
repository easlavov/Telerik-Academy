using System;
using System.Collections.Generic;
using System.Text;

class Neurons
{
    static void Main()
    {
        long x = 3758096384;
        // Initiate a string builder
        StringBuilder builder = new StringBuilder();

        // Read input
        List<long> input = new List<long>();
        while (true)
        {
            long number = long.Parse(Console.ReadLine());
            if (number > -1)
            {
                input.Add(number);
            }
            else
            {
                break;
            }
        }

        long[] output = new long[input.Count];
        // Calculate new numbers
        for (int i = 0; i < input.Count; i++)
        {
            long number = input[i];
            int onesCount = CountOnes(number);
            if (number == 0)
            {
                output[i] = 0;
                continue;
            }
            int writeOnes = 0;
            while (number > 0)
            {
                int mask = 1;
                long bitValue = mask & number;
                if (bitValue == 0)
                {
                    if (writeOnes == 0)
                    {
                        builder.Insert(0, '0');
                    }
                    else
                    {
                        builder.Insert(0, '1');
                    }
                }
                else
                {
                    if (writeOnes == 0)
                    {
                        writeOnes = 1;
                        onesCount--;
                    }
                    else if (onesCount == 0)
                    {
                        writeOnes = 0;
                    }
                    builder.Insert(0, '0');
                }
                number >>= 1;
            }
            output[i] = Convert.ToInt32(builder.ToString(), 2);
            builder.Clear();
        }

        foreach (var item in output)
        {
            Console.WriteLine(item);
        }
    }

    private static int CountOnes(long number)
    {
        int count = 0;
        while (number > 0)
        {
            int mask = 1;
            long bitValue = mask & number;
            if (bitValue == 1)
            {
                count++;
            }
            number >>= 1;
        }
        return count;
    }
}