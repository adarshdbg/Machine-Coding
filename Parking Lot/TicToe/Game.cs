namespace Parking_Lot.TicToe
{
    public class Game
    {
        private Player player1;
        private Player player2;
        private Board board;
        private Player currentPlayer;

        public Game()
        {
            InitializeGame();
        }

        private void InitializeGame()
        {
            Console.Write("Enter Player 1 Name (X): ");
            string player1Name = Console.ReadLine();
            player1 = new Player(player1Name, 'X');

            Console.Write("Enter Player 2 Name (O): ");
            string player2Name = Console.ReadLine();
            player2 = new Player(player2Name, 'O');

            board = new Board();
            currentPlayer = player1;

            Console.WriteLine("Game Initialized!");
            board.PrintBoard();
        }

        public void Start()
        {
            while (true)
            {
                Console.WriteLine($"{currentPlayer.Name}'s Turn ({currentPlayer.Symbol}):");
                Console.Write("Enter row (1-3): ");
                int row = int.Parse(Console.ReadLine());

                Console.Write("Enter column (1-3): ");
                int col = int.Parse(Console.ReadLine());

                Position position = new Position(row, col);

                if (!board.IsValidMove(position))
                {
                    Console.WriteLine("Invalid Move! Try again.");
                    continue;
                }

                board.MakeMove(position, currentPlayer.Symbol);
                board.PrintBoard();

                if (board.CheckWin(currentPlayer.Symbol))
                {
                    Console.WriteLine($"Congratulations! {currentPlayer.Name} wins!");
                    break;
                }

                if (board.IsFull())
                {
                    Console.WriteLine("It's a Draw! No more valid moves.");
                    break;
                }

                // Switch player
                currentPlayer = currentPlayer == player1 ? player2 : player1;
            }
        }
    }

}
