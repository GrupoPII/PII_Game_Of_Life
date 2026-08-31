using System;
using System.IO;

namespace Ucu.Poo.GameOfLife
{
    /// <summary>
    /// Provides functionality to import game board data from a file.
    /// </summary>
    public static class BoardImporter
    {
        /// <summary>
        /// Gets the URI path to the board file.
        /// </summary>
        public static Uri Url { get; } = new Uri("file:///Users/valentinahernandezrovere/PII_Game_Of_Life/src/Program/board.txt");

        /// <summary>
        /// Gets the content of the board file.
        /// </summary>
        public static string Content { get; } = File.ReadAllText(Url.LocalPath);

        /// <summary>
        /// Gets the content of the board file split into lines.
        /// </summary>
        public static string[] ContentLines { get; } = Content.Split('\n');

        public static bool[,] Board { get; } = InitializeBoard();

        private static bool[,] InitializeBoard()
        {
            bool[,] board = new bool[ContentLines.Length, ContentLines[0].Length];
            for (int y = 0; y < ContentLines.Length; y++)
            {
                for (int x = 0; x < ContentLines[y].Length; x++)
                {
                    if (ContentLines[y][x] == '1')
                    {
                        board[x, y] = "|x|";
                    }
                    else
                    {
                        board[x, y] = "___";
                    }
                }
            }
            return board;
        }

    }
}