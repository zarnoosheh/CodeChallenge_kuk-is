using Core.Contracts;
using Core.Dtos;
using MediatR;

namespace Core.Application.Notes.QueryHandlers;

public sealed record GetNotesQuery(NoteSearchParameters Parameters) : IRequest<Result<IEnumerable<NoteResponseDto>>>;

public class GetNotesQueryHandler : IRequestHandler<GetNotesQuery, Result<IEnumerable<NoteResponseDto>>>
{
     private readonly INoteRepository _repository;

     public GetNotesQueryHandler(INoteRepository repository)
     {
         _repository = repository;
    }

    public async Task<Result<IEnumerable<NoteResponseDto>>> Handle(GetNotesQuery request, CancellationToken cancellationToken)
    {
        var notes = await _repository.GetAll(request.Parameters);

        return Result.Success(notes);
    }
}