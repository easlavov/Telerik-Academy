namespace BinaryPasswords
{
    using System;
    using System.Linq;

    class Solution
    {
        static void Main()
        {
            string input = Console.ReadLine();
            int asterisksCount = input.Count(character => character == '*');
            long possiblePasswords = GetPasswordsCount(asterisksCount);
            Console.WriteLine(possiblePasswords);
        }

        private static long GetPasswordsCount(int asterisksCount)
        {
            if (asterisksCount == 0)
            {
                return 1;
            }

            long result = 2;
            for (int i = 0; i < asterisksCount - 1; i++)
            {
                result <<= 1;
            }

            return result;
        }
    }
}
