using Core.Contracts;
using Core.Domain.Entities;
using Core.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class NoteRepository : INoteRepository
{
    private readonly ApplicationContext _appContext;

    public NoteRepository(ApplicationContext appContext)
    {
        _appContext = appContext;
    }

    public async Task<Note?> GetById(Guid id)
    {
        return await _appContext.Notes.FindAsync(id);
    }

    public async void Add(Note note)
    {
        await _appContext.Notes.AddAsync(note);
    }

    public async void Update(Note note)
    {
        _appContext.Notes.Update(note);
    }

    public async void Delete(Note note)
    {
        _appContext.Notes.Remove(note);
    }

    public async Task<IEnumerable<NoteResponseDto>> GetAll(NoteSearchParameters? parameters)
    {
        parameters ??= new NoteSearchParameters();

        var query = _appContext.Notes.OrderByDescending(o => o.CreatedAt);
        query = ApplyFilterAndPaging(query, parameters);

        return await query
            .Select(s => new NoteResponseDto(s.Id, s.Title, s.Description, s.CreatedAt))
            .ToListAsync();
    }

    private static IOrderedQueryable<Note> ApplyFilterAndPaging(
        IOrderedQueryable<Note> notes,
        NoteSearchParameters parameters)
    {
        var filteredNotes = notes
            .WhereIf(x => x.Title.ToLower().Contains(parameters.Title!.ToLower().Trim()),
                !string.IsNullOrWhiteSpace(parameters.Title))
            .WhereIf(x => x.CreatedAt == parameters.CreatedAt,
                parameters.CreatedAt is not null);

        return (IOrderedQueryable<Note>)filteredNotes.ToPaged(parameters.Page, parameters.PageSize);
    }
}