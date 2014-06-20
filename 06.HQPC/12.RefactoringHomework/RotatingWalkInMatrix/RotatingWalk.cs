using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotatingWalkInMatrix
{
    public static class RotatingWalk
    {
        private const int MIN_MATRIX_SIZE = 1;
        private const int MAX_MATRIX_SIZE = 100;

        /// <summary>
        /// Returns a square integer matrix of specified size filled according to the Rotating Walk rules.
        /// </summary>
        /// <param name="size">The size of the matrix.</param>
        /// <returns>An Int32 matrix.</returns>
        public static int[,] GenerateMatrix(int size)
        {
            if (size < MIN_MATRIX_SIZE || MAX_MATRIX_SIZE < size)
            {
                string errMessage = string.Format("Size must be a value between {0} and {1}.",
                                                  MIN_MATRIX_SIZE,
                                                  MAX_MATRIX_SIZE);
                throw new ArgumentOutOfRangeException(errMessage);
            }

            int[,] matrix = new int[size, size];
            FillMatrix(matrix);
            return matrix;
        }
        
        private static void FillMatrix(int[,] matrix)
        {
            Debug.Assert(matrix.GetLength(0) == matrix.GetLength(1), "Matrix must be square.");
            int totalCells = matrix.GetLength(0) * matrix.GetLength(1);
            int currentRow = 0;
            int currentCol = 0;
            for (int valueToSet = 1; valueToSet < totalCells; valueToSet++)
            {
                
            }
        }
    }
}
