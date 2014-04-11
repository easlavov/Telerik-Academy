using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class VariationsGenerator<T>
{
    static int n; // total elements
    static int k; // elements in each variation
    static List<T[]> variations;
    static T[] variation;

    public static List<T[]> GenerateVariations(T[] array, int k)
    {
        variations = new List<T[]>();
        variation = new T[k];
        GenerateNext(array, k, 0);
        return variations;
    }

    private static void GenerateNext(T[] array, int k, int index)
    {
        if (index == k)
        {
            AddVariation(k);
            return;
        }
        for (int i = 0; i < array.Length; i++)
        {
            variation[index] = array[i];
            GenerateNext(array, k, index + 1);
        }
    }
  
    private static void AddVariation(int k)
    {
        T[] temp = new T[k];
        Array.Copy(variation, temp, k);
        variations.Add(temp);
    }
}