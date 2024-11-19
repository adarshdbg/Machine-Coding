namespace Parking_Lot.SnakeLadder
{
    public class Ladder
    {
        public Position start { get; }
        public Position end { get; }

        public Ladder(Position start, Position end)
        {
            this.start = start;
            this.end = end;
        }
    }
}
