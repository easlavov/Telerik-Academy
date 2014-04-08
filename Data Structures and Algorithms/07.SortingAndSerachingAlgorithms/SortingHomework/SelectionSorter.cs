namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            int leftPivot = 0;
            int count = collection.Count;
            while (leftPivot < count)
            {
                T smallest = collection[leftPivot];
                int smallestIndex = leftPivot;
                for (int index = leftPivot; index < count; index++)
                {
                    if (collection[index] < (dynamic)smallest)
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
    }
}
