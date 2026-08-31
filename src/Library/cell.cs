namespace Ucu.Poo.GameOfLife
{
    
    public class Cell
    {
        public bool IsAlive { get; set; }

        public Cell(bool isAlive)
        {
            IsAlive = isAlive;
        }
        public void SetState(bool isAlive)
        {
            IsAlive = isAlive;
        }

        public override string ToString()
        {
            return IsAlive ? "O" : "."; //if else 0 true, .false
        }
    }
}