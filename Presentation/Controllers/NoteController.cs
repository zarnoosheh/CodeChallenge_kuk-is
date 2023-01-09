using System.ComponentModel;
using Core.Application.Notes.CommandHandlers;
using Core.Application.Notes.QueryHandlers;
using Core.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Helpers;

namespace Presentation.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class NoteController : BaseController
{
    private readonly IMediator _mediator;

    public NoteController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<Result<IEnumerable<NoteResponseDto>>>> GetAll(
        [FromQuery]NoteSearchParameters parameters)
    {
        var getAllQuery = new GetNotesQuery(parameters);

        var result = await _mediator.Send(getAllQuery);

        return ApiResult(result);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Result<NoteResponseDto>>> Get(Guid id)
    {
        var getQuery = new GetNoteQuery(id);

        var result = await _mediator.Send(getQuery);

        return ApiResult(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<Result>> Add(AddNoteRequestDto request)
    {
        var addQuery = new AddNoteCommand(request);

        var result = await _mediator.Send(addQuery);

        return ApiResult(result);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Result>> Edit(EditNoteRequestDto request)
    {
        var addQuery = new EditNoteCommand(request);

        var result = await _mediator.Send(addQuery);

        return ApiResult(result);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Result>> Delete(Guid id)
    {
        var addQuery = new DeleteNoteCommand(id);

        var result = await _mediator.Send(addQuery);

        return ApiResult(result);
    }
}
