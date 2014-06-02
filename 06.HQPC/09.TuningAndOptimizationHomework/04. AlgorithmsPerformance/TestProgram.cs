using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TestProgram
{
    private const int DEFAULT_SIZE = 10000; // 10 thousand

    static void Main(string[] args)
    {
        // Testing with Int32
        // Testing with random array
        int[] randomIntArray = GetRandomIntArray();
        TestArray(randomIntArray, "Random Int32 array");

        // Testing with sorted array
        Array.Sort(randomIntArray);
        TestArray(randomIntArray, "Sorted Int32 array");

        // Testing with reversed array
        var reversedRandomIntArray = randomIntArray.Reverse().ToArray();
        TestArray(reversedRandomIntArray, "Reversed random Int32 array");

        Console.WriteLine(new String('*', 40));

        // Testing with Double
        // Testing with random array
        double[] randomDoubleArray = GetRandomDoubleArray();
        TestArray(randomDoubleArray, "Random Double array");

        // Testing with sorted array
        Array.Sort(randomDoubleArray);
        TestArray(randomDoubleArray, "Sorted Double array");

        // Testing with reversed array
        var reversedDoubleIntArray = randomDoubleArray.Reverse().ToArray();
        TestArray(reversedDoubleIntArray, "Reversed Double array");

        Console.WriteLine(new String('*', 40));

        // Testing with string
        // Testing with random array
        string[] randomStringArray = GetRandomStringArray();
        TestArray(randomStringArray, "Random string array");

        // Testing with sorted array
        Array.Sort(randomStringArray);
        TestArray(randomStringArray, "Sorted string array");

        // Testing with reversed array
        var reversedStringIntArray = randomStringArray.Reverse().ToArray();
        TestArray(reversedStringIntArray, "Reversed string array");
    }

    private static string[] GetRandomStringArray()
    {
        string[] array = new string[DEFAULT_SIZE];
        Random rndm = new Random();
        for (int i = 0; i < DEFAULT_SIZE; i++)
        {
            array[i] = rndm.Next(int.MinValue, int.MaxValue).ToString();
        }

        return array;
    }

    private static double[] GetRandomDoubleArray()
    {
        double[] array = new double[DEFAULT_SIZE];
        Random rndm = new Random();
        for (int i = 0; i < DEFAULT_SIZE; i++)
        {
            array[i] = rndm.Next(int.MinValue, int.MaxValue);
        }

        return array;
    }

    private static int[] GetRandomIntArray()
    {
        int[] array = new int[DEFAULT_SIZE];
        Random rndm = new Random();
        for (int i = 0; i < DEFAULT_SIZE; i++)
        {            
            array[i] = rndm.Next(int.MinValue, int.MaxValue);
        }

        return array;
    }

    private static void TestArray<T>(T[] array, string arrayType)
    {
        Stopwatch stopWatch = new Stopwatch();

        // Insertion sort
        T[] copyOfOriginalArray = new T[array.Length];
        Array.Copy(array, copyOfOriginalArray, array.Length);

        stopWatch.Start();
        Sorter.InsertionSort((dynamic)copyOfOriginalArray);
        stopWatch.Stop();
        Console.WriteLine(arrayType +
                          " sorted with Insertion sort took " +
                          stopWatch.Elapsed);

        // Selection sort
        copyOfOriginalArray = new T[array.Length];
        Array.Copy(array, copyOfOriginalArray, array.Length);

        stopWatch.Restart();
        Sorter.SelectionSort((dynamic)copyOfOriginalArray);
        stopWatch.Stop();
        Console.WriteLine(arrayType +
                          " sorted with Selection sort took " +
                          stopWatch.Elapsed);

        // Quick sort
        copyOfOriginalArray = new T[array.Length];
        Array.Copy(array, copyOfOriginalArray, array.Length);

        stopWatch.Restart();
        Sorter.Quicksort((dynamic)copyOfOriginalArray);
        stopWatch.Stop();
        Console.WriteLine(arrayType +
                          " sorted with Quicksort sort took " +
                          stopWatch.Elapsed);

        Console.WriteLine();
    }
}