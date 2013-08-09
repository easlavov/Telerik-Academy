// Write a method that adds two polynomials. Represent them as arrays of their coefficients

using System;

class AddTwoPolynomialsMethod
{
    static void Main()
    {
        Console.WriteLine("This program tests a method that adds two polynomials.");
        Console.WriteLine();

        // Declare arrays
        decimal[] polynomialOne = { 1, 3, 4 };
        Console.Write("First polynomial: ");
        PrintPolynomial(polynomialOne);
        decimal[] polynomialTwo = { 10, 15, 2, 3 };
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

    static void PrintPolynomial(decimal[] polynomial)
    {
        for (int i = polynomial.Length - 1; i >= 0; i--)
        {
            if (i != 0)
            {
                if (i > 1)
                {
                    Console.Write("{0}x^{1} + ", polynomial[i], i);
                }
                else
                {
                    Console.Write("{0}x + ", polynomial[i]);
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