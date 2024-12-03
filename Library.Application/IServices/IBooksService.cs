using Library.Application.DTOS.Book;
using Library.Domain.Shared;

namespace Library.Application.IServices;

public interface IBooksService
{
    Result AddBook(BookRequest request);
    Result EditBook(BookRequest bookRequest,string key);
    Result DeleteBook(string key);
    Result GetById(string key);
    Result GetBooks(string? searchWord,string? key);
}