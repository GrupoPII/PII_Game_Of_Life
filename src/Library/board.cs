using System;

namespace Ucu.Poo.GameOfLife
{
    public class Board
    {
        private Cell[][] cells;

        /// <summary>Ancho del tablero (número de columnas).</summary>
        public int Width { get; private set; }

        /// <summary>Alto del tablero (número de filas).</summary>
        public int Height { get; private set; }

        public Board(bool[,] initialBoard)
        {
            ArgumentNullException.ThrowIfNull(initialBoard);

            this.Width = initialBoard.GetLength(0);
            this.Height = initialBoard.GetLength(1);
            this.cells = new Cell[this.Width][];

            for (int x = 0; x < this.Width; x++)
            {
                this.cells[x] = new Cell[this.Height];
                for (int y = 0; y < this.Height; y++)
                {
                    this.cells[x][y] = new Cell(initialBoard[x, y]);
                }
            }
        }

        public Board(int width, int height)
        {
            if (width <= 0 || height <= 0)
                throw new ArgumentException("El ancho y el alto del tablero deben ser mayores a 0.");

            this.Width = width;
            this.Height = height;
            this.cells = new Cell[this.Width][];

            for (int x = 0; x < this.Width; x++)
            {
                this.cells[x] = new Cell[this.Height];
                for (int y = 0; y < this.Height; y++)
                {
                    this.cells[x][y] = new Cell(false);
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
                bool[,] result = new bool[this.Width, this.Height];
                for (int x = 0; x < this.Width; x++)
                {
                    for (int y = 0; y < this.Height; y++)
                    {
                        result[x, y] = this.cells[x][y].IsAlive;
                    }
                }

                return result;
            }
        }

        /// <summary>Devuelve si la célula en (x,y) está viva.</summary>
        public bool IsAlive(int x, int y)
        {
            this.ValidatePosition(x, y);
            return this.cells[x][y].IsAlive;
        }

        /// <summary>
        /// Permite sembrar el estado inicial del tablero, por ejemplo para
        /// cargar un patrón conocido
        /// </summary>
        public void SetAlive(int x, int y, bool isAlive)
        {
            this.ValidatePosition(x, y);
            this.cells[x][y].SetState(isAlive);
        }

        private void ValidatePosition(int x, int y)
        {
            if (x < 0 || x >= this.Width || y < 0 || y >= this.Height)
                throw new ArgumentOutOfRangeException(
                    $"Posición ({x},{y}) fuera de los límites del tablero ({this.Width}x{this.Height}).");
        }

        private int CountAliveNeighbors(int x, int y)
        {
            int aliveNeighbors = 0;

            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    bool esLaMismaCelula = (i == x && j == y);
                    bool dentroDelTablero = i >= 0 && i < this.Width && j >= 0 && j < this.Height;

                    if (!esLaMismaCelula && dentroDelTablero && this.cells[i][j].IsAlive)
                    {
                        aliveNeighbors++;
                    }
                }
            }

            return aliveNeighbors;
        }

        public void CreateNextGeneration()
        {
            Cell[][] cloneBoard = new Cell[this.Width][];

            for (int x = 0; x < this.Width; x++)
            {
                cloneBoard[x] = new Cell[this.Height];
                for (int y = 0; y < this.Height; y++)
                {
                    int aliveNeighbors = this.CountAliveNeighbors(x, y);
                    bool isCurrentlyAlive = this.cells[x][y].IsAlive;
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

                    cloneBoard[x][y] = new Cell(nextState);
                }
            }

            this.cells = cloneBoard;
        }

        public override string ToString()
        {
            var sb = new System.Text.StringBuilder();
            for (int y = 0; y < this.Height; y++)
            {
                for (int x = 0; x < this.Width; x++)
                {
                    sb.Append(this.cells[x][y]);
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
