using Core.Contracts;
using Core.Domain.Entities;
using Core.Dtos;
using FluentValidation;
using MediatR;

namespace Core.Application.Notes.CommandHandlers;

public sealed record AddNoteCommand(AddNoteRequestDto Note): IRequest<Result>;

public class AddNoteCommandHandler : IRequestHandler<AddNoteCommand, Result>
{
    private readonly INoteRepository _repository;
    private readonly IUnitOfWork _uow;
    private readonly IValidator<AddNoteCommand> _validator;

    public AddNoteCommandHandler(
        INoteRepository repository,
        IUnitOfWork uow,
        IValidator<AddNoteCommand> validator)
    {
        _repository = repository;
        _uow = uow;
        _validator = validator;
    }

    public async Task<Result> Handle(AddNoteCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return Result.Error(validationResult.ToErrorList());
        }

        var noteInfo = request.Note.ToNoteInfo();
        var note = new Note(noteInfo);
        _repository.Add(note);
        await _uow.CommitAsync();

        return Result.Success();
    }
}