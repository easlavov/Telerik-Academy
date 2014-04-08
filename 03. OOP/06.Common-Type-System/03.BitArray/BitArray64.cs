using System;
using System.Collections;
using System.Collections.Generic;

public class BitArray64 : IEnumerable<int>
{
    // Fields
    private readonly ulong value;
    private readonly int[] bitArray;

    // Constructors
    public BitArray64(ulong value)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException("Value can't be negative!");
        }
        if (value > ulong.MaxValue)
        {
            throw new ArgumentOutOfRangeException(string.Format(
                "Value can't be bigger than {0}!", ulong.MaxValue));
        }
        this.value = value;
        this.bitArray = ConvToBitArr(value);
    }

    // Properties
    public ulong Value
    {
        get
        {
            return this.value;
        }
    }

    public int[] BitArray
    {
        get
        {
            return this.bitArray;
        }
    }

    // Overrides
    public override bool Equals(object obj)
    {
        BitArray64 arr = obj as BitArray64;
        if (arr == null)
        {
            return false;
        }
        if (this.Value != arr.Value)
        {
            return false;
        }
        return true;
    }

    // NO NEED TO OVERRIDE THE GetHashCode()
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public static bool operator ==(BitArray64 bArr1, BitArray64 bArr2)
    {
        if (BitArray64.Equals(bArr1,bArr2))
        {
            return true;
        }
        return false;
    }

    public static bool operator !=(BitArray64 bArr1, BitArray64 bArr2)
    {
        if (BitArray64.Equals(bArr1, bArr2))
        {
            return false;
        }
        return true;
    }

    // Methods
    private int[] ConvToBitArr(ulong number)
    {
        string num = Convert.ToString((long)number, 2).PadLeft(64, '0');
        int[] bitArr = new int[64];
        for (int i = 0; i < num.Length; i++)
        {
            bitArr[i] = byte.Parse(num[i].ToString());
        }
        return bitArr;
    }

    // Implementations
    IEnumerator IEnumerable.GetEnumerator()
    {
        // Call the generic version of the method
        return this.GetEnumerator();
    }

    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 0; i < 64; i++)
        {
            yield return this.BitArray[i];
        }
    }    

    // Indexator
    public int this[int index]
    {
        get
        {
            return this.BitArray[index];
        }
    }
}