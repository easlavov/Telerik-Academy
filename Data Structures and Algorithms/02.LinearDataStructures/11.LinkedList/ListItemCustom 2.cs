using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ListItemCustom<T>
{
    public T Value { get; set; }
    public ListItemCustom<T> NextItem { get; set; }

    public ListItemCustom(T obj)
    {
        this.Value = obj;
    }

}