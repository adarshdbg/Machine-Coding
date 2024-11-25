namespace Parking_Lot.Trello
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }

}
