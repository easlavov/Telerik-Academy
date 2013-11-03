using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class TrailObject : GameObject
    {
        int lifeTime;

        public TrailObject(MatrixCoords topLeft, int lifeTime)
            : base(topLeft, new char[,] { { '.' } })
        {
            this.lifeTime = lifeTime;
        }

        protected virtual void Tick()
        {
            if (this.lifeTime <= 0)
            {
                this.IsDestroyed = true;
            }
            this.lifeTime--;

        }

        public override void Update()
        {
            this.Tick();
        }
    }
}
