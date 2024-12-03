using Library.Application.DTOS.Book;
using Library.Application.IServices;
using Library.Controllers;
using Library.Domain.Models;
using Library.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Result = Library.Domain.Shared.Result;

namespace Library.Tests.ControllersTests;

public class BooksControllerTests
{
    private readonly Mock<IBooksService> _mockBookService;
    private readonly BooksController _controller;

    private BookRequest _requestExample = new()
    {
        Title = "The Great Gatsby", Isbn = "9780743273565", Price = 25.99, Author = "F. Scott Fitzgerald",
        AvailableCopies = 14, PublishDate = new DateTime(2009, 11, 2)
    };
    private string _testKey = "some-key-0987";
    
    public BooksControllerTests()
    {
        _mockBookService = new Mock<IBooksService>();
        _controller = new BooksController(_mockBookService.Object);
    }

    [Fact]
    public void GetBooks_WithNoSearch_ReturnsOkResult()
    {
        _mockBookService
            .Setup(s => s.GetBooks(null, null))
            .Returns(Result.Success(MockData.MockData.BookResponses));
        
        var result = _controller.GetBooks();
        
        Assert.NotNull(result);
        var okObjectResult = Assert.IsType<OkObjectResult>(result);
        var res = Assert.IsType<Result>(okObjectResult.Value);
        var list = Assert.IsAssignableFrom<IEnumerable<BookResponse>>(res.Response);
        Assert.Equal(5, list.Count());
    }
    
    [Fact]
    public void AddBook_ReturnsOkResult_WhenAddedSuccessfully()
    {
        _mockBookService
            .Setup(s => s.AddBook(It.IsAny<BookRequest>()))
            .Returns(Result.Success());
        
        var result = _controller.AddBook(_requestExample);
        
        Assert.NotNull(result);
        var okObjectResult = Assert.IsType<OkObjectResult>(result);
        var res = Assert.IsType<Result>(okObjectResult.Value);
        Assert.True(res.IsSuccess);
        
        _mockBookService.Verify(s => s.AddBook(It.IsAny<BookRequest>()), Times.Once);
    }
    
    [Fact]
    public void AddBook_ReturnsBadRequest_WhenExceptionIsThrown()
    {
        _mockBookService.Setup(s => s.AddBook(_requestExample)).Throws(new Exception("Error occurred"));
        
        var result = _controller.AddBook(_requestExample);
        
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("Error occurred", badRequestResult.Value);
    }
    
    [Fact]
    public void EditBook_ReturnsResultFromService()
    {
        var expected = Result.Success();
        _mockBookService.Setup(s => s.EditBook(_requestExample, _testKey)).Returns(expected);
        
        var result = _controller.EditBook(_requestExample, _testKey);
        
        Assert.Equal(expected, result.Value);
    }
    
    [Fact]
    public void DeleteBook_ReturnsResultFromService()
    {
        var expectedResult = Result.Success();
        _mockBookService.Setup(s => s.DeleteBook(_testKey)).Returns(expectedResult);
        
        var result = _controller.DeleteBook(_testKey);
        
        Assert.Equal(expectedResult, result.Value);
    }
    
    [Fact]
    public void GetBooks_ReturnsOkResult_WhenBooksAreRetrievedSuccessfully()
    {
        var searchWord = "a Mock";
        var expectedResponse = new List<BookResponse> { new BookResponse() { Title = "To Kill a Mockingbird", Isbn = "0061120081", Price = 19.99, Author = "Harper Lee", AvailableCopies = 90, PublishDate = new DateTime(2015, 4, 13) } };
        _mockBookService.Setup(s => s.GetBooks(searchWord, null)).Returns(Result.Success(expectedResponse));
        
        var result = _controller.GetBooks(searchWord, null);
        
        var okResult = Assert.IsType<OkObjectResult>(result);
        var res = Assert.IsType<Result>(okResult.Value);
        var list = Assert.IsAssignableFrom<IEnumerable<BookResponse>>(res.Response);
        Assert.Single(list);
    }
}