namespace Parking_Lot.TicToe
{
    public class Board
    {
        private char[,] grid;

        public Board()
        {
            grid = new char[3, 3];
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    grid[i, j] = '-';
                }
            }
        }

        public void PrintBoard()
        {
            Console.WriteLine("Current Board:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(grid[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public bool IsValidMove(Position position)
        {
            return position.Row >= 0 && position.Row < 3 &&
                   position.Col >= 0 && position.Col < 3 &&
                   grid[position.Row, position.Col] == '-';
        }

        public void MakeMove(Position position, char symbol)
        {
            grid[position.Row, position.Col] = symbol;
        }

        public bool CheckWin(char symbol)
        {
            // Check rows, columns, and diagonals
            for (int i = 0; i < 3; i++)
            {
                if ((grid[i, 0] == symbol && grid[i, 1] == symbol && grid[i, 2] == symbol) ||
                    (grid[0, i] == symbol && grid[1, i] == symbol && grid[2, i] == symbol))
                    return true;
            }

            // Diagonals
            if ((grid[0, 0] == symbol && grid[1, 1] == symbol && grid[2, 2] == symbol) ||
                (grid[0, 2] == symbol && grid[1, 1] == symbol && grid[2, 0] == symbol))
                return true;

            return false;
        }

        public bool IsFull()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (grid[i, j] == '-')
                        return false;
                }
            }
            return true;
        }
    }

}
