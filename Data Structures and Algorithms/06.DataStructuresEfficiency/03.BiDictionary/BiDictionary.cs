using System.Collections.Generic;
using System.Linq;

public class BiDictionary<K1, K2, T>
{
    private Dictionary<K1, List<T>> dictKeyOne;
    private Dictionary<K2, List<T>> dictKeyTwo;

    public BiDictionary()
    {
        this.dictKeyOne = new Dictionary<K1, List<T>>();
        this.dictKeyTwo = new Dictionary<K2, List<T>>();
    }

    public void Add(K1 key1, K2 key2, T value)
    {
        AddKeyOne(key1, value);
        AddKeyTwo(key2, value);
    }  
  
    public void AddKeyOne(K1 key1, T value)
    {
        if (!this.dictKeyOne.ContainsKey(key1))
        {
            this.dictKeyOne.Add(key1, new List<T>());
        }

        this.dictKeyOne[key1].Add(value);
    }

    public void AddKeyTwo(K2 key2, T value)
    {
        if (!this.dictKeyTwo.ContainsKey(key2))
        {
            this.dictKeyTwo.Add(key2, new List<T>());
        }

        this.dictKeyTwo[key2].Add(value);
    }

    public List<T> GetValue(K1 key) // return empty list if key is not present
    {
        if (this.dictKeyOne.ContainsKey(key))
        {
            return this.dictKeyOne[key];
        }

        return new List<T>();        
    }

    public List<T> GetValue(K2 key) // return empty list if key is not present
    {
        if (this.dictKeyTwo.ContainsKey(key))
        {            
            return this.dictKeyTwo[key];
        }

        return new List<T>();
    }

    public List<T> GetValue(K1 keyOne, K2 keyTwo)
    {
        return GetValue(keyOne).Concat(GetValue(keyTwo)).ToList<T>();
    }
}