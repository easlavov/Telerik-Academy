using System;
using System.Diagnostics;
using System.Text;

public static class OperationsTest
{
    private const int ITERATIONS = 10000000; // ten million

    private static float floatVar = 35;
    private static double doubleVar = 1;
    private static decimal decimalVar = 35;

    public static string PerformTest(string operation)
    {
        StringBuilder sBuilder = new StringBuilder();
        
        TimeSpan result = new TimeSpan();

        // Float
        string floatTest = string.Format(
                                "Testing Float. Iterations: {0} Operation: {1}"
                                + Environment.NewLine,
                                ITERATIONS,
                                operation);
        result = PerformOperation(operation, result, floatVar);
        sBuilder.AppendLine(floatTest + result);

        // Double
        string doubleTest = string.Format(
                                "Testing Double. Iterations: {0} Operation: {1}"
                                + Environment.NewLine,
                                ITERATIONS,
                                operation);
        result = PerformOperation(operation, result, doubleVar);
        sBuilder.AppendLine(doubleTest + result);

        // Decimal
        string decimalTest = string.Format(
                                "Testing Decimal. Iterations: {0} Operation: {1}"
                                + Environment.NewLine,
                                ITERATIONS,
                                operation);
        result = PerformOperation(operation, result, decimalVar);
        sBuilder.AppendLine(decimalTest + result);

        ResetValues();

        return sBuilder.ToString();
    }

    private static TimeSpan PerformOperation<T>(string operation, TimeSpan result, T testVar)
    {
        switch (operation)
        {
            case "square root":
                result = SquareRootTest(testVar);
                break;
            case "logarithm":
                result = LogarithmTest(testVar);
                break;
            case "sine":
                result = SineTest(testVar);
                break;
        }

        return result;
    }

    private static void ResetValues()
    {
        floatVar = 35;
        doubleVar = 35;
        decimalVar = 35;
    }

    private static TimeSpan SquareRootTest<T>(T variable)
    {
        Stopwatch stopWatch = new Stopwatch();
        double result;
        stopWatch.Start();
        for (int i = 0; i < ITERATIONS; i++)
        {
            result = Math.Sqrt((double)(dynamic)variable);
        }

        stopWatch.Stop();
        var timeElapsed = stopWatch.Elapsed;
        return timeElapsed;
    }

    private static TimeSpan LogarithmTest<T>(T variable)
    {
        Stopwatch stopWatch = new Stopwatch();
        double result;
        stopWatch.Start();
        for (int i = 0; i < ITERATIONS; i++)
        {
            result = Math.Log((double)(dynamic)variable);
        }

        stopWatch.Stop();
        var timeElapsed = stopWatch.Elapsed;
        return timeElapsed;
    }
    
    private static TimeSpan SineTest<T>(T variable)
    {
        Stopwatch stopWatch = new Stopwatch();
        double result;
        stopWatch.Start();
        for (int i = 0; i < ITERATIONS; i++)
        {
            result = Math.Sin((double)(dynamic)variable);
        }

        stopWatch.Stop();
        var timeElapsed = stopWatch.Elapsed;
        return timeElapsed;
    }
}