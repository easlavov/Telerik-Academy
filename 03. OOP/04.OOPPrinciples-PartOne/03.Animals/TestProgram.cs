// Create a hierarchy Dog, Frog, Cat, Kitten, Tomcat and define useful constructors and methods. Dogs, frogs and cats are Animals. 
// All animals can produce sound (specified by the ISound interface). Kittens and tomcats are cats. All animals are described by age,
// name and sex. Kittens can be only female and tomcats can be only male. Each animal produces a specific sound. Create arrays of 
// different kinds of animals and calculate the average age of each kind of animal using a static method (you may use LINQ).

using System;
using System.Linq;

class TestProgram
{
    static void Main()
    {
        Dog[] dogs =
        {
            new Dog("Sharo", 3, "male"),
            new Dog ("Balkan", 1, "male"),
            new Dog ("Ara", 6, "female"),
        };

        Tomcat[] tomcats = 
        {            
            new Tomcat("Tom", 2),
            new Tomcat("Baro", 10),
        };

        Kitten[] kittens = 
        {
            new Kitten("Mara", 2),
        };

        Frog[] frogs = 
        {
            new Frog("Froggy", 1, "male"),
            new Frog("Frogitta", 1, "female"),
            new Frog("Frogger", 3, "male"),
            new Frog("Frogking", 10, "male"),
        };

        Console.WriteLine("Average age of dogs: {0:0}", Animal.AverageAge(dogs));
        Console.WriteLine("Average age of tomcats: {0:0}", Animal.AverageAge(tomcats));
        Console.WriteLine("Average age of kittens: {0:0}", Animal.AverageAge(kittens));
        Console.WriteLine("Average age of frogs: {0:0}", Animal.AverageAge(dogs));
        Console.WriteLine();

        foreach (var dog in dogs)
        {
            dog.MakeSound();
        }
        foreach (var tomcat in tomcats)
        {
            tomcat.MakeSound();
        }
        foreach (var kitten in kittens)
        {
            kitten.MakeSound();
        }
        foreach (var frog in frogs)
        {
            frog.MakeSound();
        }
    }
}