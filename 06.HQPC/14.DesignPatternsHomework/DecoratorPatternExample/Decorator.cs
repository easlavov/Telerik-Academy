namespace DecoratorPatternExample
{
    public abstract class Decorator : Person
    {
        public Person Person { get; set; }

        public Decorator(Person person)
        {
            this.Person = person;
        }

        public override void Greet()
        {
            this.Person.Greet();
        }
    }
}
