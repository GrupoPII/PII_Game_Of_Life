using System;
using System.Threading;

namespace Ucu.Poo.GameOfLife
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Carga el tablero inicial desde assets/board.txt usando BoardImporter
            Board board = BoardImporter.Board;
            BoardPrinter printer = new BoardPrinter();

            int generation = 0;
            bool running = true;

            while (running)
            {
                printer.Print(board);
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