
public class ListItemCustom<T>
{
    public ListItemCustom(T value)
    {
        this.Value = value;
    }

    public T Value { get; set; }

    public ListItemCustom<T> NextItem { get; set; }
}