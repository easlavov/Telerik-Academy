namespace FacadePatternExample
{
    using System.Collections.Generic;

    public class Hero
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Level { get; set; }
        public HeroClass Class { get; private set;}
        public Attributes Attributes { get; set; }
        public List<Item> Inventory { get; private set; }

        public Hero(string name, int age, int level, HeroClass @class, Attributes attributes)
        {
            this.Name = name;
            this.Age = age;
            this.Level = level;
            this.Attributes = attributes;
            this.Class = @class;
            this.Inventory = new List<Item>();
        }

        public void AddItem(Item item)
        {
            this.Inventory.Add(item);
        }

        public void RemoveItem(Item item)
        {
            this.Inventory.Remove(item);
        }
    }
}
