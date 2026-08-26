using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Ucu.Poo.GameOfLife
{
    public static class BoardImporter
    {
        public static string Url { get; } = "src/Program/board.txt";

        public static string Content { get; } = File.ReadAllText(Url);
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
                        board[x, y] = true;
                    }
                }
            }
            return board;
        }

    }
}