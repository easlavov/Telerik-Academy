using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyEcosystem
{
    public class Boar : Animal, ICarnivore, IHerbivore
    {
        const int BoarInitialSize = 4;
        const int BiteSize = 2;

        public Boar(string name, Point location)
            : base(name, location, BoarInitialSize)
        {
        }

        public int TryEatAnimal(Animal animal)
        {
            if (animal != null)
            {
                int meatQuantity = animal.GetMeatFromKillQuantity();
                if (animal.Size <= this.Size)
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

        public int EatPlant(Plant p)
        {
            if (p != null)
            {
                this.Size++;
                return p.GetEatenQuantity(BiteSize);
            }

            return 0;
        }
    }
}
