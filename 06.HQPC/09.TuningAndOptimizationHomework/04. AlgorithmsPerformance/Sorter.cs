using System;
using System.Collections.Generic;
using System.Linq;

public static class Sorter
{
    public static void InsertionSort<T>(IList<T> collection) where T : IComparable<T>
    {
        for (int i = 1; i < collection.Count; i++)
        {
            T index = collection[i];
            int j = i;

            //while ((j > 0) && (collection[j - 1] > (dynamic)index))
            while ((j > 0) && (collection[j - 1].CompareTo(index) > 0))
            {
                collection[j] = collection[j - 1];
                j = j - 1;
            }

            collection[j] = index;
        }
    }

    public static void SelectionSort<T>(IList<T> collection) where T : IComparable<T>
    {
        int leftPivot = 0;
        int count = collection.Count;
        while (leftPivot < count)
        {
            T smallest = collection[leftPivot];
            int smallestIndex = leftPivot;
            for (int index = leftPivot; index < count; index++)
            {
                //if (collection[index] < (dynamic)smallest)
                if (collection[index].CompareTo((dynamic)smallest) > 0)
                {
                    smallestIndex = index;
                }
            }

            if (smallestIndex != leftPivot) // swap
            {
                T temp = collection[leftPivot];
                collection[leftPivot] = collection[smallestIndex];
                collection[smallestIndex] = temp;
            }

            leftPivot++;
        }
    }

    public static void Quicksort<T>(IList<T> collection) where T : IComparable<T>
    {
        if (collection.Count < 2)
        {
            return;
        }

        dynamic pivot = collection[collection.Count / 2];
        IList<T> smaller = new List<T>();
        IList<T> pivotArr = new List<T>() { pivot };
        IList<T> bigger = new List<T>();

        for (int i = 0; i < collection.Count; i++)
        {
            if (i != collection.Count / 2)
            {
                //if (collection[i] <= pivot)
                if (collection[i].CompareTo(pivot) <= 0)
                {
                    smaller.Add(collection[i]);
                }
                else
                {
                    bigger.Add(collection[i]);
                }
            }
        }

        Quicksort(smaller);
        Quicksort(bigger);

        List<T> newList = smaller.Concat(pivotArr).Concat(bigger).ToList();
        for (int i = 0; i < newList.Count; i++)
        {
            collection[i] = newList[i];
        }
    }
}