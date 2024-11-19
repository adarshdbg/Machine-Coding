namespace Parking_Lot._2048Game
{
    public class Position
    {
        public int row { get; }
        public int col { get; }

        public int Value { get; private set; }

        public bool IsEmpty { get; private set; }

        public Position(int row, int col, int value = 0)
        {
            this.row = row;
            this.col = col;
            Value = value;
            IsEmpty = true;
        }
        public void SetValue(int value)
        {
            this.Value = value;
            this.IsEmpty = false;
        }
        public void ResetCell()
        {
            this.Value = 0;
            this.IsEmpty = true;
        }

    }
}
