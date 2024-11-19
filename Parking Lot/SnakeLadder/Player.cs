namespace Parking_Lot.SnakeLadder
{
    public class Player : IPlayturn
    {
        public string Name { get; }
        public Position Position { get; private set; }

        public Player(string name, Position position)
        {
            Name = name;
            Position = position;
        }

        public void ConsoleInLog()
        {
            Console.WriteLine("player: " + this.Name + " at position: " + this.Position.ToString());
        }
        public Position UpdatePositionByValue(Position currentPosition, int n)
        {
            // Calculate the new 1D position number
            int newPositionNumber = currentPosition.getPostionNumber() + n;

            // Ensure the new position does not exceed 100
            if (newPositionNumber > 100)
            {
                newPositionNumber = 100;
            }

            // Convert the new position number back to row and column
            int newRow = (newPositionNumber - 1) / 10;
            int newCol;

            // Determine column based on zigzag pattern
            if (newRow % 2 == 0) // Even row: left-to-right
            {
                newCol = (newPositionNumber - 1) % 10;
            }
            else // Odd row: right-to-left
            {
                newCol = 9 - ((newPositionNumber - 1) % 10);
            }

            return currentPosition= new (newRow, newCol);
        }



    }
}
