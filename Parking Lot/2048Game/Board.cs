namespace Parking_Lot._2048Game
{
    public class Board
    {
        public int boardSize {  get; }
        public int noOfCallValueSet {  get; }
        public List<List<Position>> boardPosition;
        public Board(int boardSize, int noOfCallValueSet)
        {
            this.boardSize = boardSize;
            this.noOfCallValueSet = noOfCallValueSet;
            this.boardPosition = this.InitializeBoard();
        }

        private List<List<Position>> InitializeBoard()
        {
            List<List<Position>> board = new List<List<Position>>();
            for(int i=0;i<this.boardSize;i++) 
            {
                List<Position> temp= new List<Position>();
                for(int j=0;j<this.boardSize;j++)
                {
                    temp.Add(new Position(i,j));
                }
                board.Add(temp);
            }
            this.InitializeInitalCell();
            return board;
        }
        private void InitializeInitalCell()
        {
            for(int i=0;i< this.noOfCallValueSet; i++)
            {
                int firstIndex = new Random().Next(this.boardSize * this.boardSize);
                if (this.boardPosition[firstIndex / this.boardSize - 1][firstIndex % this.boardSize - 1].Value == 0)
                    this.boardPosition[firstIndex / this.boardSize - 1][firstIndex % this.boardSize - 1].SetValue(2);
                else
                    i--;
            }
        }


    }
}
