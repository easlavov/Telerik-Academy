using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

class Solution
{
    static int maxN = 100050;

    static void Main()
    {
        var shoppingCenter = new ShoppingCenter();
        //StreamReader reader = new StreamReader(@"C:\Users\easla_000\Downloads\Sample-Exam\Problem 5 - Shopping Center\Tests\Tests\test.003.in.txt");

        int commandsCount = int.Parse(Console.ReadLine());
        string command = Console.ReadLine();
        for (int i = 0; i < commandsCount; i++)
        {
            ReadAndExecute(command, shoppingCenter);
            command = Console.ReadLine();
        }

        //int commandsCount = int.Parse(reader.ReadLine());
        //string command = reader.ReadLine();
        //for (int i = 0; i < commandsCount; i++)
        //{
        //    ReadAndExecute(command, shoppingCenter);
        //    command = reader.ReadLine();
        //}

        shoppingCenter.Print();        
    }

    private static void Test(ShoppingCenter shoppingCenter)
    {
        for (int i = 0; i < maxN; i++)
        {
            shoppingCenter.AddProduct(new string[]
            {
                // IdeaPad Z560;1536.50;Lenovo
                "IdeaPad Z560",
                "1536.50",
                "Lenovo"
            });
        }

        Console.WriteLine("Done");
        //Console.ReadKey();

        //shoppingCenter.DeleteProducts(new string[]
        //{
        //    // IdeaPad Z560;Lenovo
        //    //"IdeaPad Z560",
        //    "Lenovo",
        //});
        //Console.WriteLine("Deleted");
        //Console.ReadKey();

        shoppingCenter.FindProductsByName(new string[]
        {
            "IdeaPad Z560",
        });
    }

    private static void ReadAndExecute(string input, ShoppingCenter shoppingCenter)
    {
        string inputLine = input;
        int indexOfFirstWhitespace = inputLine.IndexOf(' ');
        string command = inputLine.Substring(0, indexOfFirstWhitespace);
        string[] commandParams = inputLine.Substring(indexOfFirstWhitespace + 1, inputLine.Length - indexOfFirstWhitespace - 1).Split(';');
        ExecuteCommand(command, commandParams, shoppingCenter);
    }

    private static void ExecuteCommand(string command, string[] parameters, ShoppingCenter shoppingCenter)
    {
        switch (command)
        {
            case "AddProduct":
                shoppingCenter.AddProduct(parameters); break;
            case "DeleteProducts":
                shoppingCenter.DeleteProducts(parameters); break;
            case "FindProductsByName" :
                shoppingCenter.FindProductsByName(parameters); break;
            case "FindProductsByPriceRange":
                shoppingCenter.FindProductsByPriceRange(parameters); break;
            case "FindProductsByProducer":
                shoppingCenter.FindProductsByProducer(parameters); break;
            default:
                break;
        }
    }
}

class ShoppingCenter
{
    private Bag<Product> products;
    private StringBuilder output;

    public ShoppingCenter()
    {
        this.products = new Bag<Product>();
        this.output = new StringBuilder();
    }

    public void AddProduct(string[] parameters)
    {
        // AddProduct CLS 63 AMG;200000;Mercedes
        string productName = parameters[0];
        float price = float.Parse(parameters[1]);
        string producer = parameters[2];
        var product = new Product(productName, price, producer);

        this.products.Add(product);

        this.output.AppendLine("Product added");
    }

    public void DeleteProducts(string[] parameters)
    {
        if (parameters.Length == 2)
        {
            this.DeleteByNameAndProducer(parameters);
        }
        else
        {
            this.DeleteByProducer(parameters);
        }
    }

    public void FindProductsByName(string[] parameters)
    {
        string name = parameters[0];
        var prods = this.products.Where(p => p.Name == name);
        if (prods.Count() == 0)
        {
            this.output.AppendLine("No products found");
            return;
        }

        var items = new OrderedBag<Product>(prods);
        this.StringifyCollection(items);
    }

    internal void FindProductsByPriceRange(string[] parameters)
    {
        float fromPrice = float.Parse(parameters[0]);
        float toPrice = float.Parse(parameters[1]);
        var prods = this.products.Where(p => p.Price >= fromPrice && toPrice >= p.Price);
        if (prods.Count() == 0)
        {
            this.output.AppendLine("No products found");
            return;
        }

        var items = new OrderedBag<Product>(prods);
        this.StringifyCollection(items);
    }

    internal void FindProductsByProducer(string[] parameters)
    {
        string producer = parameters[0];
        var prods = this.products.Where(p => p.Producer == producer);
        if (prods.Count() == 0)
        {
            this.output.AppendLine("No products found");
            return;
        }

        var items = new OrderedBag<Product>(prods);
        this.StringifyCollection(items);
    }


    public void Print()
    {
        Console.WriteLine(this.output.ToString().TrimEnd());
        //StreamWriter sr = new StreamWriter("..\\..\\output.txt");
        //sr.WriteLine(this.output.ToString().TrimEnd());
        //sr.Close();
    }

    private void StringifyCollection(OrderedBag<Product> filteredItems)
    {
        foreach (var item in filteredItems)
        {
            this.output.AppendLine(item.ToString());
        }
    }

    private void DeleteByProducer(string[] parameters)
    {
        string producer = parameters[0];
        int removed = this.products.Count(p => p.Producer == producer);
        if (removed == 0)
        {
            this.output.AppendLine("No products found");
            return;
        }

        this.products.RemoveAll(p => p.Producer == producer);
        this.output.AppendLine(string.Format("{0} products deleted", removed));
    }

    private void DeleteByNameAndProducer(string[] parameters)
    {
        // DeleteProducts IdeaPad Z560;Lenovo
        string productName = parameters[0];
        string producer = parameters[1];

        int removed = this.products.Count(p => p.Name == productName && p.Producer == producer);

        if (removed == 0)
        {
            this.output.AppendLine("No products found");
            return;
        }

        this.products.RemoveAll(p => p.Name == productName && p.Producer == producer);
        this.output.AppendLine(string.Format("{0} products deleted", removed));
    }
}

class Product : IComparable
{
    public Product(string name, float price, string producer)
    {
        this.Name = name;
        this.Price = price;
        this.Producer = producer;
    }

    public string Name { get; set; }

    public float Price { get; set; }

    public string Producer { get; set; }


    public override string ToString()
    {
        string info = string.Format("{0};{1};{2:0.00}", this.Name, this.Producer, this.Price);
        return string.Format("{{{0}}}", info);
    }

    public int CompareTo(object obj)
    {
        var comparedTo = (Product)obj;
        int compare = this.Name.CompareTo(comparedTo.Name);
        if (compare != 0)
        {
            return compare;
        }
        else
        {
            compare = this.Price.CompareTo(comparedTo.Price);
            return compare;
        }
    }
}