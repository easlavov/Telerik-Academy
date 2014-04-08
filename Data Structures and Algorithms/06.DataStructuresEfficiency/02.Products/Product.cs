using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// by barcode, vendor, title and price
public class Product : IComparable
{
    public int BarCode { get; set; }
    public string Vendor { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
    
    public Product(decimal price)
    {
        this.Price = price;
    }

    public int CompareTo(object obj)
    {
        var prod = obj as Product;
        if (prod == null)
        {
            throw new ArgumentNullException();
        }
        return this.Price.CompareTo(prod.Price);
    }
}