using System;

public class Product : IComparable
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Product(decimal price):this(null, price)
    {
    }

    public Product(string name, decimal price)
    {
        this.Name = name;
        this.Price = price;
    }

    public int CompareTo(object obj)
    {
        if (!(obj is Product))
        {
            throw new ArgumentException();
        }

        return this.Price.CompareTo((obj as Product).Price);
    }

    public override string ToString()
    {
        if (this.Name == null)
        {
            return string.Format("Unnamed; Cost:{0}", this.Price);
        }

        return string.Format("Name: {0}; Cost:{1}", this.Name, this.Price);
    }
}