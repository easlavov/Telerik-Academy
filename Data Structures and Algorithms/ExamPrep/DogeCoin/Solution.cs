namespace DogeCoin
{
    using System;

    class Solution
    {
        static void Main()
        {
            string[] firstInputRow = Console.ReadLine().Split(' ');
            int n = int.Parse(firstInputRow[0]);
            int m = int.Parse(firstInputRow[1]);

            int[,] coinsField = new int[n, m];
            int[,] pathsScores = new int[n, m];

            int k = int.Parse(Console.ReadLine());
            for (int i = 0; i < k; i++)
            {
                string[] coords = Console.ReadLine().Split(' ');
                int x = int.Parse(coords[0]);
                int y = int.Parse(coords[1]);
                coinsField[x, y] += 1;
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {
                    int currentCellCoins = coinsField[row, col];
                    int leftCellCoins = 0;
                    int upperCellCoins = 0;
                    try
                    {
                        leftCellCoins = pathsScores[row, col - 1];                        
                    }
                    catch (Exception)
                    {                        
                        
                    }

                    try
                    {
                        upperCellCoins = pathsScores[row - 1, col];
                    }
                    catch (Exception)
                    {
                        
                    }

                    int max = Math.Max(leftCellCoins, upperCellCoins);
                    int cellValue = currentCellCoins + max;
                    pathsScores[row, col] = cellValue;
                }
            }

            int result = pathsScores[n - 1, m - 1];
            Console.WriteLine(result);
        }
    }
}
