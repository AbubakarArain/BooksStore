using BookStore.Database;
using BookStore.Models;

namespace BookStore.Services;

public class BooksService: IBooksService
{
    private readonly IBooksDatabase _database;
    
    public BooksService(IBooksDatabase database)
    {
        _database = database;
    }
    
    public async Task<IEnumerable<BooksModel>> GetAll(string? searchBy)
    {
        var results = _database.GetAll(searchBy);
        return await results;
    }

    public async Task<BooksModel?> GetById(int id)
    {
        var results = _database.GetById(id);
        return await results;
    }

    public async Task Create(BooksModel booksModel)
    {
        await _database.Create(booksModel);
    }

    public async Task Update(BooksModel booksModel)
    {
        await _database.Update(booksModel);
    }

    public async Task Delete(int id)
    {
        await _database.Delete(id);
    }
}