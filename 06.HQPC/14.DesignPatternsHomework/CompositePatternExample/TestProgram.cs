namespace CompositePatternExample
{
    using System;

    class TestProgram
    {
        static void Main()
        {
            // Initializing a collection of text elements
            PrintableCollection printColl = new PrintableCollection();
            printColl.Add(new Text("Eho"));
            printColl.Add(new Text("Emo"));
            printColl.Add(new Text("Epo"));
            printColl.Add(new Text("Eno"));
            printColl.Add(new Text("Eto"));
            printColl.Add(new Text("Ero"));

            // Intializing a single text element
            Text text = new Text("lonely text");

            // Initializing another collection of text elements
            PrintableCollection printColl2 = new PrintableCollection();
            printColl2.Add(new Text("Bobo"));
            printColl2.Add(new Text("Boro"));
            printColl2.Add(new Text("Bomo"));

            // The first collection is added to the second
            printColl.Add(printColl2);

            // As you can see both the collection of printable elements and the
            // separate elements are printed by using a common method
            printColl.Print();
            Console.WriteLine();

            // A single element is also printable by itself
            text.Print();
        }
    }
}
