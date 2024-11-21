using Parking_Lot.Library;

public class User
{
    public int UserId { get; }
    public string Name { get; }
    public int MaxBorrow { get; }
    public List<BookCopy> BorrowedBooks { get; private set; }

    public User(int userId, string name, int maxBorrow = 5)
    {
        UserId = userId;
        Name = name;
        MaxBorrow = maxBorrow;
        BorrowedBooks = new List<BookCopy>();
    }

    public bool CanBorrow()
    {
        return BorrowedBooks.Count < MaxBorrow;
    }

    public bool BorrowBook(BookCopy bookCopy, DateTime dueDate)
    {
        if (!CanBorrow())
            throw new InvalidOperationException("User cannot borrow more books.");

        if (bookCopy.IsBorrowed)
            throw new InvalidOperationException("Book copy is already borrowed.");

        bookCopy.Borrow(dueDate);
        BorrowedBooks.Add(bookCopy);
        return true;
    }

    public bool ReturnBook(string copyId)
    {
        var bookCopy = BorrowedBooks.FirstOrDefault(b => b.CopyID == copyId);
        if (bookCopy == null)
            return false;

        bookCopy.Return();
        BorrowedBooks.Remove(bookCopy);
        return true;
    }
}
