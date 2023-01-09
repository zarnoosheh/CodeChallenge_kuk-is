using Core.Contracts;
using Core.Dtos;
using Core.Enums;
using FluentValidation;
using MediatR;

namespace Core.Application.Notes.CommandHandlers;

public sealed record DeleteNoteCommand(Guid Id): IRequest<Result>;

public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand, Result>
{
    private readonly INoteRepository _repository;
    private readonly IUnitOfWork _uow;
    private readonly IValidator<DeleteNoteCommand> _validator;

    public DeleteNoteCommandHandler(
        INoteRepository repository,
        IUnitOfWork uow,
        IValidator<DeleteNoteCommand> validator)
    {
        _repository = repository;
        _uow = uow;
        _validator = validator;
    }

    public async Task<Result> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return Result.Error(validationResult.ToErrorList());
        }

        var note = await _repository.GetById(request.Id);

        if (note is null)
            return Result.Error(ErrorCodes.NotFound);

        _repository.Delete(note);
        await _uow.CommitAsync();

        return Result.Success();
    }
}