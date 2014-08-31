namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using StudentSystem.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentSystem.Data.StudentSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(StudentSystem.Data.StudentSystemContext context)
        {
            this.SeedStudents(context);
            this.SeedCourses(context);
            this.SeedHomework(context);
        }

        private void SeedStudents(StudentSystemContext context)
        {
            if (context.Students.Any())
            {
                return;
            }

            context.Students.Add(new Student
            {
                Name = "Atanas Ivanov",
                Number = "10324"
            });

            context.Students.Add(new Student
            {
                Name = "Milka Bogdanova",
                Number = "10324"
            });

            context.Students.Add(new Student
            {
                Name = "Trifon Zarezan",
                Number = "02004"
            });
        }

        private void SeedCourses(StudentSystemContext context)
        {
            if (context.Courses.Any())
            {
                return;
            }

            context.Courses.Add(new Course
            {
                Name = "C# Part 1",
                Description = "Basic programming skills."
            });

            context.Courses.Add(new Course
            {
                Name = "C# Part 2",
                Description = "Advanced programming skills."
            });
        }

        private void SeedHomework(StudentSystemContext context)
        {
            if (context.Homework.Any())
            {
                return;
            }

            context.Homework.Add(new Homework
            {
                Content = "a+b+c = d",
                TimeSent = DateTime.Parse("1.2.2014")
            });

            context.Homework.Add(new Homework
            {
                Content = "Eiiii, mnogo malko doma6ni davat!",
                TimeSent = DateTime.Parse("2.2.2014")
            });

            context.Homework.Add(new Homework
            {
                Content = "Eiii, mnogo doma6ni davat be...",
                TimeSent = DateTime.Parse("3.2.2014")
            });
        }
    }
}
