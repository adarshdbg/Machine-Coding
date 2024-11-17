namespace Parking_Lot.Splitwise
{
    public class ExactExpense : IExpenseType
    {
        List<KeyValuePair<User, double>> keyValuePairs = new List<KeyValuePair<User, double>>();
        public ExactExpense(List<KeyValuePair<User, double>> notEqualExpenses) {
            this.keyValuePairs = notEqualExpenses;
        }
        public void CalculateExpense(double amount, User u)
        {
            Dictionary<int, List<KeyValuePair<User, double>>> allExpense = Expense.expenses;
            for (int j = 0; j < allExpense[u.userId].Count(); j++)
            {
                if (allExpense[u.userId][j].Key.userId != u.userId)
                {
                    User userInfo = allExpense[u.userId][j].Key;
                    allExpense[u.userId][j] = new KeyValuePair<User, double>(userInfo, eachAmount);
                }
            }
        }
    }
}
