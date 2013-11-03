using System;
using System.Collections.Generic;

public static class Extensions
{
    public static double CustomSum<T>(this IEnumerable<T> list) where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        double result = 0;
        foreach (var number in list)
        {
            result += (dynamic)number;
        }
        return result;
    }

    public static double CustomProduct<T>(this IEnumerable<T> list) where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        double result = 1;
        foreach (var number in list)
        {
            result *= (dynamic)number;
        }
        return result;
    }

    public static double CustomMin<T>(this IEnumerable<T> list) where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        double result = long.MaxValue;
        foreach (var number in list)
        {
            if ((dynamic)number < result)
            {
                result = (dynamic)number;
            }
        }
        return result;
    }

    public static double CustomMax<T>(this IEnumerable<T> list) where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        double result = long.MinValue;
        foreach (var number in list)
        {
            if ((dynamic)number > result)
            {
                result = (dynamic)number;
            }
        }
        return result;
    }

    public static double CustomAverage<T>(this IEnumerable<T> list) where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        double sum = list.CustomSum();
        int counter = 0;
        foreach (var number in list)
        {
            counter++;
        }

        return sum / counter;
    }
}