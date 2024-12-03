using System.ComponentModel.DataAnnotations;

namespace Library.Application.DTOS.Book;

public record BookRequest
{
    [MaxLength(100)] public string Title { get; set; } = string.Empty;
    [MaxLength(100)] public string Author { get; set; } = string.Empty;
    [MaxLength(100)] public string Isbn { get; set; } = string.Empty;
    public double Price { get; set; }
    public DateTime PublishDate { get; set; }
    public int AvailableCopies { get; set; }
}