using ConsoleWriteLineTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        //Console.BackgroundColor = ConsoleColor.Gray;
        char[] charachters = { '1', '2', '3', '4', '5', '6', '7', '8' };
        ConsolePrinter printer = new ConsolePrinter(new ClassicSkin());
        printer.PrintChars(charachters);
        Console.WriteLine();

        
    }
}