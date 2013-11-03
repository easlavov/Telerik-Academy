using System;
using System.Linq;

class TestProgram
{
    static void Main()
    {
        Console.WriteLine("This program tests the Students project. It will run a few tests to determine if the code has been written correctly!");
        Console.WriteLine();

        // Part 1
        Console.WriteLine("Part 1: Creating two identical instances of the Student class.");

        Student st1 = new Student("Leia", "Bail", "Organa", University.Cambridge, Faculty.SocialScience, Specialty.Art, "Dantooine", 100000000, "111555999666", new System.Net.Mail.MailAddress(@"leiaIsVadersDaughter@rebelalliance.com"));
        Student st2 = new Student("Leia", "Bail", "Organa", University.Cambridge, Faculty.SocialScience, Specialty.Art, "Dantooine", 100000000, "111555999666", new System.Net.Mail.MailAddress(@"leiaIsVadersDaughter@rebelalliance.com"));

        Console.WriteLine("The studetns are the following:");
        Console.WriteLine("Student 1: " + st1.ToString());
        Console.WriteLine("Student 2: " + st2.ToString());
        Console.WriteLine("Result of comparison (are they equal?): " + st1.Equals(st2));
        Console.WriteLine();

        Console.WriteLine("Creating a new instance of the Student class.");
        Student st3 = new Student("Petromil", "Kirov", "Ivanov", 458789652);
        Console.WriteLine("The new Student is the following: " + st3.ToString());
        Console.WriteLine("Comparing Petromil to Leia (are they equal?): " + st1.Equals(st3));
        Console.WriteLine();

        Console.WriteLine("Part 3: Printing hash codes: ");
        Console.WriteLine("Student 1: " + st1.GetHashCode());
        Console.WriteLine("Student 2: " + st2.GetHashCode());
        Console.WriteLine("Student 3: " + st3.GetHashCode());
        Console.WriteLine();

        Console.WriteLine("Part 4: Testing the == and != operators");
        Console.WriteLine("Student 1 != Student 2: " + (st1 != st2));
        Console.WriteLine("Student 1 != Student 3: " + (st1 != st3));
        Console.WriteLine("Student 1 == Student 2: " + (st1 == st2));
        Console.WriteLine();

        Console.WriteLine("Part 5: Cloning");
        Console.WriteLine("Cloning Student 1 into new student.");
        Student newSt = (Student)st1.Clone();
        Console.WriteLine("Is the new student identical to Student 1? "+ (newSt == st1));
        Console.WriteLine("Is the new student identical to Student 3? " + (newSt == st3));
        Console.WriteLine();

        Console.WriteLine("Part 6: Testing the implementation of the IComparable interface.");
        Console.WriteLine("Creating an array of Students:");
        Student student1 = new Student("Atanas", "Ivanov", "Kovachev", 458956898);
        Student student2 = new Student("Petar", "Ivanov", "Kovachev", 358956898);
        Student student3 = new Student("Atanas", "Ivanov", "Kovachev", 458956893);
        Student student4 = new Student("Zhivko", "Kolev", "Penev", 450056898);
        Student student5 = new Student("Petar", "Ivanov", "Kirov", 438956898);

        Student[] students = 
        {
            student1, student2, student3, student4, student5
        };

        foreach (var student in students)
        {
            Console.WriteLine(student.ToString() + ", SSN: " + student.SocSecNum);
        }
        Console.WriteLine();
        Console.WriteLine("Sorting students using Array.Sort");
        Console.WriteLine("Result of sorting:");
        Array.Sort(students);
        foreach (var student in students)
        {
            Console.WriteLine(student.ToString() + ", SSN: " + student.SocSecNum);
        }
    }
}