using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPatternExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var berbatov = new Footballer("Dimitar Berbatov", "Monaco");
            var internationalBerbo = new International(berbatov);
            internationalBerbo.Greet();
            internationalBerbo.Retire();
            var painter = new Artist(internationalBerbo);
            painter.Greet();
        }
    }


    abstract class Person
    {
        public string Name { get; set; }

        public abstract void Greet();
    }

    class Footballer : Person
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

    abstract class Decorator : Person
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

    class International : Decorator
    {
        private bool retired;

        public International(Person person)
            : base(person)
        {
            this.Retired = false;
        }

        public bool Retired
        {
            get
            {
                return this.retired;
            }

            set
            {
                this.retired = value;
            }
        }

        public override void Greet()
        {
            base.Greet();
            if (!this.Retired)
            {
                Console.WriteLine("I am currently an international footballer!");
            }
            else
            {
                Console.WriteLine("I am retired from international football!");
            }
        }

        public void Retire()
        {
            this.Retired = true;
            Console.WriteLine(this.Person.Name + " has retired.");
        }
    }

    class Artist : Decorator
    {
        public Artist(Person person)
            : base(person)
        {
        }

        public override void Greet()
        {
            base.Greet();
            Console.WriteLine("In my free time I'm drawing pictures!");
        }
    }
}