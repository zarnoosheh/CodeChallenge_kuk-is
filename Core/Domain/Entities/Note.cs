using Core.Domain.ValueObjects;

namespace Core.Domain.Entities;

public class Note
{
    protected Note()
    {
    }

    public Note(NoteInfo noteInfo)
    {
        Id = Guid.NewGuid();
        Title = noteInfo.Title;
        Description = noteInfo.Description;
        CreatedAt = DateTime.UtcNow;
    }

    public void Edit(NoteInfo noteInfo)
    {
        if (string.IsNullOrWhiteSpace(noteInfo.Title))
        {
            throw new ArgumentException("Title cannot be empty", nameof(noteInfo.Title));
        }

        Title = noteInfo.Title;
        Description = noteInfo.Description;
        _updatedAt = DateTime.UtcNow;
    }

    public Guid Id { get; }
    public string Title { get; private set; }
    public string? Description { get; private set; }
    public DateTime CreatedAt { get; private set;  }

    private DateTime _updatedAt;
}
