using System.Net.Mime;
using BookStore.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers;

[ApiController]
[Route("[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class BooksController : ControllerBase
{
    private readonly ILogger<BooksController> _logger;
    private readonly IBooksService _booksService;
        
    public BooksController(IBooksService booksService, ILogger<BooksController> logger)
    {
        _logger = logger;
        _booksService = booksService;
    }
        
    /// <summary>
    /// Get all books
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] string? searchBy)
    {
        _logger.LogInformation("Filtering the results by search term {0}", searchBy);
        
        var results = await _booksService.GetAll(searchBy);
        return Ok(results);
    }
    
    /// <summary>
    /// Get a book by Id
    /// </summary>
    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        _logger.LogInformation("Getting book by Id {0}", id);
        
        var results = await _booksService.GetById(id);

        return Ok(results);
    }
    
    /// <summary>
    /// Create a new book
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] BooksModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        _logger.LogInformation("Creating a book with details {0}", model);
            
        await _booksService.Create(model);

        return NoContent();
    }
      
    /// <summary>
    /// Update a book
    /// </summary>
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] BooksModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        _logger.LogInformation("Updating a book {0}", model);
            
        await _booksService.Update(model);

        return NoContent();
    }
    
    /// <summary>
    /// Delete a book
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        _logger.LogInformation("Deleting book with id {0}", id);
            
        await _booksService.Delete(id);

        return NoContent();
    }
}