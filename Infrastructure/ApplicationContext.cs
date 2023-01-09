using Core.Contracts;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class ApplicationContext: DbContext, IUnitOfWork
{


    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Note> Notes { get; set; } = null!;

    public void Commit()
    {
        SaveChanges();
    }

    public async Task CommitAsync()
    {
        await SaveChangesAsync();
    }
}