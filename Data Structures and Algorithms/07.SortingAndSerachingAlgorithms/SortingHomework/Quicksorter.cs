namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
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
                    if (collection[i] <= pivot)
                    {
                        smaller.Add(collection[i]);
                    }
                    else
                    {
                        bigger.Add(collection[i]);
                    }
                }                
            }
            Sort(smaller);
            Sort(bigger);
            List<T> newList = smaller.Concat(pivotArr).Concat(bigger).ToList();
            for (int i = 0; i < newList.Count; i++)
            {
                collection[i] = newList[i];
            }
        }
    }
}
