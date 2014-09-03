using System.Collections.Generic;

public class CharNode
{
    public HashSet<CharNode> Children { get; protected set; }

    public char Letter { get; private set; }

    public int Count { get; set; }

    public CharNode(char letter)
    {
        this.Children = new HashSet<CharNode>();
        this.Letter = letter;
    }

    public override string ToString()
    {
        return this.Letter.ToString();
    }
}