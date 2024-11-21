using Parking_Lot.Library;

public class Rack
{
    public int RackId { get; }
    public int NoOfMaxCopy { get; }
    public List<BookCopy> BookCopies { get; } // Store book copies in the rack
    private Dictionary<string, int> StoreBookByName; // Tracks book counts by title

    public Rack(int rackId, int noOfMaxCopy)
    {
        RackId = rackId;
        NoOfMaxCopy = noOfMaxCopy;
        BookCopies = new List<BookCopy>();
        StoreBookByName = new Dictionary<string, int>();
    }

    public bool AddBookInRack(BookCopy bookCopy)
    {
        if (bookCopy == null || BookCopies.Count >= NoOfMaxCopy)
            return false;

        if (!StoreBookByName.ContainsKey(bookCopy.BookID.ToString()))
            StoreBookByName[bookCopy.BookID.ToString()] = 0;

        if (StoreBookByName[bookCopy.BookID.ToString()] >= NoOfMaxCopy)
            return false;

        BookCopies.Add(bookCopy);
        StoreBookByName[bookCopy.BookID.ToString()]++;
        return true;
    }

    public bool RemoveBookInRack(BookCopy bookCopy)
    {
        if (bookCopy == null || !BookCopies.Remove(bookCopy))
            return false;

        if (StoreBookByName.ContainsKey(bookCopy.BookID.ToString()))
        {
            StoreBookByName[bookCopy.BookID.ToString()]--;
            if (StoreBookByName[bookCopy.BookID.ToString()] == 0)
                StoreBookByName.Remove(bookCopy.BookID.ToString());
        }

        return true;
    }

    public bool CheckRackAvailableOrNot(string bookTitle)
    {
        return !StoreBookByName.ContainsKey(bookTitle) || StoreBookByName[bookTitle] < NoOfMaxCopy;
    }
}
