using Core.Application.Notes.CommandHandlers;
using Core.Enums;
using FluentValidation;

namespace Core.Application.Notes.Validators;

public class EditNoteCommandValidator: AbstractValidator<EditNoteCommand>
{
    public EditNoteCommandValidator()
    {
        RuleFor(x => x.Note.Title).NotEmpty().WithErrorCode(ErrorCodes.TitleIsRequired);
        RuleFor(x => x.Note.Id).NotEmpty().WithErrorCode(ErrorCodes.IdIsRequired);
    }
}