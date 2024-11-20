namespace Parking_Lot._2048Game
{
    public class Game
    {
        public List<List<Position>> BoardGames { get; }
        public Game(int BoardSize, int noOfCallValueSet) {
            BoardGames = new Board(BoardSize, noOfCallValueSet).boardPosition;
            
        }
        public void startgame(List<MoveDir> moveDirs)
        {
            for (int i = 0; i < moveDirs.Count; i++) { 
                MoveDir moveDir = moveDirs[i];

                IMove move = AbstractMoveFactory.GetMoveInstance(moveDir);
                move.Move(this.BoardGames);
                this.PrintBoard(this.BoardGames, out bool checkWinner);

                if(checkWinner)
                {
                    Console.WriteLine("Congratulations");
                    return;
                }
            }
        }
        private void PrintBoard(List<List<Position>> positions, out bool checkWinner)
        {
            checkWinner = false;
            for (int i = 0; i < positions.Count; i++)
            {
                for (int j = 0; j < positions[i].Count; j++)
                {
                    if (positions[i][j].Value == 2048)
                        checkWinner = true;
                    Console.WriteLine(positions[i][j] + " ");
                }
                Console.WriteLine("\n");
            }
        }

    }
}
