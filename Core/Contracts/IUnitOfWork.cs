namespace Core.Contracts;

public interface IUnitOfWork
{
    void Commit();
    Task CommitAsync();
}