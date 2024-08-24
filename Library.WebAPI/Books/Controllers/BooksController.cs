using Library.WebAPI.Books.Features.AddBook;
using Library.WebAPI.Books.Features.GetBookById;
using Library.WebAPI.Books.Features.GetBooks;
using Library.WebAPI.Books.Features.UpdateBook;
using Library.WebAPI.Books.Models.Requests;
using Library.WebAPI.Books.Models.Responses;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebAPI.Books.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController(
    ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<GetBooksResponse>> GetBooks(
        [FromQuery] GetBooksRequest request)
    {
        var query = request.Adapt<GetBooksQuery>();

        var result = await sender.Send(query);

        var response = result.Adapt<GetBooksResponse>();

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetBookByIdResponse>> GetBookById(
        [FromRoute] Guid id)
    {
        var query = new GetBookByIdQuery(id);

        var result = await sender.Send(query);

        var response = result.Adapt<GetBookByIdResponse>();

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<AddBookResponse>> AddBook(
        [FromBody] AddBookRequest request)
    {
        var command = request.Adapt<AddBookCommand>();

        var result = await sender.Send(command);

        var response = result.Adapt<AddBookResponse>();

        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UpdateBookResponse>> UpdateBook(
        [FromRoute] Guid id,
        [FromBody] UpdateBookRequest request)
    {
        var command = new UpdateBookCommand(id, request.Title, request.PublishedYear);

        var result = await sender.Send(command);

        var response = result.Adapt<UpdateBookResponse>();

        return Ok(response);
    }
}