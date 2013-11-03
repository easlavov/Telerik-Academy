// Define abstract class Human with first name and last name. Define new class Student which is derived from Human
// and has new field – grade. Define class Worker derived from Human with new property WeekSalary and WorkHoursPerDay
// and method MoneyPerHour() that returns money earned by hour by the worker. Define the proper constructors and 
// properties for this hierarchy. Initialize a list of 10 students and sort them by grade in ascending order 
// (use LINQ or OrderBy() extension method). Initialize a list of 10 workers and sort them by money per hour in descending order.
// Merge the lists and sort them by first name and last name.

using System;
using System.Collections.Generic;
using System.Linq;

class TestProgram
{
    static void Main()
    {
        // Creating 10 students
        List<Student> students = new List<Student>()
        {
            new Student("Blagoy","Paskov", 1),
            new Student("Svilen","Neykov", 12),
            new Student("Petar","Petrov", 6),
            new Student("Zvezdi","Zvezdev", 8),
            new Student("Rumen","Trifonov", 10),
            new Student("Stefan","Velev", 9),
            new Student("Bozhidar","Stoychev", 10),
            new Student("Kiril","Hristov", 6),
            new Student("Kalina","Manova", 2),
            new Student("Ani","Dimova", 1)            
        };

        students =
            (from s in students
            orderby s.Grade
            select s).ToList();

        Console.WriteLine("Students sorted by grade in ascending order (using LINQ):");
        foreach (var student in students)
        {
            Console.WriteLine("{0} {1} {2}", student.FirstName, student.LastName, student.Grade);
        }

        List<Worker> workers = new List<Worker>()
        {
            new Worker("Wayne", "Rooney", 1000, 8),
            new Worker("Thiago", "Alcantara", 500, 8),
            new Worker("Cristiano", "Maldini", 100, 4),
            new Worker("Rene", "Meulesteen", 150, 6),
            new Worker("Cristiano", "Ronaldo", 2000, 8),
            new Worker("Thiago", "Alves", 300, 8),
            new Worker("Frank", "Bartra", 300, 5),
            new Worker("Lawrence", "Davies", 700, 4),
            new Worker("Hugo", "Lloris", 600, 6),
            new Worker("Alan", "Pardew", 450, 6),
        };
        Console.Write("Press a key to continue!");
        Console.ReadKey();
        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("Workers sorted by money per hour in descending order (using extension method with Lamdba expression):");
        workers = workers.OrderByDescending(x => x.MoneyPerHour()).ToList();
        foreach (var worker in workers)
        {
            Console.WriteLine("{0} {1} {2} per hour", worker.FirstName, worker.LastName, worker.MoneyPerHour());
        }
        Console.WriteLine();

        var humanList = students.Concat<Human>(workers);
        var humanSorted = humanList.OrderBy(x => x.FirstName).ThenBy(x => x.LastName);
        Console.WriteLine("Humans sorted by first and last name in ascending order (using extension method with Lamdba expression):");
        foreach (var human in humanSorted)
        {
            Console.WriteLine("{0} {1}", human.FirstName, human.LastName);
        }
    }
}