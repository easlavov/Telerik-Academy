using System;
using System.Linq;

namespace Matrix
{
    class TestProgram
    {
        static void Main()
        {
            // Explanation
            Console.WriteLine("Hello! This program tests the functionality of the Matrix project. It will run a few tests to determine if the code has been written correctly. Enjoy!");
            Console.WriteLine();

            // Testing matrix constructor and ToString override
            Console.WriteLine("Initializing matrix of size 10,15:");
            Matrix<int> matrix = new Matrix<int>(10, 15);
            Console.WriteLine(matrix.ToString());
            Console.WriteLine();

            // Testing indexer
            Console.WriteLine("Changing the value of element [1,4] to 3:");
            matrix[1, 4] = 3;
            Console.WriteLine(matrix.ToString());
            Console.WriteLine();

            // Testing indexer
            Console.WriteLine("Getting value of element [1,4]");
            Console.WriteLine(matrix[1, 4]);

            // Testing dimension extractor
            Console.WriteLine("Getting the two dimensions of the matrix:");
            Console.WriteLine(matrix.Rows);
            Console.WriteLine(matrix.Columns);
            Console.WriteLine();
            Console.WriteLine("Press any key to continue testing...");
            Console.ReadKey();
            Console.WriteLine();

            // Testing operators overload
            Console.WriteLine("Initializing two matrices and prinitng them:");
            Matrix<double> testMatrix1 = new Matrix<double>(2, 3);
            for (int rows = 0; rows < testMatrix1.Rows; rows++)
            {
                for (int columns = 0; columns < testMatrix1.Columns; columns++)
                {
                    testMatrix1[rows, columns] = 2;
                }
            }
            Matrix<double> testMatrix2 = new Matrix<double>(2, 3);
            for (int rows = 0; rows < testMatrix2.Rows; rows++)
            {
                for (int columns = 0; columns < testMatrix2.Columns; columns++)
                {
                    testMatrix2[rows, columns] = 3;
                }
            }

            Console.WriteLine("Matrix 1:" + Environment.NewLine + testMatrix1.ToString() + Environment.NewLine);
            Console.WriteLine("Matrix 2:" + Environment.NewLine + testMatrix2.ToString() + Environment.NewLine);

            Console.WriteLine("Printing result of matrices addition:");
            Matrix<double> additionResult = testMatrix1 + testMatrix2;
            Console.WriteLine(additionResult + Environment.NewLine);
            Console.WriteLine("Printing result of matrices substraction:");
            Matrix<double> substractionResult = testMatrix1 - testMatrix2;
            Console.WriteLine(substractionResult + Environment.NewLine);
            Console.WriteLine("Printing result of matrices multiplication:");
            Matrix<double> multiplicationResult = testMatrix1 * testMatrix2;
            Console.WriteLine(multiplicationResult + Environment.NewLine);

            // Testing true/false operator override
            Console.WriteLine("Testing true/false operator overload:");
            if (multiplicationResult)
            {
                Console.WriteLine("There are zero elements.");
            }
            else
            {
                Console.WriteLine("There are no zero elements.");
            }
            Console.WriteLine();
            Console.WriteLine("The test of the Matrix project has been completed successfully! Have a nice day!");
        }
    }
}