using System;
using System.Collections.Generic;
using System.Linq;

public class Node<T>
{
    private List<Node<T>> children;

    public Node(T value)
        : this(value, null)
    {        
    }

    public Node(T value, params Node<T>[] children)
    {
        this.Value = value;
        if (children != null)
        {
            this.children = new List<Node<T>>();
            foreach (var node in children)
            {
                this.AddNode(node);
            }
        }        
    }

    public T Value { get; set; }

    public void AddNode(Node<T> node)
    {
        if (this.children == null)
        {
            this.children = new List<Node<T>>();
        }

        this.children.Add(node);
    }

    public List<Node<T>> Children
    {
        get
        {
            return this.children;
        }
    }

    public void RemoveNode(Node<T> node)
    {
        this.children.Remove(node);
    }

    public override string ToString()
    {
        return this.Value.ToString();
    }
}