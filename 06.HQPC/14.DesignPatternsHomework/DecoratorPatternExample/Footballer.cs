namespace DecoratorPatternExample
{
    using System;

    public class Footballer : Person
    {
        public string Club { get; set; }

        public Footballer(string name, string club)
        {
            this.Name = name;
            this.Club = club;
        }

        public override void Greet()
        {
            Console.WriteLine("Hello! My name is " + this.Name);
            Console.WriteLine("I'm currently playing for " + this.Club);
        }
    }
}
