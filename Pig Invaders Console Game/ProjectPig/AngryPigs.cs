using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Linq;
using System.Text.RegularExpressions;

class AngryPigs
{

    // BOOLS
    public static bool RunGame = true;
    public static bool Victory = true;
    public static bool Paused = false;

    // CURRENT SCORE
    public static int CurrentScore = 0;

    
    static void Main()
    {
        // SET CONSOLE HEIGHT/WIDTH
        Console.SetWindowSize(120, 40);

        // REMOVE SCROLLING
        Console.BufferHeight = Console.WindowHeight;
        Console.BufferWidth = Console.WindowWidth;

        // CONSOLE TITLE
        Console.Title = "PIG INVADERS";
        Console.CursorVisible = false;

        // DISPLAY INTRO
        // ASK USER IF HE WANTS THE INTRO TO BE DISPLAYED
        Events.Print<string>("Do you want to display the introduction? Y/N", 35, 20);
        ConsoleKeyInfo introChoice = Console.ReadKey();
        if (introChoice.Key == ConsoleKey.Y)
        {
            Intro.Introduction();
        }

        // Choose ship
        Settings.ChooseStarship();

        // SPAWN
        Events.SpawnShips();

        // GET READY
        Events.PlayerShipDown();

        while (RunGame)
        {
            if (!Paused)
            {
                // CLEAR ENTIRE CONSOLE
                Console.Clear();

                //DRAW PLAING FIELD
                Events.DrawPlayingField();

                // MOVE WEAPONS
                Events.MoveWeapons();

                // CHECK FOR COLLISION
                // victory/defeat conditions are checked here for
                Events.CheckForCollision();

                // READ COMMAND
                Events.ReadInput();

                // ENEMY AI
                Events.EnemyAI(1);

                // DRAW SHIPS
                Events.PrintShips();

                // DRAW WEAPONS
                Events.PrintWeapons();


                Console.SetCursorPosition(0, 0);
            }
            else
            {
                Events.PrintPaused();
                // READ COMMAND
                Events.ReadInput();
            }
            Thread.Sleep(15);
        }

        // PRINT GAME OUTCOME
        if (Victory == true)
        {
            Thread.Sleep(200);
            Events.DrawPlayingField();
            Events.Print<string>("Congratulations! You have won the game!", 43-17, 17);

            CheckHighScores();           
        }
        else
        {
            Thread.Sleep(200);
            Events.DrawPlayingField();
            Events.Print<string>("You have been destroyed!", 48 - 17, 17);
        }

        // EXIT GAME ONLY WHEN ESC IS PRESSED
        Events.Print<string>("Press Spacebar to see the Top 10 or Escape to exit.", 50 - 17, 17);

        Console.SetCursorPosition(24, 25);
       
        
        while (true)
        {
            ConsoleKeyInfo command = Console.ReadKey();
            if (command.Key == ConsoleKey.Escape)
            {
                break;
            }
            if (command.Key == ConsoleKey.Spacebar )
            {
                int n = 0;
                              
                using (StreamReader input = new StreamReader("../../HighScores.txt"))
                
                  for (string line; (line = input.ReadLine()) != null; n++)
                        if (!string.IsNullOrEmpty(line))
                        {
                            Console.SetCursorPosition(24, 25 + n);
                            Console.WriteLine("{0} \t {1}", n + 1, line);
                        }
            }
        }        
    }

    private static void CheckHighScores()
    {
        //Console.WriteLine("Congratulations! You have won the game!");
        Events.Print<string>("Enter your nickname: ", 43 - 17, 19);

        string nickname  = Console.ReadLine().Trim();
        string editNikname = Regex.Replace(nickname, " ", "_");

        List<Tuple<string, int>> newHighScoreList = new List<Tuple<string, int>>();

        try
        {
            List<Tuple<string, int>> highScoresList = new List<Tuple<string, int>>();
            using (StreamReader reader = new StreamReader("../../HighScores.txt"))
            {
                string line = reader.ReadLine();
                while (!string.IsNullOrEmpty(line))
                {
                    string[] lineFromeFile = line.Split(' ');
                    highScoresList.Add(new Tuple<string, int>(lineFromeFile[0], Int32.Parse(lineFromeFile[1])));
                    line = reader.ReadLine();
                }

                foreach (Tuple<string, int> oldHighScores in highScoresList)
                {
                    if (CurrentScore >= oldHighScores.Item2)
                    {
                        highScoresList.Add(new Tuple<string, int>(editNikname, CurrentScore));
                        highScoresList.Sort((x, y) => y.Item2.CompareTo(x.Item2));
                        newHighScoreList = highScoresList.Take(10).ToList();
                    }
                }
            }
        }
        catch (Exception)
        {
            Console.WriteLine("An error has occured while reading/writing the high scores text file.");
        }

        if (newHighScoreList.Count > 0)
        {
            //clearing the high score text file
            File.WriteAllText("../../HighScores.txt", String.Empty);

            using (StreamWriter writer = new StreamWriter("../../HighScores.txt"))
            {
                foreach (Tuple<string, int> newHigh in newHighScoreList)
                {
                    writer.WriteLine(newHigh.Item1 + " " + newHigh.Item2.ToString());
                }
            }
        }
    }    
}