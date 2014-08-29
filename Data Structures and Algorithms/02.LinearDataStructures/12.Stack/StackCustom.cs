// Implement the ADT stack as auto-resizable array. Resize the capacity on demand (when no space is available to add / insert a new element).
using System;
using System.Collections;
using System.Collections.Generic;

public class StackCustom<T> : IEnumerable<T>
{
    private const int DefaultStartingCapacity = 4;
    private T[] stack;

    public StackCustom()
        : this(DefaultStartingCapacity)
    {
    }

    public int Count { get; private set; }

    public StackCustom(int capacity)
    {
        this.stack = new T[capacity];
        this.Count = 0;
    }

    public void Push(T item)
    {
        // check if stack array is full
        if (this.Count == this.stack.Length - 1)
        {
            // double the array's length
            T[] temp = new T[this.stack.Length * 2];
            Array.Copy(this.stack, temp, this.Count);
            this.stack = temp;
        }

        this.stack[this.Count] = item;
        this.Count++;
    }

    public T Pop()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("Stack is empty");
        }

        this.Count--;
        return this.stack[this.Count + 1];
    }

    public T Peek()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("Stack is empty");
        }

        return this.stack[this.Count - 1];
    }

    public bool Contains(T item)
    {
        foreach (var it in this)
        {
            if (it.Equals(item))
            {
                return true;
            }
        }

        return false;
    }

    public void Clear()
    {
        this.Count = 0;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.Count; i++)
        {
            yield return this.stack[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}