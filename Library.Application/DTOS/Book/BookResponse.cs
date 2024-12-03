namespace Library.Application.DTOS.Book;

public class BookResponse
{
    public string Id { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Isbn { get; set; } = string.Empty;
    public double Price { get; set; }
    public DateTime PublishDate { get; set; }
    public int AvailableCopies { get; set; }
}