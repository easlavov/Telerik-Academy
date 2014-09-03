using System;
using System.Collections;
using System.Collections.Generic;

public class PriorityQueue<T> : IEnumerable<T> where T: IComparable<T>
{
    private BinaryHeap<T> binHeap;

    public PriorityQueue()
    {
        this.binHeap = new BinaryHeap<T>();
    }

    public void Enqueue(T element)
    {
        this.binHeap.Add(element);
    }

    public T Dequeue()
    {
        return this.binHeap.Remove();
    }

    public T Peek()
    {
        return this.binHeap.Peek();
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (var element in this.binHeap)
        {
            yield return element;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public override string ToString()
    {
        return string.Join(", ", this);
    }
}