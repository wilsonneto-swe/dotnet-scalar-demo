namespace ToRead;

public class DataStore
{
    private readonly IList<ReadItem> _items = [];
    
    public IReadOnlyList<ReadItem> GetAll() => _items.ToList().AsReadOnly();
    
    public void Add(ReadItem item) => _items.Add(item);
    
    public ReadItem? Get(Guid id) => _items.FirstOrDefault(x => x.Id == id);
}