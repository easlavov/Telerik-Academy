namespace CompositePatternExample
{
    using System.Collections.Generic;

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
}
