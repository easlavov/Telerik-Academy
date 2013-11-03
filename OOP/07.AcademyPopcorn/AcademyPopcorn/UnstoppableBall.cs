using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class UnstoppableBall : Ball
    {
        public new const string CollisionGroupString = "unstoppableBall";
        public const char Body = '@';
        public UnstoppableBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
            this.body[0, 0] = UnstoppableBall.Body;
        }

        public override string GetCollisionGroupString()
        {
            return UnstoppableBall.CollisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            if (collisionData.HitObjectsCollisionGroupStrings[0] == "indestructibleBlock" ||
                collisionData.HitObjectsCollisionGroupStrings[0] == "racket")
            {
                base.RespondToCollision(collisionData);                
            }
        }

    }
}
