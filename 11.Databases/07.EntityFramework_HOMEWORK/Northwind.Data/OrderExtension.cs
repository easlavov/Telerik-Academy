using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Data
{
    public partial class Order
    {
        public override string ToString()
        {
            string format = "OrderId: {0}, Order date: {1}, Region: {2}";
            string info = string.Format(
                format, this.OrderID, this.OrderDate, this.ShipRegion);
            return info;
        }
    }
}
