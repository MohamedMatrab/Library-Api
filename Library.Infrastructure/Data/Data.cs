﻿using Library.Domain.Models;

namespace Library.Infrastructure.Data;

public class Data
{
    public static List<Book> Books { get;} = new()
    {
        new Book() { Title = "The Great Gatsby", Isbn = "9780743273565", Price = 25.99, Author = "F. Scott Fitzgerald",AvailableCopies = 14,PublishDate = new DateTime(2009,11,2)},
        new Book() { Title = "To Kill a Mockingbird", Isbn = "0061120081", Price = 19.99, Author = "Harper Lee",AvailableCopies = 90,PublishDate = new DateTime(2015,4,13) },
        new Book() { Title = "1984", Isbn = "9780451524935", Price = 12.50, Author = "George Orwell",AvailableCopies = 12,PublishDate = new DateTime(2021,09,01) },
        new Book() { Title = "The Catcher in the Rye", Isbn = "9780241950425", Price = 15.75, Author = "J.D. Salinger" ,AvailableCopies = 90,PublishDate = new DateTime(2019,9,01)},
        new Book() { Title = "The Hobbit", Isbn = "9780547928227", Price = 15.75, Author = "J.R.R. Tolkien" ,AvailableCopies = 101,PublishDate = new DateTime(2015,8,09)}
    };
}