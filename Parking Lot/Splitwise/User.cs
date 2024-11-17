using System.ComponentModel.DataAnnotations;

namespace Parking_Lot.Splitwise
{
    public class User
    {
        public static List<User> AllUsers { get; private set; }
        public int userId { get; }
        public string name { get; }
        public string email { get; }
        public string mobile { get; }

        public User(int userId, string name, string email, string mobile)
        {
            this.userId = userId;
            this.name = name;
            this.email = email;
            this.mobile = mobile;
        }

        public void AddUsers()
        {
            AllUsers.Add(this);
        }
    }
    public enum ExpenseType
    {
        EQUAL,
        EXACT, 
        PERCENT
    }
}
