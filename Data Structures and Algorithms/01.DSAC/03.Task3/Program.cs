using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static long CalcSum(int[,] matrix, int row)
    {
        long sum = 0;
        for (int col = 0; col < matrix.GetLength(0); col++) 
            sum += matrix[row, col];
        if (row + 1 < matrix.GetLength(1)) 
            sum += CalcSum(matrix, row + 1);
        return sum;
    }

    // TODO: Remove
    static void CalcSumAlt(int[,] matrix, int row)
    {
        for (int col = 0; col < matrix.GetLength(1); col++)
            matrix[row, col] = row + col;
        if (row + 1 < matrix.GetLength(0))
            CalcSumAlt(matrix, row + 1);        
    }



    static void Main()
    {
        // this algorithm goes over the whole matrix. it's linear
        int[,] matrix = new int[5, 10]; // 100 million
        // TODO: Rework example
        CalcSumAlt(matrix, 0);
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i,j] + " ");
            }
            Console.WriteLine();
        }

        //long sum1 = 0;
        //for (int i = 0; i < matrix.GetLength(0); i++)
        //{
        //    for (int j = 0; j < matrix.GetLength(1); j++)
        //    {
        //        sum1 += matrix[i, j];
        //    }
            
        //}
        //Console.WriteLine("Sum1: " + sum1);

        //Console.WriteLine("Sum2: " + CalcSum(matrix, 0));

        for (int i = 2; i < 12; i++)
        {

            Console.WriteLine(i % 2 == 0 ? i : -i);

        }
    }
}