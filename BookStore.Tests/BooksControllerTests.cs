using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Controllers;
using BookStore.Models;
using BookStore.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace BookStore.UnitTests;

public class BooksControllerTests
{
    private BooksController _booksController;
    
    private Mock<IBooksService> _bookServiceMock;
    private Mock<ILogger<BooksController>> _logger;
    
    [SetUp]
    public void Setup()
    {
        _bookServiceMock = new Mock<IBooksService>();
        _logger = new Mock<ILogger<BooksController>>();
    }
    
    [Test]
    public async Task GivenRequestToGetAllBooks_ThenAllBooksAreReturned()
    {
        var booksData = new List<BooksModel>
        {
            new()
            {
                Id = 0,
                Author = "foo author",
                Title = "foo title",
                price = 9.95
            },
            new()
            {
                Id = 1,
                Author = "bar author",
                Title = "bar title",
                price = 11.99
            }
        };

        _bookServiceMock.Setup(s => s.GetAll(null)).ReturnsAsync(booksData);
        _booksController = new BooksController(_bookServiceMock.Object, _logger.Object);
        
        var sut = (OkObjectResult)await _booksController.GetAll(null);

        sut.Value.Should().BeEquivalentTo(booksData);
    }
    
    [Test]
    public async Task GivenRequestToGetBookById_ThenTheBookIsReturned()
    {
        var bookData = new BooksModel()
        {
            Id = 0,
            Author = "foo author",
            Title = "foo title",
            price = 9.95
        };

        _bookServiceMock.Setup(s => s.GetById(0)).ReturnsAsync(bookData);
        _booksController = new BooksController(_bookServiceMock.Object, _logger.Object);
        
        var sut = (OkObjectResult)await _booksController.Get(0);

        sut.Value.Should().BeEquivalentTo(bookData);
    }
    
    [Test]
    public async Task GivenRequestToAddedANewBook_ThenTheBookIsAdded()
    {
        var addBook = new BooksModel()
        {
            Id = 0,
            Author = "foo author",
            Title = "foo title",
            price = 9.95
        };

        _bookServiceMock.Setup(s => s.Create(addBook));
        _booksController = new BooksController(_bookServiceMock.Object, _logger.Object);
        
        var sut = (NoContentResult)await _booksController.Post(addBook);

        sut.StatusCode.Should().Be(204);
    }
    
    [Test]
    public async Task GivenRequestToUpdateABook_ThenTheBookIsUpdated()
    {
        var bookToUpdate = new BooksModel()
        {
            Id = 0,
            Author = "foo author",
            Title = "foo title",
            price = 9.95
        };
        
        var updatedBook = new BooksModel()
        {
            Id = 0,
            Author = "foo author",
            Title = "foo title",
            price = 10.95
        };

        _bookServiceMock.Setup(s => s.Update(bookToUpdate));
        _booksController = new BooksController(_bookServiceMock.Object, _logger.Object);
        
        var sut = (NoContentResult)await _booksController.Update(updatedBook);

        sut.StatusCode.Should().Be(204);
    }
    
    [Test]
    public async Task GivenRequestToDeleteABook_ThenTheBookShouldBeDeleted()
    {
        var bookToDelete = new BooksModel()
        {
            Id = 0,
            Author = "foo author",
            Title = "foo title",
            price = 9.95
        };

        _bookServiceMock.Setup(s => s.Delete(bookToDelete.Id));
        _booksController = new BooksController(_bookServiceMock.Object, _logger.Object);
        
        var sut = (NoContentResult)await _booksController.Delete(bookToDelete.Id);

        sut.StatusCode.Should().Be(204);
    }
}