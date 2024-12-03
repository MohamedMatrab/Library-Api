using Library.Application.DTOS.Book;
using Library.Application.IServices;
using Library.Domain.IRepositories;
using Library.Domain.Models;
using Library.Domain.Shared;

namespace Library.Application.Services;

public class BooksService(ICrudRepository<Book,string> booksRepository) : IBooksService
{
    public Result AddBook(BookRequest request)
    {
        var book = new Book(request.Title,request.Author,request.Isbn,request.Price,request.PublishDate,request.AvailableCopies);
        return booksRepository.Create(book);
    }

    public Result EditBook(BookRequest request, string key)
    {
        var book = new Book(request.Title,request.Author,request.Isbn,request.Price,request.PublishDate,request.AvailableCopies);
        return booksRepository.Update(book, key);
    }

    public Result DeleteBook(string key)
    {
        return booksRepository.Delete(key);
    }

    public Result GetById(string key)
    {
        try
        {
            var dbBook = booksRepository.GetById(key);
            var book = new BookResponse
            {
                Id = dbBook.Id,
                Author = dbBook.Author,
                Isbn = dbBook.Isbn,
                Price = dbBook.Price,
                Title = dbBook.Title,
                AvailableCopies = dbBook.AvailableCopies,
                PublishDate = dbBook.PublishDate
            };
            return Result.Success(book);
        }
        catch (KeyNotFoundException e)
        {
            return new Error("Books.GetById.NotFound", "Book Not found !");
        }
        catch (Exception e)
        {
            return new Error("Books.GetById.Error", "Error Occured !");
        }
    }

    public Result GetBooks(string? searchWord, string? key)
    {
        try
        {
            var list = booksRepository.ReadList(e=>(key==null || e.Id==key) 
                                                   && (searchWord==null || e.Title.Contains(searchWord,StringComparison.InvariantCultureIgnoreCase)));
            var result = list.Select(e => new BookResponse
            {
                Author = e.Author,
                Isbn = e.Isbn,
                Price = e.Price,
                Title = e.Title,
                Id = e.Id,
                AvailableCopies = e.AvailableCopies,
                PublishDate = e.PublishDate
            });
            return Result.Success(result);
        }
        catch (Exception e)
        {
            return new Error("Books.ReadList.Error",e.Message);
        }
    }
}