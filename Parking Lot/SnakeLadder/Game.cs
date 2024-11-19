namespace Parking_Lot.SnakeLadder
{
    public class Game
    {
        public List<Player> PlayerList;
        public List<Ladder> LadderList;
        public List<Snake> snakes;
        public List<Position> position;
        public Dice dice;
        private ObserverClass ObserverClass;
        public Game(List<Player> PlayerList, List<Ladder> LadderList, List<Snake> snakes) { 
            
            this.PlayerList = PlayerList;
            this.LadderList = LadderList;
            this.snakes = snakes;
            this.position = new Board().PositionList;
            this.dice = new Dice(6);
            this.ObserverClass = new ObserverClass();
            foreach (Player player in PlayerList) {
                this.ObserverClass.AddObsrver(player);
            }
        }

        public Player StartGame()
        {
            bool winnerExist = false;
            Player winnerPlayerName = null;
            while (true)
            {
                foreach (Player player in this.PlayerList) 
                { 
                    Position position = player.Position;
                    if (position != null) {
                        int number = this.dice.GetDiceValue();
                        player.UpdatePositionByValue(position, number);
                        this.ObserverClass.NotifyUsers();
                        if(position.getPostionNumber() == 100)
                        {
                            winnerPlayerName = player;
                            winnerExist = true;
                            break;
                        }

                    }
                }

                if (winnerExist) {
                    return winnerPlayerName;
                }
            }
        }

    }
}
