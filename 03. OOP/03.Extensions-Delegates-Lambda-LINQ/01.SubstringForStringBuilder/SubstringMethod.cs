using System;
using System.Text;

public static class SubstringMethod
{
    public static string Substring(this StringBuilder sBuilder, int index, int length)
    {
        if (index < 0 || index >= sBuilder.Length
            || index + length > sBuilder.Length)
        {
            throw new IndexOutOfRangeException();
        }
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < length; i++)
        {
            result.Append(sBuilder[index + i]);
        }
        return result.ToString();
    }
}