namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            foreach (var element in this.Items)
            {
                if (element == (dynamic)item)
                {
                    return true;
                }
            }
            return false;
        }

        public bool BinarySearch(T item)
        {
            if (this.Items.Count == 1)
            {
                if (this.Items[0] == (dynamic)item)
                {
                    return true;
                }
                return false;
            }

            int pivotIndex = this.Items.Count / 2;
            int leftIndex = 0;
            int rightIndex = this.Items.Count - 1;
            while (leftIndex <= rightIndex)
            {
                if (this.Items[pivotIndex] == (dynamic)item)
                {
                    return true;
                }
                else if (this.Items[pivotIndex] < (dynamic)item) // then the number we're looking for is to the right
                {
                    leftIndex = pivotIndex + 1;
                }
                else if (this.Items[pivotIndex] > (dynamic)item) // then the number we're looking for is to the left
                {
                    rightIndex = pivotIndex - 1;
                }
                pivotIndex = (rightIndex + leftIndex) / 2;
            }
            return false;
        }

        public void Shuffle()
        {
            // Fisher-Yates shuffle - complexity O(n)
            Random rndm = new Random();
            for (int i = 0; i < this.Items.Count; i++)
            {
                int ran = rndm.Next(0, this.Items.Count);
                T temp = this.Items[i];
                this.Items[i] = this.Items[ran];
                this.Items[ran] = temp;
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
