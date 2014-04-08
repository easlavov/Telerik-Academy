/*Implement the data structure "hash table" in a class HashTable<K,T>. Keep the data in array of lists of key-value pairs (LinkedList<KeyValuePair<K,T>>[]) with initial capacity of 16. When the hash table load runs over 75%, perform resizing to 2 times larger capacity. Implement the following methods and properties: Add(key, value), Find(key)value, Remove( key), Count, Clear(), this[], Keys. Try to make the hash table to support iterating over its elements with foreach.*/

using System.Collections;
using System.Collections.Generic;

public class HashTable<K, T> : IEnumerable<KeyValuePair<K, T>>
{
    private const int InitialHashTableCapacity = 16;
    private const float MaximumHashTableLoad = 0.75f;
    private LinkedList<KeyValuePair<K, T>>[] hashTable = new LinkedList<KeyValuePair<K, T>>[InitialHashTableCapacity];

    public double Count { get; private set; }
    public T this[K key]
    {
        get { return this.Find(key); }
    }

    public void Add(K key, T value)
    {
        AddElement(key, value, this.hashTable);
        this.Count++;

        // CheckLoad
        if (this.IsOverloaded()) { this.Expand(); }
    }

    public void Remove(K key)
    {
        var table = GetList(key);

        foreach (var pair in table)
        {
            if (pair.Key.Equals(key))
            {
                table.Remove(pair);
                this.Count--;
                return;
            }
        }
        throw new KeyNotFoundException();
    }

    public K[] Keys()
    {
        List<K> keys = new List<K>();
        foreach (var pair in this)
        {
            keys.Add(pair.Key);
        }
        return keys.ToArray();
    }

    public bool Contains(K key)
    {
        var table = GetList(key);
        foreach (var pair in table)
        {
            if (pair.Key.Equals(key))
            {
                return true;
            }
        }
        return false;
    }

    public void Clear()
    {
        this.hashTable = new LinkedList<KeyValuePair<K, T>>[InitialHashTableCapacity];
    }

    public T Find(K key)
    {
        return GetPair(key).Value;
    }

    private void AddElement(K key, T value, LinkedList<KeyValuePair<K, T>>[] array)
    {
        KeyValuePair<K, T> newPair = new KeyValuePair<K, T>(key, value);
        int index = (key.GetHashCode() & 0x7FFFFFFF) % array.Length;
        if (array[index] == null)
        {
            array[index] = new LinkedList<KeyValuePair<K, T>>();
        }
        array[index].AddLast(newPair);
    }

    private void Expand()
    {
        int newSize = this.hashTable.Length * 2;
        LinkedList<KeyValuePair<K, T>>[] newArray = new LinkedList<KeyValuePair<K, T>>[newSize];
        // foreach the current elements and add them to the new array
        foreach (var pair in this)
        {
            var currentPair = pair;
            this.AddElement(currentPair.Key, currentPair.Value, newArray);
        }

        this.hashTable = newArray;
    }

    private bool IsOverloaded()
    {
        if ((this.Count) / this.hashTable.Length > MaximumHashTableLoad)
        {
            return true;
        }
        return false;
    }    

    private KeyValuePair<K, T> GetPair(K key)
    {
        var table = GetList(key);

        foreach (var pair in table)
        {
            if (pair.Key.Equals(key))
            {
                return pair;
            }
        }
        throw new KeyNotFoundException();
    }    

    private LinkedList<KeyValuePair<K, T>> GetList(K key)
    {
        int index = (key.GetHashCode() & 0x7FFFFFFF) % this.hashTable.Length;
        if (this.hashTable[index] == null)
        {
            this.hashTable[index] = new LinkedList<KeyValuePair<K, T>>();
        }
        return this.hashTable[index];
    }

    public IEnumerator<KeyValuePair<K, T>> GetEnumerator()
    {
        for (int i = 0; i < this.hashTable.Length; i++)
        {
            if (this.hashTable[i] != null)
            {
                foreach (var pair in this.hashTable[i])
                {
                    yield return pair;
                }
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}