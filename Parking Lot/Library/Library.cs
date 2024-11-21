using Parking_Lot.Library;

public class Library
{
    public string Name { get; }
    public int MaxRackNumber { get; }
    public List<Rack> Racks { get; }

    public Library(string name, int maxRackNumber)
    {
        Name = name;
        MaxRackNumber = maxRackNumber;
        Racks = new List<Rack>();
        for (int i = 1; i <= MaxRackNumber; i++)
        {
            Racks.Add(new Rack(i, 5)); // Example: Each rack can hold up to 5 copies
        }
    }

    public bool AddBookInLibrary(BookCopy bookCopy)
    {
        foreach (Rack rack in Racks)
        {
            if (rack.AddBookInRack(bookCopy))
                return true;
        }
        return false; // All racks are full
    }

    public bool RemoveBookCopy(string copyId)
    {
        foreach (Rack rack in Racks)
        {
            var bookCopy = rack.BookCopies.FirstOrDefault(b => b.CopyID == copyId);
            if (bookCopy != null)
                return rack.RemoveBookInRack(bookCopy);
        }
        return false; // Copy not found in any rack
    }
}
