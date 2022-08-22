using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Database;
using BookStore.Models;
using FluentAssertions;
using NUnit.Framework;

namespace BookStore.UnitTests;

public class BooksDatabaseTests
{
    private IBooksDatabase _booksDatabase;
    private IEnumerable<BooksModel> testBook;

    [SetUp]
    public void Setup()
    {
        _booksDatabase = new BooksDatabase();
    }

    [Test]
    public async Task GivenRequestToGetAllBooks_ThenDatabaseReturnsAllBooks()
    {
        // arrange
        testBook = new[]
        {
            new BooksModel
            {
                Id = 3,
                Author = "Abubakar Arain",
                Title = "Abu's Book",
                price = 10.95
            }
        };
        
        // act
        var results = _booksDatabase.GetAll(null);

        // assert
        results.Result.Should().Contain(testBook);
    }
    
    [Test]
    public async Task GivenRequestToGetAllBooksWithFilter_ThenDatabaseReturnsFilteredBooks()
    {
        // arrange
        testBook = new[]
        {
            new BooksModel
            {
                Id = 3,
                Author = "Abubakar Arain",
                Title = "Abu's Book",
                price = 10.95
            }
        };
        
        // act
        var results = _booksDatabase.GetAll("Abubakar Arain");

        // assert
        results.Result.Should().BeEquivalentTo(testBook);
    }
}