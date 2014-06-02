using System;

class TestProgram
{
    static void Main()
    {
        var additionResult = OperationsTest.PerformTest("addition");
        Console.WriteLine(additionResult + Environment.NewLine);

        var subtractionResult = OperationsTest.PerformTest("subtraction");
        Console.WriteLine(subtractionResult + Environment.NewLine);

        var incrementationResult = OperationsTest.PerformTest("incrementation");
        Console.WriteLine(incrementationResult + Environment.NewLine);

        var multiplicationResult = OperationsTest.PerformTest("multiplication");
        Console.WriteLine(multiplicationResult + Environment.NewLine);

        var divisionResult = OperationsTest.PerformTest("division");
        Console.WriteLine(divisionResult + Environment.NewLine);
    }
}