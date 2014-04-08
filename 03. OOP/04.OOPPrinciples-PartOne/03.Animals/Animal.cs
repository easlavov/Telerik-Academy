using System;

public abstract class Animal:ISound
{
    private byte age;
    private string name;
    private string sex;

    public byte Age
    {
        get
        {
            return this.age;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Age can't be negative value!");
            }
            this.age = value;
        }
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            this.name = value;
        }
    }

    public string Sex
    {
        get
        {
            return this.sex;
        }
        set
        {
            if (value != "male" && value != "female")
            {
                throw new ArgumentException("Sex can only be 'male' or 'female'!");
            }
            this.sex = value;
        }
    }

    public abstract void MakeSound();

    // CalcAvAge
    public static float AverageAge(Animal[] animals)
    {
        float sumOfAges = 0;
        foreach (var animal in animals)
        {
            sumOfAges += animal.Age;
        }
        return sumOfAges / animals.Length;
    }
}