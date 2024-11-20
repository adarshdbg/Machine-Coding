namespace Parking_Lot._2048Game
{
    public interface IMove
    {
        void Move(List<List<Position>> positions);
        void CreateNewCellPosition();
    }

    public enum MoveDir
    {
        Left,
        Right,
        Top,
        Bottom
    }
}
