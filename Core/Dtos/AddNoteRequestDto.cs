using Core.Domain.ValueObjects;

namespace Core.Dtos;

public record AddNoteRequestDto(string Title, string Description)
{
    public NoteInfo ToNoteInfo()
    {
        return new NoteInfo(Title, Description);
    }
}