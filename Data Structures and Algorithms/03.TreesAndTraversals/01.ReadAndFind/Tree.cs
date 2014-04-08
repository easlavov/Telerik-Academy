using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Tree<T>
{
    public Node<T> Root { get; private set; }

    public Tree(Node<T> root)
    {
        this.Root = root;
    }

    public void PrintLeafs()
    {
        List<Node<T>> leafs = new List<Node<T>>();
        DFSLeafs(this.Root, leafs);
        Console.WriteLine(string.Join(", ", leafs));
    }

    private void DFSLeafs(Node<T> root, List<Node<T>> leafs)
    {
        if (root.Children == null)
        {
            leafs.Add(root);
            return;
        }
        foreach (var node in root.Children)
        {
            this.DFSLeafs(node, leafs);
        }
    }

    public void PrintMiddle()
    {
        List<Node<T>> leafs = new List<Node<T>>();
        DFSMiddle(this.Root, leafs);
        Console.WriteLine(string.Join(", ", leafs));
    }

    private void DFSMiddle(Node<T> root, List<Node<T>> leafs)
    {
        if (root.Children != null)
        {
            leafs.Add(root);
        }
        if (root.Children != null)
        {
            foreach (var node in root.Children)
            {
                this.DFSMiddle(node, leafs);
            }
        }
    }

    public void PrintLongestPath()
    {
        Stack<Node<T>> longest = new Stack<Node<T>>();
        DFSLongest(ref longest, new Stack<Node<T>>(), this.Root);
        Console.WriteLine(string.Join(", ", longest));
    }

    private void DFSLongest(ref Stack<Node<T>> longest, Stack<Node<T>> current, Node<T> root)
    {
        current.Push(root);
        if (current.Count > longest.Count)
        {
            longest = new Stack<Node<T>>(current);
        }
        if (root.Children != null)
        {
            foreach (var node in root.Children)
            {
                DFSLongest(ref longest, current, node);
            }
        }
        current.Pop();
    }

    public void PrintAllPathsWithSumS(int sum) // TODO: Dynamic programming?
    {
        List<Stack<Node<T>>> list = new List<Stack<Node<T>>>();
        DFSSum(ref list, new Stack<Node<T>>(), this.Root, sum);
        foreach (var item in list)
        {
            Console.WriteLine(string.Join(", ", item));
        }
    }

    private void DFSSum(ref List<Stack<Node<T>>> paths, Stack<Node<T>> current, Node<T> root, int sum) // TODO: Dynamic programming?
    {
        current.Push(root);
        if (current.Sum(node => (dynamic)node.Value) == sum)
        {            
            paths.Add(new Stack<Node<T>>(current));
        }
        if (root.Children != null)
        {
            foreach (var node in root.Children)
            {
                DFSSum(ref paths, current, node, sum);
                DFSSum(ref paths, new Stack<Node<T>>(), node, sum);
            }
        }
        current.Pop();
    }
}