using Library.WebAPI.Authors.Features.AddAuthor;
using Library.WebAPI.Authors.Features.GetAuthorById;
using Library.WebAPI.Authors.Features.GetAuthors;
using Library.WebAPI.Authors.Features.UpdateAuthor;
using Library.WebAPI.Authors.Models.Requests;
using Library.WebAPI.Authors.Models.Responses;
using Library.WebAPI.Books.Features.GetBooksByAuthorId;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebAPI.Authors.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorsController(
    ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<GetAuthorsResponse>> GetAuthors(
        [FromQuery] GetAuthorsRequest request)
    {
        var query = request.Adapt<GetAuthorsQuery>();

        var result = await sender.Send(query);

        var response = result.Adapt<GetAuthorsResponse>();

        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GetAuthorByIdResponse>> GetAuthorById(
        [FromRoute] GetAuthorByIdRequest request)
    {
        var query = request.Adapt<GetAuthorByIdQuery>();

        var result = await sender.Send(query);

        var response = result.Adapt<GetAuthorByIdResponse>();

        return Ok(response);
    }

    [HttpGet("AuthorBooks/{id:guid}")]
    public async Task<ActionResult<GetAuthorBooksResponse>> GetAuthorBooks(
        [FromRoute] Guid id,
        [FromQuery] int? page = null,
        [FromQuery] int? take = null)
    {
        var query = new GetBooksByAuthorIdQuery(id, page, take);

        var result = await sender.Send(query);

        var response = result.Adapt<GetAuthorBooksResponse>();

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<AddAuthorResponse>> AddAuthor(
        [FromBody] AddAuthorRequest request)
    {
        var command = request.Adapt<AddAuthorCommand>();

        var result = await sender.Send(command);

        var response = result.Adapt<AddAuthorResponse>();

        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<UpdateAuthorResponse>> UpdateAuthor(
        [FromRoute] Guid id,
        [FromBody] UpdateAuthorRequest request)
    {
        var command = new UpdateAuthorCommand(id, request.Name);

        var result = await sender.Send(command);

        var response = result.Adapt<UpdateAuthorResponse>();

        return Ok(response);
    }
}