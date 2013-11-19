using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyEcosystem
{
    public class Zombie : Animal
    {
        const int ZombieSize = 1;

        public Zombie(string name, Point location)
            : base(name, location, ZombieSize)
        {
        }

        public override int GetMeatFromKillQuantity()
        {
            return 10;
        }
    }
}
