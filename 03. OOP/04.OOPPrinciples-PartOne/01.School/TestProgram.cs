// We are given a school. In the school there are classes of students. Each class has a set of teachers. Each teacher teaches a set of disciplines.
// Students have name and unique class number. Classes have unique text identifier. Teachers have name. Disciplines have name, number of lectures 
// and number of exercises. Both teachers and students are people. Students, classes, teachers and disciplines could have optional comments (free text block).
// Your task is to identify the classes (in terms of  OOP) and their attributes and operations, encapsulate their fields, define the class hierarchy and create a class diagram with Visual Studio.

using System;
using System.Linq;
using System.Collections.Generic;

class TestProgram
{
    static void Main()
    {
        // Creating students
        Student firstStudent = new Student("Dimitar Penev", 1);
        Student secondStudent = new Student("Emil Kostadinov", 2);
        Student thirdStudent = new Student("Krasimir Balakov", 3);
        Student fourthStudent = new Student("Zdravko Zdravkov", 4);

        // Creating disciplines
        Discipline biology = new Discipline("Biology", 8, 4);
        Discipline mathematics = new Discipline("Mathematics", 4, 2);
        Discipline economics = new Discipline("Economics", 4, 4);

        // Creating teachers
        Teacher firstTeacher = new Teacher("Kiril Hristov", new List<Discipline>() { biology });
        Teacher secondTeacher = new Teacher("Atanas Dalchev", new List<Discipline>() { mathematics });
        Teacher thirdTeacher = new Teacher("Isaac Newton", new List<Discipline>() { mathematics, economics });

        // Creating class
        Class griffindor = new Class("Griffindor", new List<Student>() { firstStudent, secondStudent, thirdStudent, fourthStudent }, new List<Teacher>() { firstTeacher, secondTeacher, thirdTeacher });

        // Creating school
        School kokiche = new School(new List<Class>() { griffindor });

        thirdStudent.SetComment("Hard-working");
        secondTeacher.SetComment("Lazy");
        griffindor.SetComment("Underachieving");
        biology.SetComment("Hard");

        Console.WriteLine(kokiche.ToString());

        Console.WriteLine("Displaying comments:");
        Console.WriteLine(thirdStudent.GetComment());
        Console.WriteLine(secondTeacher.GetComment());
        Console.WriteLine(griffindor.GetComment());
        Console.WriteLine(biology.GetComment());
    }
}