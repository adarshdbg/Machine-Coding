namespace Parking_Lot.Library
{
    public class Borrow
    {
        public Book Book { get; }
        public int UserId { get; }

        public DateTime dueDate { get; set; }
        
        public Borrow(Book book, int userId)
        {
            this.Book = book;
            this.UserId = userId;
        }

    }
}
