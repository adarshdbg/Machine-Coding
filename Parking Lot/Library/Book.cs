namespace Parking_Lot.Library
{
    public class Book
    {
        public string bookId {  get; }
        public string title { get; }
        public string author { get; }
        public string publisher { get; }
        public List<BookCopy> Copies { get; set; } // List of all copies of this book
        public Book(string title, string author, string publisher)
        {
            this.bookId = Guid.NewGuid().ToString() + title;
            this.title = title;
            this.author = author;
            this.publisher = publisher;
            Copies = new List<BookCopy>();
        }
        public void AddCopy(BookCopy copy)
        {
            Copies.Add(copy);
        }
    }
}
