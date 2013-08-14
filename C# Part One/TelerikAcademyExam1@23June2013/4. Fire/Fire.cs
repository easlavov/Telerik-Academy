using System;

class Fire
{
    static void Main()
    {
        // Read N
        int n = int.Parse(Console.ReadLine());

        // Declare a matrix
        int height = 2 * (n / 2) + n / 4 + 1;
        char[,] fire = new char[height, n];
        // Fill matrix with dots
        for (int row = 0; row < fire.GetLength(0); row++)
        {
            for (int column = 0; column < fire.GetLength(1); column++)
            {
                fire[row, column] = '.';
            }
        }

        // Draw first part
        int firstPosition = n / 2 - 1;
        int secondPosition = firstPosition + 1;
        int currentRow = 0;
        for (int iteration = 0; iteration < n / 2; iteration++, currentRow++)
        {
            fire[currentRow, firstPosition] = '#';
            fire[currentRow, secondPosition] = '#';
            firstPosition--;
            secondPosition++;
        }

        // Draw second part
        firstPosition++;
        secondPosition--;
        for (int iteration = 0; iteration < n / 4; iteration++, currentRow++)
        {
            fire[currentRow, firstPosition] = '#';
            fire[currentRow, secondPosition] = '#';
            firstPosition++;
            secondPosition--;
        }

        // Draw 3 part
        for (int i = 0; i < n; i++)
        {
            fire[currentRow, i] = '-';
        }

        // Draw last part
        currentRow++;
        firstPosition = 0;
        secondPosition = n - 1;
        int offset = 0;
        for (int i = currentRow; i < height; i++)
        {
            for (int firstHalf = 0 + offset; firstHalf < n/2; firstHalf++)
            {
                fire[i, firstHalf] = '\\';
            }
            for (int secondHalf = n/2; secondHalf < n - offset; secondHalf++)
            {
                fire[i, secondHalf] = '/';
            }
            offset++;
        }

        // Print matrix
        for (int row = 0; row < fire.GetLength(0); row++)
        {
            for (int column = 0; column < fire.GetLength(1); column++)
            {
                Console.Write(fire[row, column]);
            }
            Console.WriteLine();
        }
    }
}