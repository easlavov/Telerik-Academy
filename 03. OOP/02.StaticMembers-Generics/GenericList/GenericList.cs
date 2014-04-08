using System;
using System.Text;

namespace GenericList
{
    public class GenericList<T>
    {
        // Fields
        private int capacity;
        private int firstEmptyElement;
        private T[] arr;
        private readonly int defaulSize = 4;

        // Constructors
        public GenericList() // Task says size must be passed as a parameter
        {
            this.Capacity = defaulSize;
            // firstEmptyElement default value is int default value (0)
            this.Arr = new T[capacity];
        }

        // Properties
        public int Capacity
        {
            get { return this.capacity; }
            set { this.capacity = value; }
        }

        public int FirstEmptyElement
        {
            get { return this.firstEmptyElement; }
            set { this.firstEmptyElement = value; }
        }


        public T[] Arr
        {
            get { return this.arr; }
            set { this.arr = value; }
        }

        // Methods
        public void AddElement(T element)
        {
            // Check if array can hold one more element
            // Else double its size by creating a new array
            // and copying the elements from the old array
            // to the new
            if (this.FirstEmptyElement == this.Capacity)
            {
                IncreaseCapacity();
            }
            // Add element to the end of the array
            this.Arr[this.FirstEmptyElement] = element;
            FirstEmptyElement++;
        }

        public T ReadElement(int index)
        {
            if (index < 0 || index >= this.FirstEmptyElement)
            {
                throw new ArgumentOutOfRangeException("The index you are trying to access is invalid.");
            }
            return this.Arr[index];
        }

        public void RemoveElement(int index)
        {
            // Check input parameter
            if (index < 0 || index >= this.FirstEmptyElement)
            {
                throw new ArgumentOutOfRangeException("The index you are trying to access is invalid.");
            }
            // Check if last
            if (index == this.FirstEmptyElement - 1)
            {
                this.Arr[index] = default(T);
            }
            else
            {
                // Shift all elements after the removed one one position lower
                for (int i = index; i < this.FirstEmptyElement - 1; i++)
                {
                    this.Arr[i] = this.Arr[i + 1];
                }
            }
            this.FirstEmptyElement--;
        }

        public void InsertElement(int index, T element)
        {
            // All elements, starting from the index, are shifted to a higher position
            // in the array

            // Check input parameter
            if (index < 0 || index >= this.FirstEmptyElement)
            {
                throw new ArgumentOutOfRangeException("Index must be inside the boundaries of the list");
            }
            // Check if array can hold one element more
            if (this.FirstEmptyElement + 1 == this.Capacity)
            {
                IncreaseCapacity();
            }
            // Shift elements
            for (int i = this.FirstEmptyElement; i > index; i--)
            {
                this.Arr[i] = this.Arr[i - 1];
            }
            // Add element
            this.Arr[index] = element;
            FirstEmptyElement++;
        }

        public void ClearList()
        {
            this.Arr = new T[this.Capacity];
            this.FirstEmptyElement = 0;
        }

        // Note: Binary search would require a sorted array.
        // Sorting not specified as class function in the task.
        public int FindElement(T element)
        {
            for (int i = 0; i < this.Capacity; i++)
            {
                if (this.Arr[i] == (dynamic)element)
                {
                    return i;
                }
            }
            return -1;
        }

        public U Min<U>() where U: IComparable
        {
            if (this.Arr.Length == 0)
            {
                throw new InvalidOperationException("Can't use Min<T>() on empty lists!");
            }
            dynamic min = this.Arr[0];
            for (int i = 0; i < capacity; i++)
            {
                if (this.Arr[i] < min)
                {
                    min = this.Arr[i];
                }
            }
            return min;
        }

        public U Max<U>() where U : IComparable
        {
            if (this.Arr.Length == 0)
            {
                throw new InvalidOperationException("Can't use Max<T>() on empty lists!");
            }
            dynamic max = this.Arr[0];
            for (int i = 0; i < capacity; i++)
            {
                if (this.Arr[i] > max)
                {
                    max = this.Arr[i];
                }
            }
            return max;
        }

        private void IncreaseCapacity()
        {
            T[] newArray = new T[this.Capacity * 2];
            Array.Copy(this.Arr, newArray, this.Capacity);
            Capacity *= 2;
            this.Arr = newArray;
        }

        // Overrides
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < this.FirstEmptyElement; i++)
            {
                str.Append(this.Arr[i]);
                str.Append(' ');
            }
            return str.ToString();
        }
    }
}
