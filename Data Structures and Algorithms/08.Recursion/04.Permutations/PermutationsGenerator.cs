using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class PermutationsGenerator
{
    private static List<int[]> permutations;
    private static int[] numbers;
    public static List<int[]> GeneratePermutations(int number)
    {
        permutations = new List<int[]>();
        numbers = new int[number + 1];
        
        return permutations;
    }
}