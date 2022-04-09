using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace Tetris
{
    internal class Program
    {
        // Settings
        static int TetrisRows = 20;
        static int TetrisCols = 10;
        static int InfoCols = 10;
        static int ConsoleRows = 1 + TetrisRows + 1;
        static int ConsoleCols = 1 + TetrisCols + 1 + InfoCols + 1;
        static List<bool[,]> TetrisFigures = new List<bool[,]>()
        {
            new bool [,] //----
            {
                {true, true, true, true}
            },
            new bool [,] //O
            {
                {true, true},
                {true, true }
            },
            new bool [,] //T
            {
                {false, true , false},
                {true, true, true }
            },
            new bool [,] //S
            {
                {false, true ,true },
                {true, true, false }
            },
            new bool [,] //Z
            {
                {true, true, false },
                {false, true, true }
            },
            new bool [,] //J
            {
                {true, false, false },
                {true, true, true }
            },
            new bool [,] //L
            {
                {false, false, true },
                {true, true, true }
            },

        };
        static string SccoresFileName = "scores.txt";
        static int[] ScorePerLines = { 0, 40, 100, 300, 1200 };

        // State
        static int Highscore = 0;
        static int Score = 0;
        static int Frame = 0;
        static int FramesToMoveFigure = 16;
        static int Level = 1;
        static bool[,] CurrFigure = null;
        static int CurrFigureRow = 0;
        static int CurrFigureCol = 0;
        static bool[,] TetrisField = new bool[TetrisRows, TetrisCols];
        static Random Random = new Random();

        static void Main(string[] args)
        {
            new Thread(PlayMusic).Start();

            if (File.Exists(SccoresFileName))
            {
                var allScores = File.ReadLines(SccoresFileName);
                foreach (var score in allScores)
                {
                    var match = Regex.Match(score, @" => (?<score>[0-9]+)");
                    Highscore = Math.Max(Highscore, int.Parse(match.Groups["score"].Value));
                }
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Title = "Tetris v1.0";
            Console.WindowHeight = ConsoleRows + 1;
            Console.WindowWidth = ConsoleCols;
            Console.BufferHeight = ConsoleRows + 1;
            Console.BufferWidth = ConsoleCols;
            Console.CursorVisible = false;
            CurrFigure = TetrisFigures[Random.Next(0, TetrisFigures.Count)];

            while (true)
            {
                Frame++;
                UpdateLevel();

                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Escape)
                    {
                        return;
                    }
                    if (key.Key == ConsoleKey.LeftArrow || key.Key == ConsoleKey.A)
                    {
                        if (CurrFigureCol >= 1)
                        {
                            CurrFigureCol--;
                        }
                    }
                    if (key.Key == ConsoleKey.RightArrow || key.Key == ConsoleKey.D)
                    {
                        if (CurrFigureCol < TetrisCols - CurrFigure.GetLength(1))
                        {
                            CurrFigureCol++;
                        }
                    }
                    if (key.Key == ConsoleKey.DownArrow || key.Key == ConsoleKey.S)
                    {
                        Frame = 1;
                        Score += Level;
                        CurrFigureRow++;
                    }
                    if (key.Key == ConsoleKey.Spacebar || key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.W)
                    {
                        RotateCurrentFigure();
                    }
                }
                if (Frame % (FramesToMoveFigure - Level) == 0)
                {
                    CurrFigureRow++;
                    Frame = 0;
                }
                if (Collision(CurrFigure))
                {
                    AddCurrentFigureToTetrisField();
                    int lines = CheckForFullLines();
                    Score += ScorePerLines[lines] * Level;
                    CurrFigure = TetrisFigures[Random.Next(0, TetrisFigures.Count)];
                    CurrFigureRow = 0;
                    CurrFigureCol = 0;
                    if (Collision(CurrFigure))
                    {
                        File.AppendAllLines(SccoresFileName, new List<string>
                        {
                            $"[{DateTime.Now.ToString()}] {Environment.UserName} => {Score}"
                        });
                        var scoreAsString = Score.ToString();
                        scoreAsString += new string(' ', 5 - scoreAsString.Length);
                        Write("╔══════════╗", 5, 5);
                        Write("║   Game   ║ ", 6, 5);
                        Write("║   over!  ║ ", 7, 5);
                        Write($"║   {scoreAsString}  ║", 8, 5);
                        Write("╚══════════╝", 9, 5);
                        Thread.Sleep(100000);
                        return;
                    }
                }

                DrawBorder();
                DrawInfo();
                DrawCurrentFigure();
                DrawTetrisField();
                Thread.Sleep(40);
            }
        }
        private static void UpdateLevel()
        {
            if (Score <= 0)
            {
                Level = 1;
            }
            Level = (int)Math.Log10(Score) - 1;
            if (Level < 1)
            {
                Level = 1;
            }
            if (Level > 10)
            {
                Level = 10;
            }

        }
        static int CheckForFullLines() // 0, 1, 2, 3, 4
        {
            int lines = 0;
            for (int row = 0; row < TetrisField.GetLength(0); row++)
            {
                bool rowIsFull = true;
                for (int col = 0; col < TetrisField.GetLength(1); col++)
                {
                    if (TetrisField[row, col] == false)
                    {
                        rowIsFull = false;
                        break;
                    }
                }
                if (rowIsFull)
                {
                    for (int rowToMove = row; rowToMove >= 1; rowToMove--)
                    {
                        for (int col = 0; col < TetrisField.GetLength(1); col++)
                        {
                            TetrisField[rowToMove, col] = TetrisField[rowToMove - 1, col];
                        }
                    }
                    lines++;
                }
            }
            return lines;
        }
        static void RotateCurrentFigure()
        {
            var newFigure = new bool[CurrFigure.GetLength(1), CurrFigure.GetLength(0)];
            for (int row = 0; row < CurrFigure.GetLength(0); row++)
            {
                for (int col = 0; col < CurrFigure.GetLength(1); col++)
                {
                    newFigure[col, CurrFigure.GetLength(0) - row - 1] = CurrFigure[row, col];
                }
            }
            if (!Collision(newFigure))
            {
                CurrFigure = newFigure;
            }
        }
        static void AddCurrentFigureToTetrisField()
        {
            for (int row = 0; row < CurrFigure.GetLength(0); row++)
            {
                for (int col = 0; col < CurrFigure.GetLength(1); col++)
                {
                    if (CurrFigure[row, col])
                    {
                        TetrisField[CurrFigureRow + row, CurrFigureCol + col] = true;
                    }
                }
            }
        }
        static bool Collision(bool[,] figure)
        {
            if (CurrFigureCol > TetrisCols - figure.GetLength(1))
            {
                return true;
            }
            if (CurrFigureRow + figure.GetLength(0) == TetrisRows)
            {
                return true;
            }
            for (int row = 0; row < figure.GetLength(0); row++)
            {
                for (int col = 0; col < figure.GetLength(1); col++)
                {
                    if (figure[row, col] && TetrisField[CurrFigureRow + row + 1, CurrFigureCol + col])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        static void DrawInfo()
        {
            if (Score > Highscore)
            {
                Highscore = Score;
            }

            Write("Score:", 1, 3 + TetrisCols);
            Write(Score.ToString(), 2, 3 + TetrisCols);
            
            Write("Level:", 4, 3 + TetrisCols);
            Write(Level.ToString(), 5, 3 + TetrisCols);

            Write("Best:", 7, 3 + TetrisCols);
            Write(Highscore.ToString(), 8, 3 + TetrisCols);

            Write("Frame:", 10, 3 + TetrisCols);
            Write($"{Frame.ToString()} / {FramesToMoveFigure - Level}", 11, 3 + TetrisCols);

            Write("Position:", 13, 3 + TetrisCols);
            Write($"{CurrFigureRow}, {CurrFigureCol}", 14, 3 + TetrisCols);

            Write("Keys:", 16, 3 + TetrisCols);
            Write($" ^", 18, 3 + TetrisCols);
            Write($"< >", 19, 3 + TetrisCols);
            Write($" v", 20, 3 + TetrisCols);

        }
        static void DrawTetrisField()
        {
            for (int row = 0; row < TetrisField.GetLength(0); row++)
            {

                for (int col = 0; col < TetrisField.GetLength(1); col++)
                {
                    if (TetrisField[row, col])
                    {
                        Write("*", row + 1, col + 1);
                    }
                }
                //string line = string.Empty;
                //for (int col = 0; col < TetrisField.GetLength(1); col++)
                //{
                //    if (TetrisField[row, col])
                //    {
                //        line += "*";
                //    }
                //    elsse
                //    {
                //        line += " ";
                //    }
                //}
                //Write(line, row + 1, 1);
            }
        }
        static void DrawBorder()
        {
            Console.SetCursorPosition(0, 0);
            string line = "╔";
            line += new string('═', TetrisCols);
            line += "╦";
            line += new string('═', InfoCols);
            line += "╗";
            Console.WriteLine(line);

            for (int i = 0; i < TetrisRows; i++)
            {
                string middleLine = "║";
                middleLine += new string(' ', TetrisCols);
                middleLine += "║";
                middleLine += new string(' ', InfoCols);
                middleLine += "║";
                Console.Write(middleLine);
            }

            string endLine = "╚";
            endLine += new string('═', TetrisCols);
            endLine += "╩";
            endLine += new string('═', InfoCols);
            endLine += "╝";
            Console.Write(endLine);
        }
        static void DrawCurrentFigure()
        {
            for (int row = 0; row < CurrFigure.GetLength(0); row++)
            {
                for (int col = 0; col < CurrFigure.GetLength(1); col++)
                {
                    if (CurrFigure[row, col])
                    {
                        Write("*", row + 1 + CurrFigureRow, col +1 + CurrFigureCol);
                    }
                }
            }
        }
        static void Write(string text, int row, int col)
        {
            Console.SetCursorPosition(col, row);
            Console.Write(text);
        }
        static void PlayMusic()
        {
            while (true)
            {
                const int soundLenght = 100;
                Console.Beep(1320, soundLenght * 4);
                Console.Beep(990, soundLenght * 2);
                Console.Beep(1056, soundLenght * 2);
                Console.Beep(1188, soundLenght * 2);
                Console.Beep(1320, soundLenght);
                Console.Beep(1188, soundLenght);
                Console.Beep(1056, soundLenght * 2);
                Console.Beep(990, soundLenght * 2);
                Console.Beep(880, soundLenght * 4);
                Console.Beep(880, soundLenght * 2);
                Console.Beep(1056, soundLenght * 2);
                Console.Beep(1320, soundLenght * 4);
                Console.Beep(1188, soundLenght * 2);
                Console.Beep(1056, soundLenght * 2);
                Console.Beep(990, soundLenght * 6);
                Console.Beep(1056, soundLenght * 2);
                Console.Beep(1188, soundLenght * 4);
                Console.Beep(1320, soundLenght * 4);
                Console.Beep(1056, soundLenght * 4);
                Console.Beep(880, soundLenght * 4);
                Console.Beep(880, soundLenght * 4);
                Thread.Sleep(soundLenght * 2);
                Console.Beep(1188, soundLenght * 4);
                Console.Beep(1408, soundLenght * 2);
                Console.Beep(1760, soundLenght * 4);
                Console.Beep(1584, soundLenght * 2);
                Console.Beep(1408, soundLenght * 2);
                Console.Beep(1320, soundLenght * 6);
                Console.Beep(1056, soundLenght * 2);
                Console.Beep(1320, soundLenght * 4);
                Console.Beep(1188, soundLenght * 2);
                Console.Beep(1056, soundLenght * 2);
                Console.Beep(990, soundLenght * 4);
                Console.Beep(990, soundLenght * 2);
                Console.Beep(1056, soundLenght * 2);
                Console.Beep(1188, soundLenght * 4);
                Console.Beep(1320, soundLenght * 4);
                Console.Beep(1056, soundLenght * 4);
                Console.Beep(880, soundLenght * 4);
                Console.Beep(880, soundLenght * 4);
                Thread.Sleep(soundLenght * 4);
                Console.Beep(1320, soundLenght * 4);
                Console.Beep(990, soundLenght * 2);
                Console.Beep(1056, soundLenght * 2);
                Console.Beep(1188, soundLenght * 2);
                Console.Beep(1320, soundLenght);
                Console.Beep(1188, soundLenght);
                Console.Beep(1056, soundLenght * 2);
                Console.Beep(990, soundLenght * 2);
                Console.Beep(880, soundLenght * 4);
                Console.Beep(880, soundLenght * 2);
                Console.Beep(1056, soundLenght * 2);
                Console.Beep(1320, soundLenght * 4);
                Console.Beep(1188, soundLenght * 2);
                Console.Beep(1056, soundLenght * 2);
                Console.Beep(990, soundLenght * 6);
                Console.Beep(1056, soundLenght * 2);
                Console.Beep(1188, soundLenght * 4);
                Console.Beep(1320, soundLenght * 4);
                Console.Beep(1056, soundLenght * 4);
                Console.Beep(880, soundLenght * 4);
                Console.Beep(880, soundLenght * 4);
                Thread.Sleep(soundLenght * 2);
                Console.Beep(1188, soundLenght * 4);
                Console.Beep(1408, soundLenght * 2);
                Console.Beep(1760, soundLenght * 4);
                Console.Beep(1584, soundLenght * 2);
                Console.Beep(1408, soundLenght * 2);
                Console.Beep(1320, soundLenght * 6);
                Console.Beep(1056, soundLenght * 2);
                Console.Beep(1320, soundLenght * 4);
                Console.Beep(1188, soundLenght * 2);
                Console.Beep(1056, soundLenght * 2);
                Console.Beep(990, soundLenght * 4);
                Console.Beep(990, soundLenght * 2);
                Console.Beep(1056, soundLenght * 2);
                Console.Beep(1188, soundLenght * 4);
                Console.Beep(1320, soundLenght * 4);
                Console.Beep(1056, soundLenght * 4);
                Console.Beep(880, soundLenght * 4);
                Console.Beep(880, soundLenght * 4);
                Thread.Sleep(soundLenght * 4);
                Console.Beep(660, soundLenght * 8);
                Console.Beep(528, soundLenght * 8);
                Console.Beep(594, soundLenght * 8);
                Console.Beep(495, soundLenght * 8);
                Console.Beep(528, soundLenght * 8);
                Console.Beep(440, soundLenght * 8);
                Console.Beep(419, soundLenght * 8);
                Console.Beep(495, soundLenght * 8);
                Console.Beep(660, soundLenght * 8);
                Console.Beep(528, soundLenght * 8);
                Console.Beep(594, soundLenght * 8);
                Console.Beep(495, soundLenght * 8);
                Console.Beep(528, soundLenght * 4);
                Console.Beep(660, soundLenght * 4);
                Console.Beep(880, soundLenght * 8);
                Console.Beep(838, soundLenght * 16);
                Console.Beep(660, soundLenght * 8);
                Console.Beep(528, soundLenght * 8);
                Console.Beep(594, soundLenght * 8);
                Console.Beep(495, soundLenght * 8);
                Console.Beep(528, soundLenght * 8);
                Console.Beep(440, soundLenght * 8);
                Console.Beep(419, soundLenght * 8);
                Console.Beep(495, soundLenght * 8);
                Console.Beep(660, soundLenght * 8);
                Console.Beep(528, soundLenght * 8);
                Console.Beep(594, soundLenght * 8);
                Console.Beep(495, soundLenght * 8);
                Console.Beep(528, soundLenght * 4);
                Console.Beep(660, soundLenght * 4);
                Console.Beep(880, soundLenght * 8);
                Console.Beep(838, soundLenght * 16);
            }
        }
    }
}
