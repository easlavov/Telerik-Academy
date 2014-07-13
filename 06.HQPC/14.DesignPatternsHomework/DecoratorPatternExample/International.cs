namespace DecoratorPatternExample
{
    using System;

    class International : Decorator
    {
        private const string CURRENT_INTERNATIONAL_MESSAGE = "I am currently an international footballer!";
        private const string RETIRED_INTERNATIONAL_MESSAGE = "I am retired from international football!";
        private bool Retired { get; set; }

        public International(Person person)
            : base(person)
        {
            this.Retired = false;
        }

        public override void Greet()
        {
            base.Greet();
            if (!this.Retired)
            {
                Console.WriteLine(CURRENT_INTERNATIONAL_MESSAGE);
            }
            else
            {
                Console.WriteLine(RETIRED_INTERNATIONAL_MESSAGE);
            }
        }

        public void Retire()
        {
            this.Retired = true;
            string affix = " has retired.";
            Console.WriteLine(this.Person.Name + affix);
        }
    }
}
