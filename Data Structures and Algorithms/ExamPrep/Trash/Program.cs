using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    private const int MILLION = 1000000;
    private const int TEN_MILLION = 10000000;
    private const int HUNDRED_MILLION = 100000000;
    private const int BILLION = 1000000000;

    static void Main()
    {
        var sw = new Stopwatch();
        sw.Start();
        for (int i = 0; i < HUNDRED_MILLION; i++)
        {
            
        }
        sw.Stop();
        Console.WriteLine(sw.Elapsed);
    }
}