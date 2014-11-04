using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWriteLineTest
{
    public class ClassicSkin : IConsoleSkin
    {
        private Dictionary<char, ConsoleColor> colorScheme = new Dictionary<char, ConsoleColor>()
        {
            { '1', ConsoleColor.Blue },
            { '2', ConsoleColor.Green }, // visible
            { '3', ConsoleColor.Red }, // visible
            { '4', ConsoleColor.DarkBlue },
            { '5', ConsoleColor.DarkRed },
            { '6', ConsoleColor.Yellow }, // visible
            { '7', ConsoleColor.Cyan },
        };

        public Dictionary<char, ConsoleColor> ColorScheme
        {
            get
            {
                return this.colorScheme;
            }
        }
    }
}
