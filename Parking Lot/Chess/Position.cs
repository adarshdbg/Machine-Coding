namespace Parking_Lot.Chess
{
    public class Position
    {
        public char column { get; }

        public int row { get; }
        public bool isEmpty { get; private set; }
        public Piece Piece { get; private set; }

        public Position(char column, int row)
        {
            this.column = column;
            this.row = row;
            this.isEmpty = true;
        }

        public bool AssignChessPiece(Piece piece)
        {
            if(piece == null || !isEmpty) return false;
            if(piece != null)
            {
                this.EvacuateChessPiece();
                this.Piece = piece;
            }
            return true;
        }
        public bool EvacuateChessPiece()
        {
            this.Piece = null;
            return this.isEmpty = true;
        }
    }
}
