namespace Ucu.Poo.GameOfLife
{
    public class Engine
    {
        private bool[,] board;

        public Engine(bool[,] board)
        {
            this.board = board;
        }

        public bool[,] Board => board;

        public void CreateNextGeneration()
        {
            int width = board.GetLength(0);
            int height = board.GetLength(1);
            bool[,] nextBoard = new bool[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    int aliveNeighbors = CountAliveNeighbors(x, y);
                    bool isAlive = board[x, y];

                    if (isAlive && aliveNeighbors < 2)
                        nextBoard[x, y] = false;
                    else if (isAlive && aliveNeighbors > 3)
                        nextBoard[x, y] = false;
                    else if (!isAlive && aliveNeighbors == 3)
                        nextBoard[x, y] = true;
                    else
                        nextBoard[x, y] = isAlive;
                }
            }

            board = nextBoard;
        }

        private int CountAliveNeighbors(int x, int y)
        {
            int width = board.GetLength(0);
            int height = board.GetLength(1);
            int count = 0;

            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (i == x && j == y) continue;
                    if (i >= 0 && i < width && j >= 0 && j < height && board[i, j])
                        count++;
                }
            }

            return count;
        }
    }
}