using System.Collections.Generic;

namespace Parking_Lot.Splitwise
{
    public class Expense
    {
        List<User> users;
        public static Dictionary<int, List<KeyValuePair<User, double>>> expenses;
        public User User { get; }
        public IExpenseType expenseType { get; }
        public double amount { get; }
        public Expense(User user, IExpenseType expenseType, double amount) { 
            users = User.AllUsers;
            this.User = user;
            this.amount = amount;
        }

        public void AddExpenses()
        {
            this.expenseType.CalculateExpense(amount, this.User);
        }
        public double GetAllUserBalance()
        {
            return 0;
        }
        public double GetUserBalance()
        {
            return 0;
        }
    }
}
