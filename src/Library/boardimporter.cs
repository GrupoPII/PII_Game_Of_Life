// Copyright (c) 2024
// Licensed under the MIT License.

using System;
using System.IO;

namespace Ucu.Poo.GameOfLife
{
    /// <summary>
    /// Provides functionality to import game board data from a file.
    /// </summary>
    public static class BoardImporter
    {
        public static string Url { get; } = "src/Program/board.txt";

        /// <summary>
        /// Gets the content of the board file.
        /// </summary>
        public static string Content { get; } = File.ReadAllText(Url.LocalPath);

        /// <summary>
        /// Gets the content of the board file split into lines.
        /// </summary>
        public static string[] ContentLines { get; } = Content.Split('\n');

        public static Board Board { get; } = InitializeBoard();

        private static Board InitializeBoard()
        {
            bool[,] initialState = new bool[ContentLines.Length, ContentLines[0].Length];
            for (int y = 0; y < ContentLines.Length; y++)
            {
                for (int x = 0; x < ContentLines[y].Length; x++)
                {
                    if (ContentLines[y][x] == '1')
                    {
                        board[x, y] = true;
                    }
                }
            }
            return new Board(initialState);
        }
    }
}