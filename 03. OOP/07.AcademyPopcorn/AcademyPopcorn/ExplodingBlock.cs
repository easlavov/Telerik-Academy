using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class ExplodingBlock : Block
    {
        public const char Body = '*';
        public ExplodingBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body[0, 0] = ExplodingBlock.Body;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> obj = new List<GameObject>();
            if (this.IsDestroyed == true)
            {
                int blockRow = this.GetTopLeft().Row;
                int blockCol = this.GetTopLeft().Col;
                for (int row = -1; row <= 1; row++)
                {
                    for (int col = -1; col <= 1; col++)
                    {
                        if (row == 0 && col == 0)
                        {
                            continue;
                        }
                        //obj.Add(new UnstoppableBall(
                        //    new MatrixCoords(blockRow + row, blockCol + col), new MatrixCoords(row, col)));
                        obj.Add(new ExplodingParticle(
                          new MatrixCoords(blockRow + row, blockCol + col), new MatrixCoords(0, 0)));
                    }
                }
            }
            return obj;
        }
    }
}
