using System.Threading.Tasks;
using BookStore.Database;
using BookStore.Models;
using BookStore.Services;
using Moq;
using NUnit.Framework;

namespace BookStore.UnitTests;

public class BooksServiceTests
{
    private readonly Mock<IBooksDatabase> _database = new();

    [Test]
    public async Task GivenRequestToGetAllBooks_ThenGetAllIsCalled()
    {
        // arrange

        // act
        var sut = new BooksService(_database.Object);
        await sut.GetAll(null);

        // assert
        _database.Verify(c => c.GetAll(null), Times.Once);
    }
    
    [Test]
    public async Task GivenRequestToGetAllBooksWithFilter_ThenGetAllIsCalled()
    {
        // arrange
        var searchBy = "search term";
        
        // act
        var sut = new BooksService(_database.Object);
        await sut.GetAll(searchBy);

        // assert
        _database.Verify(c => c.GetAll(searchBy), Times.Once);
    }
    
    [Test]
    public async Task GivenRequestToGetBookById_ThenGetByIdIsCalled()
    {
        // arrange
        var bookId = 1;

        // act
        var sut = new BooksService(_database.Object);
        await sut.GetById(bookId);

        // assert
        _database.Verify(c => c.GetById(bookId), Times.Once);
    }
    
    [Test]
    public async Task GivenRequestToCreateABook_ThenCreateIsCalled()
    {
        // arrange
        var bookToAdd = new BooksModel
        {
            Id = 0,
            Author = "foo author",
            Title = "foo title",
            price = 9.95
        };

        // act
        var sut = new BooksService(_database.Object);
        await sut.Create(bookToAdd);

        // assert
        _database.Verify(c => c.Create(bookToAdd), Times.Once);
    }
    
    [Test]
    public async Task GivenRequestToUpdateABook_ThenUpdateIsCalled()
    {
        // arrange
        var bookToUpdate = new BooksModel
        {
            Id = 0,
            Author = "foo author",
            Title = "foo title",
            price = 9.95
        };

        // act
        var sut = new BooksService(_database.Object);
        await sut.Update(bookToUpdate);

        // assert
        _database.Verify(c => c.Update(bookToUpdate), Times.Once);
    }
    
    [Test]
    public async Task GivenRequestToDeleteABook_ThenDeleteIsCalled()
    {
        // arrange
        var bookToDelete = new BooksModel
        {
            Id = 0,
            Author = "foo author",
            Title = "foo title",
            price = 9.95
        };

        // act
        var sut = new BooksService(_database.Object);
        await sut.Delete(bookToDelete.Id);

        // assert
        _database.Verify(c => c.Delete(bookToDelete.Id), Times.Once);
    }
    
}