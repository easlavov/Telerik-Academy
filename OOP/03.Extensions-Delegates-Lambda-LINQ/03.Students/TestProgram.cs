// Current project solves tasks 3-5

using System;
using System.Linq;

class TestProgram
{
    static void Main()
    {
        Student[] students =
        {
            new Student("Iva", "Ivanova", 19),
            new Student("Petar", "Atanasov", 24),
            new Student("Petar", "Kirov", 24),
            new Student("Zina", "Apostolova", 23),
            new Student("Atanas", "Ivanov", 19),
            new Student("Georgi", "Georgiev", 29)
        };

        Console.WriteLine("This is the students list:");
        foreach (var student in students)
        {
            Console.WriteLine(student.FirstName + " " + student.LastName + " " + student.Age);
        }
        Console.WriteLine();

        Console.WriteLine("Finds all students whose first name is before its last name alphabetically. Using LINQ query operators.");
        Methods.FindStudentsByNames(students);
        Console.WriteLine();
        Console.WriteLine("Finds the first name and last name of all students with age between 18 and 24. Using LINQ.");
        Methods.FindStudentsNamesByAge(students);
        Console.WriteLine();
        Console.WriteLine("Sorts the students by first name and last name in descending order using Lamdba expression.");
        Methods.OrderLambda(students);
        Console.WriteLine();
        Console.WriteLine("Sorts the students by first name and last name in descending order using LINQ.");
        Methods.OrderLinq(students);
    }
}