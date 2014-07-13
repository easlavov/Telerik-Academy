namespace FacadePatternExample
{
    public class Item
    {
        public string Name { get; private set; }
        public int Value { get; private set; }
        public int CurrentDurability { get; private set; }
        public int MaximumDurability { get; private set; }
        public bool IsBroken { get; private set; }

        public Item(string name, int value, int durability)
        {
            this.Name = name;
            this.Value = value;
            this.CurrentDurability = durability;
            this.MaximumDurability = durability;
            this.IsBroken = false;
        }

        public void Damage(int amount)
        {
            this.CurrentDurability -= amount;
            if (this.CurrentDurability < 1)
            {
                this.IsBroken = true;
            }
        }

        public void Repair(int amount)
        {
            if ((this.CurrentDurability + amount) > this.MaximumDurability)
            {
                this.CurrentDurability = MaximumDurability;
            }
            else
            {
                this.CurrentDurability += amount;
            }
        }

        public override string ToString()
        {
            string itemInfo = string.Format("{0}, value: {1}, Durability: {2}/{3}",
                this.Name,
                this.Value,
                this.CurrentDurability,
                this.MaximumDurability);

            return itemInfo;
        }
    }
}
