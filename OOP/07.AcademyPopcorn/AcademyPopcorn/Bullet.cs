using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class Bullet : Ball
    {
        public const char Body = '+';

        public Bullet(MatrixCoords topLeft)
            : base(topLeft, new MatrixCoords(-1, 0))
        {
            this.body[0, 0] = Body;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }
    }
}
