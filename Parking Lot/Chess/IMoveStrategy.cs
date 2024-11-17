namespace Parking_Lot.Chess
{
    public interface IMoveStrategy
    {
        List<(int, int)> GetMoveVectors();
    }
}
