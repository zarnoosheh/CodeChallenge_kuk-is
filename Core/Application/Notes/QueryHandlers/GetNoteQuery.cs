using Core.Contracts;
using Core.Dtos;
using Core.Enums;
using MediatR;

namespace Core.Application.Notes.QueryHandlers;

public sealed record GetNoteQuery(Guid Id) : IRequest<Result<NoteResponseDto>>;

public class GetNoteQueryHandler : IRequestHandler<GetNoteQuery, Result<NoteResponseDto>>
{
    private readonly INoteRepository _repository;

    public GetNoteQueryHandler(INoteRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<NoteResponseDto>> Handle(GetNoteQuery request, CancellationToken cancellationToken)
    {
        var note = await _repository.GetById(request.Id);

        return note is null
            ? Result.Error<NoteResponseDto>(ErrorCodes.NotFound)
            : Result.Success(NoteResponseDto.FromNote(note));
    }
}