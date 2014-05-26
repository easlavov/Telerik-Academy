using System;

public class Statistics
{
    public void PrintStatistics(double[] arr)
    {
        double max = GetMaximum(arr);
        Console.WriteLine(max);

        double min = GetMinimum(arr);
        Console.WriteLine(min);

        double average = GetAverage(arr);
        Console.WriteLine(average);
    }
    
    /// <summary>
    /// Returns the biggest value from an array of doubles
    /// </summary>
    /// <param name="arr">The array of doubles.</param>
    /// <returns>The biggest value in the array.</returns>
    private double GetMaximum(double[] arr)
    {
        double max = arr[0];
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
            }
        }

        return max;
    }

    /// <summary>
    /// Returns the smallest value from an array of doubles
    /// </summary>
    /// <param name="arr">The array of doubles.</param>
    /// <returns>The smallest value in the array.</returns>
    private double GetMinimum(double[] arr)
    {
        double min = arr[0];
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] < min)
            {
                min = arr[i];
            }
        }

        return min;
    }

    /// <summary>
    /// Returns the average value of an array of doubles
    /// </summary>
    /// <param name="arr">The array of doubles.</param>
    /// <returns>The average value of the array.</returns>
    private double GetAverage(double[] arr)
    {
        double sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }

        double average = sum / arr.Length;
        return average;
    }
}

