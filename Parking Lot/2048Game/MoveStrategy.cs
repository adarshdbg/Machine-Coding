
namespace Parking_Lot._2048Game
{
    public class MoveStrategy
    {
    }
    public class LeftMoveStrategy : IMove
    {
        public void Move(List<List<Position>> positions)
        {
            foreach (var row in positions)
            {
                SlideAndMergeRow(row);
            }
        }

        private void SlideAndMergeRow(List<Position> row)
        {
            // Slide non-empty values to the left
            var values = row.Where(cell => !cell.IsEmpty).Select(cell => cell.Value).ToList();
            var merged = new List<int>();
            int i = 0;

            while (i < values.Count)
            {
                if (i < values.Count - 1 && values[i] == values[i + 1])
                {
                    // Merge tiles
                    merged.Add(values[i] * 2);
                    i += 2; // Skip the next tile since it merged
                }
                else
                {
                    merged.Add(values[i]);
                    i++;
                }
            }

            // Reset all cells and update with merged values
            for (int j = 0; j < row.Count; j++)
            {
                if (j < merged.Count)
                {
                    row[j].SetValue(merged[j]);
                }
                else
                {
                    row[j].ResetCell();
                }
            }
        }
    }

    public class RightMoveStrategy : IMove
    {
        public void Move(List<List<Position>> positions)
        {
            foreach (var row in positions)
            {
                SlideAndMergeRow(row);
            }
        }

        private void SlideAndMergeRow(List<Position> row)
        {
            // Slide non-empty values to the right
            var values = row.Where(cell => !cell.IsEmpty).Select(cell => cell.Value).ToList();
            var merged = new List<int>();
            int i = values.Count - 1;

            while (i >= 0)
            {
                if (i > 0 && values[i] == values[i - 1])
                {
                    // Merge tiles
                    merged.Insert(0, values[i] * 2);
                    i -= 2; // Skip the next tile since it merged
                }
                else
                {
                    merged.Insert(0, values[i]);
                    i--;
                }
            }

            // Reset all cells and update with merged values
            for (int j = 0; j < row.Count; j++)
            {
                if (j < row.Count - merged.Count)
                {
                    row[j].ResetCell();
                }
                else
                {
                    row[j].SetValue(merged[j - (row.Count - merged.Count)]);
                }
            }
        }
    }
    public class TopMoveStrategy : IMove
    {
        public void Move(List<List<Position>> positions)
        {
            int cols = positions[0].Count;

            for (int col = 0; col < cols; col++)
            {
                SlideAndMergeColumn(positions, col);
            }
        }

        private void SlideAndMergeColumn(List<List<Position>> positions, int col)
        {
            var values = new List<int>();

            foreach (var row in positions)
            {
                if (!row[col].IsEmpty)
                {
                    values.Add(row[col].Value);
                }
            }

            var merged = new List<int>();
            int i = 0;

            while (i < values.Count)
            {
                if (i < values.Count - 1 && values[i] == values[i + 1])
                {
                    // Merge tiles
                    merged.Add(values[i] * 2);
                    i += 2;
                }
                else
                {
                    merged.Add(values[i]);
                    i++;
                }
            }

            // Reset all cells in the column and update with merged values
            for (int row = 0; row < positions.Count; row++)
            {
                if (row < merged.Count)
                {
                    positions[row][col].SetValue(merged[row]);
                }
                else
                {
                    positions[row][col].ResetCell();
                }
            }
        }
    }
    public class BottomMoveStrategy : IMove
    {
        public void Move(List<List<Position>> positions)
        {
            int cols = positions[0].Count;

            for (int col = 0; col < cols; col++)
            {
                SlideAndMergeColumn(positions, col);
            }
        }

        private void SlideAndMergeColumn(List<List<Position>> positions, int col)
        {
            var values = new List<int>();

            foreach (var row in positions)
            {
                if (!row[col].IsEmpty)
                {
                    values.Add(row[col].Value);
                }
            }

            var merged = new List<int>();
            int i = values.Count - 1;

            while (i >= 0)
            {
                if (i > 0 && values[i] == values[i - 1])
                {
                    // Merge tiles
                    merged.Insert(0, values[i] * 2);
                    i -= 2;
                }
                else
                {
                    merged.Insert(0, values[i]);
                    i--;
                }
            }

            // Reset all cells in the column and update with merged values
            for (int row = 0; row < positions.Count; row++)
            {
                if (row < positions.Count - merged.Count)
                {
                    positions[row][col].ResetCell();
                }
                else
                {
                    positions[row][col].SetValue(merged[row - (positions.Count - merged.Count)]);
                }
            }
        }
    }




}
