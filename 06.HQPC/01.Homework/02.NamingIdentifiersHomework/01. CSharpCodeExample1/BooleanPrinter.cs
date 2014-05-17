using System;

public class BooleanPrinter
{
    private const int MAX_COUNT = 6;

    public void PrintBooleanValue(bool booleanValue)
    {
        string booleanAsString = booleanValue.ToString();
        Console.WriteLine(booleanAsString);
    }
}