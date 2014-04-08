// Write a program to calculate n! for each n in the range [1..100]. 
// Hint: Implement first a method that multiplies a number represented as array of digits by given integer number.

using System;

class CalculateNFactForEachNInTheRange1to100
{
    static void Main()
    {
        Console.WriteLine("This program calculates n! for each n in the range [1..100(and more)].");
        Console.Write("Please, enter n: ");
        int number = int.Parse(Console.ReadLine());
        int[] factorial = Factorial(number);
        Console.Write("{0}! is ", number);
        for (int i = factorial.Length-1; i >= 0; i--)
        {
            Console.Write("{0}", factorial[i]);
        }
        Console.WriteLine();
    }

    static int[] Factorial(int number)
    {
        int[] factorial = { 1 };
        for (int i = 1; i <= number; i++)
        {
            factorial = ArrayMultiplication(factorial, i);
        }
        return factorial;
    }

    static int[] ArrayMultiplication(int[] array, int multiplicator)
    {
        // This algorithm replicates the common method for multiplication of multi-digit numbers
        int displacement = 0;
        int multiplications = array.Length;
        int[] product = new int[array.Length];
        while (multiplicator > 0)
        {
            int multiplicatorDigit = multiplicator % 10;
            int remainder = 0;
            for (int i = 0, j = displacement; i < multiplications; i++, j++)
            {
                if (j == product.Length)
	            {
                    Array.Resize(ref product, product.Length+1);
	            }                
                product[j] += (array[i] * multiplicatorDigit) + remainder;
                if (product[j] > 9)
                {
                    remainder = (product[j] / 10) % 10;
                    product[j] %= 10;                    
                }
                else
                {
                    remainder = 0;
                }
                if (i == multiplications-1 && remainder > 0)
                {
                    Array.Resize(ref product, product.Length + 1);
                    product[product.Length - 1] = remainder;
                }
            }
            //END
            multiplicator /= 10;
            displacement++;
        }
        return product;
    }
}