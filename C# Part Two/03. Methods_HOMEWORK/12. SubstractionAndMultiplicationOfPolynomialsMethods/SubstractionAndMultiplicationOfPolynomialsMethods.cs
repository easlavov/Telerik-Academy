// Extend the program to support also subtraction and multiplication of polynomials

using System;

class SubstractionAndMultiplicationOfPolynomialsMethods
{
    static void Main()
    {
        Console.WriteLine("This program tests methods that substract or multiply two polynomials in addition to adding them.");
        Console.WriteLine();

        // Declare arrays
        decimal[] polynomialOne = { 5, -1 };
        Console.Write("First polynomial: ");
        PrintPolynomial(polynomialOne);
        decimal[] polynomialTwo = { 10, -5, 6 };
        Console.Write("Second polynomial: ");
        PrintPolynomial(polynomialTwo);
        int resultSize = Math.Max(polynomialOne.Length, polynomialTwo.Length);
        // Declare an array that will hold the result
        decimal[] result = new decimal[resultSize];

        // Call the addition method
        AddPolynomials(polynomialOne, polynomialTwo, result);
        Console.Write("Result of addition: ");
        // Print result
        PrintPolynomial(result);

        // Call the substraction method
        Array.Clear(result, 0, result.Length);
        SubstractPolynomials(polynomialOne, polynomialTwo, result);
        Console.Write("Result of substraction: ");
        PrintPolynomial(result);

        // Call the multiplication method
        Array.Clear(result, 0, result.Length);
        Console.Write("Result of multiplication: ");
        MultiplyPolynomials(polynomialOne, polynomialTwo, result);        
    }

    static void AddPolynomials(decimal[] polynomialOne, decimal[] polynomialTwo, decimal[] result)
    {
        // Assume polynomialOne is the longer array. If not, call the same method with reversed parameters
        if (polynomialTwo.Length > polynomialOne.Length)
        {
            AddPolynomials(polynomialTwo, polynomialOne, result);
            return;
        }

        // Copy first array to the result array
        Array.Copy(polynomialOne, result, polynomialOne.Length);

        // Perform addition
        for (int i = 0; i < polynomialTwo.Length; i++)
        {
            result[i] += polynomialTwo[i];
        }
    }

    static void SubstractPolynomials(decimal[] polynomialOne, decimal[] polynomialTwo, decimal[] result)
    {
        // Assume polynomialOne is the longer array. If not, call the same method with reversed parameters
        if (polynomialTwo.Length > polynomialOne.Length)
        {
            SubstractPolynomials(polynomialTwo, polynomialOne, result);
            return;
        }

        // Copy first array to the result array
        Array.Copy(polynomialOne, result, polynomialOne.Length);

        // Perform substraction
        for (int i = 0; i < polynomialTwo.Length; i++)
        {
            result[i] -= polynomialTwo[i];
        }
    }

    static void MultiplyPolynomials(decimal[] polynomialOne, decimal[] polynomialTwo, decimal[] result)
    {
        // Assume polynomialOne is the longer array. If not, call the same method with reversed parameters
        if (polynomialTwo.Length > polynomialOne.Length)
        {
            MultiplyPolynomials(polynomialTwo, polynomialOne, result);
            return;
        }


        // Perform multiplication
        for (int i = 0; i < polynomialTwo.Length; i++)
        {
            for (int p = 0; p < polynomialOne.Length; p++)
            {
                if (p + i == result.Length)
                {
                    Array.Resize(ref result, result.Length + 1);
                }
                result[p + i] += polynomialTwo[i] * polynomialOne[p];
            }
        }
        PrintPolynomial(result);
    }

    static void PrintPolynomial(decimal[] polynomial)
    {
        for (int i = polynomial.Length - 1; i >= 0; i--)
        {
            if (i != 0)
            {
                if (i > 1)
                {
                    if (polynomial[i] < 0)
                    {
                        Console.Write("({0}x^{1}) + ", polynomial[i], i);
                    }
                    else
                    {
                        Console.Write("{0}x^{1} + ", polynomial[i], i);
                    }
                    
                }
                else
                {
                    if (polynomial[i] < 0)
                    {
                        Console.Write("({0}x) + ", polynomial[i]);
                    }
                    else
                    {
                        Console.Write("{0}x + ", polynomial[i]);
                    }                    
                }
            }
            else
            {
                Console.Write("{0}", polynomial[i]);
            }
        }
        Console.WriteLine();
    }
}