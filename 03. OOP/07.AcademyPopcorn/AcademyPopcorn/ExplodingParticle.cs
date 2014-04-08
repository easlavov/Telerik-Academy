using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class ExplodingParticle : MovingObject
    {
        public ExplodingParticle(MatrixCoords topLeft, MatrixCoords speed):base(topLeft, new char[,]{{'.'}}, speed)
        {}

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "block";
        }

        public override void Update()
        {
            this.IsDestroyed = true;
        }
    }
}
