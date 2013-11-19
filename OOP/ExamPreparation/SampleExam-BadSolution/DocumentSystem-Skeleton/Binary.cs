using System;
using System.Linq;

namespace DocumentSystem
{
    public abstract class Binary: Document
    {
        int? size;
        public int? Size
        {
            get
            {
                return this.size;
            }
            set
            {
                this.size = value;
            }
        }
    }
}
