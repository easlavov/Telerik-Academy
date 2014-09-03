using System;
using System.Collections.Generic;
using System.IO;
using Wintellect.PowerCollections;

class TestProgram
{
    static string filePath = @"..\..\Courses.txt";
    static void Main()
    {
        SortedDictionary<string, OrderedBag<Student>> studentRecords = ReadRecords();

        foreach (var record in studentRecords)
        {
            Console.WriteLine("{0} {1}", record.Key, record.Value);
        }
    }

    private static SortedDictionary<string, OrderedBag<Student>> ReadRecords()
    {
        SortedDictionary<string, OrderedBag<Student>> result = new SortedDictionary<string, OrderedBag<Student>>();

        List<string[]> students = ReadFile();
        foreach (var student in students)
        {
            string course = student[2].Trim();
            string firstName = student[0].Trim();
            string lastName = student[1].Trim();

            Student newStudent = new Student(firstName,lastName);
            if (!result.ContainsKey(course))
            {
                result.Add(course, new OrderedBag<Student>());
            }

            result[course].Add(newStudent);
        }

        return result;
    }

    private static List<string[]> ReadFile()
    {
        List<string[]> list = new List<string[]>();
        StreamReader reader = new StreamReader(filePath);
        char[] separator = {'|'};
        using (reader)
        {
            string line = reader.ReadLine();
            while (line != null)
            {
                string[] record = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                list.Add(record);
                line = reader.ReadLine();
            }            
        }
        return list;
    }
}