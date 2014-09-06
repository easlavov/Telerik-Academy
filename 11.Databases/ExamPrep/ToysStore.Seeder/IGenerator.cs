using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToysStore.Seeder
{
    public interface IGenerator<T>
    {
        ICollection<T> GetGeneratedItems(int count);
    }
}
