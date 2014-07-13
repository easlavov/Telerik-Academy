namespace DecoratorPatternExample
{
    using System;

    class Artist : Decorator
    {
        private const string INTRODUCTION = "In my free time I'm drawing pictures!";

        public Artist(Person person)
            : base(person)
        {
        }

        public override void Greet()
        {
            base.Greet();
            Console.WriteLine(INTRODUCTION);
        }
    }
}
