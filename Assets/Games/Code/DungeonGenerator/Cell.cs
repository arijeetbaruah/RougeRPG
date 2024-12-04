namespace RougeRPG.Map
{
    public class Cell<T>
    {
        public T Value;

        public int XPos;
        public int YPos;

        public Cell(T value, int xPos, int yPos)
        {
            Value = value;
            XPos = xPos;
            YPos = yPos;
        }
    }
}
