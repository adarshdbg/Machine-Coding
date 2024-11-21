namespace Parking_Lot.Library
{
    public class BookCopy 
    {
        public string CopyID { get; }
        public int BookID { get; }
        public bool IsBorrowed { get; private set; } 
        public DateTime? DueDate { get; set; } // Due date for borrowed copy

        public BookCopy(int bookID)
        {
            CopyID = Guid.NewGuid().ToString() + bookID;
            BookID = bookID;
            IsBorrowed = false;
            DueDate = null;
        }

        public void Borrow(DateTime dueDate)
        {
            if (IsBorrowed)
                throw new InvalidOperationException("This copy is already borrowed.");

            IsBorrowed = true;
            DueDate = dueDate;
        }

        public void Return()
        {
            if (!IsBorrowed)
                throw new InvalidOperationException("This copy is not currently borrowed.");

            IsBorrowed = false;
            DueDate = null;
        }
    }
}
