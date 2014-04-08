class Program
{
    static long CalcCount(int[,] matrix)
    {
        long count = 0;
        for (int row = 0; row < matrix.GetLength(0); row++)
            if (matrix[row, 0] % 2 == 0)
                for (int col = 0; col < matrix.GetLength(1); col++)
                    if (matrix[row, col] > 0)
                        count++;
        return count;
    }

    static void Main()
    {
        // complexity is n * (n/2)*m
        // this is linear complexity
        int[,] matrix = new int[1,100000000]; // 100 million test completes in a few seconds
        long res = CalcCount(matrix);
    }
}