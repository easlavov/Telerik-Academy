// Write a method that adds two positive integer numbers represented as arrays
// of digits (each array element arr[i] contains a digit; the last digit is kept
// in arr[0]). Each of the numbers that will be added could have up to 10 000 digits.

using System;

class AddPositiveIntegerNumbersMethod
{
    // Test program
    static void Main()
    {
        // Declare two test arrays. Numbers are REVERSED (last digit is at position 0)
        byte[] numberOne = { 9, 9, 9 };
        byte[] numberTwo = { 1,1,1 };
        // Calculate the sum by using the method
        byte[] sum = AddPositiveIntegerNumbers(numberTwo, numberOne);
        // Print the result of the addition as a proper number (last digit is printed in the end).
        for (int i = sum.Length - 1; i >= 0; i--)
        {
            Console.Write(sum[i]);
        }
        Console.WriteLine();
    }

    // Method - returns the sum as an array
    static byte[] AddPositiveIntegerNumbers(byte[] firstNumber, byte[] secondNumber)
    {
        byte remainder = 0;
        if (firstNumber.Length > secondNumber.Length)
        {
            Array.Resize(ref secondNumber, firstNumber.Length);
        }
        if (firstNumber.Length < secondNumber.Length)
        {
            Array.Resize(ref firstNumber, secondNumber.Length);
        }
        // Calculate
        for (int i = 0; i < firstNumber.Length; i++)
        {
            // Calculations are made digit by digit
            byte sum = (byte)(firstNumber[i] + secondNumber[i]);
            secondNumber[i] = (byte)(remainder + sum);
            remainder = 0;
            // This conditional sets a reminder for the next cycle
            if (secondNumber[i] > 9)
            {
                secondNumber[i] = (byte)(secondNumber[i] % 10);
                remainder += 1;
            }
            //
            if (i == firstNumber.Length - 1 && remainder == 1)
            {
                if (firstNumber.Length == secondNumber.Length)
                {
                    Array.Resize(ref secondNumber, secondNumber.Length + 1);
                }
                secondNumber[firstNumber.Length] += 1;
            }
        }
        return secondNumber;
    }
}