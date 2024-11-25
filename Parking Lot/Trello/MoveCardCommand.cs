namespace Parking_Lot.Trello
{
    public class MoveCardCommand : ICommand
    {
        private List sourceList;
        private List targetList;
        private Card card;

        public MoveCardCommand(List sourceList, List targetList, Card card)
        {
            this.sourceList = sourceList;
            this.targetList = targetList;
            this.card = card;
        }

        public void Execute()
        {
            Console.WriteLine($"Moving card '{card.name}' from '{sourceList.name}' to '{targetList.name}'");
            sourceList.DeleteCard(card);
            targetList.AddCard(card);
        }

        public void Undo()
        {
            Console.WriteLine($"Undoing move: Moving card '{card.name}' back to '{sourceList.name}'");
            targetList.DeleteCard(card);
            sourceList.AddCard(card);
        }
    }

}
