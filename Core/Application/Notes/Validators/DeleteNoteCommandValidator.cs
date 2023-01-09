using Core.Application.Notes.CommandHandlers;
using Core.Enums;
using FluentValidation;

namespace Core.Application.Notes.Validators;

public class DeleteNoteCommandValidator: AbstractValidator<DeleteNoteCommand>
{
    public DeleteNoteCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithErrorCode(ErrorCodes.IdIsRequired);
    }
}