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
            // Carga el tablero inicial desde src/Program/board.txt usando BoardImporter
            bool[,] initialState = BoardImporter.Board;
            Board board = new Board(initialState);
            BoardPrinter printer = new BoardPrinter();
            int width = initialState.GetLength(1);

            int generation = 0;
            bool running = true;

            while (running)
            {
                BoardPrinter.Print(initialState, width);
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