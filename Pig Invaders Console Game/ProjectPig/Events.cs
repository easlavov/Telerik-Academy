using System;
using System.IO;
using System.Media;
using System.Threading;

class Events
{
    static Random rndm = new Random();
    
    public static void PlayerShipDown()
    {
        Console.Clear();
        Console.SetCursorPosition(51, 0);
        Console.WriteLine("*** Get Ready! ***");
        for (int i = 1; i < 35; i++)
        {
            Console.SetCursorPosition(0, i);
            Console.WriteLine("*                                                                                                                      *");

            Print<Type>(Ships.GetModel(0), 57, 1+i);
            Thread.Sleep(90);
        }
        for (int i = 35; i < 40; i++)
        {
            Console.SetCursorPosition(0, i);
            Console.Write('*');
            Console.SetCursorPosition(119, i);
            Console.Write('*');
            Thread.Sleep(90);
        }

        for (int col = 0; col < 30; col++)
        {
            for (int row = 0; row < 39; row++)
            {
            Console.SetCursorPosition(75-col,row);
                if(col>0){Console.Write("                                         * ");}
                else { Console.Write("                                         *"); }
            }
            if (col > 10 && Settings.ShipChoice!=1)
            {
                Print<Type>(Ships.GetModel(0), 67 - col, 34);
            }
            if (col > 11 && Settings.ShipChoice == 1)
            {
                Print<Type>(Ships.GetModel(0), 68 - col, 34);
            }
            Thread.Sleep(135);
        }
    }

    public static void Boom(int bx,int by)
    {
        Console.SetCursorPosition(bx,by);
        Print<Type>(Ships.DeadShip1, bx, by);
        Thread.Sleep(35);
        Print<Type>(Ships.DeadShip2, bx, by);
        Thread.Sleep(35);
        Print<Type>(Ships.DeadShip3, bx, by);
        EnemysCrash();
    }

    //DRAW PLAING FIELD
    public static void DrawPlayingField()
    {
        for (int i = 0; i < 40; i++)
        {
            Console.WriteLine("*                                                                                      *                              *"); 
        }
        Console.SetCursorPosition(0, 1);
        Console.WriteLine("*                                                                                      ********************************"); 
        Console.SetCursorPosition(0, 39);
        Console.WriteLine("*                                                                                      ********************************"); 

        Console.SetCursorPosition(95,10);
        Console.WriteLine("ENEMIES LEFT:" + (Ships.SpawnedShipsList.Count - 1));
        Console.SetCursorPosition(95, 15);
        Console.WriteLine("SCORE: " + AngryPigs.CurrentScore.ToString());
        Console.SetCursorPosition(95, 20);
        Console.WriteLine("LIVES LEFT:"+ Settings.LiveCount.ToString());
        Console.SetCursorPosition(95, 33);
        Console.WriteLine("SPACEBAR - FIRE");
        Console.SetCursorPosition(95, 35);
        Console.WriteLine("P - PAUSE GAME");


    }

    //SOUNDS
    public static void PlayersShot()
    {
        try
        {
            SoundPlayer player = new SoundPlayer(@"..\..\trprsht1.wav");
            player.Play();
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("The sound file can't be found!");
        }
        
    }
    public static void EnemysShot()
    {
        try
        {
            SoundPlayer player1 = new SoundPlayer(@"..\..\wlkrsht2.wav");
            player1.Play();
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("The sound file can't be found!");
        }
        
    }
    public static void EnemysCrash()
    {
        try
        {
            SoundPlayer player3 = new SoundPlayer(@"..\..\expl2.wav");
            player3.Play();
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("The sound file can't be found!");
        }
        
    }    


    // PRINT PAUSE MESSAGE
    public static void PrintPaused()
    {
        Console.SetCursorPosition(35,15);
        Console.WriteLine("PAUSED");
    }

    // SPAWN ALL SHIPS
    public static void SpawnShips()
    {
        // SPAWN PLAYER SHIP
        SpawnPlayer(Settings.ShipChoice);

        // SELECT LIVES COUNT
        Settings.ChooseLives();

        // SPAWN ENEMIES
        Settings.ChooseEnemies();
        SpawnEnemies(Settings.EnemyCount);


    }

    // SPAWN PLAYER
    private static void SpawnPlayer(int shipChoice)
    {
        int[] shipStats = new int[5];
        shipStats[0] = shipChoice;
        shipStats[1] = 38;  // starting horizontal coords  57
        shipStats[2] = 34;  // starting vertical coords
        shipStats[3] = Ships.GetHorizontalDimension(shipChoice);
        shipStats[4] = Ships.GetVerticalDimension(shipChoice);
        Ships.SpawnedShipsList.Add(shipStats);
    }
    
    private static void PlayerNewLive(int shipChoice)
    {
        int[] shipStats = new int[5];
        shipStats[0] = shipChoice;
        shipStats[1] = 38;  // starting horizontal coords  57
        shipStats[2] = 34;  // starting vertical coords
        shipStats[3] = Ships.GetHorizontalDimension(shipChoice);
        shipStats[4] = Ships.GetVerticalDimension(shipChoice);

        Ships.SpawnedShipsList.Add(shipStats);
    }

    // DONE: SPAWN ENEMIES
    private static void SpawnEnemies(int ships)
    {
        for (int i = 1; i <= ships; i++)
        {
            int rollModel = rndm.Next(1, 3);
            int shipChoice = rollModel + 10;
            int[] shipStats = new int[5];
            shipStats[0] = shipChoice;
            // starting horizontal coords: 17, 35, 53
            shipStats[1] = 35;
            if (i % 2 == 0)
            {
                shipStats[1] = 17;
            }
            if (i%3 == 0)
            {
                shipStats[1] = 53;
            }
            shipStats[2] = 5;  // starting vertical coords
            shipStats[3] = Ships.GetHorizontalDimension(shipChoice);
            shipStats[4] = Ships.GetVerticalDimension(shipChoice);
            Ships.SpawnedShipsList.Add(shipStats);
        }
    }

    // DONE: READ INPUT
    public static void ReadInput()
    {
        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo command = Console.ReadKey();
            // GAME COMMANDS
            if (command.Key.Equals(ConsoleKey.P))
            {
                AngryPigs.Paused = !AngryPigs.Paused;

            }
            else
            {
                // NAVIGATIONAL COMMANDS
                if (command.Key.Equals(ConsoleKey.LeftArrow))
                {
                    MoveShip(0, "left");
                }
                if (command.Key.Equals(ConsoleKey.RightArrow))
                {
                    MoveShip(0, "right");
                }
                if (command.Key.Equals(ConsoleKey.UpArrow))
                {
                    MoveShip(0, "up");
                }
                if (command.Key.Equals(ConsoleKey.DownArrow))
                {
                    MoveShip(0, "down");
                }

                // WEAPONS COMMANDS
                if (command.Key.Equals(ConsoleKey.Spacebar))
                {
                    int horizontal = Ships.SpawnedShipsList[0][1] + Ships.SpawnedShipsList[0][3] / 2;
                    int vertical = Ships.SpawnedShipsList[0][2];
                    FireWeapon(Weapons.CurrentWeapon, horizontal, vertical, 0);
                    //Console.Beep(400, 100);
                    PlayersShot();//
                }
            }

           
        }
    }

    // ENEMY AI
    public static void EnemyAI(int scenario)
    {
        if (scenario == 1)
        {
            for (int i = 1; i < Ships.SpawnedShipsList.Count; i++)
            {
                int roll = rndm.Next(1, 501);
                if (roll <= 25) // left
                {
                    MoveShip(i, "left");
                }
                if (roll >= 26 && roll <= 50) // right
                {
                    MoveShip(i, "right");
                }
                if (roll >= 51 && roll <= 75) // up
                {
                    MoveShip(i, "up");
                }
                if (roll >= 76 && roll <= 100) // down
                {
                    MoveShip(i, "down");
                }
            }
            for (int ship = 1; ship < Ships.SpawnedShipsList.Count; ship++)
            {
                int next = rndm.Next(1, 201);
                if (next <= 2)
                {
                    int horizontal = Ships.SpawnedShipsList[ship][1] + Ships.SpawnedShipsList[0][3] / 2;
                    int vertical = Ships.SpawnedShipsList[ship][2] + Ships.SpawnedShipsList[ship][4];
                    FireWeapon(Weapons.CurrentWeapon, horizontal, vertical, 1);
                    //Console.Beep(300, 100);
                    EnemysShot();
                }
            }
        }
    }

    // FIRE WEAPON
    private static void FireWeapon(int weaponType, int horizontal, int vertical, int source)
    {
        int[] weaponStats = new int[5];
        weaponStats[0] = weaponType;   // ship mode - according to unimplemented param
        weaponStats[1] = horizontal;  // starting horizontal coords
        weaponStats[2] = vertical;  // starting vertical coords
        weaponStats[3] = source; // 0 for player, 1 for enemy
        //weaponStats[3] = Ships.GetHorizontalDimension(shipChoice);
        //weaponStats[4] = Ships.GetVerticalDimension(shipChoice);
        Weapons.FiredWeaponsList.Add(weaponStats);
    }

    // MOVE SHIP
    public static void MoveShip(int ship, string direction)
    {
        // move left
        if (direction == "left")
        {
            if (Ships.SpawnedShipsList[ship][1] == 2)
            {
                Ships.SpawnedShipsList[ship][1]--;
            }
            if (Ships.SpawnedShipsList[ship][1] > 1)
            {
                Ships.SpawnedShipsList[ship][1] -= 2;
            }
            return;
        }
        // movE right
        if (direction == "right")
        {
            if (Ships.SpawnedShipsList[ship][1] == Console.WindowWidth - Ships.SpawnedShipsList[ship][3] - 34)
            {
                Ships.SpawnedShipsList[ship][1]++;
            }
            if (Ships.SpawnedShipsList[ship][1] < Console.WindowWidth - Ships.SpawnedShipsList[ship][3] - 34)
            {
                Ships.SpawnedShipsList[ship][1] += 2;
            }
            return;
        }
        // move up
        if (direction == "up")
        {
            if (Ships.SpawnedShipsList[ship][2] >= 1)
            {
                Ships.SpawnedShipsList[ship][2] -= 1;
            }
            return;
        }
        // move down
        if (direction == "down")
        {
            if (Ships.SpawnedShipsList[ship][2] < Console.WindowHeight - Ships.SpawnedShipsList[ship][4])
            {
                Ships.SpawnedShipsList[ship][2] += 1;
            }
            return;
        }
    }

    // MOVE WEAPONS
    public static void MoveWeapons()
    {
        for (int i = 0; i < Weapons.FiredWeaponsList.Count; i++)
        {
            // Move up
            if (Weapons.FiredWeaponsList[i][3] == 0)
            {
                Weapons.FiredWeaponsList[i][2] -= 1;
                if (Weapons.FiredWeaponsList[i][2] == -1)
                {
                    Weapons.FiredWeaponsList.RemoveAt(i);
                }
                continue;
            }
            // Move down
            if (Weapons.FiredWeaponsList[i][3] == 1)
            {
                Weapons.FiredWeaponsList[i][2] += 1;
                if (Weapons.FiredWeaponsList[i][2] > Console.WindowHeight - 1)
                {
                    Weapons.FiredWeaponsList.RemoveAt(i);
                }
                continue;
            }
        }
    }

    // PRINT WEAPONS
    public static void PrintWeapons()
    {
        for (int i = 0; i < Weapons.FiredWeaponsList.Count; i++)
        {
            char model = Weapons.GetModel(i);
            Print<Type>(model, Weapons.FiredWeaponsList[i][1], Weapons.FiredWeaponsList[i][2]);
        }
    }

    // PRINT SHIP
    public static void PrintShips()
    {
        for (int i = 0; i < Ships.SpawnedShipsList.Count; i++)
        {
            char[,] model = Ships.GetModel(i);
            Print<Type>(model, Ships.SpawnedShipsList[i][1], Ships.SpawnedShipsList[i][2]);
        }
    }


    // A METHOD FOR PRINTING OBJECTS ON THE SCREEN
    public static void Print<T>(dynamic obj, int cursorWidth, int cursorHeight)
    {
        Type typeOfT = obj.GetType();
        if (typeOfT.IsArray == false)
        {
            PrintObject<Type>(obj, cursorWidth, cursorHeight);
            return;
        }
        if (typeOfT.GetArrayRank() > 1)
        {
            PrintMatrix<Type>(obj, cursorWidth, cursorHeight);
        }
        else
        {
            PrintArray<Type>(obj, cursorWidth, cursorHeight);
        }
    }

    // A METHOD THAT PRINTS A TWO-DIMENSIONAL ARRAY
    private static void PrintMatrix<T>(dynamic obj, int cursorWidth, int cursorHeight)
    {
        Console.SetCursorPosition(cursorWidth, cursorHeight);
        for (int i = 0; i < obj.GetLength(0); i++)
        {
            for (int p = 0; p < obj.GetLength(1); p++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                if (obj[i, p] == '|')
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                if (obj[i, p] == '+' || obj[i, p] == '=' || obj[i, p] == '.')
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                if (obj[i, p] == '*')
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.Write(obj[i, p]);
            }
            cursorHeight++;
            if (cursorHeight < Console.WindowHeight)
            {
                Console.SetCursorPosition(cursorWidth, cursorHeight);
            }
        }
    }

    // A METHOD THAT PRINTS A ONE-DIMENSONAL ARRAY
    private static void PrintArray<T>(dynamic obj, int cursorWidth, int cursorHeight)
    {
        Console.SetCursorPosition(cursorWidth, cursorHeight);
        foreach (var item in obj)
        {
            Console.Write(item);
        }
    }

    // A METHOD THAT PRINTS A SINGLE OBJECT
    private static void PrintObject<T>(dynamic obj, int cursorWidth, int cursorHeight)
    {
        if (cursorHeight > 39) { cursorHeight = 39; }  // Da se proveri kakvo se dani
        Console.SetCursorPosition(cursorWidth, cursorHeight);
        Console.Write(obj);
    }

    // COLLISION
    // Scan for every ship if there is any weapon overlaping its matrix
    public static void CheckForCollision()
    {
        for (int i = 0; i < Ships.SpawnedShipsList.Count; i++)
        {
            bool toBreak = false;
            int coordX = Ships.SpawnedShipsList[i][1];
            int coordY = Ships.SpawnedShipsList[i][2];
            for (int row = 0; row < Ships.SpawnedShipsList[i][4]; row++)
            {
                for (int column = 0; column < Ships.SpawnedShipsList[i][3]; column++)
                {
                    // check weapon coords
                    for (int weapon = 0; weapon < Weapons.FiredWeaponsList.Count; weapon++)
                    {
                        int weaponX = Weapons.FiredWeaponsList[weapon][1];
                        int weaponY = Weapons.FiredWeaponsList[weapon][2];
                        if (coordX == weaponX && coordY == weaponY)
                        {
                            if (i != 0)
                            {
                                Ships.SpawnedShipsList.RemoveAt(i);
                                Weapons.FiredWeaponsList.RemoveAt(weapon);
                                Boom(coordX, coordY); //vzriv
                                AngryPigs.CurrentScore += 100; //Adding points to the score
                            }
                          
                            // player ship destroyed
                            //if (i == 0 && Settings.LiveCount<1)
                            //{
                            //    Boom(coordX, coordY); //vzriv
                            //    AngryPigs.Victory = false;
                            //    AngryPigs.RunGame = false;
                            //}

                            // player next live
                            if (i == 0 /*&& Settings.LiveCount > 1*/)
                            {
                                Settings.LiveCount--;
                                Weapons.FiredWeaponsList.RemoveAt(weapon);
                                Boom(coordX, coordY); //vzriv
                                if (Settings.LiveCount > 0)
                                {
                                    Ships.SpawnedShipsList[0][1] = 38;
                                    Ships.SpawnedShipsList[0][2] = 34;
                                }
                                else
                                {
                                    AngryPigs.Victory = false;
                                    AngryPigs.RunGame = false;
                                }
                            }
                            // all enemy ships destroyed
                            if (Ships.SpawnedShipsList.Count == 1)
                            {
                                AngryPigs.RunGame = false;
                            }
                            toBreak = true;
                            break;
                        }
                    }
                    if (toBreak == true)
                    {
                        break;
                    }
                    coordX++;
                }
                if (toBreak == true)
                {
                    toBreak = false;
                    break;
                }
                coordY++;
                coordX = Ships.SpawnedShipsList[i][1];
            }
        }
    }

}