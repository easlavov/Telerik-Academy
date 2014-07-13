namespace CompositePatternExample
{
    using System;

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
}
