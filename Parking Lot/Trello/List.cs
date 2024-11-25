namespace Parking_Lot.Trello
{
    public class List: BoardComponent
    {
        public string id {  get; }
        public string name { get; }
        public List<BoardComponent> cards { get; private set; }

        public List(string id, string name, List<BoardComponent> cards)
        {
            this.id = id;
            this.name = name;
            this.cards = cards;
        }

        public void AddCard(BoardComponent boardComponent)
        {
            this.cards
                .Add(boardComponent);
        }
        public void DeleteCard(BoardComponent boardComponent)
        {
            this.cards
                .Remove(boardComponent);
        }
        public override void delete()
        {
            foreach (var card in cards)
                card.delete();
            cards.Clear();
        }
    }
}
