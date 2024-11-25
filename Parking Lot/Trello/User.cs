namespace Parking_Lot.Trello
{
    public class User
    {
        public string userId { get; }
        public string name { get; }
        public string email { get; }

        public User(string name, string email)
        {
            this.userId = Guid.NewGuid().ToString();
            this.name = name;
            this.email = email;
        }
    }
}
