using System;

namespace Ucu.Poo.GameOfLife
{
    
    public class Board
    {
        private Cell[,] cells;

        /// <summary>Ancho del tablero (número de columnas).</summary>
        public int Width { get; private set; }

        /// <summary>Alto del tablero (número de filas).</summary>
        public int Height { get; private set; }

        
        public Board(bool[,] initialBoard)
        {
            if (initialBoard == null)
                throw new ArgumentNullException(nameof(initialBoard));

            Width = initialBoard.GetLength(0);
            Height = initialBoard.GetLength(1);
            cells = new Cell[Width, Height];

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    cells[x, y] = new Cell(initialBoard[x, y]);
                }
            }
        }

        
        public Board(int width, int height)
        {
            if (width <= 0 || height <= 0)
                throw new ArgumentException("El ancho y el alto del tablero deben ser mayores a 0.");

            Width = width;
            Height = height;
            cells = new Cell[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    cells[x, y] = new Cell(false);
                }
            }
        }

        /// <summary>
        /// Expone el estado del tablero como bool[,] para mantener
        /// compatibilidad con código existente que consuma Engine.Board
        /// </summary>
        public bool[,] BoardState
        {
            get
            {
                bool[,] result = new bool[Width, Height];
                for (int x = 0; x < Width; x++)
                {
                    for (int y = 0; y < Height; y++)
                    {
                        result[x, y] = cells[x, y].IsAlive;
                    }
                }
                return result;
            }
        }

        /// <summary>Devuelve si la célula en (x,y) está viva.</summary>
        public bool IsAlive(int x, int y)
        {
            ValidatePosition(x, y);
            return cells[x, y].IsAlive;
        }

        /// <summary>
        /// Permite sembrar el estado inicial del tablero, por ejemplo para
        /// cargar un patrón conocido
        /// </summary>
        public void SetAlive(int x, int y, bool isAlive)
        {
            ValidatePosition(x, y);
            cells[x, y].SetState(isAlive);
        }

        private void ValidatePosition(int x, int y)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height)
                throw new ArgumentOutOfRangeException(
                    $"Posición ({x},{y}) fuera de los límites del tablero ({Width}x{Height}).");
        }

        
        private int CountAliveNeighbors(int x, int y)
        {
            int aliveNeighbors = 0;

            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    bool esLaMismaCelula = (i == x && j == y);
                    bool dentroDelTablero = i >= 0 && i < Width && j >= 0 && j < Height;

                    if (!esLaMismaCelula && dentroDelTablero && cells[i, j].IsAlive)
                    {
                        aliveNeighbors++;
                    }
                }
            }

            return aliveNeighbors;
        }

    
        public void CreateNextGeneration()
        {
            Cell[,] cloneBoard = new Cell[Width, Height];

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    int aliveNeighbors = CountAliveNeighbors(x, y);
                    bool isCurrentlyAlive = cells[x, y].IsAlive;
                    bool nextState = isCurrentlyAlive;

                    if (isCurrentlyAlive && aliveNeighbors < 2)
                    {
                        // Muere por soledad
                        nextState = false;
                    }
                    else if (isCurrentlyAlive && aliveNeighbors > 3)
                    {
                        // Muere por sobrepoblación
                        nextState = false;
                    }
                    else if (!isCurrentlyAlive && aliveNeighbors == 3)
                    {
                        // Nace por reproducción
                        nextState = true;
                    }
                    // En cualquier otro caso, la célula mantiene su estado actual

                    cloneBoard[x, y] = new Cell(nextState);
                }
            }

            cells = cloneBoard;
        }

        public override string ToString()
        {
            var sb = new System.Text.StringBuilder();
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    sb.Append(cells[x, y]);
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
