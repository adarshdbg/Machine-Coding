namespace Parking_Lot.SnakeLadder
{
    public class Snake
    {
        public Position start {  get; }
        public Position end { get; }

        public Snake(Position start, Position end)
        {
            this.start = start;
            this.end = end;
        }
    }
}
