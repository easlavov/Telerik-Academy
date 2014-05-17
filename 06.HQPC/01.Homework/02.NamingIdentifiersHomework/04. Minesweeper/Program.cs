using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper
{
	public class Mines
	{
		public class Score
		{
			private string name;
			private int points;

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

			public Score() 
            {                 
            }

			public Score(string name, int points)
			{
				this.Name = name;
				this.Points = points;
			}
		}

		static void Main(string[] args)
		{
			string command = string.Empty;
			char[,] field = InitiaiteGamingField();
			char[,] bombs = PlaceBombs();
			int currentPoints = 0;
			bool mineDetonated = false;
			List<Score> highScores = new List<Score>(6);
			int row = 0;
			int column = 0;
			bool isNewGame = true;
			const int TOTAL_SAFE_CELLS = 35; // TODO: refactor
			bool isCleared = false;

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
								isCleared = true;
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
					Console.Write("\nHrrrrrr! Umria gerojski s {0} to4ki. " +
						"Daj si niknejm: ", currentPoints);
					string niknejm = Console.ReadLine();
					Score t = new Score(niknejm, currentPoints);
					if (highScores.Count < 5)
					{
						highScores.Add(t);
					}
					else
					{
						for (int i = 0; i < highScores.Count; i++)
						{
							if (highScores[i].Points < t.Points)
							{
								highScores.Insert(i, t);
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

				if (isCleared)
				{
					Console.WriteLine(Environment.NewLine + "Congratulations! You revealed {0} cells without detonating a mine!", TOTAL_SAFE_CELLS);
					PrintField(bombs);
					Console.WriteLine("Enter your name: ");
					string playerName = Console.ReadLine();
					Score score = new Score(playerName, currentPoints);
					highScores.Add(score);
					PrintHighScores(highScores);
					field = InitiaiteGamingField();
					bombs = PlaceBombs();
					currentPoints = 0;
					isCleared = false;
					isNewGame = true;
				}
			}
			while (command != "exit");

			Console.WriteLine("Made in Bulgaria!");
			Console.Read();
		}

		private static void PrintHighScores(List<Score> champions)
		{
			Console.WriteLine(Environment.NewLine + "High scores:");
			if (champions.Count > 0)
			{
				for (int i = 0; i < champions.Count; i++)
				{
					Console.WriteLine("{0}. {1} --> {2} cells",
						i + 1, champions[i].Name, champions[i].Points);
				}

				Console.WriteLine();
			}
			else
			{
				Console.WriteLine("The high scores list is empty!" + Environment.NewLine);
			}
		}

		private static void UpdateField(char[,] field,
			char[,] bombs, int row, int column)
		{
			char adjacentMinesCount = GetAdjacentMinesCountAsChar(bombs, row, column);
			bombs[row, column] = adjacentMinesCount;
			field[row, column] = adjacentMinesCount;
		}

		private static void PrintField(char[,] board)
		{
			int rowsTotal = board.GetLength(0);
			int columnsTotal = board.GetLength(1);
			Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
			Console.WriteLine("   ---------------------");
			for (int i = 0; i < rowsTotal; i++)
			{
				Console.Write("{0} | ", i);
				for (int j = 0; j < columnsTotal; j++)
				{
					Console.Write(string.Format("{0} ", board[i, j]));
				}

				Console.Write("|");
				Console.WriteLine();
			}

			Console.WriteLine("   ---------------------\n");
		}

		private static char[,] InitiaiteGamingField()
		{
			int boardRows = 5;
			int boardColumns = 10;
			char[,] board = new char[boardRows, boardColumns];
			for (int i = 0; i < boardRows; i++)
			{
				for (int j = 0; j < boardColumns; j++)
				{
					board[i, j] = '?';
				}
			}

			return board;
		}

		private static char[,] PlaceBombs()
		{
			int Редове = 5;
			int Колони = 10;
			char[,] игрално_поле = new char[Редове, Колони];

			for (int i = 0; i < Редове; i++)
			{
				for (int j = 0; j < Колони; j++)
				{
					игрално_поле[i, j] = '-';
				}
			}

			List<int> r3 = new List<int>();
			while (r3.Count < 15)
			{
				Random random = new Random();
				int asfd = random.Next(50);
				if (!r3.Contains(asfd))
				{
					r3.Add(asfd);
				}
			}

			foreach (int i2 in r3)
			{
				int kol = (i2 / Колони);
				int red = (i2 % Колони);
				if (red == 0 && i2 != 0)
				{
					kol--;
					red = Колони;
				}
				else
				{
					red++;
				}
				игрално_поле[kol, red - 1] = '*';
			}

			return игрално_поле;
		}

		private static void smetki(char[,] pole)
		{
			int kol = pole.GetLength(0);
			int red = pole.GetLength(1);

			for (int i = 0; i < kol; i++)
			{
				for (int j = 0; j < red; j++)
				{
					if (pole[i, j] != '*')
					{
						char kolkoo = GetAdjacentMinesCountAsChar(pole, i, j);
						pole[i, j] = kolkoo;
					}
				}
			}
		}

		private static char GetAdjacentMinesCountAsChar(char[,] r, int rr, int rrr)
		{
			int brojkata = 0;
			int reds = r.GetLength(0);
			int kols = r.GetLength(1);

			if (rr - 1 >= 0)
			{
				if (r[rr - 1, rrr] == '*')
				{ 
					brojkata++; 
				}
			}
			if (rr + 1 < reds)
			{
				if (r[rr + 1, rrr] == '*')
				{ 
					brojkata++; 
				}
			}
			if (rrr - 1 >= 0)
			{
				if (r[rr, rrr - 1] == '*')
				{ 
					brojkata++;
				}
			}
			if (rrr + 1 < kols)
			{
				if (r[rr, rrr + 1] == '*')
				{ 
					brojkata++;
				}
			}
			if ((rr - 1 >= 0) && (rrr - 1 >= 0))
			{
				if (r[rr - 1, rrr - 1] == '*')
				{ 
					brojkata++; 
				}
			}
			if ((rr - 1 >= 0) && (rrr + 1 < kols))
			{
				if (r[rr - 1, rrr + 1] == '*')
				{ 
					brojkata++; 
				}
			}
			if ((rr + 1 < reds) && (rrr - 1 >= 0))
			{
				if (r[rr + 1, rrr - 1] == '*')
				{ 
					brojkata++; 
				}
			}
			if ((rr + 1 < reds) && (rrr + 1 < kols))
			{
				if (r[rr + 1, rrr + 1] == '*')
				{ 
					brojkata++; 
				}
			}
			return char.Parse(brojkata.ToString());
		}
	}
}
