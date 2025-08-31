using System;
using System.IO;
using System.Threading;
using System.Reflection;

namespace Ucu.Poo.GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            string folder = Path.GetDirectoryName(
                Assembly.GetExecutingAssembly().Location);
            string boardPath = Path.Combine(folder, "board.txt");
            // Reemplaza 👇 esta línea con tu código
            Console.WriteLine(boardPath);
        }
    }
}
