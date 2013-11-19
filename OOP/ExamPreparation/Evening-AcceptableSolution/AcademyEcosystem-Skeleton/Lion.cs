using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyEcosystem
{
    public class Lion : Animal, ICarnivore
    {
        const int LionInitialSize = 6;

        public Lion(string name, Point location)
            : base(name, location, LionInitialSize)
        {
        }

        public int TryEatAnimal(Animal animal)
        {
            if (animal != null)
            {
                int meatQuantity = animal.GetMeatFromKillQuantity();
                if (animal.Size <= this.Size * 2)
                {
                    this.Size++;
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
