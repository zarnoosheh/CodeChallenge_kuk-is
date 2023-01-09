using Core.Application.Notes.CommandHandlers;
using Core.Enums;
using FluentValidation;

namespace Core.Application.Notes.Validators;

public class AddNoteCommandValidator: AbstractValidator<AddNoteCommand>
{
    public AddNoteCommandValidator()
    {
        RuleFor(x => x.Note.Title).NotEmpty().WithErrorCode(ErrorCodes.TitleIsRequired);
    }
}