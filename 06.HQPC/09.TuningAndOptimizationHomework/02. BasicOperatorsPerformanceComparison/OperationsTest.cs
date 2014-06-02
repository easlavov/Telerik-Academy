using System;
using System.Diagnostics;
using System.Text;

public static class OperationsTest
{
    private const int ITERATIONS = 10000000; // ten million

    private static int intVar = 1;
    private static long longVar = 1;
    private static float floatVar = 1;
    private static double doubleVar = 1;
    private static decimal decimalVar = 1;

    public static string PerformTest(string operation)
    {
        StringBuilder sBuilder = new StringBuilder();

        // Int32
        string intTest = string.Format(
                                "Testing Int32. Iterations: {0} Operation: {1}"
                                + Environment.NewLine,
                                ITERATIONS,
                                operation);
        TimeSpan result = new TimeSpan();
        result = PerformOperation(operation, result, intVar);
        sBuilder.AppendLine(intTest + result);

        // Int64
        string longTest = string.Format(
                                "Testing Int64. Iterations: {0} Operation: {1}"
                                + Environment.NewLine,
                                ITERATIONS,
                                operation);
        result = PerformOperation(operation, result, longVar);
        sBuilder.AppendLine(longTest + result);

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
            case "addition":
                result = AdditionTest(testVar);
                break;
            case "subtraction":
                result = SubtractTest(testVar);
                break;
            case "incrementation":
                result = IncrementTest(testVar);
                break;
            case "multiplication":
                result = MultiplicationTest(testVar);
                break;
            case "division":
                result = DivisionTest(testVar);
                break;
        }
        return result;
    }

    private static void ResetValues()
    {
        intVar = 1;
        longVar = 1;
        floatVar = 1;
        doubleVar = 1;
        decimalVar = 1;
    }

    private static TimeSpan AdditionTest<T>(T variable)
    {
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
        for (int i = 0; i < ITERATIONS; i++)
        {
            variable = (dynamic)variable + 2;
        }

        stopWatch.Stop();
        var timeElapsed = stopWatch.Elapsed;
        return timeElapsed;
    }

    private static TimeSpan SubtractTest<T>(T variable)
    {
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
        for (int i = 0; i < ITERATIONS; i++)
        {
            variable = (dynamic)variable - 2;
        }

        stopWatch.Stop();
        var timeElapsed = stopWatch.Elapsed;
        return timeElapsed;
    }

    // Danger: low-quality program code
    private static TimeSpan IncrementTest<T>(T variable)
    {
        Stopwatch stopWatch = new Stopwatch();

        if (variable is Int32)
        {
            stopWatch.Start();
            for (int i = 0; i < ITERATIONS; i++)
            {
                intVar++;
            }

            stopWatch.Stop();            
        }
        else if (variable is Int64)
        {
            stopWatch.Start();
            for (int i = 0; i < ITERATIONS; i++)
            {
                longVar++;
            }

            stopWatch.Stop();    
        }
        else if (variable is float)
        {
            stopWatch.Start();
            for (int i = 0; i < ITERATIONS; i++)
            {
                floatVar++;
            }

            stopWatch.Stop();
        }
        else if (variable is double)
        {
            stopWatch.Start();
            for (int i = 0; i < ITERATIONS; i++)
            {
                doubleVar++;
            }

            stopWatch.Stop();
        }
        else if (variable is decimal)
        {
            stopWatch.Start();
            for (int i = 0; i < ITERATIONS; i++)
            {
                decimalVar++;
            }

            stopWatch.Stop();
        }

        var timeElapsed = stopWatch.Elapsed;
        return timeElapsed;
    }

    private static TimeSpan MultiplicationTest<T>(T variable)
    {
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
        for (int i = 0; i < ITERATIONS; i++)
        {
            variable = (dynamic)variable * 1;
        }

        stopWatch.Stop();
        var timeElapsed = stopWatch.Elapsed;
        return timeElapsed;
    }

    private static TimeSpan DivisionTest<T>(T variable)
    {
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
        for (int i = 0; i < ITERATIONS; i++)
        {
            variable = (dynamic)variable / 1;
        }

        stopWatch.Stop();
        var timeElapsed = stopWatch.Elapsed;
        return timeElapsed;
    }
}