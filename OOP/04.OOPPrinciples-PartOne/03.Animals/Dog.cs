using System;

class Dog : Animal
{
    public Dog(string name, byte age, string sex)
    {
        this.Name = name;
        this.Age = age;
        this.Sex = sex;
    }

    public override void MakeSound()
    {
        Console.WriteLine(this.Name + " says 'Woof!'");
    }
}