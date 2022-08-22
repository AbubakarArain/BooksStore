using BookStore.Models;
using JsonFlatFileDataStore;

namespace BookStore.Database;

// NuGet package used to mimic database https://github.com/ttu/json-flatfile-datastore
public class BooksDatabase : IBooksDatabase
{
    private static DataStore? _store;
    private readonly IDocumentCollection<BooksModel>? _collection;
    
    public BooksDatabase()
    {
        _store = new DataStore("Database.json");
        _collection = _store.GetCollection<BooksModel>();
    }
    
    public async Task<IEnumerable<BooksModel>> GetAll(string? searchBy)
    {
        if (searchBy != null) return _collection?.Find(searchBy)!;
        return _collection.AsQueryable();
    }

    public async Task<BooksModel> GetById(int id)
    {
        return _collection?.AsQueryable().FirstOrDefault(e => e.Id > id - 1);
    }

    public async Task Create(BooksModel booksModel)
    {
        var addBook = new BooksModel()
        {
            Id = booksModel.Id,
            Author = booksModel.Author,
            Title = booksModel.Title,
            price = booksModel.price
        };
        
        await _collection.InsertOneAsync(addBook);
    }

    public async Task Update(BooksModel booksModel)
    {
        var updateBook = new BooksModel()
        {
            Id = booksModel.Id,
            Author = booksModel.Author,
            Title = booksModel.Title,
            price = booksModel.price
        };
        
        await _collection.UpdateOneAsync(e => e.Id == booksModel.Id, updateBook);

    }

    public async Task Delete(int id)
    {
        await _collection.DeleteOneAsync(e => e.Id == id);
    }
}