
namespace Parking_Lot.Chess
{
    public class PawnPiece : IPieceMoveStrategy
    {
        List<IMoveStrategy> pawnMoveStrategy;

        public PawnPiece() { 
            pawnMoveStrategy.Add(new VerticalUpMoveStrategy());
            pawnMoveStrategy.Add(new DiagonalUpLeftStrategy());
            pawnMoveStrategy.Add(new DiagonalUpRightStrategy());
        }
        public List<(int, int)> GetMoveVectors()
        {
            return pawnMoveStrategy.Select((p)=>p.GetMoveVectors().First()).ToList();
        }
    }
    public class BishopPiece : IPieceMoveStrategy
    {
        List<IMoveStrategy> bishopMoveStrategy;
        public BishopPiece()
        {
            bishopMoveStrategy.Add(new DiagonalDownLeftStrategy());
            bishopMoveStrategy.Add(new DiagonalUpLeftStrategy());
            bishopMoveStrategy.Add(new DiagonalUpRightStrategy());
            bishopMoveStrategy.Add(new DiagonalDownRightStrategy());
        }
        public List<(int, int)> GetMoveVectors()
        {
            return bishopMoveStrategy.SelectMany((p) => p.GetMoveVectors()).ToList();
        }
    }
    public class RootPiece : IPieceMoveStrategy
    {
        List<IMoveStrategy> rootMoveStrategy;
        public RootPiece()
        {
            rootMoveStrategy.Add(new HorizontalLeftMoveStrategy());
            rootMoveStrategy.Add(new HorizontalRightMoveStrategy());
            rootMoveStrategy.Add(new VerticalUpMoveStrategy());
            rootMoveStrategy.Add(new VerticalDownMoveStrategy());
        }
        public List<(int, int)> GetMoveVectors()
        {
            return rootMoveStrategy.SelectMany((p) => p.GetMoveVectors()).ToList();
        }
    }
    public class QueenPiece : IPieceMoveStrategy
    {
        List<IMoveStrategy> queenMoveStrategy;
        public QueenPiece()
        {
            queenMoveStrategy.Add(new HorizontalLeftMoveStrategy());
            queenMoveStrategy.Add(new HorizontalRightMoveStrategy());
            queenMoveStrategy.Add(new DiagonalDownLeftStrategy());
            queenMoveStrategy.Add(new DiagonalDownRightStrategy());
            queenMoveStrategy.Add(new DiagonalUpLeftStrategy());
            queenMoveStrategy.Add(new DiagonalUpRightStrategy());
            queenMoveStrategy.Add(new VerticalUpMoveStrategy());
            queenMoveStrategy.Add(new VerticalDownMoveStrategy());
        }
        public List<(int, int)> GetMoveVectors()
        {
            return queenMoveStrategy.SelectMany((p) => p.GetMoveVectors()).ToList();
        }
    }
    public class KnightMoveStrategy : IPieceMoveStrategy
    {
        public List<(int, int)> GetMoveVectors()
        {
            return new List<(int, int)>
            {
                (2, 1), (2, -1), // Right-up and right-down
                (-2, 1), (-2, -1), // Left-up and left-down
                (1, 2), (-1, 2), // Up-right and up-left
                (1, -2), (-1, -2) // Down-right and down-left
            };
        }
    }
    public class KingPiece : IPieceMoveStrategy
    {
        List<IMoveStrategy> kingMoveStrategy;

        public KingPiece()
        {
            kingMoveStrategy.Add(new HorizontalLeftMoveStrategy());
            kingMoveStrategy.Add(new HorizontalRightMoveStrategy());
            kingMoveStrategy.Add(new DiagonalDownLeftStrategy());
            kingMoveStrategy.Add(new DiagonalDownRightStrategy());
            kingMoveStrategy.Add(new DiagonalUpLeftStrategy());
            kingMoveStrategy.Add(new DiagonalUpRightStrategy());
            kingMoveStrategy.Add(new VerticalUpMoveStrategy());
            kingMoveStrategy.Add(new VerticalDownMoveStrategy());
        }
        public List<(int, int)> GetMoveVectors()
        {
            return kingMoveStrategy.Select((p) => p.GetMoveVectors().First()).ToList();
        }
    }
}
