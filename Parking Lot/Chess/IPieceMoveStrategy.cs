namespace Parking_Lot.Chess
{
    public interface IPieceMoveStrategy
    {
        List<(int, int)> GetMoveVectors();
    }
}
