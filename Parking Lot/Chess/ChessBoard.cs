namespace Parking_Lot.Chess
{
    public class ChessBoard
    {
        public List<Position> Positions = new List<Position>();

        public ChessBoard() { }

        public bool MoveChessPiece(Position position1, Position position2)
        {
            if (position1 == null || position2 == null) return false;

            Piece piece1 = position1.Piece;
            Piece piece2 = position2.Piece;
            if( piece1 == null)
                return false;
            if (piece2 == null)
            {
                return this.ValidateChessMove(position1, position2);
            }
            if (piece2.Color != piece1.Color)
            {
                return this.ValidateChessMove(position1, position2);
            }
            return false;

        }
        public bool ValidateChessMove(Position position1, Position position2)
        {
            return position1.Piece.PieceCanGoTo(position1, position2);
        }

    }
}
