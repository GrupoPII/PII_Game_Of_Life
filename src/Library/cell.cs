namespace Ucu.Poo.GameOfLife
{
    
    public class Cell
    {
        /// <summary>
        /// Estado actual de la célula. Solo la propia Cell puede
        /// modificarlo (setter privado), reforzando que es la única
        /// responsable de su dato.
        /// </summary>
        public bool IsAlive { get; private set; }

        public Cell(bool isAlive = false)
        {
            IsAlive = isAlive;
        }

        /// <summary>
        /// Cambia el estado de la célula. Cell no decide POR QUÉ cambia
        /// (eso es responsabilidad de Board, que aplica las reglas),
        /// solo sabe CÓMO guardar ese cambio.
        /// </summary>
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