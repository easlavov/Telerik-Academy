// Write a method that from a given array of students finds all 
// students whose first name is before its last name alphabetically. 
// Use LINQ query operators.

using System;
using System.Linq;

public static class Methods
{
    public static void FindStudentsByNames(Student[] students)
    {
        // LINQ
        var matches =
            (from s in students
             where s.FirstNameBeforeLast()
             select s);

        foreach (var student in matches)
        {
            Console.WriteLine(student.FirstName + " " + student.LastName);
        }
    }

    public static void FindStudentsNamesByAge(Student[] students)
    {
        // LINQ
        var matches =
            (from s in students
             where s.Age >= 18 && s.Age <= 24
             select s);

        foreach (var student in matches)
        {
            Console.WriteLine(student.FirstName + " " + student.LastName);
        }
    }

    public static void OrderLambda(Student[] students)
    {
        var newOrder = students.OrderByDescending(s => s.FirstName).ThenByDescending(s => s.LastName);
        foreach (var student in newOrder)
        {
            Console.WriteLine(student.FirstName + " " + student.LastName);
        }
    }

    public static void OrderLinq(Student[] students)
    {
        var newOrder = (
            from s in students
                orderby s.FirstName descending, s.LastName descending
                select s                
                );
        foreach (var student in newOrder)
        {
            Console.WriteLine(student.FirstName + " " + student.LastName);
        }
    }
}