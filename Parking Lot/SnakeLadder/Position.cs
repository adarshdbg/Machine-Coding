using System.Text.Json.Serialization;

namespace Parking_Lot.SnakeLadder
{
    public class Position
    {
        public int row {  get; }
        public int col { get; }

        public int postionNumber { get; private set; }

        public Position(int row, int col)
        {
            this.row = row;
            this.col = col;
            this.postionNumber = this.getPostionNumber();
        }
        public static Position GetPositionFromNumber(int number)
        {
            // Ensure the number is between 1 and 100
            if (number < 1 || number > 100)
                throw new ArgumentOutOfRangeException(nameof(number), "Number must be between 1 and 100");

            int row = (number - 1) / 10;
            int col;

            // Zigzag pattern
            if (row % 2 == 0) // Even row: left-to-right
            {
                col = (number - 1) % 10;
            }
            else // Odd row: right-to-left
            {
                col = 9 - ((number - 1) % 10);
            }

            return new Position(row, col);
        }

        public int getPostionNumber()
        {
            if (row % 2 == 0)
            {
                // Even row: left-to-right
                return row * 10 + col + 1;
            }
            else
            {
                // Odd row: right-to-left
                return (row + 1) * 10 - col;
            }
        }

        public bool SnakeExist(List<Snake> snakes) {
            return snakes.Exists((p) => p.start.Equals(this));
        }
        public bool LadderExist(List<Ladder> ladders)
        {
            return ladders.Exists((p) => p.start.Equals(this));
        }

        // Override Equals method
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Position other = (Position)obj;
            return this.row == other.row && this.col == other.col;
        }
        public override string ToString()
        {
            return this.getPostionNumber().ToString();
        }
    }
}
