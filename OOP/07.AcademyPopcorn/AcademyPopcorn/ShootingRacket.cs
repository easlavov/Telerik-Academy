using System.Collections.Generic;

namespace AcademyPopcorn
{
    public class ShootingRacket : Racket
    {
        private bool isLoaded = false;
        public ShootingRacket(MatrixCoords topLeft, int width)
            : base(topLeft, width)
        {
        }

        public void Fire()
        {
            this.isLoaded = true;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> obj = new List<GameObject>();
            if (this.isLoaded == true)
            {
                MatrixCoords bul = this.GetTopLeft();
                bul.Col += this.Width / 2;
                Bullet bullet = new Bullet(bul);
                obj.Add(bullet);
                this.isLoaded = false;
            }
            return obj;
        }
    }
}
