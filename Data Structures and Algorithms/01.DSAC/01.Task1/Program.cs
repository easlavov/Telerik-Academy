using System;

class Program
{
    static long Compute(int[] arr)
    {
        long count = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            int start = 0, end = arr.Length - 1;
            while (start < end)
                if (arr[start] < arr[end])
                { start++; count++; }
                else
                    end--;
        }
        return count;
    }

    static void Main()
    {
        // the complexity is n * n - 1
        // this is quadratic complexity
        int[] arr = new int[100000]; // 100 000 doesn't complete in less than 2 secs
        long res = Compute(arr);

        Console.WriteLine(res);
    }
}