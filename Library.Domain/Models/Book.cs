using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Models;

public class Book : Base<string>
{
    public Book() : base(Guid.NewGuid().ToString())
    {
        CreatedAt = DateTime.Now;
    }

    public Book(string title,string author,string isbn,double price,DateTime publishDate,int availableCopies) : this()
    {
        Title = title;
        Author = author;
        Isbn = isbn;
        Price = price;
        AvailableCopies = availableCopies;
        PublishDate = publishDate;
    }
    [StringLength(100)] public string Title { get; set; } = string.Empty;
    [StringLength(100)] public string Author { get; set; } = string.Empty;
    [StringLength(100)] public string Isbn { get; set; } = string.Empty;
    public DateTime PublishDate { get; set; }
    public int AvailableCopies { get; set; }
    public double Price { get; set; }
    public override string ToString()
    {
        return$"{Title} ({Author})";
    }
}