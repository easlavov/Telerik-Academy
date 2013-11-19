using System;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Collections.Generic;

namespace SoftwareAcademy
{
    public interface ITeacher
    {
        string Name { get; set; }
        void AddCourse(ICourse course);
        string ToString();
    }

    public interface ICourse
    {
        string Name { get; set; }
        ITeacher Teacher { get; set; }
        void AddTopic(string topic);
        string ToString();
    }

    public interface ILocalCourse : ICourse
    {
        string Lab { get; set; }
    }

    public interface IOffsiteCourse : ICourse
    {
        string Town { get; set; }
    }

    public abstract class Course : ICourse
    {
        private string name;
        private ITeacher teacher;
        private List<string> topics = new List<string>();

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                this.name = value;
            }
        }

        public ITeacher Teacher
        {
            get
            {
                return this.teacher;
            }
            set
            {
                this.teacher = value;
            }
        }

        public void AddTopic(string topic)
        {
            this.topics.Add(topic);
        }

        public override string ToString()
        {
            // (course type): Name=(course name); Teacher=(teacher name); Topics=[(course topics – comma separated)]; 
            // Lab=(lab name – when applicable); Town=(town name – when applicable);
            StringBuilder result = new StringBuilder();

            result.AppendFormat("{0}: Name={1}", this.GetType().Name, this.Name);
            if (this.Teacher != null)
            {
                result.AppendFormat("; Teacher={0}", this.Teacher.Name);
            }
            if (this.topics.Count > 0)
            {
                result.Append("; Topics=[");
                foreach (var topic in this.topics)
                {
                    result.Append(topic + ", ");
                }
                result.Length -= 2;
                result.Append("]");
            }
            if (this is LocalCourse)
            {
                LocalCourse course = this as LocalCourse;
                result.AppendFormat("; Lab={0}", course.Lab);
            }
            else if (this is OffsiteCourse)
            {
                OffsiteCourse course = this as OffsiteCourse;
                result.AppendFormat("; Town={0}", course.Town);
            }
            return result.ToString();
        }
    }

    public class LocalCourse : Course, ILocalCourse
    {
        private string lab;

        // ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab)
        public LocalCourse(string name, ITeacher teacher, string lab)
        {
            this.Name = name;
            this.Teacher = teacher;
            this.Lab = lab;
        }

        public string Lab
        {
            get
            {
                return this.lab;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                this.lab = value;
            }
        }
    }

    public class OffsiteCourse : Course, IOffsiteCourse
    {
        private string town;

        // IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town)
        public OffsiteCourse(string name, ITeacher teacher, string town)
        {
            this.Name = name;
            this.Teacher = teacher;
            this.Town = town;
        }

        public string Town
        {
            get
            {
                return this.town;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                this.town = value;
            }
        }
    }

    public class Teacher : ITeacher
    {
        private string name;
        private List<ICourse> courses = new List<ICourse>();

        public Teacher(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                this.name = value;
            }
        }

        public void AddCourse(ICourse course)
        {
            this.courses.Add(course);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("{0}: Name={1}", this.GetType().Name, this.Name);
            if (this.courses.Count > 0)
            {
                result.Append("; Courses=[");
                foreach (var course in this.courses)
                {
                    result.Append(course.Name + ", ");
                }
                result.Length -= 2;
                result.Append("]");
            }
            return result.ToString();
        }
    }

    public interface ICourseFactory
    {
        ITeacher CreateTeacher(string name);
        ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab);
        IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town);
    }

    public class CourseFactory : ICourseFactory
    {
        public ITeacher CreateTeacher(string name)
        {
            Teacher teacher = new Teacher(name);
            return teacher;
        }

        public ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab)
        {
            LocalCourse lCourse = new LocalCourse(name, teacher, lab);
            return lCourse;
        }

        public IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town)
        {
            OffsiteCourse offCourse = new OffsiteCourse(name, teacher, town);
            return offCourse;
        }
    }

    public class SoftwareAcademyCommandExecutor
    {
        static void Main()
        {
            string csharpCode = ReadInputCSharpCode();
            CompileAndRun(csharpCode);
        }

        private static string ReadInputCSharpCode()
        {
            StringBuilder result = new StringBuilder();
            string line;
            while ((line = Console.ReadLine()) != "")
            {
                result.AppendLine(line);
            }
            return result.ToString();
        }

        static void CompileAndRun(string csharpCode)
        {
            // Prepare a C# program for compilation
            string[] csharpClass =
            {
                @"using System;
                  using SoftwareAcademy;

                  public class RuntimeCompiledClass
                  {
                     public static void Main()
                     {"
                        + csharpCode + @"
                     }
                  }"
            };

            // Compile the C# program
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.GenerateInMemory = true;
            compilerParams.TempFiles = new TempFileCollection(".");
            compilerParams.ReferencedAssemblies.Add("System.dll");
            compilerParams.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
            CSharpCodeProvider csharpProvider = new CSharpCodeProvider();
            CompilerResults compile = csharpProvider.CompileAssemblyFromSource(
                compilerParams, csharpClass);

            // Check for compilation errors
            if (compile.Errors.HasErrors)
            {
                string errorMsg = "Compilation error: ";
                foreach (CompilerError ce in compile.Errors)
                {
                    errorMsg += "\r\n" + ce.ToString();
                }
                throw new Exception(errorMsg);
            }

            // Invoke the Main() method of the compiled class
            Assembly assembly = compile.CompiledAssembly;
            Module module = assembly.GetModules()[0];
            Type type = module.GetType("RuntimeCompiledClass");
            MethodInfo methInfo = type.GetMethod("Main");
            methInfo.Invoke(null, null);
        }
    }
}
