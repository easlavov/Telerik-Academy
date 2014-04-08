// Declare a character variable and assign it with the
// symbol that has Unicode code 72.

using System;

class DeclareCharacter
{
    static void Main()
    {
        // 72(10) = 48(16).
        // The Unicode code 72 corresponds to the symbol 'H'.
        char character = '\u0048';
        char alternative = (char)0x0048;

        // Check:

        Console.WriteLine(character);
        Console.WriteLine(alternative);
    }
}