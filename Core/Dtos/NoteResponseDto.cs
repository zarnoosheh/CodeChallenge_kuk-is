using Core.Domain.Entities;
using Core.Domain.ValueObjects;

namespace Core.Dtos;

public record NoteResponseDto(Guid Id, string Title, string? Description, DateTime CreatedAt)
{
    public static NoteResponseDto FromNote(Note note)
    {
        return new NoteResponseDto(note.Id, note.Title, note.Description, note.CreatedAt);
    }
}