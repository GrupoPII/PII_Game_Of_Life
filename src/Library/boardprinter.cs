using System;
using System.Text;

namespace Ucu.Poo.GameOfLife
{
    /// <summary>
    /// Prints and animates a Game of Life board.
    /// </summary>
    public class BoardPrinter
    {
        public void Print(bool[,] board, int width, int height, Engine engine = null)
        {
            while (true)
            {
                Console.Clear();
                StringBuilder output = new StringBuilder();
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        output.Append(board[x, y] ? "|X|" : "___");
                    }

                output.AppendLine();
            }

                Console.WriteLine(output.ToString());
                engine?.CreateNextGeneration();
                Thread.Sleep(300);
            }
        }
    }
}