using System;
using System.IO;

namespace Ucu.Poo.GameOfLife
{
    public static class BoardImporter
    {
        public static string Url { get; } = "board.txt";

        public static string Content { get; } = File.ReadAllText(Url);
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
                        initialState[x, y] = true;
                    }
                }
            }
            return new Board(initialState);
        }
    }
}