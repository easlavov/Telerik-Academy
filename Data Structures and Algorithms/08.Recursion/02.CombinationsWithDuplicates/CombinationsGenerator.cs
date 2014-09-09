using System.Collections.Generic;

public static class CombinationsGenerator
{
    private static int uppermost;
    private static int elementsPerCombination;
    private static bool skipDuplicates;
    private static List<int[]> result;
    private static int[] combination;

    public static List<int[]> GenerateCombinations(int upper, int elementsPerComb, bool toSkipDuplicates)
    {
        uppermost = upper;
        elementsPerCombination = elementsPerComb;
        skipDuplicates = toSkipDuplicates;
        result = new List<int[]>();
        combination = new int[elementsPerComb];
        Generator(0, 1);
        return result;
    }

    private static void Generator(int index, int start)
    {
        if (index == elementsPerCombination)
        {
            int[] temp = new int[elementsPerCombination];
            combination.CopyTo(temp, 0);
            result.Add(temp);
            return;
        }

        for (int i = start; i <= uppermost; i++)
        {
            combination[index] = i;
            if (skipDuplicates)
            {
                Generator(index + 1, i + 1);            
            }
            else
            {
                Generator(index + 1, 1);
            }
        }
    }
}