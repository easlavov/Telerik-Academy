using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class GiftBlock:Block
    {
        public const char Body = 'P';
        public GiftBlock(MatrixCoords topLeft):base(topLeft)
        {
            this.body[0, 0] = GiftBlock.Body;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> obj = new List<GameObject>();
            if (this.IsDestroyed==true)
            {
                Gift gift = new Gift(new MatrixCoords(this.GetTopLeft().Row, this.GetTopLeft().Col));
                obj.Add(gift);
            }
            return obj;
        }

        
    }
}
