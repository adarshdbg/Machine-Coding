namespace Parking_Lot.Trello
{
    public class Card : BoardComponent
    {
        public string id {  get;}
        public string name { get;}
        public string description { get;}
        public User User { get; private set; }

        public Card(string id, string name, string description, User user)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            User = user;
        }

        public void AssignedUser(User user)
        {
            this.User = user;
        }
        public void UnAssignedUser()
        {
            this.User = null;
        }
        public override void delete()
        {
            Console.WriteLine("deleted");
        }
    }
}
