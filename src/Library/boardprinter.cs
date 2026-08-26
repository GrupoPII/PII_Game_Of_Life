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
                        if (board[x,y])
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
                new Engine(board).CreateNextGeneration();
                Thread.Sleep(300);
            }
        }
    }
}