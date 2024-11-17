namespace Parking_Lot.Chess
{
    public class HorizontalLeftMoveStrategy : IMoveStrategy
    {
        public List<(int, int)> GetMoveVectors()
        {
            var moves = new List<(int, int)>();
            for (int i = 1; i <= 7; i++) // Assuming a board size of 8x8
            {
                moves.Add((-i, 0)); // Move left
            }
            return moves;
        }
    }

    public class HorizontalRightMoveStrategy : IMoveStrategy
    {
        public List<(int, int)> GetMoveVectors()
        {
            var moves = new List<(int, int)>();
            for (int i = 1; i <= 7; i++)
            {
                moves.Add((i, 0)); // Move right
            }
            return moves;
        }
    }

    public class VerticalUpMoveStrategy : IMoveStrategy
    {
        public List<(int, int)> GetMoveVectors()
        {
            var moves = new List<(int, int)>();
            for (int i = 1; i <= 7; i++)
            {
                moves.Add((0, i)); // Move up
            }
            return moves;
        }
    }

    public class VerticalDownMoveStrategy : IMoveStrategy
    {
        public List<(int, int)> GetMoveVectors()
        {
            var moves = new List<(int, int)>();
            for (int i = 1; i <= 7; i++)
            {
                moves.Add((0, -i)); // Move down
            }
            return moves;
        }
    }

    public class DiagonalUpLeftStrategy : IMoveStrategy
    {
        public List<(int, int)> GetMoveVectors()
        {
            var moves = new List<(int, int)>();
            for (int i = 1; i <= 7; i++)
            {
                moves.Add((-i, i)); // Diagonal up-left
            }
            return moves;
        }
    }

    public class DiagonalUpRightStrategy : IMoveStrategy
    {
        public List<(int, int)> GetMoveVectors()
        {
            var moves = new List<(int, int)>();
            for (int i = 1; i <= 7; i++)
            {
                moves.Add((i, i)); // Diagonal up-right
            }
            return moves;
        }
    }

    public class DiagonalDownLeftStrategy : IMoveStrategy
    {
        public List<(int, int)> GetMoveVectors()
        {
            var moves = new List<(int, int)>();
            for (int i = 1; i <= 7; i++)
            {
                moves.Add((-i, -i)); // Diagonal down-left
            }
            return moves;
        }
    }

    public class DiagonalDownRightStrategy : IMoveStrategy
    {
        public List<(int, int)> GetMoveVectors()
        {
            var moves = new List<(int, int)>();
            for (int i = 1; i <= 7; i++)
            {
                moves.Add((i, -i)); // Diagonal down-right
            }
            return moves;
        }
    }


}
