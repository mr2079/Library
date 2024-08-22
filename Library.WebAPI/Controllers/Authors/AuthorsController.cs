using Library.WebAPI.Authors.Features.GetAuthors;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebAPI.Controllers.Authors;

[Route("api/[controller]")]
[ApiController]
public class AuthorsController(
    ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<Response>> GetAuthors(
        [FromQuery] GetAuthorsRequest request)
    {
        var query = request.Adapt<GetAuthorsQuery>();

        var result = await sender.Send(query);

        var response = result.Adapt<GetAuthorsResponse>();

        return Ok(response);
    }
}