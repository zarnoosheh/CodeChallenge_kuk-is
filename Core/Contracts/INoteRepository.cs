using Core.Domain.Entities;
using Core.Dtos;

namespace Core.Contracts;

public interface INoteRepository
{
    Task<Note?> GetById(Guid id);
    void Add(Note note);
    void Update(Note note);
    void Delete(Note note);
    Task<IEnumerable<NoteResponseDto>> GetAll(NoteSearchParameters? parameters);
}