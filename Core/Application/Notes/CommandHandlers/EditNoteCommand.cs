using Core.Contracts;
using Core.Dtos;
using Core.Enums;
using FluentValidation;
using MediatR;

namespace Core.Application.Notes.CommandHandlers;

public sealed record EditNoteCommand(EditNoteRequestDto Note): IRequest<Result>;

public class EditNoteCommandHandler : IRequestHandler<EditNoteCommand, Result>
{
    private readonly INoteRepository _repository;
    private readonly IUnitOfWork _uow;
    private readonly IValidator<EditNoteCommand> _validator;

    public EditNoteCommandHandler(
        INoteRepository repository,
        IUnitOfWork uow,
        IValidator<EditNoteCommand> validator)
    {
        _repository = repository;
        _uow = uow;
        _validator = validator;
    }

    public async Task<Result> Handle(EditNoteCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return Result.Error(validationResult.ToErrorList());
        }

        var note = await _repository.GetById(request.Note.Id);

        if (note is null)
            return Result.Error(ErrorCodes.NotFound);

        note.Edit(request.Note.ToNoteInfo());

        _repository.Update(note);
        await _uow.CommitAsync();

        return Result.Success();
    }
}