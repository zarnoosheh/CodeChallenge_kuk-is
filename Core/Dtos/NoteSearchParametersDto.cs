using System.ComponentModel;

namespace Core.Dtos;

public class NoteSearchParameters
{
    public string? Title { get; set; }
    public DateTime? CreatedAt { get; set; }

    [DefaultValue(1)]
    public int Page { get; set; } = 1;

    [DefaultValue(25)]
    public int PageSize { get; set; } = 25;
}