using BookStore.Models;

namespace BookStore.Database;

public interface IBooksDatabase
{
    Task<IEnumerable<BooksModel>> GetAll(string? searchBy);
    Task<BooksModel> GetById(int id);
    Task Create(BooksModel booksModel);
    Task Update(BooksModel booksModel);
    Task Delete(int id);
}