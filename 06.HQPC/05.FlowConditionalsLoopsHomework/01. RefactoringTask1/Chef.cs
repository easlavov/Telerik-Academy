using System;

//public void Cook();
public class Chef
{    
    public void Cook()
    {
        Bowl bowl = this.GetBowl();
        Potato potato = this.GetPotato();
        Carrot carrot = this.GetCarrot();

        Peel(potato);
        Peel(carrot);

        Cut(potato);
        Cut(carrot);

        bowl.Add(potato);
        bowl.Add(carrot);
    }

    private Bowl GetBowl()
    {
        //...
    }

    private Potato GetPotato()
    {
        //...
    }

    private Carrot GetCarrot()
    {
        //...
    }

    private void Peel(Vegetable vegetable)
    {
        //...
    }

    private void Cut(Vegetable vegetable)
    {
        //...
    }
}