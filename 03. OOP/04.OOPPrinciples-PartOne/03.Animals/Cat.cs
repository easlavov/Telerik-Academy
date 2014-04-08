using System;

public abstract class Cat : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine(this.Name + " says 'Meooowww!'");
    }
}