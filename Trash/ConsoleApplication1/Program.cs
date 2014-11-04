using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1
{
    class Program
    {

        static readonly int power = 15 * 6;

        public interface IPrintable
        {
            void Print();
        }

        public class Text : IPrintable
        {
            public string Content { get; set; }

            public Text(string text)
            {
                this.Content = text;
            }

            public void Print()
            {
                Console.WriteLine(this.Content);
            }
        }

        public class PrintableCollection : IPrintable
        {
            public IList<IPrintable> Elements { get; private set; }

            public PrintableCollection()
            {
                this.Elements = new List<IPrintable>();
            }

            public void Print()
            {
                foreach (var element in this.Elements)
                {
                    element.Print();
                }
            }

            public void Add(IPrintable element)
            {
                this.Elements.Add(element);
            }

            public void Remove(IPrintable element)
            {
                this.Elements.Remove(element);
            }
        }

        static void Main(string[] args)
        {
            PrintableCollection printColl = new PrintableCollection();
            printColl.Add(new Text("Eho"));
            printColl.Add(new Text("Emo"));
            printColl.Add(new Text("Epo"));
            printColl.Add(new Text("Eno"));
            printColl.Add(new Text("Eto"));
            printColl.Add(new Text("Ero"));

            Text text = new Text("lonely text");

            PrintableCollection printColl2 = new PrintableCollection();
            printColl2.Add(new Text("Bobo"));
            printColl2.Add(new Text("Boro"));
            printColl2.Add(new Text("Bomo"));

            printColl.Add(printColl2);

            printColl.Print();
            //text.Print();

        }
    }
}
