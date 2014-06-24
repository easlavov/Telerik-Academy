namespace MatrixWalk
{
    using System;

    public class TestProgram
    {
        private const int MIN_SIZE = 1;
        private const int MAX_SIZE = 100;

        static void Main()
        {
            Console.WriteLine("Enter a positive number between {0} and {1}",
                                MIN_SIZE,
                                MAX_SIZE);
            string input = Console.ReadLine();
            int matrixSize;

            while (!int.TryParse(input, out matrixSize) ||
                    matrixSize < MIN_SIZE ||
                    MAX_SIZE < matrixSize)
            {
                Console.WriteLine("You haven't entered a correct positive number. Try again.");
                input = Console.ReadLine();
            }

            Matrix matrix = new Matrix(matrixSize);
            Console.WriteLine(matrix);
        }
    }
}
