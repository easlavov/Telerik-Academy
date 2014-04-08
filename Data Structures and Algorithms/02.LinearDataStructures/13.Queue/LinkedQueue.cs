using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedQueue<T> : IEnumerable<T>
{
    private ListItemCustom<T> firstElement;
    private ListItemCustom<T> lastElement;
    public int Count { get; private set; }

    public LinkedQueue()
    {
        this.Count = 0;
    }

    public void Enqueue(T item)
    {
        ListItemCustom<T> newNode = new ListItemCustom<T>(item);
        if (this.Count == 0)
        {
            this.firstElement = newNode;                        
        }
        else
        {
            this.lastElement.NextItem = newNode;            
        }
        this.lastElement = newNode;
        this.Count++;
    }

    public T Dequeue()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }
        this.firstElement = this.firstElement.NextItem;
        if (this.Count == 1)
        {
            this.lastElement = null;
        }
        this.Count--;
        return this.firstElement.Value;
    }

    public T Peek()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("Queue is empty");
        }
        return this.firstElement.Value;
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
        this.firstElement = null;
        this.lastElement = null;
        this.Count = 0;
    }

    public IEnumerator<T> GetEnumerator()
    {
        ListItemCustom<T> currentNode = this.firstElement;
        while (currentNode != null)
        {
            yield return currentNode.Value;
            currentNode = currentNode.NextItem;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}