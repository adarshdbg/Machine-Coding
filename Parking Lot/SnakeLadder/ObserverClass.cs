namespace Parking_Lot.SnakeLadder
{
    public class ObserverClass
    {
        List<IPlayturn> playturns;

        public ObserverClass() { }

        public void AddObsrver(IPlayturn opponent) {
            playturns.Add(opponent);
        }
        public void RemoveObserver(IPlayturn opponent) {
            playturns.Remove(opponent);
        }

        public void NotifyUsers()
        {
            foreach (var opponent in playturns)
            {
                opponent.ConsoleInLog();
            }
        }
    }
}
