using System;
using System.Threading;

class FallingRocks
{
    static int dwarfPosition;
    static Random randomGenerator = new Random();
    static int rockType1PositionX;
    static int rockType1PositionY;
    static int rockType2PositionX;
    static int rockType2PositionY;
    static int rockType3PositionX;
    static int rockType3PositionY;
    static int rockType4PositionX;
    static int rockType4PositionY;
    static int rockType5PositionX;
    static int rockType5PositionY;
    static int rockType6PositionX;
    static int rockType6PositionY;
    static int rockType7PositionX;
    static int rockType7PositionY;
    static int rockType8PositionX;
    static int rockType8PositionY;
    static int rockType9PositionX;
    static int rockType9PositionY;
    static int rockType10PositionX;
    static int rockType10PositionY;
    static int rockType11PositionX;
    static int rockType11PositionY;
    static int lives;
    static int speed;
    static int surviveTimer;
    static int choice;
    static int cont = 0;

    static void RemoveScrollBars()
    {
        Console.BufferHeight = Console.WindowHeight;
        Console.BufferWidth = Console.WindowWidth;
    }

    static void SetDwarfStartingPosition()
    {
        dwarfPosition = Console.WindowWidth / 2;
    }

    static void MoveDwarfRight()
    {
        if (dwarfPosition < Console.WindowWidth - 4)
        {
            dwarfPosition += 2;
        }
    }

    static void MoveDwarfLeft()
    {
        if (dwarfPosition > 0)
        {
            dwarfPosition -= 2;
        }
    }

    static void SetRocksStartingPositions()
    {
        rockType1PositionX = 2;
        rockType1PositionY = 4;
        PrintAtPosition(rockType1PositionX, rockType1PositionY, '^');
        rockType2PositionX = 4;
        rockType2PositionY = 1;
        PrintAtPosition(rockType2PositionX, rockType2PositionY, '@');
        rockType3PositionX = 15;
        rockType3PositionY = 3;
        PrintAtPosition(rockType3PositionX, rockType3PositionY, '*');
        rockType4PositionX = 33;
        rockType4PositionY = 0;
        PrintAtPosition(rockType4PositionX, rockType4PositionY, '&');
        rockType5PositionX = 56;
        rockType5PositionY = 5;
        PrintAtPosition(rockType5PositionX, rockType5PositionY, '+');
        rockType6PositionX = 40;
        rockType6PositionY = 6;
        PrintAtPosition(rockType6PositionX, rockType6PositionY, '%');
        PrintAtPosition(rockType6PositionX + 1, rockType6PositionY, '%');
        PrintAtPosition(rockType6PositionX + 2, rockType6PositionY, '%');
        rockType7PositionX = 73;
        rockType7PositionY = 10;
        PrintAtPosition(rockType7PositionX, rockType7PositionY, '$');
        rockType8PositionX = 57;
        rockType8PositionY = 9;
        PrintAtPosition(rockType8PositionX, rockType8PositionY, '#');
        rockType9PositionX = 33;
        rockType9PositionY = 8;
        PrintAtPosition(rockType9PositionX, rockType9PositionY, '!');
        PrintAtPosition(rockType9PositionX + 1, rockType9PositionY, '!');
        rockType10PositionX = 65;
        rockType10PositionY = 2;
        PrintAtPosition(rockType10PositionX, rockType10PositionY, '.');
        PrintAtPosition(rockType10PositionX + 1, rockType10PositionY, '.');
        PrintAtPosition(rockType10PositionX + 2, rockType10PositionY, '.');
        rockType11PositionX = 10;
        rockType11PositionY = 7;
        PrintAtPosition(rockType11PositionX, rockType11PositionY, ';');
    }

    static void MoveRocks()
    {
        for (int i = 1; i <= 11; i++)
        {
            switch (i)
            {
                case 1: rockType1PositionY += 1;
                    if (rockType1PositionX >= dwarfPosition && rockType1PositionX <= dwarfPosition + 2 && rockType1PositionY == Console.WindowHeight)
                    {
                        lives--;
                    }
                    if (rockType1PositionY == Console.WindowHeight)
                    {
                        rockType1PositionY = 0;
                        rockType1PositionX = randomGenerator.Next(0, 80);
                    }
                    PrintAtPosition(rockType1PositionX, rockType1PositionY, '^');
                    break;
                case 2: rockType2PositionY += 1;
                    if (rockType2PositionX >= dwarfPosition && rockType2PositionX <= dwarfPosition + 2 && rockType2PositionY == Console.WindowHeight)
                    {
                        lives--;
                    }
                    if (rockType2PositionY == Console.WindowHeight)
                    {
                        rockType2PositionY = 0;
                        rockType2PositionX = randomGenerator.Next(0, 80);
                    }
                    PrintAtPosition(rockType2PositionX, rockType2PositionY, '@');
                    break;
                case 3: rockType3PositionY += 1;
                    if (rockType3PositionX >= dwarfPosition && rockType3PositionX <= dwarfPosition + 2 && rockType3PositionY == Console.WindowHeight)
                    {
                        lives--;
                    }
                    if (rockType3PositionY == Console.WindowHeight)
                    {
                        rockType3PositionY = 0;
                        rockType3PositionX = randomGenerator.Next(0, 80);
                    }
                    PrintAtPosition(rockType3PositionX, rockType3PositionY, '*');
                    break;
                case 4: rockType4PositionY += 1;
                    if (rockType4PositionX >= dwarfPosition && rockType4PositionX <= dwarfPosition + 2 && rockType4PositionY == Console.WindowHeight)
                    {
                        lives--;
                    }
                    if (rockType4PositionY == Console.WindowHeight)
                    {
                        rockType4PositionY = 0;
                        rockType4PositionX = randomGenerator.Next(0, 80);
                    }
                    PrintAtPosition(rockType4PositionX, rockType4PositionY, '&');
                    break;
                case 5: rockType5PositionY += 1;
                    if (rockType5PositionX >= dwarfPosition && rockType5PositionX <= dwarfPosition + 2 && rockType5PositionY == Console.WindowHeight)
                    {
                        lives--;
                    }
                    if (rockType5PositionY == Console.WindowHeight)
                    {
                        rockType5PositionY = 0;
                        rockType5PositionX = randomGenerator.Next(0, 80);
                    }
                    PrintAtPosition(rockType5PositionX, rockType5PositionY, '+');
                    break;
                case 6: rockType6PositionY += 1;
                    if ((rockType6PositionX >= dwarfPosition || rockType6PositionX + 1 >= dwarfPosition || rockType6PositionX + 2 >= dwarfPosition)
                        && (rockType6PositionX <= dwarfPosition + 2 || rockType6PositionX + 1 <= dwarfPosition + 2 || rockType6PositionX + 2 <= dwarfPosition + 2)
                        && rockType6PositionY == Console.WindowHeight)
                    {
                        lives -= 3;
                    }
                    if (rockType6PositionY == Console.WindowHeight)
                    {
                        rockType6PositionY = 0;
                        rockType6PositionX = randomGenerator.Next(0, 78);
                    }
                    PrintAtPosition(rockType6PositionX, rockType6PositionY, '%');
                    PrintAtPosition(rockType6PositionX + 1, rockType6PositionY, '%');
                    PrintAtPosition(rockType6PositionX + 2, rockType6PositionY, '%');
                    break;
                case 7: rockType7PositionY += 1;
                    if (rockType7PositionX >= dwarfPosition && rockType7PositionX <= dwarfPosition + 2 && rockType7PositionY == Console.WindowHeight)
                    {
                        lives--;
                    }
                    if (rockType7PositionY == Console.WindowHeight)
                    {
                        rockType7PositionY = 0;
                        rockType7PositionX = randomGenerator.Next(0, 80);
                    }
                    PrintAtPosition(rockType7PositionX, rockType7PositionY, '$');
                    break;
                case 8: rockType8PositionY += 1;
                    if (rockType8PositionX >= dwarfPosition && rockType8PositionX <= dwarfPosition + 2 && rockType8PositionY == Console.WindowHeight)
                    {
                        lives--;
                    }
                    if (rockType8PositionY == Console.WindowHeight)
                    {
                        rockType8PositionY = 0;
                        rockType8PositionX = randomGenerator.Next(0, 80);
                    }
                    PrintAtPosition(rockType8PositionX, rockType8PositionY, '#');
                    break;
                case 9: rockType9PositionY += 1;
                    if ((rockType9PositionX >= dwarfPosition || rockType9PositionX + 1 >= dwarfPosition)
                        && (rockType9PositionX <= dwarfPosition + 2 || rockType9PositionX + 1 <= dwarfPosition + 2)
                        && rockType9PositionY == Console.WindowHeight)
                    {
                        lives -= 2;
                    }
                    if (rockType9PositionY == Console.WindowHeight)
                    {
                        rockType9PositionY = 0;
                        rockType9PositionX = randomGenerator.Next(0, 79);
                    }
                    PrintAtPosition(rockType9PositionX, rockType9PositionY, '!');
                    PrintAtPosition(rockType9PositionX + 1, rockType9PositionY, '!');
                    break;
                case 10: rockType10PositionY += 1;
                    if ((rockType10PositionX >= dwarfPosition || rockType10PositionX + 1 >= dwarfPosition || rockType10PositionX + 2 >= dwarfPosition)
                        && (rockType10PositionX <= dwarfPosition + 2 || rockType10PositionX + 1 <= dwarfPosition + 2 || rockType10PositionX + 2 <= dwarfPosition + 2)
                        && rockType10PositionY == Console.WindowHeight)
                    {
                        lives -= 3;
                    }
                    if (rockType10PositionY == Console.WindowHeight)
                    {
                        rockType10PositionY = 0;
                        rockType10PositionX = randomGenerator.Next(0, 78);
                    }
                    PrintAtPosition(rockType10PositionX, rockType10PositionY, '.');
                    PrintAtPosition(rockType10PositionX + 1, rockType10PositionY, '.');
                    PrintAtPosition(rockType10PositionX + 2, rockType10PositionY, '.');
                    break;
                case 11: rockType11PositionY += 1;
                    if (rockType11PositionX >= dwarfPosition && rockType11PositionX <= dwarfPosition + 2 && rockType11PositionY == Console.WindowHeight)
                    {
                        lives--;
                    }
                    if (rockType11PositionY == Console.WindowHeight)
                    {
                        rockType11PositionY = 0;
                        rockType11PositionX = randomGenerator.Next(0, 80);
                    }
                    PrintAtPosition(rockType11PositionX, rockType11PositionY, ';');
                    break;
                default: break;
            }
        }
    }

    static void DrawDwarf()
    {
        for (int x = dwarfPosition; x < dwarfPosition + 1; x++)
        {
            PrintAtPosition(x, Console.WindowHeight - 1, '(');
            PrintAtPosition(x + 1, Console.WindowHeight - 1, 'O');
            PrintAtPosition(x + 2, Console.WindowHeight - 1, ')');
        }
    }

    static void PrintAtPosition(int x, int y, char symbol)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(symbol);
    }

    static void DisplayScore()
    {
        Console.SetCursorPosition(Console.WindowWidth / 2 - 4, 0);
        Console.Write("Lives: {0}", lives);
        Console.SetCursorPosition(Console.WindowWidth / 2 - 6, 1);
        Console.Write("Time left: {0}", surviveTimer);
    }

    static void Main()
    {
        RemoveScrollBars();
        Console.SetCursorPosition(Console.WindowWidth / 2 - 12, Console.WindowHeight / 2 - 2);
        Console.Write("Welcome to Falling Rocks!");
        Console.ReadKey();
        Console.Clear();
        Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 2);
        Console.Write("You are a brave little dwarf that got lost in the mining tunnels below your clan's village.");
        Console.ReadKey();
        Console.Clear();
        Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.WindowHeight / 2 - 2);
        Console.Write("While trying to find your way back home you hear a loud noise.");
        Console.ReadKey();
        Console.Clear();
        Console.SetCursorPosition(Console.WindowWidth / 2 - 39, Console.WindowHeight / 2 - 2);
        Console.Write("You look up and see large pieces of rock ready to fall from the cave's ceiling!");
        Console.ReadKey();
        Console.Clear();
        Console.SetCursorPosition(Console.WindowWidth / 2 - 34, Console.WindowHeight / 2 - 2);
        Console.Write("'Oh, no! A quake!', you yell in terror! 'The cave is going crush me!'");
        Console.ReadKey();
        Console.Clear();
        Console.SetCursorPosition(Console.WindowWidth / 2 - 29, Console.WindowHeight / 2 - 2);
        Console.Write("Help the little dwarf survive by avoiding the falling rocks!");
        Console.ReadKey();
        Console.Clear();


        while (cont == 0)
        {
            while (true)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - 12, Console.WindowHeight / 2 - 4);
                Console.Write("Please, select difficulty:");
                Console.SetCursorPosition(Console.WindowWidth / 2 - 12, Console.WindowHeight / 2 - 2);
                Console.Write("1. Easy.");
                Console.SetCursorPosition(Console.WindowWidth / 2 - 12, Console.WindowHeight / 2);
                Console.Write("2. Medium.");
                Console.SetCursorPosition(Console.WindowWidth / 2 - 12, Console.WindowHeight / 2 + 2);
                Console.Write("3. Hard.");
                Console.SetCursorPosition(Console.WindowWidth / 2 - 12, Console.WindowHeight / 2 + 4);
                Console.Write("Your choice: ");
                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    ;
                }
                if (choice >= 1 && choice <= 3)
                {
                    cont = 0;
                    break;
                }
                Console.Clear();
            }

            if (choice == 1)
            {
                speed = 150;
                lives = 5;
                surviveTimer = 150;
            }
            if (choice == 2)
            {
                speed = 45;
                lives = 4;
                surviveTimer = 300;
            }
            if (choice == 3)
            {
                speed = 30;
                lives = 3;
                surviveTimer = 800;
            }

            SetRocksStartingPositions();
            SetDwarfStartingPosition();

            while (lives > 0 & surviveTimer > 0)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.RightArrow)
                    {
                        MoveDwarfRight();
                    }
                    if (keyInfo.Key == ConsoleKey.LeftArrow)
                    {
                        MoveDwarfLeft();
                    }
                }
                Console.Clear();
                MoveRocks();
                DrawDwarf();
                surviveTimer--;
                DisplayScore();
                Thread.Sleep(speed);
            }
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 2 - 16, Console.WindowHeight / 2);
            if (lives == 0)
            {
                Console.Write("Your death is quick and painful!");
                Console.ReadKey();
                Console.SetCursorPosition(Console.WindowWidth / 2 - 13, Console.WindowHeight / 2 + 2);
                Console.Write("Press any key to restart.");
                Console.ReadKey();
                Console.Clear();
            }
            if (surviveTimer == 0)
            {                
                if (lives == 1)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 37, Console.WindowHeight / 2 - 5);
                    Console.Write("The falling rocks don't kill you outright but your wounds are so severe that finding the way back home is now an impossible task. \n");
                    Console.SetCursorPosition(Console.WindowWidth / 2 + 13, Console.WindowHeight / 2 - 4);
                    Console.Write("Slowly, the Undergod embraces your shaking body and in the end there's nothing left of you but torn flesh and an empty gaze staring into the dark.");
                    Console.ReadKey();
                    Console.WriteLine("\n\n   Your clan never hears of you again...");
                    Console.ReadKey();
                }
                if (lives == 2)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 37, Console.WindowHeight / 2 - 3);
                    Console.Write("Your arm's been torn off by one of the rocks but at least you are alive. Eventually, you make your way back home. The clan is happy to see you at first. But without an arm you are no longer able to fulfil your duties. In time you become nothing, but a little more than a burden to your clan.\n\n   The accident in the cave has marked you forever...");
                    Console.ReadKey();
                }
                if (lives >= 3)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 37, Console.WindowHeight / 2 - 2);
                    Console.Write("You survive the quake with only minor injuries.");
                    int badFate = randomGenerator.Next(1, 101);
                    Console.ReadKey();
                    if (badFate < 31)
                    {
                        Console.SetCursorPosition(Console.WindowWidth / 2 - 37, Console.WindowHeight / 2 - 1);
                        Console.Write("Quickly you start looking for an exit, but after hours of searching you realize that heavy rocks have blocked all tunnels.\n\n   Your clan never hears of you again...");
                    }
                    if (badFate >= 31)
                    {
                        Console.SetCursorPosition(Console.WindowWidth / 2 - 37, Console.WindowHeight / 2 - 1);
                        Console.Write("Quickly you start looking for an exit and after finding one it takes you only a few hours to travel back home. You find your friends in good health and after you tell them about the quake and your miraculous survival you become the hero of the day. \n\n   You have escaped the Undergod.. for now.");
                    }
                    Console.ReadKey();
                }
                Console.Clear();
            }
        }
    }
}