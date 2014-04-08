using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class MeteoriteBall : Ball
    {
        private const int lifetime = 3;

        public MeteoriteBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            TrailObject tail = new TrailObject(this.GetTopLeft(), 3);
            List<GameObject> list = new List<GameObject>();
            list.Add(tail);
            return list;
        }
    }
}
