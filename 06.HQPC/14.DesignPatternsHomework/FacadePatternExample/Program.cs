namespace FacadePatternExample
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var hero = new HeroFacade();
            Console.WriteLine(hero.ToString());

            Console.WriteLine("----------Leveling up----------");
            hero.AutoLevelUp();

            Console.WriteLine("----------Adding some items----------");
            hero.Hero.AddItem(new Item("Kirka", 15, 20));
            hero.Hero.AddItem(new Item("Botush", 10, 20));
            Console.WriteLine(hero.ToString());

            Console.WriteLine("----------Damaging all items----------");
            hero.DamageItems(5);
            Console.WriteLine(hero.ToString());

            Console.WriteLine("----------Repairing all items----------");
            hero.RepairAllItems();
            Console.WriteLine(hero.ToString());
        }
    }
}
