using System;
using System.Threading;

namespace Ucu.Poo.GameOfLife
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Carga el tablero inicial desde src/Program/board.txt usando BoardImporter
            bool[,] initialState = BoardImporter.Board;
            Board board = new Board(initialState);
            BoardPrinter printer = new BoardPrinter();

            int generation = 0;
            bool running = true;

            while (running)
            {
                printer.Print(board.BoardState, board.Width, board.Height);
                Console.WriteLine($"Generación {generation}");

                board.CreateNextGeneration();
                generation++;

                Thread.Sleep(300);

                // Corta si el usuario apreta una tecla
                if (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                    running = false;
                }
            }
        }
    }
}