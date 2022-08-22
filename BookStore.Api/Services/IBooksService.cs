using BookStore.Models;

namespace BookStore.Services;

public interface IBooksService
{
    Task<IEnumerable<BooksModel>> GetAll(string? searchBy);
    Task<BooksModel?> GetById(int id);
    Task Create(BooksModel booksModel);
    Task Update(BooksModel booksModel);
    Task Delete(int id);
}