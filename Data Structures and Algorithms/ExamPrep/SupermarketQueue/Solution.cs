using System;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

class Solution
{
    static BigList<string> queue;
    static Bag<string> persons;
    static StringBuilder output;

    static void Main()
    {
        queue = new BigList<string>();
        output = new StringBuilder();
        persons = new Bag<string>();

        string inputLine = Console.ReadLine();
        while (inputLine != null)
        {
            string[] parameters = inputLine.Split(' ');
            string command = parameters[0];
            switch (command)
            {
                case "Append" :
                    AppendPerson(parameters); break;
                case "Insert" :
                    InsertPerson(parameters); break;
                case "Find" :
                    FindPersons(parameters); break;
                case "Serve" :
                    Serve(parameters); break;
                case "End":
                    PrintOutput();
                    break;
            }

            inputLine = Console.ReadLine();
        }
    }

    private static void PrintOutput()
    {
        Console.WriteLine(output.ToString());

        Environment.Exit(0);
    }
 
    private static void Serve(string[] parameters)
    {
        int count = int.Parse(parameters[1]);
        if (queue.Count < count)
        {
            output.AppendLine("Error");
            return;
        }

        StringBuilder row = new StringBuilder();
        var names = queue.Range(0, count).ToList();
        persons.RemoveMany(names);
        foreach (var name in names)
        {
            row.Append(name + ' ');
        }

        output.AppendLine(row.ToString());
        queue.RemoveRange(0, count);
    }
 
    private static void FindPersons(string[] parameters)
    {
        string name = parameters[1];
        int count = persons.NumberOfCopies(name);
        output.AppendLine(count.ToString());
    }
 
    private static void InsertPerson(string[] parameters)
    {
        int position = int.Parse(parameters[1]);
        if (position < 0 || queue.Count < position)
        {
            output.AppendLine("Error");
            return;
        }

        string name = parameters[2];
        queue.Insert(position, name);
        persons.Add(name);
        output.AppendLine("OK");
    }
 
    private static void AppendPerson(string[] parameters)
    {
        string name = parameters[1];
        queue.Add(name);
        persons.Add(name);
        output.AppendLine("OK");
    }
}