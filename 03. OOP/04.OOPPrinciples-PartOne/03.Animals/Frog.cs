using System;

public class Frog:Animal
{
    public Frog(string name, byte age, string sex)
    {
        this.Name = name;
        this.Age = age;
        this.Sex = sex;
    }

    public override void MakeSound()
    {
        Console.WriteLine(this.Name + " says 'Quack!'");
    }
}