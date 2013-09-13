using System;
using System.Threading;

class Settings
{
    // ALL SETTINGS VARIABLES ARE STORED HERE
    public static int ShipChoice;
    public static int EnemyCount = 0;
    public static int LiveCount;

    // DISPLAYS SHIP SELECTION INTERFACE
    public static void ChooseStarship()
    {
        string[] shipModels = System.IO.File.ReadAllLines(@"..\..\ShipsModels.txt");
        foreach (string row in shipModels)
        {
            for (int i = 0; i < row.Length; i++)
            {
                if (row[i] == '.' || row[i] == '+' || row[i] == '`' || row[i] == '=')
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else if (row[i] == '*')
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else if (row[i] == '|')
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write(row[i]);
            }
            Console.WriteLine();
            Thread.Sleep(80);

        }
        while (true)
        {
            ConsoleKeyInfo playerShipChoice = Console.ReadKey();
            if (playerShipChoice.Key == ConsoleKey.D1 || playerShipChoice.Key == ConsoleKey.NumPad1)
            {
                ShipChoice = 1;
                return;
            }
            if (playerShipChoice.Key == ConsoleKey.D2 || playerShipChoice.Key == ConsoleKey.NumPad2)
            {
                ShipChoice = 2;
                return;
            }
            if (playerShipChoice.Key == ConsoleKey.D3 || playerShipChoice.Key == ConsoleKey.NumPad3)
            {
                ShipChoice = 3;
                return;
            }
        }
    }

    public static void ChooseEnemies()
    {
      
        var secondTry = false;
        while (true)
        {
            Console.Clear();
            if (secondTry)
            {
                Console.SetCursorPosition(24, 21);
                Console.Write("You should enter a value between 1 and 10.");
            }
            Console.SetCursorPosition(24, 20);
            Console.Write("How many enemies would you like to play against? Choose from 1 to 10: ");
            int.TryParse(Console.ReadLine(), out EnemyCount);
            if (EnemyCount >0 && EnemyCount < 11)
            {
                return;
            }
            secondTry = true;
            
        }
    }

     public static void ChooseLives()
    {
         
        var secondTry = false;
        
         while (true)
        {
            Console.Clear();
            if (secondTry)
            {
                Console.SetCursorPosition(24, 21);
                Console.Write("You should enter a value between 1 and 3."); 
            }
            
            Console.SetCursorPosition(24, 20);
            Console.Write("How many lives would you like to play with? Choose from 1 to 3: ");
            int.TryParse(Console.ReadLine(), out LiveCount);
            if (LiveCount > 0 && LiveCount < 4)
            {
                return;
            }
            secondTry = true;
            
        }
    }
}