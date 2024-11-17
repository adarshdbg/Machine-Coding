namespace Parking_Lot.Splitwise
{
    public class EqualExpense : IExpenseType
    {
        private int noOfUser;
        public EqualExpense(int noOfUser) 
        {
            this.noOfUser = noOfUser;
        }
        public void CalculateExpense(double amount, User u)
        {
            double eachAmount = amount/ this.noOfUser;
            Dictionary<int, List<KeyValuePair<User, double>>> allExpense = Expense.expenses;
            for(int j = 0; j < allExpense[u.userId].Count(); j++)
            {
                if(allExpense[u.userId][j].Key.userId != u.userId)
                {
                    User userInfo = allExpense[u.userId][j].Key;
                    allExpense[u.userId][j] = new KeyValuePair<User, double> ( userInfo, eachAmount );
                }
            }
        }
    }
}
