
public class ListItemCustom<T>
{
    public T Value { get; set; }
    public ListItemCustom<T> NextItem { get; set; }

    public ListItemCustom(T value)
    {
        this.Value = value;
    }
}