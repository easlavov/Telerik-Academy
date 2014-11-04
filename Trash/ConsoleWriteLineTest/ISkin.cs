using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWriteLineTest
{
    public interface IConsoleSkin
    {
        Dictionary<char, ConsoleColor> ColorScheme { get; }
    }
}
