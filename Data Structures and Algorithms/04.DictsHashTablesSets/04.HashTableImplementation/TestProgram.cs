using System;

class TestProgram
{
    static void Main()
    {
        Console.WriteLine("Adding 10 000 elements to the custom HashTable");
        HashTable<int, int> test = new HashTable<int, int>();
        for (int i = 0; i < 10000; i++)
        {
            test.Add(i*15-7,i-33*7);
        }

        Console.Write("Printing all pairs using foreach. Press any key: ");
        Console.ReadKey();
        PrintHashTable(test);

        Console.WriteLine("Press any key to create a new test hash table with 7 elements:");
        Console.ReadKey();
        HashTable<string, int> testStudents = new HashTable<string, int>();
        testStudents.Add("Mimi", 5);
        testStudents.Add("Pepi", 5);
        testStudents.Add("Gogo", 5);
        testStudents.Add("Kaka", 5);
        testStudents.Add("Mama", 5);
        testStudents.Add("Dido", 5);
        testStudents.Add("Zizo", 5);
        PrintHashTable(testStudents);

        Console.WriteLine("Removing Kaka:");
        testStudents.Remove("Kaka");
        PrintHashTable(testStudents);
    }
  
    private static void PrintHashTable<K, T>(HashTable<K, T> test)
    {
        foreach (var pair in test)
        {
            Console.Write("{0} - {1}, ", pair.Key, pair.Value);
        }

        Console.WriteLine();
        Console.WriteLine();
    }
}