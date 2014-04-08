
public class File
{
    public string Name { get; set; }
    public long Size { get; set; }

    public File(string name, long size)
    {
        this.Name = name;
        this.Size = size;
    }

    public override string ToString()
    {
        return this.Name;
    }
}