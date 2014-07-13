namespace DecoratorPatternExample
{
    public abstract class Person
    {
        public string Name { get; set; }

        public abstract void Greet();
    }
}