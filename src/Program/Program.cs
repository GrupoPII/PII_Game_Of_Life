using System;
using System.Threading;

namespace Ucu.Poo.GameOfLife
{
    /// <summary>
    /// Entry point for the Game of Life application.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Main entry point for the application.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        public static void Main(string[] args)
        {
            // Carga el tablero inicial desde assets/board.txt usando BoardImporter
            Board board = BoardImporter.Board;
            BoardPrinter printer = new BoardPrinter();
            int width = initialState.GetLength(1);

            int generation = 0;
            bool running = true;

            while (running)
            {
                printer.Print(board.BoardState, board.Width, board.Height);
                Console.WriteLine($"Generación {generation}");

                board.CreateNextGeneration();
                generation++;

                Thread.Sleep(300);

                // Corta si el usuario toca una tecla
                if (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                    running = false;
                }
            }
        }
    }
}