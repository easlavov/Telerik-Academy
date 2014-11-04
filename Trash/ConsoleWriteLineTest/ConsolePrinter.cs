using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWriteLineTest
{
    public class ConsolePrinter
    {
        private IConsoleSkin skin;

        public ConsolePrinter(IConsoleSkin skin)
        {
            this.skin = skin;
        }

        public void PrintChars(char[] chars)
        {
            foreach (var character in chars)
            {
                if (this.skin.ColorScheme.ContainsKey(character))
                {
                    Console.ForegroundColor = this.skin.ColorScheme[character];
                }

                Console.Write(character + " ");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
