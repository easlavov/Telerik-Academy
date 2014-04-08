using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedListCustom<T> : IEnumerable<T>
{
    public ListItemCustom<T> FirstItem { get; set; }
    public ListItemCustom<T> LastItem { get; set; }
    public int Count
    {
        get;
        private set;
    }

    public void AddFirst(ListItemCustom<T> item)
    {
        if (this.Count == 0)
        {
            this.FirstItem = item;
            this.LastItem = item;
        }
        else
        {
            item.NextItem = this.FirstItem;
            this.FirstItem = item;
        }
        this.Count++;
    }

    public void AddFirst(T item)
    {
        ListItemCustom<T> newItem = new ListItemCustom<T>(item);
        this.AddFirst(newItem);
    }

    public void AddLast(ListItemCustom<T> item)
    {
        if (this.Count == 0)
        {
            this.FirstItem = item;
            this.LastItem = item;
        }
        else
        {
            this.LastItem.NextItem = item;
            this.LastItem = item;
        }
        this.Count++;
    }

    public void AddLast(T item)
    {
        ListItemCustom<T> newItem = new ListItemCustom<T>(item);
        this.AddLast(newItem);
    }

    public void AddBefore(ListItemCustom<T> node, ListItemCustom<T> newItem) 
    {
        if (node == null || newItem == null)
        {
            throw new ArgumentNullException();
        }   
        if (node == this.FirstItem)
        {
            this.AddFirst(newItem);
            return;
        }
        GetPrev(node).NextItem = newItem;
        newItem.NextItem = node;
        this.Count++;
    }

    public void AddBefore(ListItemCustom<T> node, T newItem)
    {
        ListItemCustom<T> newNode = new ListItemCustom<T>(newItem);
        this.AddBefore(node, newNode);
    }

    private ListItemCustom<T> GetPrev(ListItemCustom<T> item)
    {
        ListItemCustom<T> currentNode = this.FirstItem;
        while (currentNode.NextItem != null)
        {
            if (currentNode.NextItem == item)
            {
                return currentNode;
            }
            currentNode = currentNode.NextItem;
        }
        throw new NullReferenceException();
    }

    public void AddAfter(ListItemCustom<T> node, ListItemCustom<T> newItem)
    {
        if (node == null || newItem == null)
        {
            throw new ArgumentNullException();
        }
        if (node.NextItem == null)
        {
            this.AddLast(newItem);
            return;
        }        
        newItem.NextItem = node.NextItem;
        node.NextItem = newItem;
        this.Count++;
    }

    public void AddAfter(ListItemCustom<T> node, T newItem)
    {
        ListItemCustom<T> newNode = new ListItemCustom<T>(newItem);
        this.AddAfter(node, newNode);
    }

    public IEnumerator<T> GetEnumerator()
    {
        var currentNode = this.FirstItem;
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