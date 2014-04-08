using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TestProgram
{
    static void Main()
    {
        Console.WriteLine("Adding 10 (numbers from 0 to 9) elements to the custom HashSet");
        HashedSet<int> testSet = new HashedSet<int>();
        for (int i = 0; i < 10; i++)
        {
            testSet.Add(i);
        }

        Console.Write("Printing all elements using foreach. Press any key: ");
        Console.ReadKey();
        PrintHashSet(testSet);

        Console.WriteLine("Adding 10 (numbers from 5 to 14 ) elements to another custom custom HashSet");
        HashedSet<int> testSet2 = new HashedSet<int>();
        for (int i = 5; i < 15; i++)
        {
            testSet2.Add(i);
        }

        Console.Write("Printing all elements using foreach. Press any key: ");
        Console.ReadKey();
        PrintHashSet(testSet2);

        Console.WriteLine("Printing intersection between the two sets (the first set is modified):");
        testSet.IntersectWith(testSet2);
        PrintHashSet(testSet);

        Console.WriteLine("Printing union between the two sets (the modified first set and the second set):");
        testSet.UnionWith(testSet2);
        PrintHashSet(testSet);
    }

    private static void PrintHashSet<T>(HashedSet<T> test)
    {
        foreach (var element in test)
        {
            Console.Write("{0}, ", element);
        }
        Console.WriteLine();
        Console.WriteLine();
    }
}