namespace Parking_Lot.TicToe
{
    public struct Position
    {
        public int Row { get; }
        public int Col { get; }

        public Position(int row, int col)
        {
            Row = row - 1; 
            Col = col - 1; 
        }
    }

}
