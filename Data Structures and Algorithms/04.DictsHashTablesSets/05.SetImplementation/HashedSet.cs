/*Implement the data structure "set" in a classHashedSet<T>using your classHashTable<K,T>to hold the elements. Implement all standard set operations likeAdd(T),Find(T),Remove(T),Count,Clear(), union and intersect.*/

using System.Collections;
using System.Collections.Generic;

public class HashedSet<T> : IEnumerable<T>
{
    private HashTable<T, bool> hashTable;

    public HashedSet()
    {
        this.hashTable = new HashTable<T, bool>();
    }

    public int Count
    {        
        get
        {            
            return (int)this.hashTable.Count;
        }
    }

    public bool Add(T element)
    {
        if (!this.hashTable.Contains(element))
        {
            this.hashTable.Add(element, true);
            return true;
        }

        return false;
    }

    public bool Contains(T element) // Find
    {
        if (this.hashTable.Contains(element))
        {
            return true;
        }

        return false;
    }

    public bool Remove(T element)
    {
        try
        {
            this.hashTable.Remove(element);
            return true;
        }
        catch (KeyNotFoundException)
        {
            return false;
        }        
    }

    public void Clear()
    {
        this.hashTable.Clear();
    }

    public void UnionWith(HashedSet<T> collection)
    {
        foreach (var key in collection)
        {
            this.Add(key);
        }
    }

    public void IntersectWith(HashedSet<T> collection)
    {
        List<T> toRemove = new List<T>();

        foreach (var key in this.hashTable)
        {
            if (!collection.Contains(key.Key))
            {
                toRemove.Add(key.Key);
            }
        }

        foreach (var key in toRemove)
        {
            this.Remove(key);
        }
    }


    public IEnumerator<T> GetEnumerator()
    {
        foreach (var element in this.hashTable)
        {
            yield return element.Key;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}