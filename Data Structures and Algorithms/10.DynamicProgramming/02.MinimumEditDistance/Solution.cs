using System;
using System.Text;

public class Solution
{
    private const double REPLACE_COST = 1;
    private const double DELETE_COST = 0.9;
    private const double INSERT_COST = 0.8;

    public static void Main(string[] args)
    {
        Console.WriteLine("Please enter a word:");
        string word = Console.ReadLine();
        Console.WriteLine("Please enter the target word:");
        string changedWord = Console.ReadLine();
        int[,] longestCommonSetMatrix = BuildMatrixOfLongestCommonSet(changedWord, word);
        double cost = CalcTransformCost(longestCommonSetMatrix, changedWord, word);
        Console.WriteLine("The cost is: {0}", cost);
    }    

    private static double CalcTransformCost(int[,] matrix, string changedWord, string word)
    {
        double transformCost = 0;

        int currentX = matrix.GetLength(0) - 1;
        int currentY = matrix.GetLength(1) - 1;

        while (currentX != 0 && currentY != 0)
        {
            if (changedWord[currentX - 1] == word[currentY - 1])
            {
                currentX--;
                currentY--;
            }
            else if (matrix[currentX - 1, currentY] == matrix[currentX, currentY - 1])
            {
                transformCost += REPLACE_COST;
                currentX--;
                currentY--;
            }
            else if (matrix[currentX - 1, currentY] > matrix[currentX, currentY - 1])
            {
                transformCost += INSERT_COST;
                currentX--;
            }
            else
            {
                transformCost += DELETE_COST;
                currentY--;
            }
        }

        if (currentX > 0)
        {
            transformCost += currentX * INSERT_COST;
        }

        if (currentY > 0)
        {
            transformCost += currentY * DELETE_COST;
        }

        return transformCost;
    }

    private static int[,] BuildMatrixOfLongestCommonSet(string targetWord, string initialWord)
    {
        int[,] longestCommonSetMatrix = new int[targetWord.Length + 1, initialWord.Length + 1];

        for (int i = 1; i <= targetWord.Length; i++)
        {
            bool letterMatched = false;
            for (int j = 1; j <= initialWord.Length; j++)
            {
                if ((!letterMatched) && (targetWord[i - 1] == initialWord[j - 1]))
                {
                    longestCommonSetMatrix[i, j] = longestCommonSetMatrix[i, j - 1] + 1;
                    letterMatched = true;
                }
                else
                {
                    longestCommonSetMatrix[i, j] = Math.Max(longestCommonSetMatrix[i - 1, j], longestCommonSetMatrix[i, j - 1]);
                }
            }
        }

        return longestCommonSetMatrix;
    }
}