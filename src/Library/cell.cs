namespace Ucu.Poo.GameOfLife
{
    
    public class Cell
    {
       
        public bool IsAlive { get; private set; }

        public Cell(bool isAlive = false)
        {
            IsAlive = isAlive;
        }

    
        public void SetState(bool isAlive)
        {
            IsAlive = isAlive;
        }

        public override string ToString()
        {
            return IsAlive ? "O" : ".";
        }
    }
}