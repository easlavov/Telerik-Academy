using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyEcosystem
{
    public class Wolf : Animal, ICarnivore
    {
        const int WolfSize = 4;

        public Wolf(string name, Point location)
            : base(name, location, WolfSize)
        {
        }

        public int TryEatAnimal(Animal animal)
        {
            if (animal != null)
            {
                int meatQuantity = animal.GetMeatFromKillQuantity();
                if (animal.Size <= this.Size || animal.State == AnimalState.Sleeping)
                {
                    return meatQuantity;
                }
                else
                {
                    return 0;
                }
            }            
            else
            {
                return 0;
            }
        }
    }
}
