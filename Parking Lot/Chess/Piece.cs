namespace Parking_Lot.Chess
{
    public class Piece
    {
        public PieceColor Color { get; }
        public string name { get; }

        private IPieceMoveStrategy moveStrategies;
        
        public Piece(PieceColor pieceColor, string name, IPieceMoveStrategy moveStrategies)
        {
            this.Color = pieceColor;
            this.name = name;
            this.moveStrategies = moveStrategies;
        }
        public bool PieceCanGoTo(Position start, Position end)
        {
            int row = start.row;
            int col = start.column - 'a';
            List<(int, int)> list = this.moveStrategies.GetMoveVectors();
            for (int i = 0; i < list.Count(); i++) { 
                var a = list[i];
                if (row + a.Item1 >= 0 && row + a.Item1 < 8 && col + a.Item2 >= 0 && col + a.Item2 < 8 && row + a.Item1 == end.row && col + a.Item2 == (end.column -'a') )
                {
                    start.EvacuateChessPiece();
                    end.AssignChessPiece(this);
                    return true;
                }
            }
            return false;
        }
    }

    public enum PieceColor
    {
        Black,
        White
    }
}
