using System;
using System.Collections.Generic;
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
        // State
        static int Score = 0;
        static int Frame = 0;
        static int FramesToMoveFigure = 15;
        static int CurrFigureIndex = 2;
        static bool[,] CurrFigure = null;
        static int CurrFigureRow = 0;
        static int CurrFigureCol = 0;
        static bool[,] TetrisField = new bool[TetrisRows, TetrisCols];

        static void Main(string[] args)
        {
            Console.Title = "Tetris v1.0";
            Console.WindowHeight = ConsoleRows + 1;
            Console.WindowWidth = ConsoleCols;
            Console.BufferHeight = ConsoleRows + 1;
            Console.BufferWidth = ConsoleCols;
            Console.CursorVisible = false;
            while (true)
            {
                Frame++;
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Escape)
                    {
                        return;
                    }
                    if (key.Key == ConsoleKey.LeftArrow || key.Key == ConsoleKey.A)
                    {
                        CurrFigureCol--; //TODO: Out of range
                        //TODO: Move current figure left
                    }
                    if (key.Key == ConsoleKey.RightArrow || key.Key == ConsoleKey.D)
                    {
                        CurrFigureCol++; //TODO: Out of range
                        //TODO: Move current figure right
                    }
                    if (key.Key == ConsoleKey.DownArrow || key.Key == ConsoleKey.S)
                    {
                        Frame = 1;
                        Score++;
                        CurrFigureRow++;
                        //TODO: Move current figure down
                    }
                    if (key.Key == ConsoleKey.Spacebar || key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.W)
                    {
                        // TODO: Implement 90 degree rotation of the current figure
                    }
                }
                if (Frame % FramesToMoveFigure == 0)
                {
                    CurrFigureRow++;
                    Frame = 0;
                }
                //Update the game state
                // Score++;
                //if (Collision())
                //{
                //    // AddCurrentFigureToTetrisField();
                // CheckForFullLines();
                // if(liens remove) Score++;
                //}

                DrawBorder();
                DrawInfo();
                DrawCurrentFigure();
                Thread.Sleep(40);
            }
        }

        static void DrawInfo()
        {
            Write("Score:", 1, 3 + TetrisCols);
            Write(Score.ToString(), 2, 3 + TetrisCols);
            Write("Frame:", 4, 3 + TetrisCols);
            Write(Frame.ToString(), 5, 3 + TetrisCols);
            Write("Position:", 7, 3 + TetrisCols);
            Write($"{CurrFigureRow}, {CurrFigureCol}", 8, 3 + TetrisCols);
            Write("Keys:", 10, 3 + TetrisCols);
            Write($" ^", 12, 3 + TetrisCols);
            Write($"<v>", 13, 3 + TetrisCols);

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
            var currFigure = TetrisFigures[CurrFigureIndex];
            for (int row = 0; row < currFigure.GetLength(0); row++)
            {
                for (int col = 0; col < currFigure.GetLength(1); col++)
                {
                    if (currFigure[row, col])
                    {
                        Write("*", row + 1 + CurrFigureRow, col + 1 + CurrFigureCol);

                    }
                }
            }
        }
        static void Write(string text, int row, int col, ConsoleColor color = ConsoleColor.Yellow)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(col, row);
            Console.Write(text);
            Console.ResetColor();
        }
    }
}
