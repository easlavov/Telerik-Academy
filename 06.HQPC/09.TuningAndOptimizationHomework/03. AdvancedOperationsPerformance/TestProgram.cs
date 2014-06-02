using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TestProgram
{
    static void Main()
    {
        var additionResult = OperationsTest.PerformTest("square root");
        Console.WriteLine(additionResult + Environment.NewLine);

        var subtractionResult = OperationsTest.PerformTest("logarithm");
        Console.WriteLine(subtractionResult + Environment.NewLine);

        var incrementationResult = OperationsTest.PerformTest("sine");
        Console.WriteLine(incrementationResult + Environment.NewLine);
    }
}