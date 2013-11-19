using System;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Collections.Generic;

namespace HTMLRenderer
{
    //public interface IElement
    //{
    //    string Name { get; }
    //    string TextContent { get; set; }
    //    IEnumerable<IElement> ChildElements { get; }
    //    void AddElement(IElement element);
    //    void Render(StringBuilder output);
    //    string ToString();
    //}

    public interface IElement
    {
        string Name { get; }
        void Render(StringBuilder output);
        string ToString();
    }

    public abstract class HTMLElement : IElement
    {
        protected string name = null;

        public string Name { get { return this.name; } }

        public virtual void Render(StringBuilder output)
        {


        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            this.Render(output);
            return output.ToString();
        }

        protected string Escape(string str)
        {
            if (str == null)
            {
                return string.Empty;
            }
            if (str.Contains("&lt"))
            {
                str = str.Replace("&lt", "<");
            }
            if (str.Contains("&gt"))
            {
                str = str.Replace("&gt", ">");
            }
            if (str.Contains("&amp"))
            {
                str = str.Replace("&amp", "&");
            }
            return str;
        }
    }

    public interface ISimpleElement : IElement
    {
        string TextContent { get; set; }
        IEnumerable<IElement> ChildElements { get; }
        void AddElement(IElement element);
    }

    public class SimpleElement : HTMLElement, ISimpleElement
    {
        string textContent = null;
        List<SimpleElement> childElements;

        public SimpleElement(string name)
            : this(name, null)
        {

        }
        public SimpleElement(string name, string content)
        {
            this.name = name;
            this.TextContent = content;
            this.childElements = new List<SimpleElement>();
        }

        public string TextContent { get { return this.textContent; } set { this.textContent = value; } }
        public IEnumerable<IElement> ChildElements { get { return this.childElements; } }

        public void AddElement(IElement element)
        {
            this.childElements.Add((SimpleElement)element);
        }

        public override void Render(StringBuilder output)
        {
            // <(name)>(text_content)(child_content)</(name)>
            if (this.Name!= null)
            {
                output.AppendFormat("<{0}>", this.Escape(this.Name));
            }            
            if (this.TextContent != null)
            {
                output.AppendFormat("{0}", this.Escape(this.textContent));
            }
            if (this.childElements.Count > 0)
            {
                foreach (var child in this.childElements)
                {
                    output.AppendFormat("{0}", this.Escape(child.TextContent));
                }
            }
            if (this.Name != null)
            {
                output.AppendFormat("</{0}>", this.Escape(this.Name));
            }   
            
        }
    }

    public interface ITable : IElement
    {
        int Rows { get; }
        int Cols { get; }
        IElement this[int row, int col] { get; set; }
    }

    public class Table : HTMLElement, ITable
    {
        int rows;
        int cols;
        IElement[,] table;

        public Table(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            this.table = new HTMLElement[rows, cols];
            this.name = "table";
        }

        public int Rows { get { return this.rows; } }
        public int Cols { get { return this.cols; } }

        public IElement this[int row, int col]
        {
            set
            {
                this.table[row, col] = value;
            }
            get
            {
                return this.table[row, col];
            }
        }

        public override void Render(StringBuilder output)
        {
            // <table><tr><td>(cell_0_0)</td><td>(cell_0_1)</td>…</tr><tr><td>(cell_1_0)</td><td>(cell_1_1)</td>…</tr>…</table>
            //For each row its content is rendered enclosed between the <tr> and </tr> tags. For each column inside a row its element 
            //content is rendered enclosed between the <td> and </td> tags.
            if (this.Name != null)
            {
                output.AppendFormat("<{0}>", this.Escape(this.Name));
            }
            
            for (int rows = 0; rows < this.Rows; rows++)
            {
                output.AppendFormat("<tr>");
                for (int cols = 0; cols < this.Cols; cols++)
                {
                    if (this.table[rows,cols] != null)
                    {
                        SimpleElement temp = (SimpleElement)this.table[rows, cols];
                        output.AppendFormat("<td><{0}></td>", this.Escape(temp.ToString()));
                    }
                }
                output.AppendFormat("</tr>");
            }
            if (this.name != null)
            {
                output.AppendFormat("</{0}>", this.Escape(this.Name));
            }
            output = output.Replace("<<", "<");
            output = output.Replace(">>", ">");
        }
    }

    public interface IElementFactory
    {
        IElement CreateElement(string name);
        IElement CreateElement(string name, string content);
        ITable CreateTable(int rows, int cols);
    }

    public class HTMLElementFactory : IElementFactory
    {
        public IElement CreateElement(string name)
        {
            IElement element = new SimpleElement(name);
            return element;
        }

        public IElement CreateElement(string name, string content)
        {
            IElement element = new SimpleElement(name, content);
            return element;
        }

        public ITable CreateTable(int rows, int cols)
        {
            ITable table = new Table(rows, cols);
            return table;
        }
    }

    public class HTMLRendererCommandExecutor
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
                  using HTMLRenderer;

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
