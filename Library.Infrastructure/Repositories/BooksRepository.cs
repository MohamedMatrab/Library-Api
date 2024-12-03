using System.Linq.Expressions;
using Library.Domain.IRepositories;
using Library.Domain.Models;
using Library.Domain.Shared;

namespace Library.Infrastructure.Repositories;

public class BooksRepository : ICrudRepository<Book,string>
{
    public Result Create(Book obj)
    {
        try
        {
            Data.Data.Books.Add(obj);
            return Result.Success(obj);
        }
        catch (Exception e)
        {
            return new Error("Books.Create.Error",$"Error creating the book with title {obj}");
        }
    }

    public IEnumerable<Book> ReadList(Expression<Func<Book,bool>> filter)
    {
        return Data.Data.Books.AsQueryable().Where(filter);
    }

    public Book GetById(string key)
    {
        var book = Data.Data.Books.FirstOrDefault(book => book.Id == key);
        if (book == null)
            throw new KeyNotFoundException();
        return book;
    }

    public Result Update(Book obj, string key)
    {
        try
        {
            var book = Data.Data.Books.FirstOrDefault(book => book.Id == key);
            if (book == null)
                return new Error("Books.Update.NotFound", $"Book with key {key} is not found !");
            book.Author = obj.Author;
            book.Isbn = obj.Isbn;
            book.Price = obj.Price;
            book.Title = obj.Title;
            book.SetUpdatedDate();

            return Result.Success(book);
        }
        catch (Exception)
        {
            return new Error("Books.Update.Error",$"Error occurred while updating book with key {key} !");
        }
    }

    public Result Delete(string key)
    {
        try
        {
            var book = Data.Data.Books.FirstOrDefault(book => book.Id == key);
            if (book == null)
                return new Error("Books.Delete.NotFound", $"Book with key {key} is not found !");
            Data.Data.Books.Remove(book);
            return Result.Success(book);
        }
        catch (Exception)
        {
            return new Error("Books.Delete.Error",$"Cannot delete book with key {key} !");
        }
    }
}