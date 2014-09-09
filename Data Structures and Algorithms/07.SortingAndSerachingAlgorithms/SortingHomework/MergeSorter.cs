namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            var asArray = collection.ToArray();
            Split(asArray, 0, collection.Count);
            var result = asArray.ToList();
            collection = result;
        }

        // TODO: Rework!
        static T[] Split(T[] arr, int low, int high)
        {
            // Splitting part:

            // This is the bottom of the recursion
            if (high == 1)
            {
                return arr;
            }

            // Arrays are split in two until only single element arrays remain. Recursion is used.
            int mid = high / 2;
            int lengthLow, lengthHigh;
            if (high % 2 == 0)
            {
                lengthLow = high / 2;
                lengthHigh = lengthLow;
            }
            else
            {
                lengthLow = high / 2 + 1;
                lengthHigh = high / 2;
            }
            T[] lowArray = new T[lengthLow];
            for (int i = 0; i < lowArray.Length; i++)
            {
                lowArray[i] = (dynamic)arr[i];
            }
            T[] highArray = new T[lengthHigh];
            for (int i = 0; i < highArray.Length; i++)
            {
                if (high % 2 == 0)
                {
                    highArray[i] = (dynamic)arr[mid + i];
                }
                else
                {
                    highArray[i] = (dynamic)arr[mid + i + 1];
                }
            }

            // Split the remaining arrays using recursion
            Split(lowArray, 0, lowArray.Length);
            Split(highArray, 0, highArray.Length);

            // Sorting part

            int index = 0;
            int pos1 = 0;
            int pos2 = 0;

            // Array elements from both arrays are compared and moved into the resulting array
            while (true)
            {
                if (lowArray[pos1] <= (dynamic)highArray[pos2])
                {
                    arr[index] = (dynamic)lowArray[pos1];
                    pos1++;
                    if (pos1 == lowArray.Length)
                    {
                        pos1--;
                        lowArray[pos1] = (dynamic)int.MaxValue;
                    }
                }
                else
                {
                    arr[index] = highArray[pos2];
                    pos2++;
                    if (pos2 == highArray.Length)
                    {
                        pos2--;
                        highArray[pos2] = (dynamic)int.MaxValue;
                    }
                }
                index++;
                if (index == arr.Length)
                {
                    break;
                }

            }

            // Resulting array is returned to be compared to another until we have only one array left - the sorted one
            return arr;
        }
    }
}
