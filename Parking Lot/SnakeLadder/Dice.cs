namespace Parking_Lot.SnakeLadder
{
    public class Dice
    {
        private int MaxnNumber { get;}
        public Dice(int maxNumber) {
            this.MaxnNumber = maxNumber;
        }

        public int GetDiceValue()
        {
            return new Random().Next(1,this.MaxnNumber);
        }


    }
}
