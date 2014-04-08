using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ReadAndFind
{
    static void Main()
    {
        Tree<int> tree = new Tree<int>(new Node<int>(5,
            new Node<int>(8, 
                new Node<int>(4), new Node<int>(12)),
            new Node<int>(1),
            new Node<int>(10,
                new Node<int>(15,
                    new Node<int>(0), new Node<int>(3)))));

        Console.WriteLine(tree.Root);
        tree.PrintLeafs();
        tree.PrintMiddle();
        tree.PrintLongestPath();
        tree.PrintAllPathsWithSumS(18);
    }
}