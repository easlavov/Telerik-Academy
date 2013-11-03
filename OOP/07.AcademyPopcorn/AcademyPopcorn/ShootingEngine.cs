using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class ShootingEngine : Engine
    {
        public ShootingEngine(IRenderer renderer, IUserInterface userInterface): base(renderer, userInterface, 250)
        {}
        public void ShootPlayerRacket()
        {
            if (this.playerRacket is ShootingRacket)
            {
                (this.playerRacket as ShootingRacket).Fire();
            }
        }
    }
}
