using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        var additionResult = Test.PerformTest("addition");
        Console.WriteLine(additionResult + Environment.NewLine);

        var subtractionResult = Test.PerformTest("subtraction");
        Console.WriteLine(subtractionResult + Environment.NewLine);

        var incrementationResult = Test.PerformTest("incrementation");
        Console.WriteLine(incrementationResult + Environment.NewLine);

        var multiplicationResult = Test.PerformTest("multiplication");
        Console.WriteLine(multiplicationResult + Environment.NewLine);

        var divisionResult = Test.PerformTest("division");
        Console.WriteLine(divisionResult + Environment.NewLine);
    }
}