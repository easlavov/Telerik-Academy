using System;
using System.Linq;

namespace DocumentSystem
{
    public abstract class MultimediaDocument : Binary
    {
        int? length;
        public int? Length
        {
            get
            {
                return this.length;
            }
            set
            {
                this.length = value;
            }
        }
    }
}
