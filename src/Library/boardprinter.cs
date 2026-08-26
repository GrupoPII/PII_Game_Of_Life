using System;
using System.Text;
using System.Threading;

namespace Ucu.Poo.GameOfLife
{
    /// <summary>
    /// Prints and animates a Game of Life board.
    /// </summary>
    public class BoardPrinter
    {
        /// <summary>
        /// Prints the board and continuously displays generations.
        /// </summary>
        /// <param name="board">The board state to print.</param>
        /// <param name="width">The width of the board.</param>
        public static void Print(bool[,] board, int width)
        {
            Engine engine = new Engine(board);
            while (true)
            {
                Console.Clear();
                StringBuilder output = new StringBuilder();
                for (int y = 0; y < board.GetLength(1); y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        if (board[x, y])
                        {
                        output.Append("|X|");
                        }
                        else
                        {
                        output.Append("___");
                        }
                    }
                    output.AppendLine();
                }

                Console.WriteLine(output.ToString());
                engine.CreateNextGeneration();
                Thread.Sleep(300);
            }
        }
    }
}