using System.ComponentModel.DataAnnotations;

namespace BookStore.Models;

public record BooksModel
{
    public int Id { get; set; }
    
    [Required]
    public string Author { get; set; }
    
    [Required]
    public string Title { get; set; }
    
    [Required]
    public double price { get; set; }
}