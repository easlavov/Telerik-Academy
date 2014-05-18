namespace Minesweeper
{
    using System;
    using System.Collections.Generic;

    public class Mines
    {
        public static void Main(string[] args)
        {
            const int TOTAL_SAFE_CELLS = 35;
            string command = string.Empty;
            char[,] field = InitiaiteGamingField();
            char[,] bombs = PlaceBombs();
            int currentPoints = 0;
            bool mineDetonated = false;
            List<Score> highScores = new List<Score>(6);
            int row = 0;
            int column = 0;
            bool isNewGame = true;
            bool fieldCleared = false;

            do
            {
                if (isNewGame)
                {
                    Console.WriteLine("Lets play 'Minesweeper'! Try to find all mine-free fields! " +
                        "'top' displays the high scores, 'restart' starts a new game, 'exit' quits the application. " +
                        "Good luck!");
                    PrintField(field);
                    isNewGame = false;
                }

                Console.Write("Enter row and column: ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                        int.TryParse(command[2].ToString(), out column) &&
                        row <= field.GetLength(0) && column <= field.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        PrintHighScores(highScores);
                        break;
                    case "restart":
                        field = InitiaiteGamingField();
                        bombs = PlaceBombs();
                        PrintField(field);
                        mineDetonated = false;
                        isNewGame = false;
                        break;
                    case "exit":
                        Console.WriteLine("Bye, bye!");
                        break;
                    case "turn":
                        if (bombs[row, column] != '*')
                        {
                            if (bombs[row, column] == '-')
                            {
                                UpdateField(field, bombs, row, column);
                                currentPoints++;
                            }

                            if (currentPoints == TOTAL_SAFE_CELLS)
                            {
                                fieldCleared = true;
                            }
                            else
                            {
                                PrintField(field);
                            }
                        }
                        else
                        {
                            mineDetonated = true;
                        }

                        break;
                    default:
                        Console.WriteLine(Environment.NewLine + "Invalid command!" +
                            Environment.NewLine);
                        break;
                }

                if (mineDetonated)
                {
                    PrintField(bombs);
                    Console.Write(
                        Environment.NewLine +
                        "You died honorably with {0} points. " +
                        "Enter your name: ",
                        currentPoints);
                    string playerName = Console.ReadLine();
                    Score playerScore = new Score(playerName, currentPoints);
                    if (highScores.Count < 5)
                    {
                        highScores.Add(playerScore);
                    }
                    else
                    {
                        for (int i = 0; i < highScores.Count; i++)
                        {
                            if (highScores[i].Points < playerScore.Points)
                            {
                                highScores.Insert(i, playerScore);
                                highScores.RemoveAt(highScores.Count - 1);
                                break;
                            }
                        }
                    }

                    highScores.Sort((Score r1, Score r2) => r2.Name.CompareTo(r1.Name));
                    highScores.Sort((Score r1, Score r2) => r2.Points.CompareTo(r1.Points));
                    PrintHighScores(highScores);

                    field = InitiaiteGamingField();
                    bombs = PlaceBombs();
                    currentPoints = 0;
                    mineDetonated = false;
                    isNewGame = true;
                }

                if (fieldCleared)
                {
                    Console.WriteLine(
                        Environment.NewLine +
                        "Congratulations! You revealed {0} cells without detonating a mine!",
                        TOTAL_SAFE_CELLS);
                    PrintField(bombs);
                    Console.WriteLine("Enter your name: ");
                    string playerName = Console.ReadLine();
                    Score playerScore = new Score(playerName, currentPoints);
                    highScores.Add(playerScore);
                    PrintHighScores(highScores);

                    field = InitiaiteGamingField();
                    bombs = PlaceBombs();
                    currentPoints = 0;
                    fieldCleared = false;
                    isNewGame = true;
                }
            }
            while (command != "exit");

            Console.WriteLine("Made in Bulgaria!");
            Console.Read();
        }

        private static void PrintHighScores(List<Score> playerScores)
        {
            Console.WriteLine(Environment.NewLine + "High scores:");
            if (playerScores.Count > 0)
            {
                for (int i = 0; i < playerScores.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} cells", i + 1, playerScores[i].Name, playerScores[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("The high scores list is empty!" + Environment.NewLine);
            }
        }

        private static void UpdateField(char[,] field, char[,] bombs, int row, int column)
        {
            char adjacentMinesCount = GetAdjacentMinesCountAsChar(bombs, row, column);
            bombs[row, column] = adjacentMinesCount;
            field[row, column] = adjacentMinesCount;
        }

        private static void PrintField(char[,] field)
        {
            int fieldRows = field.GetLength(0);
            int fieldColumns = field.GetLength(1);
            Console.WriteLine(Environment.NewLine + "    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < fieldRows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < fieldColumns; j++)
                {
                    Console.Write(string.Format("{0} ", field[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------" + Environment.NewLine);
        }

        private static char[,] InitiaiteGamingField()
        {
            int fieldRows = 5;
            int fieldColumns = 10;
            char[,] field = new char[fieldRows, fieldColumns];
            for (int i = 0; i < fieldRows; i++)
            {
                for (int j = 0; j < fieldColumns; j++)
                {
                    field[i, j] = '?';
                }
            }

            return field;
        }

        private static char[,] PlaceBombs()
        {
            int rows = 5;
            int columns = 10;
            char[,] field = new char[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    field[i, j] = '-';
                }
            }

            List<int> bombsCoords = new List<int>();
            while (bombsCoords.Count < 15)
            {
                Random random = new Random();
                int bombCoord = random.Next(50);
                if (!bombsCoords.Contains(bombCoord))
                {
                    bombsCoords.Add(bombCoord);
                }
            }

            foreach (int bombCoord in bombsCoords)
            {
                int column = bombCoord / columns;
                int row = bombCoord % columns;
                if (row == 0 && bombCoord != 0)
                {
                    column--;
                    row = columns;
                }
                else
                {
                    row++;
                }

                field[column, row - 1] = '*';
            }

            return field;
        }

        private static void PrintMinesCount(char[,] field)
        {
            int columns = field.GetLength(0);
            int rows = field.GetLength(1);

            for (int col = 0; col < columns; col++)
            {
                for (int row = 0; row < rows; row++)
                {
                    if (field[col, row] != '*')
                    {
                        char adjacentMinesCount = GetAdjacentMinesCountAsChar(field, col, row);
                        field[col, row] = adjacentMinesCount;
                    }
                }
            }
        }

        private static char GetAdjacentMinesCountAsChar(char[,] field, int col, int row)
        {
            int minesCount = 0;
            int rows = field.GetLength(0);
            int columns = field.GetLength(1);

            if (col - 1 >= 0)
            {
                if (field[col - 1, row] == '*')
                {
                    minesCount++;
                }
            }

            if (col + 1 < rows)
            {
                if (field[col + 1, row] == '*')
                {
                    minesCount++;
                }
            }

            if (row - 1 >= 0)
            {
                if (field[col, row - 1] == '*')
                {
                    minesCount++;
                }
            }

            if (row + 1 < columns)
            {
                if (field[col, row + 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((col - 1 >= 0) && (row - 1 >= 0))
            {
                if (field[col - 1, row - 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((col - 1 >= 0) && (row + 1 < columns))
            {
                if (field[col - 1, row + 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((col + 1 < rows) && (row - 1 >= 0))
            {
                if (field[col + 1, row - 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((col + 1 < rows) && (row + 1 < columns))
            {
                if (field[col + 1, row + 1] == '*')
                {
                    minesCount++;
                }
            }

            return char.Parse(minesCount.ToString());
        }

        public class Score
        {
            private string name;
            private int points;

            public Score()
            {
            }

            public Score(string name, int points)
            {
                this.Name = name;
                this.Points = points;
            }

            public string Name
            {
                get
                {
                    return this.name;
                }

                set
                {
                    this.name = value;
                }
            }

            public int Points
            {
                get
                {
                    return this.points;
                }

                set
                {
                    this.points = value;
                }
            }
        }
    }
}