using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class Gift: MovingObject
    {
        public new const string CollisionGroupString = "gift";

        public Gift(MatrixCoords topLeft):base(topLeft, new char[,]{{'G'}}, new MatrixCoords(1,0))
        {            
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "racket";
        }

        public override string GetCollisionGroupString()
        {
            return Gift.CollisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;   
            this.ProduceObjects();
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            
            if (this.IsDestroyed)
            {
                List<GameObject> obj = new List<GameObject>();
                obj.Add(new ShootingRacket(new MatrixCoords(this.topLeft.Row + 1, this.topLeft.Col), 6));
                return obj;
            }
            else
            {
                return base.ProduceObjects();
            }           

        }
    }
}
