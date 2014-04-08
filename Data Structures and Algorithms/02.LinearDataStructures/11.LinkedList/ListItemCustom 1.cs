using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ListItemCustom<T>
{
    private T value;
    private ListItemCustom<T> nextItem;
        
    public ListItemCustom()
    {

    }

    public T Value
    {
        get { return this.value; }
        set { this.value = value; }
    }

    public ListItemCustom<T> NextItem
    {
        get { return this.nextItem; }
        set { this.nextItem = value; }
    }
}