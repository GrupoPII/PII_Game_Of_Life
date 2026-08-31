using System;
using System.Text;

namespace Ucu.Poo.GameOfLife
{
    public class BoardPrinter
    {
        public void Print(Board board)
        {
            Console.Clear();
            StringBuilder output = new StringBuilder();
            for (int y = 0; y < board.Height; y++)
            {
                for (int x = 0; x < board.Width; x++)
                {
                    output.Append(board.IsAlive(x, y) ? "|X|" : "___");
                }

                output.AppendLine();
            }

            Console.WriteLine(output.ToString());
        }
    }
}