
namespace Ucu.Poo.GameOfLife{
public class Engine
{
    private Board board;

    public Engine(Board board)
    {
        this.board = board;
    }

    public Board Board => board;

    public void CreateNextGeneration()
    {
        int width = board.Width;
        int height = board.Height;

        Cell[,] nextCells = new Cell[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                int aliveNeighbors = CountAliveNeighbors(x, y);
                bool isAlive = board.GetCell(x, y).IsAlive;

                bool willBeAlive;
                if (isAlive && aliveNeighbors < 2)
                {
                    willBeAlive = false; // baja población
                }
                else if (isAlive && aliveNeighbors > 3)
                {
                    willBeAlive = false; // sobrepoblación
                }
                else if (!isAlive && aliveNeighbors == 3)
                {
                    willBeAlive = true; // reproducción
                }
                else
                {
                    willBeAlive = isAlive; // se mantiene
                }

                nextCells[x, y] = new Cell(willBeAlive);
            }
        }

        board.SetCells(nextCells);
    }

    private int CountAliveNeighbors(int x, int y)
    {
        int width = board.Width;
        int height = board.Height;
        int count = 0;

        for (int i = x - 1; i <= x + 1; i++)
        {
            for (int j = y - 1; j <= y + 1; j++)
            {
                if (i == x && j == y) continue;
                if (i >= 0 && i < width && j >= 0 && j < height && board.GetCell(i, j).IsAlive)
                {
                    count++;
                }
            }
        }

        return count;
    }
}
}