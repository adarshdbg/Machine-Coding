namespace Parking_Lot.SnakeLadder
{

    public class Board
    {
        public List<Position> PositionList { get; }

        public Board()
        {
            PositionList = InitializeBoard();
        }

        private List<Position> InitializeBoard()
        {
            for (int number = 1; number <= 100; number++)
            {
                int row = (number - 1) / 10;
                int col;

                // Determine column based on the zigzag pattern
                if (row % 2 == 0) // Even row: left-to-right
                {
                    col = (number - 1) % 10;
                }
                else // Odd row: right-to-left
                {
                    col = 9 - ((number - 1) % 10);
                }

                PositionList.Add(new Position(row, col));
            }

            return PositionList;
        }
    }
}
