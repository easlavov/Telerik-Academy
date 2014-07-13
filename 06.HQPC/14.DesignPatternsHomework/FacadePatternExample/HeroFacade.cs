namespace FacadePatternExample
{
    using System.Text;

    public class HeroFacade
    {
        private const string DEFAULT_NAME = "Pesho";
        private const int DEFAULT_AGE = 20;
        private const int DEFAULT_LEVEL = 1;
        private const HeroClass DEFAULT_HERO_CLASS = HeroClass.Warrior;
        private const int DEFAULT_STRENGTH = 20;
        private const int DEFAULT_INTELECT = 10;
        private const int DEFAULT_DEXTERITY = 10;
        private const int DEFAULT_VITALITY = 20;

        public Hero Hero { get; private set; }

        public HeroFacade()
        {
            this.Hero = CreateDefaultHero();
        }

        public void RepairAllItems()
        {
            foreach (var item in this.Hero.Inventory)
            {
                RepairToMaxiumum(item);
            }
        }

        public void DamageItems(int amount)
        {
            foreach (var item in this.Hero.Inventory)
            {
                item.Damage(amount);
            }
        }

        public void AutoLevelUp()
        {
            this.Hero.Level++;
            switch (this.Hero.Class)
            {
                case HeroClass.Warrior:
                    this.Hero.Attributes.Strength++; break;
                case HeroClass.Mage:
                    this.Hero.Attributes.Intelect++; break;
                case HeroClass.Rogue:
                    this.Hero.Attributes.Vitality++; break;
            }
        }

        private void RepairToMaxiumum(Item item)
        {
            int amountToRepair = item.MaximumDurability - item.CurrentDurability;
            item.Repair(amountToRepair);
        }

        private Hero CreateDefaultHero()
        {
            var newHero = new Hero(DEFAULT_NAME,
                                   DEFAULT_AGE,
                                   DEFAULT_LEVEL,
                                   DEFAULT_HERO_CLASS,
                                   new Attributes());
            newHero.Attributes.Strength = DEFAULT_STRENGTH;
            newHero.Attributes.Intelect = DEFAULT_INTELECT;
            newHero.Attributes.Dexterity = DEFAULT_DEXTERITY;
            newHero.Attributes.Vitality = DEFAULT_VITALITY;

            return newHero;
        }

        // TODO: Can and should be refactored to use the ToString() override of the corresponding classes
        public override string ToString()
        {
            var sBuilder = new StringBuilder();
            string basicInfo = string.Format("Name: {0}, Age: {1}, Level: {2}",
                                               this.Hero.Name,
                                               this.Hero.Age,
                                               this.Hero.Level);

            string @class = string.Format("Class: {0}", this.Hero.Class);

            string str = string.Format("Str: {0}", this.Hero.Attributes.Strength);
            string intel = string.Format("Int: {0}", this.Hero.Attributes.Intelect);
            string dex = string.Format("Dex: {0}", this.Hero.Attributes.Dexterity);
            string vit = string.Format("Vit: {0}", this.Hero.Attributes.Vitality);

            sBuilder.AppendLine(basicInfo);
            sBuilder.AppendLine(@class);
            sBuilder.AppendLine(str);
            sBuilder.AppendLine(intel);
            sBuilder.AppendLine(dex);
            sBuilder.AppendLine(vit);

            sBuilder.Append("Inventory: ");
            if (this.Hero.Inventory.Count == 0)
            {
                sBuilder.Append("Empty");
            }
            else
            {
                sBuilder.AppendLine();
                foreach (var item in this.Hero.Inventory)
                {
                    sBuilder.AppendLine(item.ToString());
                }
            }

            return sBuilder.ToString();
        }
    }
}
