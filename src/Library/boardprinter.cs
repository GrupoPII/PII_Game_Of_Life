using System;
using System.Text;
using System.Threading;

namespace Ucu.Poo.GameOfLife
{
    public class BoardPrinter
    {
        public void Print(bool[,] board, int width, int height)
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
                Thread.Sleep(300);
            }
        }
    }
}