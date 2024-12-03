using Library.Application.DTOS.Book;
using Library.Application.IServices;
using Library.Domain.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

[ApiController]
[Route("api/books")]
public class BooksController(IBooksService booksService) : ControllerBase
{
    [HttpPost]
    public IActionResult AddBook([FromBody] BookRequest request)
    {
        try
        {
            return Ok(booksService.AddBook(request));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        ;
    }

    [HttpPut("{key}")]
    public ActionResult<Result> EditBook([FromBody] BookRequest bookRequest, string key)
    {
        return booksService.EditBook(bookRequest,key);
    }

    [HttpDelete("{key}")]
    public ActionResult<Result> DeleteBook(string key)
    {
        return booksService.DeleteBook(key);
    }

    [HttpGet]
    public IActionResult GetBooks(string? searchWord=null, string? key=null)
    {
        try
        {
            return Ok(booksService.GetBooks(searchWord, key));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{key}")]
    public IActionResult GetById(string? key = null)
    {
        try
        {
            return Ok(booksService.GetById(key));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}