using System;
using System.Threading;

class Intro
{
    public static void Introduction()
    {
        Console.BufferHeight = Console.WindowHeight = 40;
        Console.BufferWidth = Console.WindowWidth = 120;

        Console.WriteLine();

        Thread.Sleep(100);

        string[] lines1 = System.IO.File.ReadAllLines(@"..\..\logo.txt");
        foreach (string row in lines1)
        {
            for (int i = 0; i < row.Length; i++)
            {
                if (row[i] == '_' || row[i] == '\\' || row[i] == '|' || row[i] == '/')
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (row[i] == '*')
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write(row[i]);
            }
            Console.WriteLine();
            Thread.Sleep(100);
        }
        Thread.Sleep(1000);

        string[] lines2 = System.IO.File.ReadAllLines(@"..\..\logo2.txt");
        foreach (string row in lines2)
        {
            for (int i = 0; i < row.Length; i++)
            {
                if (row[i] == '_' || row[i] == '\\' || row[i] == '|' || row[i] == '/')
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (row[i] == '*')
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write(row[i]);
            }
            Console.WriteLine();
            Thread.Sleep(100);
        }
        ConsoleKeyInfo buton = Console.ReadKey();
        if (buton.Key == ConsoleKey.Enter)
        {
            return;
        }
    }
}